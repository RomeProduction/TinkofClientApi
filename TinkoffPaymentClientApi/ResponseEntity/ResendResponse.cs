namespace TinkoffPaymentClientApi.ResponseEntity {
  /// <summary>
  /// Результат отправки уведомлений
  /// </summary>
  public class ResendResponse: TinkoffResponse {
    /// <summary>
    /// Количество сообщений, отправляемых повторно
    /// </summary>
    public long Count { get; set; }
  }
}
