namespace TinkoffPaymentClientApi.ResponseEntity;

/// <summary>
/// Данные об отмене платежа
/// </summary>
public class CancelResponse : TinkoffResponse
{
	/// <summary>
	/// Идентификатор заказа в системе продавца
	/// </summary>
	public string OrderId { get; set; } = string.Empty;
	/// <summary>
	/// Уникальный идентификатор транзакции в системе банка
	/// </summary>
	public string PaymentId { get; set; } = string.Empty;
	/// <summary>
	/// Сумма до возврата в копейках
	/// </summary>
	public uint OriginalAmount { get; set; }
	/// <summary>
	/// Сумма после возврата в копейках
	/// </summary>
	public uint NewAmount { get; set; }
	/// <summary>
	/// Статус платежа
	/// </summary>
	public string Status { get; set; } = string.Empty;
}
