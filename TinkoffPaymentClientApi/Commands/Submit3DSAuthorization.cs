using System;

namespace TinkoffPaymentClientApi.Commands {
  public class Submit3DSAuthorization: BaseCommand {
    public string MD { get; private set; }
    public string PaRes { get; private set; }
    public string PaymentId { get; private set; }

    internal override string CommandName => "Submit3DSAuthorization";

    public Submit3DSAuthorization(string paymentId, string md, string paRes) {
      if (string.IsNullOrEmpty(paymentId)) {
        throw new ArgumentNullException(nameof(paymentId), "Must be not empty");
      }
      PaymentId = paymentId;
      if (string.IsNullOrEmpty(md)) {
        throw new ArgumentNullException(nameof(md), "Must be not empty");
      }
      MD = md;
      if (string.IsNullOrEmpty(paRes)) {
        throw new ArgumentNullException(nameof(paRes), "Must be not empty");
      }
      PaRes = paRes;
    }
  }
}