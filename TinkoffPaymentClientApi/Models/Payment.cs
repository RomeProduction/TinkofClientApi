namespace TinkoffPaymentClientApi.Models;

/// <summary>
/// Детали по статусу заказа
/// https://www.tinkoff.ru/kassa/develop/api/payments/checkorder-response/
/// </summary>
public class Payment
{
	/// <summary>
	/// Уникальный идентификатор транзакции в системе Банка	
	/// </summary>

	public string? PaymentId { get; set; }
	/// <summary>
	/// Сумма операции в копейках	
	/// </summary>
	public uint? Amount { get; set; }
	/// <summary>
	/// Статус транзакции
	/// </summary>

	public string Status { get; set; } = string.Empty;
	/// <summary>
	/// RRN операции
	/// </summary>
	public string? RRN { get; set; }
}
