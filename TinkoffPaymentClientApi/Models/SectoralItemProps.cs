
namespace TinkoffPaymentClientApi.Models;

/// <summary>
/// Отраслевой реквизит предмета расчета. 
/// Указывается только для товаров подлежащих обязательной маркировке средством идентификации. 
/// Включение этого реквизита предусмотрено НПА отраслевого регулирования для соответствующей товарной группы
/// </summary>
public class SectoralItemProps
{
	/// <summary>
	/// ФФД 1.2, Тег ФФД: 1262
	/// <para>
	/// Идентификатор ФОИВ — федеральный орган исполнительной власти
	/// </para>
	/// </summary>
	public string FederalId { get; set; }
	/// <summary>
	/// ФФД 1.2, Тег ФФД: 1263
	/// <para>
	/// Дата нормативного акта ФОИВ
	/// </para>
	/// </summary>
	public string Date { get; set; }
	/// <summary>
	/// ФФД 1.2, Тег ФФД: 1264
	/// <para>
	/// Номер нормативного акта ФОИВ
	/// </para>
	/// </summary>
	public string Number { get; set; }
	/// <summary>
	/// ФФД 1.2, Тег ФФД: 1265
	/// <para>
	/// Состав значений, определенных нормативным актом ФОИВ
	/// </para>
	/// </summary>
	public string Value { get; set; }

	public SectoralItemProps(string federalId, string date, string number, string value)
	{
		FederalId = federalId;
		Date = date;
		Number = number;
		Value = value;
	}
}
