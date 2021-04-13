using System;
using System.Collections.Generic;
using System.Threading;
using TinkoffPaymentClientApi;
using TinkoffPaymentClientApi.Commands;
using TinkoffPaymentClientApi.Models;
using TinkoffPaymentClientApi.ResponseEntity;

namespace TinkofClientApi {
  class Program {
    static void Main(string[] args) {
      using (var clientApi = new TinkoffPaymentClient("DEMO", "TEST_Password")) {
        CancellationToken cancellationToken = CancellationToken.None;
        //должна быть в копейках
        decimal amount = 10 * 100;
        var result = clientApi.InitAsync(new Init(Guid.NewGuid() + "", amount) {
          Receipt = new Receipt("test@mail.ru", TinkoffPaymentClientApi.Enums.ETaxation.Osn) {
            ReceiptItems = new List<ReceiptItem> {
              new ReceiptItem("test", 1, 10 * 100, TinkoffPaymentClientApi.Enums.ETax.Vat20),
            },
          },
          Data = new Dictionary<string, string> {
            { "Email", "test@mail.ru" }
          }
        }
        , cancellationToken).Result;
        Console.WriteLine("Init result: " + result.Success);

        var response = new TinkoffNotification {
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
        response = new TinkoffNotification {
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
        Console.ReadKey();
      }
    }
  }
}
