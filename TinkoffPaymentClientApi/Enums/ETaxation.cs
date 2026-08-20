namespace TinkoffPaymentClientApi.Enums;

/// <summary>
/// Система налогооблажения
/// </summary>
public static class ETaxation
{
	/// <summary>
	/// Общая
	/// </summary>
	public const string Osn = "osn";
	/// <summary>
	/// Упрощенная (доходы)
	/// </summary>
	public const string UsnIncome = "usn_income";
	/// <summary>
	/// Упрощенная (доходы минус расходы)
	/// </summary>
	public const string UsnIncomeOutcome = "usn_income_outcome";
	/// <summary>
	/// Патентная
	/// </summary>
	public const string Patent = "patent";
	/// <summary>
	/// Единый налог на вмененный доход
	/// </summary>
	public const string Envd = "envd";
	/// <summary>
	/// Единый сельскохозяйственный налог
	/// </summary>
	public const string Esn = "esn";
}
