namespace TinkoffPaymentClientApi.Enums;

public static class EMarkCodeType
{
	/// <summary>
	/// код товара, формат которого не идентифицирован, как один из реквизитов
	/// </summary>
	public const string UNKNOWN = "UNKNOWN";
	/// <summary>
	/// код товара в формате EAN-8
	/// </summary>
	public const string EAN8 = "EAN8";
	/// <summary>
	/// код товара в формате EAN-13
	/// </summary>
	public const string EAN13 = "EAN13";
	/// <summary>
	/// код товара в формате ITF-14
	/// </summary>
	public const string ITF14 = "ITF14";
	/// <summary>
	/// код товара в формате GS1, нанесенный на товар, не подлежащий маркировке
	/// </summary>
	public const string GS10 = "GS10";
	/// <summary>
	/// код товара в формате GS1, нанесенный на товар, подлежащий маркировке
	/// </summary>
	public const string GS1M = "GS1M";
	/// <summary>
	/// код товара в формате короткого кода маркировки, нанесенный на товар
	/// </summary>
	public const string SHORT = "SHORT";
	/// <summary>
	/// контрольно-идентификационный знак мехового изделия
	/// </summary>
	public const string FUR = "FUR";
	/// <summary>
	/// код товара в формате ЕГАИС-2.0
	/// </summary>
	public const string EGAIS20 = "EGAIS20";
	/// <summary>
	/// код товара в формате ЕГАИС-3.0
	/// </summary>
	public const string EGAIS30 = "EGAIS30";
	/// <summary>
	/// код маркировки, как он был прочитан сканером
	/// </summary>
	public const string RAWCODE = "RAWCODE";
}
