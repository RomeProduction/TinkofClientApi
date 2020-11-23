using System;

namespace TinkoffPaymentClientApi.Commands {
  public class GetState: BaseCommand {
    public string PaymentId { get; private set; }
    public string IP { get; set; }

    internal override string CommandName => "GetState";

    public GetState(string paymentId) {
      if (string.IsNullOrEmpty(paymentId)) {
        throw new ArgumentNullException(nameof(paymentId), "Must be not empty");
      }
      PaymentId = paymentId;
    }
  }
}