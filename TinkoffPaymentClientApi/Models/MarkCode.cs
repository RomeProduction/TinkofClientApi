namespace TinkoffPaymentClientApi.Models;

/// <summary>
/// Код маркировки в машиночитаемой форме, представленный в виде одного из видов кодов, формируемых в соответствии с требованиями, предусмотренными правилами, для нанесения на потребительскую упаковку, или на товары, или на товарный ярлык
/// <para>
/// Включается в чек, если предметом расчета является товар, подлежащий обязательной маркировке средством идентификации — соответствующий код в поле <see cref="ReceiptItem.PaymentObject"/>
/// </para>
/// </summary>
public class MarkCode
{
	/// <summary>
	/// Тип штрих кода. <see cref="Enums.EMarkCodeType"/>
	/// </summary>
	public string MarkCodeType { get; set; }
	/// <summary>
	/// Код маркировки
	/// </summary>
	public string Value { get; set; }

	/// <summary>
	/// Конструктор
	/// </summary>
	/// <param name="markCodeType">Тип штрих кода. <see cref="Enums.EMarkCodeType"/></param>
	/// <param name="value">Код маркировки</param>
	public MarkCode(string markCodeType, string value)
	{
		MarkCodeType = markCodeType;
		Value = value;
	}
}
