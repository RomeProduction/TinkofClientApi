using TinkoffPaymentClientApi.Enums;

namespace TinkoffPaymentClientApi.ResponseEntity {
  /// <summary>
  /// Данные об отмене платежа
  /// </summary>
  public class CancelResponse : TinkoffResponse {
    /// <summary>
    /// Идентификатор заказа в системе продавца
    /// </summary>
    public string OrderId { get; set; }
    /// <summary>
    /// Уникальный идентификатор транзакции в системе банка
    /// </summary>
    public string PaymentId { get; set; }
    /// <summary>
    /// Сумма до возврата в копейках
    /// </summary>
    public decimal OriginalAmount { get; set; }
    /// <summary>
    /// Сумма после возврата в копейках
    /// </summary>
    public decimal NewAmount { get; set; }
    /// <summary>
    /// Статус платежа
    /// </summary>
    public EStatusResponse Status { get; set; }
  }
}
