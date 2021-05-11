using System;

namespace TinkoffPaymentClientApi.Commands {
  public class RemoveCustomer : BaseCommand {
    /// <summary>
    /// Идентификатор покупателя в системе продавца
    /// </summary>
    public string CustomerKey { get; private set; }
    /// <summary>
    /// IP-адрес покупателя
    /// </summary>
    public string? IP { get; set; }

    internal override string CommandName => "RemoveCustomer";

    public RemoveCustomer(string customerKey) {
      if (string.IsNullOrEmpty(customerKey)) {
        throw new ArgumentNullException(nameof(customerKey), "Must be not empty");
      }
      CustomerKey = customerKey;
    }
  }
}
