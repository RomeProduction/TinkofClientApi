using System;

namespace TinkoffPaymentClientApi.Commands {
  public class AddCustomer : BaseCommand {
    public string CustomerKey { get; private set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string IP { get; set; }

    internal override string CommandName => "AddCustomer";

    public AddCustomer(string customerKey) {
      if (string.IsNullOrEmpty(customerKey)) {
        throw new ArgumentNullException(nameof(customerKey), "Must be not empty");
      }
      CustomerKey = customerKey;
    }
  }
}