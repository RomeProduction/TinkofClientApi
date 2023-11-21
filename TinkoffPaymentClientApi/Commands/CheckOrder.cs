using System;
using System.Collections.Generic;
using System.Text;

namespace TinkoffPaymentClientApi.Commands {

  /// <summary>
  /// Метод возвращает статус заказа.
  /// https://www.tinkoff.ru/kassa/develop/api/payments/checkorder-request/
  /// </summary>
  public class CheckOrder : BaseCommand {
    internal override string CommandName => "CheckOrder";

    /// <summary>
    /// Номер заказа в системе Продавца	
    /// </summary>
    public string OrderId { get; }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="orderId">Номер заказа в системе Продавца</param>
    public CheckOrder(string orderId) {
      OrderId = orderId;
    }
  }
}
