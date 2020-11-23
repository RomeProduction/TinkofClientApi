using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TinkoffPaymentClientApi.Enums {
  /// <summary>
  /// Ставка НДС
  /// </summary>
  [JsonConverter(typeof(StringEnumConverter))]
  public enum ETax {
    /// <summary>
    /// Без НДС
    /// </summary>
    none = 1,
    /// <summary>
    /// 0%
    /// </summary>
    vat0,
    /// <summary>
    /// 10%
    /// </summary>
    vat10,
    /// <summary>
    /// 20%
    /// </summary>
    vat20,
    /// <summary>
    /// 10/110
    /// </summary>
    vat110,
    /// <summary>
    /// 20/120
    /// </summary>
    vat120,
  }
}