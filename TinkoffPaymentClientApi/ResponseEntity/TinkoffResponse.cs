using Newtonsoft.Json;

namespace TinkoffPaymentClientApi.ResponseEntity {
  /// <summary>
  /// Базовый класс ответа
  /// </summary>
  public abstract class TinkoffResponse {
    /// <summary>
    /// Идентификатор терминала. Выдается продавцу банком при заведении терминала
    /// </summary>
    // [JsonRequired] //not documented in SendClosingReceipt
    public string TerminalKey { get; set; } = string.Empty;
    /// <summary>
    /// Признак успешного выполнения запроса
    /// </summary>
    [JsonRequired]
    public bool Success { get; set; } = false;
    /// <summary>
    /// Код ошибки. Если ошибки не произошло, передается значение «0»
    /// </summary>
    [JsonRequired]
    public string ErrorCode { get; set; } = string.Empty;
    /// <summary>
    /// Краткое описание ошибки
    /// </summary>
    public string? Message { get; set; }
    /// <summary>
    /// Подробное описание ошибки	
    /// </summary>
    public string? Details { get; set; }
  }
}
