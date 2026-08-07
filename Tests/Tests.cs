using TinkoffPaymentClientApi.Commands;
using TinkoffPaymentClientApi.Helpers;

namespace Tests;

public class Tests
{
	// Для проверки валидности токена: https://tokentcs.web.app/

	[Test, Theory]
	public void TokenGeneratorTest1(bool useExpressionBuilder)
	{
		var json = "{\"OrderId\":\"Мой парк/24892e9f-b1f7-44ec-8610-3bbc504b165f\",\"CustomerKey\":\"test@mail.ru\",\"Amount\":1100,\"Description\":\"Мой парк: бпс2\",\"SuccessURL\":\"http://localhost:4200/shop/check-order?integrationId=4106&publicOrderId=decc1b66-f61c-47c5-9058-5537a6ebfd8c\",\"FailURL\":\"http://localhost:4200/shop/check-order?integrationId=4106&publicOrderId=decc1b66-f61c-47c5-9058-5537a6ebfd8c\",\"Language\":\"ru\",\"PayType\":\"T\",\"Receipt\":{\"Email\":\"test@mail.ru\",\"Taxation\":\"usnincomeoutcome\",\"Items\":[{\"Name\":\"Карусель (онлайн)\",\"Quantity\":1,\"Price\":1100,\"Tax\":\"vat20\",\"Amount\":1100,\"PaymentMethod\":\"full_payment\",\"PaymentObject\":\"service\"}]},\"DATA\":{\"Email\":\"test@mail.ru\"},\"Token\":\"1f3515e976fad335dd230467bdc7e1b2a265384be6939a3fbd287f58187ab48b\",\"TerminalKey\":\"1733135659250DEMO\"}";
		var init = Newtonsoft.Json.JsonConvert.DeserializeObject<Init>(json)!;

		var hash = TokenGeneratorHelper.GenerateToken(init, "some_test_password", useExpressionBuilder);
		Assert.That(hash, Is.EqualTo("4619e80e71656fa8baac2d22fe32bc12789f4d330c24195661caf9ed3032bc99"));
	}

	[Test, Theory]
	public void TokenGeneratorTest2(bool useExpressionBuilder)
	{
		var json = "{\"OrderId\":\"Мой парк/24892e9f-b1f7-44ec-8610-3bbc504b165f\",\"CustomerKey\":\"test@mail.ru\",\"Amount\":1100,\"Description\":\"Мой парк: бпс2\",\"RedirectDueDate\":\"2024-01-01T00:00:00+05:00\",\"SuccessURL\":\"http://localhost:4200/shop/check-order?integrationId=4106&publicOrderId=decc1b66-f61c-47c5-9058-5537a6ebfd8c\",\"FailURL\":\"http://localhost:4200/shop/check-order?integrationId=4106&publicOrderId=decc1b66-f61c-47c5-9058-5537a6ebfd8c\",\"Language\":\"ru\",\"PayType\":\"T\",\"Receipt\":{\"Email\":\"test@mail.ru\",\"Taxation\":\"usnincomeoutcome\",\"Items\":[{\"Name\":\"Карусель (онлайн)\",\"Quantity\":1,\"Price\":1100,\"Tax\":\"vat20\",\"Amount\":1100,\"PaymentMethod\":\"full_payment\",\"PaymentObject\":\"service\"}]},\"DATA\":{\"Email\":\"test@mail.ru\"},\"Token\":\"1f3515e976fad335dd230467bdc7e1b2a265384be6939a3fbd287f58187ab48b\",\"TerminalKey\":\"1733135659250DEMO\"}";
		var init = Newtonsoft.Json.JsonConvert.DeserializeObject<Init>(json)!;
		//init.RedirectDueDate = new DateTime(2024, 01, 01);

		var hash = TokenGeneratorHelper.GenerateToken(init, "some_test_password", useExpressionBuilder);
		Assert.That(hash, Is.EqualTo("d88de3ddd2499a56f59b00b12a230d36d0ae44e9f2a9c91cc5132ec22eb4db69"));
	}

	public class TestRequest
	{
		public bool BoolValue { get; set; }
		public bool? NullableBoolValue { get; set; }
		public DateTimeOffset DateTimeValue { get; set; }
		public DateTimeOffset? NullableDateTimeValue { get; set; }
		public string? NullStringValue { get; set; }
		public string StringValue { get; set; } = "some_string_по_русски";
	}

	[Test, Theory]
	public void NullbleValuesTest1(bool useExpressionBuilder)
	{
		var tr = new TestRequest()
		{
			BoolValue = true,
			DateTimeValue = new DateTimeOffset(2024, 01, 01, 00, 00, 00, TimeSpan.FromHours(5))
		};

		var hash = TokenGeneratorHelper.GenerateToken(tr, "some_test_password", useExpressionBuilder);
		Assert.That(hash, Is.EqualTo("60486d9144673c22835da5e8b4f7ca4f3bdf0944990fe9c1f2fd253174f90c35"));
	}
	[Test, Theory]
	public void NullbleValuesTest2(bool useExpressionBuilder)
	{
		var tr = new TestRequest()
		{
			BoolValue = true,
			NullableBoolValue = false,
			DateTimeValue = new DateTimeOffset(2024, 01, 01, 00, 00, 00, TimeSpan.FromHours(5)),
			NullableDateTimeValue = new DateTimeOffset(2024, 01, 01, 00, 00, 00, TimeSpan.FromHours(5)),
		};

		var hash = TokenGeneratorHelper.GenerateToken(tr, "some_test_password", useExpressionBuilder);
		Assert.That(hash, Is.EqualTo("f6f4f151ffb44edb354562cd1f85430d2b3561e5e529c192e905aa220493f947"));
	}
}
