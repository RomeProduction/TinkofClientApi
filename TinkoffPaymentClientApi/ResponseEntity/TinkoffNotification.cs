using Newtonsoft.Json;
using System.Collections.Generic;
using TinkoffPaymentClientApi.Attributes;
using TinkoffPaymentClientApi.Helpers;

namespace TinkoffPaymentClientApi.ResponseEntity {

  public class TinkoffNotification: TinkoffResponse {
    public string? ExpDate { get; set; }
    public string? Pan { get; set; }
    public string? CardId { get; set; }
    public string? RebillId { get; set; }
    public decimal? Amount { get; set; }
    public string? PaymentId { get; set; }
    public string? OrderId { get; set; }
    public string? Status { get; set; }

    [IgnoreTokenCalculate]
    public string? Token { get; set; }
    [IgnoreTokenCalculate]
    [JsonProperty(PropertyName = "DATA")]
    public Dictionary<string, string>? Data { get; set; }

    public bool CheckToken(string password) {
      var generatedToken = TokenGeneratorHelper.GenerateToken(this, password);
      return string.Equals(generatedToken, Token);
    }
  }

}
