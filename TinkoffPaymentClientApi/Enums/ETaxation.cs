using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TinkoffPaymentClientApi.Enums {
  /// <summary>
  /// Система налогооблажения
  /// </summary>
  [JsonConverter(typeof(StringEnumConverter))]
  public enum ETaxation {
    /// <summary>
    /// Общая
    /// </summary>
    osn = 1,
    /// <summary>
    /// Упрощенная (доходы)
    /// </summary>
    usn_income,
    /// <summary>
    /// Упрощенная (доходы минус расходы)
    /// </summary>
    usn_income_outcome,
    /// <summary>
    /// Патентная
    /// </summary>
    patent,
    /// <summary>
    /// Единый налог на вмененный доход
    /// </summary>
    envd,
    /// <summary>
    /// Единый сельскохозяйственный налог
    /// </summary>
    esn,
  }
}