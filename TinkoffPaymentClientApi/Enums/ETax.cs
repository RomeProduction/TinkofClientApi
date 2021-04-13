using System.Runtime.Serialization;
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
    [EnumMember(Value = "none")]
    None = 1,
    /// <summary>
    /// 0%
    /// </summary>
    [EnumMember(Value = "vat0")]
    Vat0,
    /// <summary>
    /// 10%
    /// </summary>
    [EnumMember(Value = "vat10")]
    Vat10,
    /// <summary>
    /// 20%
    /// </summary>
    [EnumMember(Value = "vat20")]
    Vat20,
    /// <summary>
    /// 10/110
    /// </summary>
    [EnumMember(Value = "vat110")]
    Vat110,
    /// <summary>
    /// 20/120
    /// </summary>
    [EnumMember(Value = "vat120")]
    Vat120,
  }
}
