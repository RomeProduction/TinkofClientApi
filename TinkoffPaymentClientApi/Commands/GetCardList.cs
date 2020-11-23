using System;

namespace TinkoffPaymentClientApi.Commands {
  public class GetCardList: BaseCommand {
    public string CustomerKey { get; private set; }
    public string IP { get; set; }

    internal override string CommandName => "GetCardList";

    public GetCardList(string customerKey) {
      if (string.IsNullOrEmpty(customerKey)) {
        throw new ArgumentNullException(nameof(customerKey), "Must be not empty");
      }
      CustomerKey = customerKey;
    }
  }
}