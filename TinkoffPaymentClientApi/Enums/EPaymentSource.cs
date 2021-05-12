using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TinkoffPaymentClientApi.Enums {

  /// <summary>
  /// Источник платежа
  /// </summary>
  [JsonConverter(typeof(StringEnumConverter))]
  public enum EPaymentSource {
    /// <summary>
    /// Картой
    /// </summary>
    Cards,
    /// <summary>
    /// ApplePay
    /// </summary>
    ApplePay,
    /// <summary>
    /// GooglePay
    /// </summary>
    GooglePay
  }
}
