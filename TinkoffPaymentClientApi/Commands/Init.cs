using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using TinkoffPaymentClientApi.Attributes;
using TinkoffPaymentClientApi.Enums;
using TinkoffPaymentClientApi.Models;

namespace TinkoffPaymentClientApi.Commands {
  public class Init : BaseCommand {
    internal override string CommandName => "Init";

    [JsonProperty(PropertyName = "OrderId", Required = Required.Always)]
    public string OrderId { get; private set; }
    public string Recurrent { get; private set; }
    public string CustomerKey { get; private set; }
    public decimal Amount { get; private set; }

    public string IP { get; set; }
    public string Description { get; set; }
    public DateTime? RedirectDueDate { get; set;}
    public string NotificationURL { get; set; }
    public string SuccessURL { get; set; }
    public string FailURL { get; set; }

    public ELanguageForm Language { get; set; }
    public EPayType? PayType { get; set; }

    [IgnoreTokenCalculate]
    public Receipt Receipt { get; set; }
    [IgnoreTokenCalculate]
    [JsonProperty(PropertyName = "DATA")]
    public Dictionary<string, string> Data { get; set; }

    public Init(string orderId, decimal amount, bool isReccurent = false, string customerKey = null) {
      if(amount <= 0) {
        throw new ArgumentOutOfRangeException(nameof(amount), "Must be greater then zero");
      }
      if(isReccurent && string.IsNullOrEmpty(customerKey)) {
        throw new ArgumentNullException("If payment is reccurent - CustomerKey must be not empty");
      }
      Language = ELanguageForm.Ru;
      Amount = amount;
      OrderId = orderId;
      Recurrent = isReccurent ? "Y" : null;
      CustomerKey =customerKey;
    }
  }
}