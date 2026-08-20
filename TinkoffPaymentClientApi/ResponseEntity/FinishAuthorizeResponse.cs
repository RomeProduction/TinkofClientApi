namespace TinkoffPaymentClientApi.ResponseEntity;

/// <summary>
/// Данные о подтверждении платежа
/// </summary>
public class FinishAuthorizeResponse : TinkoffResponse
{
	/// <summary>
	/// Номер заказа в системе Продавца
	/// </summary>
	public string OrderId { get; set; } = string.Empty;
	/// <summary>
	/// Статус платежа
	/// </summary>
	public string Status { get; set; } = string.Empty;
	/// <summary>
	/// Сумма в копейках
	/// </summary>
	public uint Amount { get; set; }
	/// <summary>
	/// Уникальный идентификатор транзакции в системе банка
	/// </summary>
	public string PaymentId { get; set; } = string.Empty;
	/// <summary>
	/// Идентификатор карты в системе банка. Передается только для сохраненной карты
	/// </summary>
	public string? CardId { get; set; }
}
