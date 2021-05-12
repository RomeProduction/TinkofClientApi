using Newtonsoft.Json;
using TinkoffPaymentClientApi.Enums;

namespace TinkoffPaymentClientApi.ResponseEntity {
  /// <summary>
  /// Текущее состояние платежа
  /// </summary>
  public class GetStateResponse : TinkoffResponse {
    /// <summary>
    /// Идентификатор заказа в системе продавца
    /// </summary>
    [JsonRequired]
    public string OrderId { get; set; } = string.Empty;
    /// <summary>
    /// Уникальный идентификатор транзакции в системе банка
    /// </summary>
    [JsonRequired]
    public string PaymentId { get; set; } = string.Empty;
    /// <summary>
    /// Статус платежа
    /// </summary>
    [JsonRequired]
    public EStatusResponse Status { get; set; }
  }
}
