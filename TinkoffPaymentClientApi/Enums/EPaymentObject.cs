using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TinkoffPaymentClientApi.Enums {
  /// <summary>
  /// Предмет расчета
  /// </summary>
  [JsonConverter(typeof(StringEnumConverter))]
  public enum EPaymentObject {
    /// <summary>
    /// Товар
    /// </summary>
    commodity = 1,
    /// <summary>
    /// Подакцизный товар
    /// </summary>
    excise,
    /// <summary>
    /// Работа
    /// </summary>
    job,
    /// <summary>
    /// Услуга
    /// </summary>
    service,
    /// <summary>
    /// Ставка азартной игры
    /// </summary>
    gambling_bet,
    /// <summary>
    /// Выигрыш азартной игры
    /// </summary>
    gambling_prize,
    /// <summary>
    /// Лотерейный билет
    /// </summary>
    lottery,
    /// <summary>
    /// Выигрыш лотереи
    /// </summary>
    lottery_prize,
    /// <summary>
    /// Предоставление результатов интеллектуальной деятельности
    /// </summary>
    intellectual_activity,
    /// <summary>
    /// Платеж
    /// </summary>
    payment,
    /// <summary>
    /// Агентское вознаграждение
    /// </summary>
    agent_commission,
    /// <summary>
    /// Составной предмет расчета
    /// </summary>
    composite,
    /// <summary>
    /// Иной предмет расчета
    /// </summary>
    another,
  }
}