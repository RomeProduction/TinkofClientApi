namespace TinkoffPaymentClientApi.ResponseEntity;

/// <summary>
/// Текущее состояние платежа
/// </summary>
public class GetStateResponse : TinkoffResponse
{
	/// <summary>
	/// Сумма в копейках
	/// </summary>
	public uint Amount { get; set; }
	/// <summary>
	/// Идентификатор заказа в системе продавца
	/// </summary>
	public string OrderId { get; set; } = string.Empty;
	/// <summary>
	/// Уникальный идентификатор транзакции в системе банка
	/// </summary>
	public string PaymentId { get; set; } = string.Empty;
	/// <summary>
	/// Статус платежа
	/// </summary>
	public string Status { get; set; } = string.Empty;

}
