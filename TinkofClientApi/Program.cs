using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using TinkoffPaymentClientApi;
using TinkoffPaymentClientApi.Commands;
using TinkoffPaymentClientApi.Models;
using TinkoffPaymentClientApi.ResponseEntity;

namespace TinkofClientApi;

class Program
{
	static async Task Main(string[] args)
	{
		var rnd = new Random();
		var terminalKey = args.FirstOrDefault() ?? "DEMO";
		var password = args.Skip(1).FirstOrDefault() ?? "TEST_Password";
		var clientApi = new TinkoffPaymentClient(terminalKey, password);
		CancellationToken cancellationToken = CancellationToken.None;
		//должна быть в копейках
		var amount = 10u * 100;
		var result = await clientApi.InitAsync(new Init(Guid.NewGuid() + "", amount)
		{
			RedirectDueDate = DateTime.Now.AddDays(1),
			Receipt = new Receipt(string.Empty, "test@mail.ru", TinkoffPaymentClientApi.Enums.ETaxation.Osn,
			new List<ReceiptItem> {
		  new ReceiptItem("test", 1, 10 * 100, TinkoffPaymentClientApi.Enums.ETax.Vat20),
			}),
		}.SetEmail("test@mail.ru"),
		  cancellationToken);

		Console.WriteLine("Init result: " + result.Success);

		var response = new TinkoffNotification
		{
			Amount = 9855,
			CardId = "322264",
			ErrorCode = "0",
			ExpDate = "1122",
			OrderId = "201709",
			Pan = "430000******0777",
			PaymentId = "8742591",
			RebillId = "101709",
			Status = "AUTHORIZED",
			Success = true,
			TerminalKey = "1321054611234DEMO",
			Token = "b906d28e76c6428e37b25fcf86c0adc52c63d503013fdd632e300593d165766b",
		};
		var isCorrect = response.CheckToken("Dfsfh56dgKl");
		Console.WriteLine("First check notification: " + isCorrect);
		response = new TinkoffNotification
		{
			Amount = 9855,
			CardId = "322264",
			ErrorCode = "0",
			ExpDate = "1122",
			OrderId = "201709",
			Pan = "430000******0777",
			PaymentId = "8742591",
			RebillId = "101709",
			Status = "AUTHORIZED",
			Success = false,
			TerminalKey = "1321054611234DEMO",
			Token = "014e237c74b5746cfff5b98459740afcd75e8d624156210857287397c4c8258e",
		};
		isCorrect = response.CheckToken("Dfsfh56dgKl");
		Console.WriteLine("Second check notification: " + isCorrect);

		Console.WriteLine("Check Qr responses");
		CheckQr(rnd.Next(100000));
		Console.ReadKey();
	}

	public static void CheckQr(int orderId)
	{
		var payment = new Init($"{orderId}", 100);
		var httpClient = new HttpClient();
		var client = new TinkoffPaymentClient(httpClient, "Demo", "password");
		var paymentResponse = client.Init(payment);
		//На тесте нельзя получить Qr-код и изменить статус платежа
		try
		{
			var qrResponse = client.GetQr(new GetQr(paymentResponse.PaymentId));
			Console.WriteLine(qrResponse.Data);
		}
		catch (TinkoffPaymentClientException ex)
		{
			Console.WriteLine(ex.Message);
		}
		try
		{
			var sbpPayTest = client.SbpPayTest(new SbpPayTest(paymentResponse.PaymentId));
			Console.WriteLine(sbpPayTest.Details);
		}
		catch (TinkoffPaymentClientException ex)
		{
			Console.WriteLine(ex.Message);
		}
	}
}
