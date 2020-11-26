using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using TinkoffPaymentClientApi.Enums;

namespace TinkoffPaymentClientApi.Models {
  public class Receipt {
    public string Email { get; set; }
    public string Phone { get; set; }
    [JsonProperty(PropertyName = "Taxation", Required = Required.Always)]
    public ETaxation Taxation { get; set; }

    public string EmailCompany { get; set; }

    [JsonProperty("Items")]
    public IEnumerable<ReceiptItem> ReceiptItems { get; set; }

    public Receipt(string email, ETaxation taxation) : this(null, email, taxation){}

    public Receipt(string phone, string email, ETaxation taxation) {
      if(string.IsNullOrEmpty(email) && string.IsNullOrEmpty(phone)) {
        throw new ArgumentNullException("Phone or Email must be not empty");
      }

      ReceiptItems = new List<ReceiptItem>();
      Phone = phone;
      Email = email;
      Taxation = taxation;
    }
  }
}