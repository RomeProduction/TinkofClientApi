using System;

namespace TinkoffPaymentClientApi.Commands {
  /// <summary>
  /// Метод осуществляет автоплатеж.
  /// <para>
  /// Всегда работает по типу одностадийной оплаты: во время выполнения метода на Notification URL будет отправлен синхронный запрос, на который требуется корректный ответ.
  /// </para>
  /// </summary>
  public class Charge : BaseCommand {

    /// <summary>
    /// Идентификатор платежа в системе банка	
    /// </summary>
    public string PaymentId { get; private set; }
    /// <summary>
    /// Идентификатор автоплатежа	
    /// </summary>
    public string RebillId { get; private set; }
    /// <summary>
    /// Получение покупателем уведомлений на электронную почту	
    /// </summary>
    public bool? SendEmail { get; set; }
    /// <summary>
    /// Электронная почта покупателя. Заполнить в случае если задан <see cref="SendEmail"/>
    /// </summary>
    public string InfoEmail { get; set; }
    /// <summary>
    /// IP-адрес покупателя	
    /// </summary>
    public string IP { get; set; }

    internal override string CommandName => "Charge";

    public Charge(string paymentId, string rebillId, 
      bool? sendEmail = null, string infoEmail = null) {
      if(sendEmail.HasValue && !sendEmail.Value) {
        sendEmail = null;
      }
      if (string.IsNullOrEmpty(paymentId)) {
        throw new ArgumentNullException(nameof(paymentId), "Must be not empty");
      }
      if (string.IsNullOrEmpty(rebillId)) {
        throw new ArgumentNullException(nameof(rebillId), "Must be not empty");
      }
      if(sendEmail.HasValue && string.IsNullOrEmpty(infoEmail)) {
        throw new ArgumentNullException(nameof(infoEmail), "If SendEmail is true, then must be not empty");
      }

      PaymentId = paymentId;
      RebillId = rebillId;
      SendEmail = sendEmail;
      InfoEmail = infoEmail;
    }
  }
}
