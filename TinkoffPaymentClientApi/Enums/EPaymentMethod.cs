﻿using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TinkoffPaymentClientApi.Enums {
  /// <summary>
  /// Способ расчета
  /// </summary>
  [JsonConverter(typeof(StringEnumConverter))]
  public enum EPaymentMethod {
    /// <summary>
    /// Полный расчет
    /// </summary>
    [EnumMember(Value = "full_payment")]
    FullPayment = 1,
    /// <summary>
    /// Предоплата 100%
    /// </summary>
    [EnumMember(Value = "full_prepayment")]
    FullPrepayment,
    /// <summary>
    /// Предоплата
    /// </summary>
    [EnumMember(Value = "prepayment")]
    Prepayment,
    /// <summary>
    /// Аванс
    /// </summary>
    [EnumMember(Value = "advance")]
    Advance,
    /// <summary>
    /// Частичный расчет и кредит
    /// </summary>
    [EnumMember(Value = "partial_payment")]
    PartialPayment,
    /// <summary>
    /// Передача в кредит
    /// </summary>
    [EnumMember(Value = "credit")]
    Credit,
    /// <summary>
    /// Оплата кредита
    /// </summary>
    [EnumMember(Value = "credit_payment")]
    CreditPayment,
  }
}
