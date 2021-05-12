using System;

namespace TinkoffPaymentClientApi.Commands {
  public class AddCustomer : BaseCommand {
    /// <summary>
    /// Идентификатор покупателя в системе продавца
    /// </summary>
    public string CustomerKey { get; private set; }
    /// <summary>
    /// Электронная почта покупателя
    /// </summary>
    public string? Email { get; set; }
    /// <summary>
    /// Телефон покупателя В формате +71234567890
    /// </summary>
    public string? Phone { get; set; }
    /// <summary>
    /// IP-адрес покупателя
    /// </summary>
    public string? IP { get; set; }

    internal override string CommandName => "AddCustomer";

    public AddCustomer(string customerKey) {
      if (string.IsNullOrEmpty(customerKey)) {
        throw new ArgumentNullException(nameof(customerKey), "Must be not empty");
      }
      CustomerKey = customerKey;
    }
  }
}
