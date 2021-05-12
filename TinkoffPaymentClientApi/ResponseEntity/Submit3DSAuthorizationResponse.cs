using Newtonsoft.Json;
using TinkoffPaymentClientApi.Enums;

namespace TinkoffPaymentClientApi.ResponseEntity {
  /// <summary>
  /// Результат проверки 3DS
  /// </summary>
  public class Submit3DSAuthorizationResponse : TinkoffResponse {
    /// <summary>
    /// Сумма в копейках
    /// </summary>
    [JsonRequired]
    public uint Amount { get; set; }
    /// <summary>
    /// Номер заказа в системе Продавца
    /// </summary>
    [JsonRequired]
    public string OrderId { get; set; } = string.Empty;
    /// <summary>
    /// Уникальный идентификатор транзакции в системе банка
    /// </summary>
    [JsonRequired]
    public string PaymentId { get; set; } = string.Empty;
    /// <summary>
    /// Идентификатор рекуррентного платежа
    /// </summary>
    public string? RebillId { get; set; }
    /// <summary>
    /// Идентификатор карты в системе банка. Передается только для сохраненной карты
    /// </summary>
    public string? CardId { get; set; }
    /// <summary>
    /// Статус транзакции
    /// </summary>
    [JsonRequired]
    public EStatusResponse Status { get; set; }
  }
}
