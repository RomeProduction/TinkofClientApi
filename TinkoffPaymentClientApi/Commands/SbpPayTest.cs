namespace TinkoffPaymentClientApi.Commands;

/// <summary>
/// Тестовая платежная сессия с предопределенным статусом по СБП
/// </summary>
public class SbpPayTest : BaseCommand
{
	internal override string CommandName => "SbpPayTest";
	/// <summary>
	/// Идентификатор платежа в системе Т-Кассы
	/// </summary>
	public string PaymentId { get; set; } = string.Empty;
	/// <summary>
	///Признак эмуляции отказа проведения платежа Банком по таймауту.По умолчанию не используется (эмуляция не требуется)
	///false — эмуляция не требуется,
	///true — требуется эмуляция(не может быть использован вместе с IsRejected = true).
	/// </summary>
	public bool IsDeadlineExpired { get; set; } = false;
	/// <summary>
	/// Признак эмуляции отказа Банка в проведении платежа. По умолчанию не используется (эмуляция не требуется)
	///false — эмуляция не требуется,
	///true — требуется эмуляция(не может быть использован вместе с IsDeadlineExpired = true).
	/// </summary>
	public bool IsRejected { get; set; } = false;

	public SbpPayTest(string paymentId)
	{
		PaymentId = paymentId;
	}
}
