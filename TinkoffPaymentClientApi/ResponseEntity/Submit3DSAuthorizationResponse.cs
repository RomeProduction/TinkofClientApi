using TinkoffPaymentClientApi.Enums;

namespace TinkoffPaymentClientApi.ResponseEntity {
  /// <summary>
  /// Результат проверки 3DS
  /// </summary>
  public class Submit3DSAuthorizationResponse : TinkoffResponse {
    /// <summary>
    /// Сумма в копейках
    /// </summary>
    public decimal Amount { get; set; }
    /// <summary>
    /// Номер заказа в системе Продавца
    /// </summary>
    public string OrderId { get; set; }
    /// <summary>
    /// Уникальный идентификатор транзакции в системе банка
    /// </summary>
    public string PaymentId { get; set; }
    /// <summary>
    /// Идентификатор рекуррентного платежа
    /// </summary>
    public string RebillId { get; set; }
    /// <summary>
    /// Идентификатор карты в системе банка. Передается только для сохраненной карты
    /// </summary>
    public string CardId { get; set; }
    /// <summary>
    /// Статус транзакции
    /// </summary>
    public EStatusResponse Status { get; set; }
  }
}
