using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using TinkoffPaymentClientApi.Enums;

namespace TinkoffPaymentClientApi.Models {
  /// <summary>
  /// Данные по чеку
  /// </summary>
  public class Receipt {
    /// <summary>
    /// Электронная почта покупателя. Обязательна если не задан <see cref="Phone"/>
    /// </summary>
    public string Email { get; private set; }
    /// <summary>
    /// Телефон покупателя. Обязателен если не задан <see cref="Email"/>
    /// </summary>
    public string Phone { get; private set; }
    /// <summary>
    /// Система налогообложения.
    /// </summary>
    [JsonProperty(PropertyName = "Taxation", Required = Required.Always)]
    public ETaxation Taxation { get; private set; }
    /// <summary>
    /// Электронная почта продавца
    /// </summary>
    public string? EmailCompany { get; set; }
    /// <summary>
    /// Позиции чека с информацией о товарах.
    /// </summary>
    public IEnumerable<ReceiptItem> Items { get; private set; }
    /// <summary>
    /// Объект c информацией о видами суммы платежа.
    /// <para>
    /// Если объект не передан, будет автоматически указана итоговая сумма чека с видом оплаты "Безналичный".
    /// </para>
    /// <para>
    /// Если передан то значение в <see cref="Payments.Electronic"/> должно быть равно итоговому значению <see cref="Commands.Init.Amount"/>.
    /// При этом сумма введенных значений по всем видам оплат, включая <see cref="Payments.Electronic"/>,
    /// должна быть равна сумме (<see cref="ReceiptItem.Amount"/>) всех товаров, переданных в <see cref="Items"/>
    /// </para>
    /// </summary>
    public Payments? Payments { get; set; }

    public Receipt(string phone, string email, ETaxation taxation, IEnumerable<ReceiptItem> items) {
      if(string.IsNullOrEmpty(email) && string.IsNullOrEmpty(phone)) {
        throw new ArgumentNullException(TinkoffPaymentClientApi.Properties.Resources.Receipt_PhoneOrEmailShouldBeProvided);
      }

      Items = items;
      Phone = phone;
      Email = email;
      Taxation = taxation;
    }
  }
}
