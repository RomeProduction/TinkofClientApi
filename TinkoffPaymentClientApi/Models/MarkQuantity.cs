using System;

namespace TinkoffPaymentClientApi.Models;

/// <summary>
/// Реквизит "дробное количество маркированного товара"
/// Передается, только если расчет осуществляется за маркированный товар — соответствующий код в поле <see cref="ReceiptItem.PaymentObject"/>, и значение в поле <see cref="ReceiptItem.MeasurementUnit"/> равно 0
/// <para>
/// MarkQuantity не является обязательным объектом, в том числе для товаров с маркировкой. Этот объект можно передавать, если товар с маркировкой. То есть даже при ФФД 1.2 этот объект не является обязательным
/// </para>
/// </summary>
public class MarkQuantity
{
	/// <summary>
	/// ФФД 1.2, Тег ФФД: 1293
	/// <para>
	/// Числитель дробной части предмета расчета. Значение должно быть строго меньше значения реквизита "знаменатель" (<see cref="Denominator"/>)
	/// </para>
	/// </summary>
	public int Numerator { get; set; }
	/// <summary>
	/// ФФД 1.2, Тег ФФД: 1294
	/// <para>
	/// Знаменатель дробной части предмета расчета. Значение равно количеству товара в партии (упаковке), имеющей общий код маркировки товара
	/// </para>
	/// </summary>
	public int Denominator { get; set; }
	public MarkQuantity(int numerator, int denominator)
	{
		if (numerator >= denominator)
		{
			throw new ArgumentException(TinkoffPaymentClientApi.Properties.Resources.NumeratorShouldBeLessThenDenominator);
		}

		Numerator = numerator;
		Denominator = denominator;
	}
}
