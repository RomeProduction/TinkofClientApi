using TinkoffPaymentClientApi.Enums;

namespace TinkoffPaymentClientApi.ResponseEntity {
  public class CancelResponse : TinkoffResponse {
    public string OrderId { get; set; }
    public string PaymentId { get; set; }
    public decimal OriginalAmount { get; set; }
    public decimal NewAmount { get; set; }

    public EStatusResponse Status { get; set; }
  }
}
