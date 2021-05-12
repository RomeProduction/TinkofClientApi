using Newtonsoft.Json;
using TinkoffPaymentClientApi.Enums;

namespace TinkoffPaymentClientApi.ResponseEntity {
  public class RemoveCardResponse: TinkoffResponse {
    /// <summary>
    /// Идентификатор покупателя в системе продавца
    /// </summary>
    [JsonRequired]
    public string CustomerKey { get; set; } = string.Empty;

    /// <summary>
    /// Идентификатор карты в системе Банка
    /// </summary>
    [JsonRequired]
    public string CardId { get; set; } = string.Empty;

    /// <summary>
    /// Статус карты: D – удалена
    /// </summary>
    [JsonRequired]
    public ECardStatus Status { get; set; }

    /// <summary>
    /// Тип карты
    /// </summary>
    [JsonRequired]
    public ECardType CardType { get; set; }
  }
}
