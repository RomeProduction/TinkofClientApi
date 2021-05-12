using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using TinkoffPaymentClientApi.Enums;

namespace TinkoffPaymentClientApi.Commands {
  /// <summary>
  /// Метод подтверждает платеж передачей реквизитов, а также списывает средства с карты покупателя при одностадийной оплате и блокирует указанную сумму при двухстадийной.
  /// <para>
  /// Используется, если у площадки есть сертификация PCI DSS и собственная платежная форма.
  /// </para>
  /// </summary>
  public class FinishAuthorize : BaseCommand {
    /// <summary>
    /// Метод подтверждает платеж передачей реквизитов, а также списывает средства с карты покупателя при одностадийной оплате и блокирует указанную сумму при двухстадийной.
    /// </summary>
    /// <param name="cardData">
    /// Зашифрованные данные карты. Не используется и не является обязательным, если передается <see cref="EncryptedPaymentData"/>
    /// См: https://oplata.tinkoff.ru/develop/api/payments/finishAuthorize-request/
    /// </param>
    /// <param name="encryptedPaymentData">
    /// Данные карт.
    /// <para>
    /// Используется и является обязательным только для Apple Pay или Google Pay
    /// </para>
    /// </param>
    public FinishAuthorize(string cardData, string encryptedPaymentData) {
      CardData = cardData;
      EncryptedPaymentData = encryptedPaymentData;
    }

    /// <summary>
    /// Зашифрованные данные карты. Не используется и не является обязательным, если передается <see cref="EncryptedPaymentData"/>
    /// См: https://oplata.tinkoff.ru/develop/api/payments/finishAuthorize-request/
    /// </summary>
    public string CardData { get; set; }
    /// <summary>
    /// Данные карт.
    /// <para>
    /// Используется и является обязательным только для Apple Pay или Google Pay
    /// </para>
    /// </summary>
    public string EncryptedPaymentData { get; set; }
    /// <summary>
    /// Сумма в копейках
    /// </summary>
    public uint Amount { get; set; }
    /// <summary>
    /// Дополнительные параметры платежа в формате "ключ":"значение" (не более 20 пар)
    /// </summary>
    [JsonProperty("DATA")]
    public Dictionary<string, string>? Data { get; set; }
    /// <summary>
    /// Email для отправки информации об оплате
    /// </summary>
    public string? InfoEmail { get; set; }
    /// <summary>
    /// IP-адрес клиента
    /// </summary>
    public string? IP { get; set; }
    /// <summary>
    /// Уникальный идентификатор транзакции в системе Банка, полученный в ответе на вызов метода Init
    /// </summary>
    public string? PaymentId { get; set; }
    /// <summary>
    /// Телефон клиента
    /// </summary>
    public string? Phone { get; set; }
    /// <summary>
    /// Отправлять клиенту информацию на почту об оплате
    /// </summary>
    public bool SendEmail { get; set; } = false;
    /// <summary>
    /// Способ платежа. Возможные значения: ACQ
    /// Используется и является обязательным для Apple Pay или Google Pay
    /// </summary>
    public string? Route => Source == EPaymentSource.ApplePay || Source == EPaymentSource.ApplePay ? "ACQ" : null;
    /// <summary>
    /// Источник платежа.
    /// Используется и является обязательным для Apple Pay или Google Pay
    /// </summary>
    public EPaymentSource? Source { get; set; }

    internal override string CommandName => "FinishAuthorize";
  }
} 
