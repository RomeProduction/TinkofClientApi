using Newtonsoft.Json;

namespace TinkoffPaymentClientApi.ResponseEntity {
  public class CustomerResponse : TinkoffResponse {
    /// <summary>
    /// Идентификатор покупателя в системе продавца
    /// </summary>
    [JsonRequired]
    public string CustomerKey { get; set; } = string.Empty;
  }
}
