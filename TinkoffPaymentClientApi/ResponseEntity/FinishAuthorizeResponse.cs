using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using TinkoffPaymentClientApi.Enums;

namespace TinkoffPaymentClientApi.ResponseEntity {
  /// <summary>
  /// Данные о подтверждении платежа
  /// </summary>
  public class FinishAuthorizeResponse: TinkoffResponse {
    /// <summary>
    /// Номер заказа в системе Продавца
    /// </summary>
    [JsonRequired]
    public string OrderId { get; set; } = string.Empty;
    /// <summary>
    /// Статус платежа
    /// </summary>
    [JsonRequired]
    public EStatusResponse Status { get; set; }
    /// <summary>
    /// Сумма в копейках
    /// </summary>
    [JsonRequired]
    public uint Amount { get; set; }
    /// <summary>
    /// Уникальный идентификатор транзакции в системе банка
    /// </summary>
    [JsonRequired]
    public string PaymentId { get; set; } = string.Empty;
    /// <summary>
    /// Идентификатор карты в системе банка. Передается только для сохраненной карты
    /// </summary>
    public string? CardId { get; set; }
  }
}
