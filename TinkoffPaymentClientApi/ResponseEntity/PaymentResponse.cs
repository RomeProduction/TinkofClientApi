using Newtonsoft.Json;
using TinkoffPaymentClientApi.Enums;

namespace TinkoffPaymentClientApi.ResponseEntity {
  /// <summary>
  /// Данные о платеже
  /// </summary>
  public class PaymentResponse : TinkoffResponse {
    /// <summary>
    /// Сумма в копейках	
    /// </summary>
    [JsonRequired]
    public uint Amount { get; set; }
    /// <summary>
    /// Идентификатор заказа в системе продавца
    /// </summary>
    [JsonRequired]
    public string OrderId { get; set; } = string.Empty;
    /// <summary>
    /// Идентификатор платежа в системе банка
    /// </summary>
    [JsonRequired]
    public string PaymentId { get; set; } = string.Empty;
    /// <summary>
    /// Статус платежа
    /// </summary>
    [JsonRequired]
    public EStatusResponse Status { get; set; }
    /// <summary>
    /// Ссылка на платежную форму
    /// </summary>
    [JsonRequired]
    public string PaymentURL { get; set; } = string.Empty;
  }
}
