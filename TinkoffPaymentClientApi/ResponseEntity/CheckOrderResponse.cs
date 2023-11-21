using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using TinkoffPaymentClientApi.Models;

namespace TinkoffPaymentClientApi.ResponseEntity {

  /// <summary>
  /// Статус заказа.
  /// https://www.tinkoff.ru/kassa/develop/api/payments/checkorder-request/
  /// </summary>
  public class CheckOrderResponse: TinkoffResponse {
    /// <summary>
    /// Номер заказа в системе Продавца	
    /// </summary>
    public string? OrderId { get; set; }

    /// <summary>
    /// Детали
    /// </summary>
    public Payment[] Payments { get; set; } = Array.Empty<Payment>();

  }
}
