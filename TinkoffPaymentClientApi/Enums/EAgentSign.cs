namespace TinkoffPaymentClientApi.Enums;

/// <summary>
/// Признак агента
/// </summary>
public static class EAgentSign
{
	/// <summary>
	/// Банковский платежный агент
	/// </summary>
	public const string BankPayingAgent = "bank_paying_agent";
	/// <summary>
	/// Банковский платежный субагент
	/// </summary>
	public const string BankPayingSubagent = "bank_paying_subagent";
	/// <summary>
	/// Платежный агент
	/// </summary>
	public const string PayingAgent = "paying_agent";
	/// <summary>
	/// Платежный субагент
	/// </summary>
	public const string PayingSubagent = "paying_subagent";
	/// <summary>
	/// Поверенный
	/// </summary>
	public const string Attorney = "attorney";
	/// <summary>
	/// Комиссионер
	/// </summary>
	public const string CommissionAgent = "commission_agent";
	/// <summary>
	/// Другой тип агента
	/// </summary>
	public const string Another = "another";
}
