using Newtonsoft.Json;
using TinkoffPaymentClientApi.Attributes;

namespace TinkoffPaymentClientApi.Commands {
  public abstract class BaseCommand {
    [IgnoreTokenCalculate, JsonIgnore]
    internal abstract string CommandName { get; }
    [JsonProperty]
    [IgnoreTokenCalculate]
    internal string Token { get; set; }
    [JsonProperty]
    internal string TerminalKey { get; set; }
  }
}
