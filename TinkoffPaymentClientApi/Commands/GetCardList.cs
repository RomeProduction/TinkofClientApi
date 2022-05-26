using System;

namespace TinkoffPaymentClientApi.Commands {
  public class GetCardList: BaseCommand {
    /// <summary>
    /// Идентификатор покупателя в системе продавца
    /// </summary>
    public string CustomerKey { get; private set; }
    /// <summary>
    /// IP-адрес покупателя
    /// </summary>
    public string? IP { get; set; }

    internal override string CommandName => "GetCardList";

    public GetCardList(string customerKey) {
      if (string.IsNullOrEmpty(customerKey)) {
        throw new ArgumentNullException(nameof(customerKey), Properties.Resources.TinkoffPaymentClient_ShouldNotBeEmpty);
      }
      CustomerKey = customerKey;
    }
  }
}
