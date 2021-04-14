using System;
using System.Collections.Generic;
using System.Text;
using TinkoffPaymentClientApi.Attributes;
using TinkoffPaymentClientApi.Enums;
using TinkoffPaymentClientApi.Models;

namespace TinkoffPaymentClientApi.Commands {
  /// <summary>
  /// Метод позволяет отправить закрывающий чек в кассу.
  /// Условия метода:
  /// <list type="number">
  /// <item>Закрывающий чек может быть отправлен если платежная сессия по первому чеку находится в статусе <see cref="EStatusResponse.Confirmed"/>.</item>
  /// <item>В платежной сессии был передан объект <see cref="Receipt"/>.</item>
  /// <item>В объекте <see cref="Receipt"/> был передан хотя бы один объект <see cref="ReceiptItem.PaymentMethod"/> <see cref="EPaymentMethod.FullPrepayment"/> или <see cref="EPaymentMethod.Prepayment"/> или <see cref="EPaymentMethod.Advance"/></item>
  /// </list>
  /// </summary>
  public class SendClosingReceipt : BaseCommand {
    internal override string CommandName => "SendClosingReceipt";

    /// <summary>
    /// Чек
    /// </summary>
    [IgnoreTokenCalculate]
    public Receipt Receipt { get; set; }
  }
}
