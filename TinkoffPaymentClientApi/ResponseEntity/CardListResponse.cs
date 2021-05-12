using Newtonsoft.Json;
using TinkoffPaymentClientApi.Enums;

namespace TinkoffPaymentClientApi.ResponseEntity {
  public class CardListResponse {
    /// <summary>
    /// Идентификатор сохраненной карты в системе банка
    /// </summary>
    [JsonRequired]
    public string CardId { get; set; } = string.Empty;
    /// <summary>
    /// Замаскированный номер карты
    /// </summary>
    [JsonRequired]
    public string Pan { get; set; } = string.Empty;
    /// <summary>
    /// Срок действия карты
    /// </summary>
    [JsonRequired]
    public string ExpDate { get; set; } = string.Empty;
    /// <summary>
    /// Тип карты
    /// </summary>
    [JsonRequired]
    public ECardType CardType { get; set; }
    /// <summary>
    /// Статус карты
    /// </summary>
    [JsonRequired]
    public ECardStatus Status { get; set; }
    /// <summary>
    /// Идентификатор автоплатежа	
    /// </summary>
    public string? RebillId { get; set; }
  }
}
