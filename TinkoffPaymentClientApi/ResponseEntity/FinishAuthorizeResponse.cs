using System;
using System.Collections.Generic;
using System.Text;
using TinkoffPaymentClientApi.Enums;

namespace TinkoffPaymentClientApi.ResponseEntity {
  /// <summary>
  /// Данные о подтверждении платежа
  /// </summary>
  public class FinishAuthorizeResponse: TinkoffResponse {
    /// <summary>
    /// Номер заказа в системе Продавца
    /// </summary>
    public string OrderId { get; set; }
    /// <summary>
    /// Статус платежа
    /// </summary>
    public EStatusResponse Status { get; set; }
    /// <summary>
    /// Сумма в копейках
    /// </summary>
    public decimal Amount { get; set; }
    /// <summary>
    /// Уникальный идентификатор транзакции в системе банка
    /// </summary>
    public string PaymentId { get; set; }
    /// <summary>
    /// Идентификатор карты в системе банка. Передается только для сохраненной карты
    /// </summary>
    public string CardId { get; set; }
  }
}
