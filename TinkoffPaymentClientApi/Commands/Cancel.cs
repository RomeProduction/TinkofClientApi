using System;
using TinkoffPaymentClientApi.Attributes;
using TinkoffPaymentClientApi.Models;

namespace TinkoffPaymentClientApi.Commands {
  /// <summary>
  /// Отмена платежа
  /// </summary>
  public class Cancel : BaseCommand {
    /// <summary>
    /// Идентификатор платежа в системе банка
    /// </summary>
    public string PaymentId { get; private set; }
    /// <summary>
    /// Сумма возврата в копейках
    /// </summary>
    public uint? Amount{ get; set; }
    /// <summary>
    /// IP-адрес покупателя
    /// </summary>
    public string? IP { get; set; }
    /// <summary>
    /// В чеке указываются данные товаров, подлежащих возврату
    /// </summary>
    [IgnoreTokenCalculate]
    public Receipt? Receipt { get; set; }

    internal override string CommandName => "Cancel";

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="paymentId">Идентификатор платежа в системе банка</param>
    public Cancel(string paymentId) {
      if (string.IsNullOrEmpty(paymentId)) {
        throw new ArgumentNullException(nameof(paymentId), Properties.Resources.TinkoffPaymentClient_ShouldNotBeEmpty);
      }
      PaymentId = paymentId;
    }
  }
}
