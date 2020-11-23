using Newtonsoft.Json;
using TinkoffPaymentClientApi.Enums;

namespace TinkoffPaymentClientApi.Models {
  public class ReceiptItem {
    [JsonProperty(PropertyName = "Name", Required = Required.Always)]
    public string Name { get; set; }
    [JsonProperty(PropertyName = "Quantity", Required = Required.Always)]
    public int Quantity { get; set; }
    [JsonProperty(PropertyName = "Price", Required = Required.Always)]
    public decimal Price { get; set; }
    [JsonProperty(PropertyName = "Tax", Required = Required.Always)]
    public ETax Tax { get; set; }

    public decimal Amount => Price * Quantity;

    public string Ean13 { get; set; }
    public EPaymentMethod? PaymentMethod { get; set; }
    public EPaymentObject? PaymentObject { get; set; }

    public ReceiptItem(string name, int quantity, decimal price, ETax tax) {
      Name = name;
      Quantity = quantity;
      Price = price;
      Tax = tax;
    }
  }
}