namespace TinkoffPaymentClientApi.Enums;

/// <summary>
/// Ставка НДС
/// </summary>
public static class ETax
{
	/// <summary>
	/// Без НДС
	/// </summary>
	public const string None = "none";
	/// <summary>
	/// НДС по ставке 0%
	/// </summary>
	public const string Vat0 = "vat0";
	/// <summary>
	/// НДС по ставке 10%
	/// </summary>
	public const string Vat10 = "vat10";
	/// <summary>
	/// НДС по ставке 20%
	/// </summary>
	public const string Vat20 = "vat20";
	/// <summary>
	/// НДС по расчетной ставке 10/110
	/// </summary>
	public const string Vat110 = "vat110";
	/// <summary>
	/// НДС по расчетной ставке 20/120
	/// </summary>
	public const string Vat120 = "vat120";
	/// <summary>
	/// НДС по ставке 5%
	/// </summary>
	public const string Vat5 = "vat5";
	/// <summary>
	/// НДС по ставке 7%
	/// </summary>
	public const string Vat7 = "vat7";
	/// <summary>
	/// НДС по расчетной ставке 5/105
	/// </summary>
	public const string Vat105 = "vat105";
	/// <summary>
	/// НДС по расчетной ставке 7/107
	/// </summary>
	public const string Vat107 = "vat107";
}
