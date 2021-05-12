namespace TinkoffPaymentClientApi.Commands {
  /// <summary>
  /// Метод отправляет все неотправленные уведомления
  /// </summary>
  public class Resend: BaseCommand {
    internal override string CommandName => "Resend";
  }
}
