namespace TinkoffPaymentClientApi.ResponseEntity;

/// <summary>
/// Данные о подтверждении платежа
/// </summary>
public class ConfirmResponse : TinkoffResponse
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
	/// Статус платежа
	/// </summary>
	public string Status { get; set; } = string.Empty;
}
