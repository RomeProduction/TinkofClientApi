using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TinkoffPaymentClientApi.Enums {
  [JsonConverter(typeof(StringEnumConverter))]
  public enum ELanguageForm {
    en = 1,
    ru,
  }
}