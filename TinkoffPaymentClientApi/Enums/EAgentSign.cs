using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TinkoffPaymentClientApi.Enums {
  /// <summary>
  /// Признак агента
  /// </summary>
  [JsonConverter(typeof(StringEnumConverter))]
  public enum EAgentSign {
    /// <summary>
    /// Банковский платежный агент
    /// </summary>
    bank_paying_agent = 1,
    /// <summary>
    /// Банковский платежный субагент
    /// </summary>
    bank_paying_subagent,
    /// <summary>
    /// Платежный агент
    /// </summary>
    paying_agent,
    /// <summary>
    /// Платежный субагент
    /// </summary>
    paying_subagent,
    /// <summary>
    /// Поверенный
    /// </summary>
    attorney,
    /// <summary>
    /// Комиссионер
    /// </summary>
    commission_agent,
    /// <summary>
    /// Другой тип агента
    /// </summary>
    another,
  }
}