using TinkoffPaymentClientApi.Enums;

namespace TinkoffPaymentClientApi.ResponseEntity {
  /// <summary>
  /// Данные о платеже
  /// </summary>
  public class PaymentResponse : TinkoffResponse {
    /// <summary>
    /// Сумма в копейках	
    /// </summary>
    public decimal Amount { get; set; }
    /// <summary>
    /// Идентификатор заказа в системе продавца
    /// </summary>
    public string OrderId { get; set; }
    /// <summary>
    /// Идентификатор платежа в системе банка
    /// </summary>
    public string PaymentId { get; set; }
    /// <summary>
    /// Статус платежа
    /// </summary>
    public EStatusResponse Status { get; set; }
    /// <summary>
    /// Ссылка на платежную форму
    /// </summary>
    public string PaymentURL { get; set; }
  }
}
