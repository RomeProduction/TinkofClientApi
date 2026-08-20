namespace TinkoffPaymentClientApi.Enums;

/// <summary>
/// Способ расчета
/// </summary>
public static class EPaymentMethod
{
	/// <summary>
	/// Полный расчет
	/// </summary>
	public const string FullPayment = "full_payment";
	/// <summary>
	/// Предоплата 100%
	/// </summary>
	public const string FullPrepayment = "full_prepayment";
	/// <summary>
	/// Предоплата
	/// </summary>
	public const string Prepayment = "prepayment";
	/// <summary>
	/// Аванс
	/// </summary>
	public const string Advance = "advance";
	/// <summary>
	/// Частичный расчет и кредит
	/// </summary>
	public const string PartialPayment = "partial_payment";
	/// <summary>
	/// Передача в кредит
	/// </summary>
	public const string Credit = "credit";
	/// <summary>
	/// Оплата кредита
	/// </summary>
	public const string CreditPayment = "credit_payment";
}
