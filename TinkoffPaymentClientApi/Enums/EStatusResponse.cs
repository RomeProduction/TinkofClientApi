using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace TinkoffPaymentClientApi.Enums {
  [JsonConverter(typeof(StringEnumConverter))]
  public enum  EStatusResponse {
    NEW = 1,
    FORM_SHOWED,
    DEADLINE_EXPIRED,
    CANCELED,
    PREAUTHORIZING,
    AUTHORIZING,
    AUTHORIZED,
    AUTH_FAIL,
    REJECTED,
    [EnumMember(Value = "3DS_CHECKING")]
    CHECKING_3DS,
    [EnumMember(Value = "3DS_CHECKED")]
    CHECKED_3DS,
    REVERSING,
    PARTIAL_REVERSED,
    REVERSED,
    CONFIRMING,
    CONFIRMED,
    REFUNDING,
    PARTIAL_REFUNDED,
    REFUNDED,
  }
}