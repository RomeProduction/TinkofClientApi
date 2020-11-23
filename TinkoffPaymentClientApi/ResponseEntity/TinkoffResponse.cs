namespace TinkoffPaymentClientApi.ResponseEntity {
  public abstract class TinkoffResponse {
    public string TerminalKey { get; set; }
    public bool Success { get; set;}
    public string ErrorCode { get; set; }

    public string Message { get; set; }
    public string Details { get; set; }
  }
}