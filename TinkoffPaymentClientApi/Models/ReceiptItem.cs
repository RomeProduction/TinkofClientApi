using Newtonsoft.Json;

namespace TinkoffPaymentClientApi.Models;

/// <summary>
/// Данные о позиции чека
/// </summary>
public class ReceiptItem
{
	/// <summary>
	/// Наименование товара
	/// </summary>
	[JsonProperty(PropertyName = "Name", Required = Required.Always)]
	public string Name { get; private set; }
	/// <summary>
	/// Количество или вес товара
	/// </summary>
	[JsonProperty(PropertyName = "Quantity", Required = Required.Always)]
	public uint Quantity { get; private set; }
	/// <summary>
	/// Цена за единицу товара в копейках
	/// </summary>
	[JsonProperty(PropertyName = "Price", Required = Required.Always)]
	public uint Price { get; private set; }
	/// <summary>
	/// Ставка НДС
	/// </summary>
	[JsonProperty(PropertyName = "Tax", Required = Required.Always)]
	public string Tax { get; private set; }

	/// <summary>
	/// Стоимость товара в копейках, произведение <see cref="Quantity"/> и <see cref="Price"/>
	/// </summary>
	public uint Amount => Price * Quantity;
	/// <summary>
	/// Штрих-код в требуемом формате. В зависимости от типа кассы требования могут отличаться:
	/// <list type="bullet">
	/// <item>АТОЛ Онлайн - шестнадцатеричное представление с пробелами. Максимальная длина – 32 байта. Пример: 00 00 00 01 00 21 FA 41 00 23 05 41 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 12 00 AB 00</item>
	/// <item>CloudKassir - длина строки: четная, от 8 до 150 байт, т.е. от 16 до 300 ASCII символов ['0' - '9' , 'A' - 'F' ] шестнадцатеричного представления кода маркировки товара. Пример: 303130323930303030630333435</item>
	/// <item>OrangeData - строка, содержащая base64 кодированный массив от 8 до 32 байт. Пример: igQVAAADMTIzNDU2Nzg5MDEyMwAAAAAAAQ==</item>
	/// </list>
	/// В случае передачи в запросе параметра Ean13 не прошедшего валидацию, возвращается неуспешный ответ с текстом ошибки в параметре message = "Неверный параметр Ean13". Валидация параметра Ean13 необходима как в объекте Receipt, так и в объекте Receipts.
	/// </summary>
	public string? Ean13 { get; set; }
	/// <summary>
	/// Признак способа расчета
	/// </summary>
	public string? PaymentMethod { get; set; }
	/// <summary>
	/// Признак предмета расчета
	/// </summary>
	public string? PaymentObject { get; set; }
	/// <summary>
	/// Данные агента. Используется при работе по агентской схеме.
	/// </summary>
	public AgentData? AgentData { get; set; }
	/// <summary>
	/// Данные поставщика платежного агента.
	/// Используется при работе по агентской схеме.
	/// Требуется передать в случае если задан <see cref="AgentData"/>
	/// </summary>
	public SupplierInfo? SupplierInfo { get; set; }
	/// <summary>
	/// ФФД 1.2, Тег ФФД: 1191
	/// <para>
	/// Дополнительный реквизит предмета расчета
	/// </para>
	/// </summary>
	public string? UserData { get; set; }
	/// <summary>
	/// ФФД 1.2, Тег ФФД: 
	/// <para>
	/// Сумма акциза в рублях с учетом копеек, включенная в стоимость предмета расчета:
	/// целая часть — не больше 8 знаков;
	/// дробная часть — не больше 2 знаков;
	/// значение не может быть отрицательным
	/// </para>
	/// </summary>
	public string? Excise { get; set; }
	/// <summary>
	/// ФФД 1.2, Тег ФФД: 1230
	/// <para>
	/// Цифровой код страны происхождения товара в соответствии с Общероссийским классификатором стран мира — 3 цифры
	/// </para>
	/// </summary>
	public string? CountryCode { get; set; }
	/// <summary>
	/// ФФД 1.2, Тег ФФД: 1231
	/// <para>
	/// Номер таможенной декларации
	/// </para>
	/// </summary>
	public string? DeclarationNumber { get; set; }
	/// <summary>
	/// ФФД 1.2, Тег ФФД: 2108
	/// <para>
	/// Единицы измерения. Передавать в соответствии с ОК 015-94 (МК 002-97)
	/// </para>
	/// <para>
	/// Возможные значения: https://www.consultant.ru/document/cons_doc_LAW_362322/0060b1f1924347c03afbc57a8d4af63888f81c6c/
	/// Также возможна передача произвольных значений
	/// </para>
	/// <para>
	/// обязателен, если версия ФД онлайн-кассы — 1.2
	/// </para>
	/// </summary>
	public string? MeasurementUnit { get; set; }
	/// <summary>
	/// ФФД 1.2, Тег ФФД: 2102
	/// <para>
	/// Режим обработки кода маркировки. Должен принимать значение, равное 0. Включается в чек , если предметом расчета является товар, подлежащий обязательной маркировке средством идентификации — соответствующий код в поле <see cref="PaymentObject"/>
	/// </para>
	/// </summary>
	public string? MarkProcessingMode { get; set; }
	/// <summary>
	/// Код маркировки в машиночитаемой форме, представленный в виде одного из видов кодов, формируемых в соответствии с требованиями, предусмотренными правилами, для нанесения на потребительскую упаковку, или на товары, или на товарный ярлык
	/// <para>
	/// Включается в чек, если предметом расчета является товар, подлежащий обязательной маркировке средством идентификации — соответствующий код в поле <see cref="ReceiptItem.PaymentObject"/>
	/// </para>
	/// </summary>
	public MarkCode? MarkCode { get; set; }
	/// <summary>
	/// Реквизит "дробное количество маркированного товара"
	/// Передается, только если расчет осуществляется за маркированный товар — соответствующий код в поле <see cref="ReceiptItem.PaymentObject"/>, и значение в поле <see cref="ReceiptItem.MeasurementUnit"/> равно 0
	/// <para>
	/// MarkQuantity не является обязательным объектом, в том числе для товаров с маркировкой. Этот объект можно передавать, если товар с маркировкой. То есть даже при ФФД 1.2 этот объект не является обязательным
	/// </para>
	/// </summary>
	public MarkQuantity? MarkQuantity { get; set; }
	/// <summary>
	/// Отраслевой реквизит предмета расчета. 
	/// Указывается только для товаров подлежащих обязательной маркировке средством идентификации. 
	/// Включение этого реквизита предусмотрено НПА отраслевого регулирования для соответствующей товарной группы
	/// </summary>
	public SectoralItemProps? SectoralItemProps { get; set; }

	public ReceiptItem(string name, uint quantity, uint price, string tax)
	{
		Name = name;
		Quantity = quantity;
		Price = price;
		Tax = tax;
	}
}
