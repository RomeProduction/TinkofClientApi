using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TinkoffPaymentClientApi.Models {
  /// <summary>
  /// Данные о поставщике
  /// </summary>
  public class SupplierInfo {
    public SupplierInfo(string phone, string name, string inn): this(new List<string>() { phone }, name, inn) {

    }

    [JsonConstructor]
    public SupplierInfo(IEnumerable<string> phones, string name, string inn) {
      Phones = phones;
      Name = name;
      Inn = inn;
    }

    /// <summary>
    /// Телефон поставщика
    /// </summary>
    public IEnumerable<string>? Phones { get; set; }
    /// <summary>
    /// Наименование поставщика
    /// </summary>
    public string? Name { get; set; }
    /// <summary>
    /// ИНН поставщика
    /// </summary>
    public string? Inn { get; set; }

  }
}
