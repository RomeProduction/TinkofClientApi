using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TinkoffPaymentClientApi.Enums {
  /// <summary>
  /// Способ расчета
  /// </summary>
  [JsonConverter(typeof(StringEnumConverter))]
  public enum EPaymentMethod {
    /// <summary>
    /// Полный расчет
    /// </summary>
    full_payment = 1,
    /// <summary>
    /// Предоплата 100%
    /// </summary>
    full_prepayment,
    /// <summary>
    /// Предоплата
    /// </summary>
    prepayment,
    /// <summary>
    /// Аванс
    /// </summary>
    advance,
    /// <summary>
    /// Частичный расчет и кредит
    /// </summary>
    partial_payment,
    /// <summary>
    /// Передача в кредит
    /// </summary>
    credit,
    /// <summary>
    /// Оплата кредита
    /// </summary>
    credit_payment,
  }
}