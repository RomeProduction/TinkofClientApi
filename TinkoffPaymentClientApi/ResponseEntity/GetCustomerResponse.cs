namespace TinkoffPaymentClientApi.ResponseEntity {
  public class GetCustomerResponse : CustomerResponse {
    public string Email { get; set; }
    public string Phone { get; set; }
  }
}