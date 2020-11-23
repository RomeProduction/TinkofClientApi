using System;

namespace TinkoffPaymentClientApi.Commands {
  public class RemoveCard : BaseCommand {
    public string CustomerKey { get; private set; }
    public string CardId { get; private set; }
    public string IP { get; set; }

    internal override string CommandName => "RemoveCard";

    public RemoveCard(string customerKey, string cardId) {
      if (string.IsNullOrEmpty(customerKey)) {
        throw new ArgumentNullException(nameof(customerKey), "Must be not empty");
      }
      CustomerKey = customerKey;

      if (string.IsNullOrEmpty(cardId)) {
        throw new ArgumentNullException(nameof(cardId), "Must be not empty");
      }
      CardId = cardId;
    }
  }
}