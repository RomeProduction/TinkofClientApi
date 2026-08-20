namespace TinkoffPaymentClientApi.Enums;

/// <summary>
/// Тип аозвращаемого значения для <see cref="Commands.GetQr"/>
/// </summary>
public static class EQrDataType
{
	/// <summary>
	/// В ответе возвращается только Payload (по-умолчанию)
	/// </summary>
	public const string Payload = "PAYLOAD";
	public const string Image = "IMAGE";
}
