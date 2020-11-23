using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TinkoffPaymentClientApi.Commands;
using TinkoffPaymentClientApi.Helpers;
using TinkoffPaymentClientApi.ResponseEntity;

namespace TinkoffPaymentClientApi {
  public sealed class TinkoffPaymentClient: IDisposable {
    private readonly string _termianlKey;
    private readonly string _password;
    private const string _baseUrl = "https://securepay.tinkoff.ru/v2/";

    public TinkoffPaymentClient(string terminalKey, string password) {
      if (string.IsNullOrEmpty(terminalKey)) {
        throw new ArgumentNullException(nameof(terminalKey), "Must be not empty");
      }
      _termianlKey = terminalKey;
      if (string.IsNullOrEmpty(password)) {
        throw new ArgumentNullException(nameof(password), "Must be not empty");
      }
      _password = password;
    }

    public async Task<PaymentResponse> InitAsync(Init init, CancellationToken token) {
      var result = await SendRequestPost<Init, PaymentResponse>(init, token);
      return result;
    }

    public async Task<PaymentResponse> ChargeAsync(Charge charge, CancellationToken token) {
      var result = await SendRequestPost<Charge, PaymentResponse>(charge, token);
      return result;
    }

    public async Task<ConfirmResponse> ConfirmAsync(Confirm confirm, CancellationToken token) {
      var result = await SendRequestPost<Confirm, ConfirmResponse>(confirm, token);
      return result;
    }

    public async Task<CancelResponse> CancelAsync(Cancel cancel, CancellationToken token) {
      var result = await SendRequestPost<Cancel, CancelResponse>(cancel, token);
      return result;
    }

    public async Task<Submit3DSAuthorizationResponse> Submit3DSAuthorizationAsync(Submit3DSAuthorization submit3ds, CancellationToken token) {
      var result = await SendRequestPost<Submit3DSAuthorization, Submit3DSAuthorizationResponse>(submit3ds, token);
      return result;
    }

    public async Task<ResendResponse> ResendAsync(Resend resend, CancellationToken token) {
      var result = await SendRequestPost<Resend, ResendResponse>(resend, token);
      return result;
    }


    private async Task<E> SendRequestPost<T, E>(T parameter, CancellationToken token)
      where T : BaseCommand
      where E : class{
      parameter.TerminalKey = _termianlKey;
      parameter.Token = TokenGeneratorHelper.GenerateToken(parameter, _password);

      var json = JsonConvert.SerializeObject(parameter, new JsonSerializerSettings {
        NullValueHandling = NullValueHandling.Ignore,
      });

      var response = await SendRequestPost(parameter.CommandName, json, token);
      if (string.IsNullOrEmpty(response)) {
        return null;
      }

      return JsonConvert.DeserializeObject<E>(response);
    }
    private async Task<string> SendRequestPost(string methodName, string json, CancellationToken token) {
      var url = _baseUrl + methodName;
      var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
      using (var client = new HttpClient()) {
        var response = await client.PostAsync(url, httpContent, token);
        if (response.IsSuccessStatusCode && response.Content != null) {
          return await response.Content.ReadAsStringAsync();
        }
      }
      return null;
    }

    public void Dispose() {}
  }
}