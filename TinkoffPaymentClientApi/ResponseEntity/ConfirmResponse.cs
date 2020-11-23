using TinkoffPaymentClientApi.Enums;

namespace TinkoffPaymentClientApi.ResponseEntity {
  public class ConfirmResponse : TinkoffResponse {
    public string OrderId { get; set; }
    public string PaymentId { get; set; }

    public EStatusResponse Status { get; set; }
  }
}
