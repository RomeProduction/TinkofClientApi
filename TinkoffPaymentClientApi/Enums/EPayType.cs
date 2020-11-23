using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TinkoffPaymentClientApi.Enums {
  [JsonConverter(typeof(StringEnumConverter))]
  public enum EPayType {
    /// <summary>
    /// Одностадийная
    /// </summary>
    O = 1,
    /// <summary>
    /// Двухстадийная
    /// </summary>
    T
  }
}