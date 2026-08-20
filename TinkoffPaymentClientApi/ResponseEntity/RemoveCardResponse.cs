using TinkoffPaymentClientApi.Enums;

namespace TinkoffPaymentClientApi.ResponseEntity;

public class RemoveCardResponse : TinkoffResponse
{
	/// <summary>
	/// Идентификатор покупателя в системе продавца
	/// </summary>
	public string CustomerKey { get; set; } = string.Empty;

	/// <summary>
	/// Идентификатор карты в системе Банка
	/// </summary>
	public string CardId { get; set; } = string.Empty;

	/// <summary>
	/// Статус карты: D – удалена
	/// </summary>
	public string Status { get; set; } = string.Empty;

	/// <summary>
	/// Тип карты
	/// </summary>
	public ECardType CardType { get; set; }
}
