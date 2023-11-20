using System;
using Newtonsoft.Json.Converters;

namespace TinkoffPaymentClientApi.Json.Converters;

/// <summary>
/// Преобразователь <see cref="DateTime"/> в/из строку в формате YYYY-MM-DDTHH24:MI:SS+GMT
/// </summary>
class TinkoffDateTimeConverter : IsoDateTimeConverter
{
  /// <summary>
  /// Преобразователь &lt;see cref="DateTime"/&gt; в/из строку в формате YYYY-MM-DDTHH24:MI:SS+GMT
  /// </summary>
  public TinkoffDateTimeConverter()
  {
    DateTimeFormat = "yyyy'-'MM'-'dd'T'HH':'mm':'sszzz";
  }
}
