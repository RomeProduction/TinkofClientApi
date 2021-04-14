using System;

namespace TinkoffPaymentClientApi.Commands {
  /// <summary>
  /// Запрос состояния платежа
  /// </summary>
  public class GetState: BaseCommand {
    /// <summary>
    /// Идентификатор платежа в системе банка
    /// </summary>
    public string PaymentId { get; private set; }
    /// <summary>
    /// IP-адрес покупателя
    /// </summary>
    public string IP { get; set; }

    internal override string CommandName => "GetState";

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="paymentId">Идентификатор платежа в системе банка</param>
    public GetState(string paymentId) {
      if (string.IsNullOrEmpty(paymentId)) {
        throw new ArgumentNullException(nameof(paymentId), "Must be not empty");
      }
      PaymentId = paymentId;
    }
  }
}
