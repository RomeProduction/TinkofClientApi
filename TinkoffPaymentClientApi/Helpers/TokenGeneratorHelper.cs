﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using TinkoffPaymentClientApi.Attributes;

namespace TinkoffPaymentClientApi.Helpers {
  internal static class TokenGeneratorHelper {
    internal static string GenerateToken<T>(T parametr, string password)
      where T : class {
      if (parametr == null) {
        throw new ArgumentNullException(nameof(parametr));
      }
      if (string.IsNullOrEmpty(password)) {
        throw new ArgumentNullException(nameof(password), Properties.Resources.TinkoffPaymentClient_ShouldNotBeEmpty);
      }
      var properties = parametr.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
      var pairs = new Dictionary<string, object>() {
        { "Password", password }
      };
      foreach (var property in properties) {
        var attribute = property.GetCustomAttribute<IgnoreTokenCalculateAttribute>();
        if (attribute != null) {
          continue;
        }
        var value = property.GetValue(parametr);
        var type = property.PropertyType;
        object? defaultValue = null;
        if (object.Equals(value, defaultValue)) {
          continue;
        }
        var propValue = property.GetValue(parametr);
        if(type == typeof(bool) || type == typeof(bool?)) {
          propValue = (propValue + "").ToLower();
        }
        pairs[property.Name] = propValue ?? string.Empty;
      }

      var strValues = pairs.OrderBy(x => x.Key).Select(x => x.Value).Aggregate((x, y) => x + "" + y) + "";
      return CalculateHash256(strValues);
    }

    private static string CalculateHash256(string value) {
      var bytes = Encoding.UTF8.GetBytes(value);
      using (SHA256 mySHA256 = SHA256.Create()) {
        var hashBytes = mySHA256.ComputeHash(bytes);
        return BitConverter.ToString(hashBytes, 0).Replace("-", "").ToLower();
      }
    }
  }
}
