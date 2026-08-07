using Newtonsoft.Json.Converters;
using System;

namespace TinkoffPaymentClientApi.Json.Converters;

/// <summary>
/// Преобразователь <see cref="DateTime"/> в/из строку в формате YYYY-MM-DDTHH24:MI:SS+GMT
/// </summary>
class TinkoffDateTimeConverter : IsoDateTimeConverter
{
	public const string Format = "yyyy'-'MM'-'dd'T'HH':'mm':'sszzz";
	/// <summary>
	/// Преобразователь &lt;see cref="DateTime"/&gt; в/из строку в формате YYYY-MM-DDTHH24:MI:SS+GMT
	/// </summary>
	public TinkoffDateTimeConverter()
	{
		DateTimeFormat = Format;
	}
}
