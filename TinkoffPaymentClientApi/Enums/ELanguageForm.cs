using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TinkoffPaymentClientApi.Enums {
  [JsonConverter(typeof(StringEnumConverter))]
  public enum ELanguageForm {
    [EnumMember(Value = "en")]
    En = 1,
    [EnumMember(Value = "ru")]
    Ru,
  }
}
