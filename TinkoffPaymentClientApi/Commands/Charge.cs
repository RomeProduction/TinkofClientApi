using System;

namespace TinkoffPaymentClientApi.Commands {
  public class Charge : BaseCommand {

    public string PaymentId { get; private set; }
    public string RebillId { get; private set; }

    public bool SendEmail { get; set; }
    public string InfoEmail { get; set; }
    public string IP { get; set; }

    internal override string CommandName => "Charge";

    public Charge(string paymentId, string rebillId, 
      bool sendEmail = false, string infoEmail = null) {
      if (string.IsNullOrEmpty(paymentId)) {
        throw new ArgumentNullException(nameof(paymentId), "Must be not empty");
      }
      if (string.IsNullOrEmpty(rebillId)) {
        throw new ArgumentNullException(nameof(rebillId), "Must be not empty");
      }
      if(sendEmail && string.IsNullOrEmpty(infoEmail)) {
        throw new ArgumentNullException(nameof(infoEmail), "If SendEmail is true, then must be not empty");
      }

      PaymentId = paymentId;
      RebillId = rebillId;
      SendEmail = sendEmail;
      InfoEmail = infoEmail;
    }
  }
}