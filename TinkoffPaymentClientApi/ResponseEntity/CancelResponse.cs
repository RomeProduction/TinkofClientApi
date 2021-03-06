﻿using Newtonsoft.Json;
using TinkoffPaymentClientApi.Enums;

namespace TinkoffPaymentClientApi.ResponseEntity {
  /// <summary>
  /// Данные об отмене платежа
  /// </summary>
  public class CancelResponse : TinkoffResponse {
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
    /// Сумма до возврата в копейках
    /// </summary>
    [JsonRequired]
    public uint OriginalAmount { get; set; }
    /// <summary>
    /// Сумма после возврата в копейках
    /// </summary>
    [JsonRequired]
    public uint NewAmount { get; set; }
    /// <summary>
    /// Статус платежа
    /// </summary>
    [JsonRequired]
    public EStatusResponse Status { get; set; }
  }
}
