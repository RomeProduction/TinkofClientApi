namespace TinkoffPaymentClientApi.ResponseEntity {
  public class GetCustomerResponse : CustomerResponse {
    /// <summary>
    /// Электронная почта покупателя
    /// </summary>
    public string? Email { get; set; }
    /// <summary>
    /// Телефон покупателя в формате +71234567890
    /// </summary>
    public string? Phone { get; set; }
  }
}
