using Newtonsoft.Json;
using TinkoffPaymentClientApi.Attributes;

namespace TinkoffPaymentClientApi.Commands {
  /// <summary>
  /// Базовый запрос к API
  /// </summary>
  public abstract class BaseCommand {
    [IgnoreTokenCalculate, JsonIgnore]
    internal abstract string CommandName { get; }
    /// <summary>
    /// Подпись, будет посчитана и заполнена автоматически.
    /// </summary>
    [JsonProperty]
    [IgnoreTokenCalculate]
    public string? Token { get; internal set; }
    /// <summary>
    /// Идентификатор терминала. Выдается продавцу банком при заведении терминала. Будет подставлен автоматически
    /// </summary>
    [JsonProperty]
    public string? TerminalKey { get; internal set; }
  }
}
