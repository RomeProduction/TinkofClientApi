namespace TinkoffPaymentClientApi.ResponseEntity;
/// <summary>
/// Информация о Qr коде(вызывается после метода Init)
/// </summary>
public class QrResponse : TinkoffResponse
{
	/// <summary>
	/// Номер заказа в системе Мерчанта
	/// </summary>
	public string OrderId { get; set; } = string.Empty;
	/// <summary>
	/// В зависимости от параметра DataType в запросе это:
	/// Payload — информация, которая должна быть закодирована в QR;
	/// SVG изображение QR в котором уже закодирован Payload.
	/// </summary>
	public string Data { get; set; } = string.Empty;
	/// <summary>
	/// Уникальный идентификатор транзакции в системе Т-Кассы
	/// </summary>
	public string PaymentId { get; set; } = string.Empty;
	/// <summary>
	/// Идентификатор запроса на привязку счета. Передается в случае привязки и одновременной оплаты по CБП
	/// </summary>
	public string RequestKey { get; set; } = string.Empty;
}
