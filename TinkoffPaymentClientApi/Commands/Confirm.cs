using System;
using TinkoffPaymentClientApi.Attributes;
using TinkoffPaymentClientApi.Models;

namespace TinkoffPaymentClientApi.Commands {
  /// <summary>
  /// Подтверждает платеж и списывает ранее заблокированные средства.
  /// <para>
  /// Используется при двухстадийной оплате. При одностадийной оплате вызывается автоматически. Применим к платежу только в статусе AUTHORIZED и только один раз.
  /// </para>
  /// <para>
  /// Сумма подтверждения не может быть больше заблокированной. Если сумма подтверждения меньше заблокированной, будет выполнено частичное подтверждение.
  /// </para>
  /// </summary>
  public class Confirm : BaseCommand {
    /// <summary>
    /// Идентификатор платежа в системе банка	
    /// </summary>
    public string PaymentId { get; private set; }
    /// <summary>
    /// Сумма в копейках	
    /// </summary>
    public decimal? Amount{ get; set; }
    /// <summary>
    /// IP-адрес покупателя	
    /// </summary>
    public string IP { get; set; }
    /// <summary>
    /// Чек
    /// </summary>
    [IgnoreTokenCalculate]
    public Receipt Receipt { get; set; }

    internal override string CommandName => "Confirm";

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="paymentId">Идентификатор платежа в системе банка</param>
    public Confirm(string paymentId) {
      if (string.IsNullOrEmpty(paymentId)) {
        throw new ArgumentNullException(nameof(paymentId), "Must be not empty");
      }
      PaymentId = paymentId;
    }
  }
}
