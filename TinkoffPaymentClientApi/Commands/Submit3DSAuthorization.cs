using System;

namespace TinkoffPaymentClientApi.Commands {
  /// <summary>
  /// Осуществляет проверку результатов прохождения 3-D Secure и при успешном результате прохождения 3-D Secure подтверждает инициированный платеж.
  /// </summary>
  public class Submit3DSAuthorization: BaseCommand {
    /// <summary>
    /// Уникальный идентификатор транзакции в системе Банка
    /// </summary>
    public string MD { get; private set; }
    /// <summary>
    /// Шифрованная строка, содержащая результаты 3-D Secure аутентификации
    /// </summary>
    public string PaRes { get; private set; }
    /// <summary>
    /// Уникальный идентификатор транзакции в системе Банка
    /// </summary>
    public string PaymentId { get; private set; }

    internal override string CommandName => "Submit3DSAuthorization";

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="paymentId">Уникальный идентификатор транзакции в системе Банка</param>
    /// <param name="md">Уникальный идентификатор транзакции в системе Банка</param>
    /// <param name="paRes">Шифрованная строка, содержащая результаты 3-D Secure аутентификации</param>
    public Submit3DSAuthorization(string paymentId, string md, string paRes) {
      if (string.IsNullOrEmpty(paymentId)) {
        throw new ArgumentNullException(nameof(paymentId), Properties.Resources.TinkoffPaymentClient_ShouldNotBeEmpty);
      }
      PaymentId = paymentId;
      if (string.IsNullOrEmpty(md)) {
        throw new ArgumentNullException(nameof(md), Properties.Resources.TinkoffPaymentClient_ShouldNotBeEmpty);
      }
      MD = md;
      if (string.IsNullOrEmpty(paRes)) {
        throw new ArgumentNullException(nameof(paRes), Properties.Resources.TinkoffPaymentClient_ShouldNotBeEmpty);
      }
      PaRes = paRes;
    }
  }
}
