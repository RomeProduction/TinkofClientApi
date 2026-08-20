using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using TinkoffPaymentClientApi.Attributes;
using TinkoffPaymentClientApi.Json.Converters;

namespace TinkoffPaymentClientApi.Helpers;

public static class TokenGeneratorHelper
{
	/// <summary>
	/// Использует оптимизированный метод для расчета токена
	/// </summary>
	public static bool UseExpressionBuilder = true;

	private static Dictionary<Type, MethodInfo> StringBuilderAppends = typeof(StringBuilder).GetMethods(BindingFlags.Instance | BindingFlags.Public)
	  .Where(_ => _.Name == nameof(StringBuilder.Append) && _.IsGenericMethod == false && _.GetParameters().Length == 1)
	  .ToDictionary(_ => _.GetParameters().First().ParameterType);

	public static class TokenGenerator<T>
	{
		public static readonly Func<T, string, string> BuildString;

		static TokenGenerator()
		{
			var obj = Expression.Parameter(typeof(T), "obj");
			var pwd = Expression.Parameter(typeof(string), "pwd");
			var sb = Expression.Variable(typeof(StringBuilder), "sb");

			var properties = typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public)
			  .Where(_ => _.GetCustomAttribute<IgnoreTokenCalculateAttribute>() == null)
			  .ToDictionary(_ => _.Name);

			var orderedProps = properties
			  .Keys
			  .Concat(["Password"])
			  .OrderBy(p => p);

			var expressions = new List<Expression>();
			expressions.Add(Expression.Assign(sb, Expression.New(typeof(StringBuilder))));

			foreach (var p in orderedProps)
			{
				if (p == "Password")
				{
					expressions.Add(Expression.Call(sb, StringBuilderAppends[typeof(string)], pwd));
					continue;
				}

				var pi = properties[p];
				var pv = Expression.Property(obj, p);

				if (pi.PropertyType == typeof(bool))
					expressions.Add(Expression.Call(sb, StringBuilderAppends[typeof(string)],
					  Expression.Condition(pv, Expression.Constant("true"), Expression.Constant("false"))
					  ));
				else if (pi.PropertyType == typeof(bool?))
					expressions.Add(Expression.IfThen(
					  Expression.IsTrue(Expression.Property(pv, "HasValue")),
					  Expression.Call(sb,
						StringBuilderAppends[typeof(string)],
						Expression.Condition(Expression.Property(pv, "Value"), Expression.Constant("true"), Expression.Constant("false"))
					  )));
				else if (pi.PropertyType == typeof(DateTimeOffset))
					expressions.Add(Expression.Call(sb,
					  StringBuilderAppends[typeof(string)],
					  Expression.Call(pv, "ToString", [], Expression.Constant(TinkoffDateTimeConverter.Format))
					  ));
				else if (pi.PropertyType == typeof(DateTimeOffset?))
					expressions.Add(Expression.IfThen(
					  Expression.IsTrue(Expression.Property(pv, "HasValue")),
					  Expression.Call(sb,
						StringBuilderAppends[typeof(string)],
						Expression.Call(Expression.Property(pv, "Value"), "ToString", [], Expression.Constant(TinkoffDateTimeConverter.Format))
					  )));
				else if (Nullable.GetUnderlyingType(pi.PropertyType) != null)
				{
					var underlying = Nullable.GetUnderlyingType(pi.PropertyType)!;
					expressions.Add(Expression.IfThen(
					  Expression.IsTrue(Expression.Property(pv, "HasValue")),
					  Expression.Call(sb,
						underlying.IsPrimitive
						  ? StringBuilderAppends[underlying]
						  : StringBuilderAppends[typeof(object)],
						underlying.IsPrimitive
						  ? Expression.Property(pv, "Value")
						  : Expression.Convert(pv, typeof(object))
					  )));
				}
				else if (pi.PropertyType.IsPrimitive || pi.PropertyType == typeof(string))
					expressions.Add(Expression.Call(sb, StringBuilderAppends[pi.PropertyType], pv));
				else
					expressions.Add(Expression.IfThen(
					  Expression.NotEqual(
						Expression.Property(obj, p),
						Expression.Constant(null, pi.PropertyType)),
					  Expression.Call(sb, StringBuilderAppends[typeof(object)], Expression.Convert(pv, typeof(object)))
					  ));
			}

			var res = Expression.Variable(typeof(string), "res");
			expressions.Add(Expression.Assign(res, Expression.Call(sb, "ToString", [])));

			var returnTarget = Expression.Label(typeof(string));
			var returnExpression = Expression.Return(returnTarget, res, typeof(string));
			var returnLabel = Expression.Label(returnTarget, Expression.Constant(string.Empty));
			expressions.Add(returnExpression);
			expressions.Add(returnLabel);

			var block = Expression.Block([sb, res], expressions);
			var labmbda = Expression.Lambda<Func<T, string, string>>(block, obj, pwd);
			BuildString = labmbda.Compile();

		}
	}
	public static string GenerateToken<T>(T parametr, string password) where T : class
	  => GenerateToken(parametr, password, UseExpressionBuilder);

	public static string GenerateToken<T>(T parametr, string password, bool useExpressionBuilder) where T : class
	  => useExpressionBuilder
		? GenerateTokenNew(parametr, password)
		: GenerateTokenOld(parametr, password);

	public static string GenerateTokenNew<T>(T parametr, string password) where T : class
	  => CalculateHash256(TokenGenerator<T>.BuildString(parametr, password));

	public static string GenerateTokenOld<T>(T parametr, string password)
	  where T : class
	{
		if (parametr == null)
		{
			throw new ArgumentNullException(nameof(parametr));
		}
		if (string.IsNullOrEmpty(password))
		{
			throw new ArgumentNullException(nameof(password), Properties.Resources.TinkoffPaymentClient_ShouldNotBeEmpty);
		}
		var properties = parametr.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
		var pairs = new Dictionary<string, object>() {
	{ "Password", password }
  };
		foreach (var property in properties)
		{
			var attribute = property.GetCustomAttribute<IgnoreTokenCalculateAttribute>();
			if (attribute != null)
			{
				continue;
			}
			var value = property.GetValue(parametr);
			var type = property.PropertyType;
			object? defaultValue = null;
			if (object.Equals(value, defaultValue))
			{
				continue;
			}
			var propValue = property.GetValue(parametr);
			if (propValue != null)
			{
				if (type == typeof(bool) || type == typeof(bool?))
				{
					propValue = (propValue + "").ToLower();
				}
				else if (type == typeof(DateTimeOffset) || type == typeof(DateTimeOffset?))
				{
					propValue = ((DateTimeOffset)propValue).ToString(TinkoffDateTimeConverter.Format);
				}
				pairs[property.Name] = propValue;
			}
			else
			{
				pairs[property.Name] = string.Empty;
			}
		}

		var strValues = pairs.OrderBy(x => x.Key).Select(x => x.Value).Aggregate((x, y) => x + "" + y) + "";
		return CalculateHash256(strValues);
	}

	private static string CalculateHash256(string value)
	{
		var bytes = Encoding.UTF8.GetBytes(value);
		using (SHA256 mySHA256 = SHA256.Create())
		{
			var hashBytes = mySHA256.ComputeHash(bytes);
			return BitConverter.ToString(hashBytes, 0).Replace("-", "").ToLower();
		}
	}
}
