using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using TinkoffPaymentClientApi.Attributes;
using TinkoffPaymentClientApi.Enums;
using TinkoffPaymentClientApi.Models;

namespace TinkoffPaymentClientApi.Commands {
  /// <summary>
  /// Метод создает платеж: продавец получает ссылку на платежную форму и должен перенаправить по ней покупателя
  /// </summary>
  public class Init : BaseCommand {
    internal override string CommandName => "Init";
    /// <summary>
    /// Идентификатор заказа в системе продавца	
    /// </summary>
    [JsonProperty(PropertyName = "OrderId", Required = Required.Always)]
    public string OrderId { get; private set; }
    /// <summary>
    /// Идентификатор родительского платежа
    /// </summary>
    public string Recurrent { get; private set; }
    /// <summary>
    /// Идентификатор покупателя в системе продавца. Передается вместе с параметром CardId. См. метод GetGardList
    /// Также необходим для сохранения карт на платежной форме(платежи в один клик).
    /// </summary>
    public string CustomerKey { get; private set; }
    /// <summary>
    /// Сумма в копейках	
    /// </summary>
    public decimal Amount { get; private set; }
    /// <summary>
    /// IP-адрес покупателя	
    /// </summary>
    public string IP { get; set; }
    /// <summary>
    /// Описание заказа	
    /// </summary>
    public string Description { get; set; }
    /// <summary>
    /// Cрок жизни ссылки (не более 90 дней)
    /// </summary>
    public DateTime? RedirectDueDate { get; set;}
    /// <summary>
    /// Адрес для получения http нотификаций
    /// </summary>
    public string NotificationURL { get; set; }
    /// <summary>
    /// Страница успеха
    /// </summary>
    public string SuccessURL { get; set; }
    /// <summary>
    /// Страница ошибки
    /// </summary>
    public string FailURL { get; set; }
    /// <summary>
    /// Язык платежной формы
    /// </summary>
    public ELanguageForm Language { get; set; }
    /// <summary>
    /// Тип оплаты, одно или дву стадийная
    /// </summary>
    public EPayType? PayType { get; set; }
    /// <summary>
    /// Данные по чеку
    /// </summary>
    [IgnoreTokenCalculate]
    public Receipt Receipt { get; set; }
    /// <summary>
    /// Дополнительные параметры платежа в формате "ключ":"значение" (не более 20 пар). Наименование самого параметра должно быть в верхнем регистре, иначе его содержимое будет игнорироваться.
    /// <list type="number">
    /// <item> Если у терминала включена опция привязки покупателя после успешной оплаты и передается параметр CustomerKey, то в передаваемых параметрах DATA могут присутствовать параметры метода AddCustomer. Если они присутствуют, то автоматически привязываются к покупателю.
    /// Например, если указать: "DATA":{"Phone":"+71234567890", "Email":"a@test.com"}, к покупателю автоматически будут привязаны данные Email и телефон, и они будут возвращаться при вызове метода GetCustomer.</item>
    /// <item>
    /// Если используется функционал сохранения карт на платежной форме, то при помощи опционального параметра "DefaultCard" можно задать какая карта будет выбираться по умолчанию. Возможные варианты:
    /// <list type="bullet">
    /// <item>Оставить платежную форму пустой. Пример: "DATA":{"DefaultCard":"none"};</item>
    /// <item>Заполнить данными передаваемой карты. В этом случае передается CardId. Пример: "DATA":{"DefaultCard":"894952"};</item>
    /// <item>Заполнить данными последней сохраненной карты. Применяется, если параметр "DefaultCard" не передан, передан с некорректным значением или в значении null.</item>
    /// </list>
    /// По умолчанию возможность сохранения карт на платежной форме может быть отключена. Для активации обратитесь в службу технической поддержки.
    /// </item>
    /// </list>
    /// </summary>
    [IgnoreTokenCalculate]
    [JsonProperty(PropertyName = "DATA")]
    public Dictionary<string, string> Data { get; set; }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="orderId">Идентификатор заказа в системе продавца</param>
    /// <param name="amount">Сумма в копейках</param>
    /// <param name="isReccurent">Признак автоплатежа</param>
    /// <param name="customerKey">Идентификатор покупателя в системе продавца <see cref="CustomerKey"/></param>
    public Init(string orderId, decimal amount, bool isReccurent = false, string customerKey = null) {
      if(amount <= 0) {
        throw new ArgumentOutOfRangeException(nameof(amount), "Must be greater then zero");
      }
      if(isReccurent && string.IsNullOrEmpty(customerKey)) {
        throw new ArgumentNullException("If payment is reccurent - CustomerKey must be not empty");
      }
      Language = ELanguageForm.Ru;
      Amount = amount;
      OrderId = orderId;
      Recurrent = isReccurent ? "Y" : null;
      CustomerKey =customerKey;
    }
  }
}
