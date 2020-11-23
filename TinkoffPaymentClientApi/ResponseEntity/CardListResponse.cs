using TinkoffPaymentClientApi.Enums;

namespace TinkoffPaymentClientApi.ResponseEntity {
  public class CardListResponse {
    public string CardId { get; set; }
    public string Pan { get; set; }
    public string ExpDate { get; set; }
    public ECardType CardType { get; set; }
    public ECardStatus Status { get; set; }
    public string RebillId { get; set; }
  }
}