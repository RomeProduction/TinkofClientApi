using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TinkoffPaymentClientApi.Commands;
using TinkoffPaymentClientApi.Helpers;
using TinkoffPaymentClientApi.ResponseEntity;

namespace TinkoffPaymentClientApi {
  public sealed class TinkoffPaymentClient {
    private static readonly HttpClient DefaultHttpClient = new HttpClient();

    private readonly string _termianlKey;
    private readonly string _password;
    private readonly string _baseUrl;
    private readonly HttpClient _httpClient;

    private const string DefaultBaseUrl = "https://securepay.tinkoff.ru/v2/";

    public TinkoffPaymentClient(string terminalKey, string password): this(DefaultHttpClient, DefaultBaseUrl, terminalKey, password) {
    }

    public TinkoffPaymentClient(HttpClient httpClient, string terminalKey, string password): this(httpClient, DefaultBaseUrl, terminalKey, password) {
    }
    public TinkoffPaymentClient(string baseUrl, string terminalKey, string password): this(DefaultHttpClient, baseUrl, terminalKey, password) {
    }

    public TinkoffPaymentClient(HttpClient httpClient, string baseUrl, string terminalKey, string password) {
      if (string.IsNullOrEmpty(terminalKey)) {
        throw new ArgumentNullException(nameof(terminalKey), "Must be not empty");
      }
      _termianlKey = terminalKey;
      if (string.IsNullOrEmpty(password)) {
        throw new ArgumentNullException(nameof(password), "Must be not empty");
      }
      _password = password;
      if (string.IsNullOrEmpty(baseUrl)) {
        throw new ArgumentNullException(nameof(baseUrl), "Must be not empty");
      }
      _baseUrl = baseUrl.TrimEnd('/') + "/";
      _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
    }

    public Task<PaymentResponse> InitAsync(Init init, CancellationToken token)
      => PostAsync<Init, PaymentResponse>(init, token);
    public PaymentResponse Init(Init init)
      => Post<Init, PaymentResponse>(init);

    public Task<PaymentResponse> ChargeAsync(Charge charge, CancellationToken token)
      => PostAsync<Charge, PaymentResponse>(charge, token);
    public PaymentResponse Charge(Charge charge)
      => Post<Charge, PaymentResponse>(charge);

    public Task<ConfirmResponse> ConfirmAsync(Confirm confirm, CancellationToken token)
      => PostAsync<Confirm, ConfirmResponse>(confirm, token);
    public ConfirmResponse Confirm(Confirm confirm)
      => Post<Confirm, ConfirmResponse>(confirm);

    public Task<CancelResponse> CancelAsync(Cancel cancel, CancellationToken token)
      => PostAsync<Cancel, CancelResponse>(cancel, token);
    public CancelResponse Cancel(Cancel cancel)
      => Post<Cancel, CancelResponse>(cancel);

    public Task<Submit3DSAuthorizationResponse> Submit3DSAuthorizationAsync(Submit3DSAuthorization submit3ds, CancellationToken token)
      => PostAsync<Submit3DSAuthorization, Submit3DSAuthorizationResponse>(submit3ds, token);
    public Submit3DSAuthorizationResponse Submit3DSAuthorization(Submit3DSAuthorization submit3ds)
      => Post<Submit3DSAuthorization, Submit3DSAuthorizationResponse>(submit3ds);

    public Task<ResendResponse> ResendAsync(Resend resend, CancellationToken token)
      => PostAsync<Resend, ResendResponse>(resend, token);
    public ResendResponse Resend(Resend resend)
      => Post<Resend, ResendResponse>(resend);

    private HttpRequestMessage BuildRequest<T>(T parameter)
    where T: BaseCommand {
      parameter.TerminalKey = _termianlKey;
      parameter.Token = TokenGeneratorHelper.GenerateToken(parameter, _password);
      var request = new HttpRequestMessage(HttpMethod.Post, _baseUrl + parameter.CommandName);

      var json = JsonConvert.SerializeObject(parameter, new JsonSerializerSettings {
        NullValueHandling = NullValueHandling.Ignore,
      });
      request.Content = new StringContent(json, Encoding.UTF8, "application/json");

      return request;
    }
    private static string ReadToEnd(Stream stream) {
      if (stream == null) return null;

      using (var reader = new StreamReader(stream)) {
        return reader.ReadToEnd();
      }
    }

    private E ProcessResponse<E>(int statusCode, Stream bodyStream) where E : class {
      var body = ReadToEnd(bodyStream);
      if (statusCode == 200)
        return JsonConvert.DeserializeObject<E>(body);

      throw new HttpRequestException($"Wrong answer reveived from {_baseUrl}, Status: {statusCode}, Body: {body}");
    }

    private async Task<E> PostAsync<T, E>(T parameter, CancellationToken token)
      where T : BaseCommand
      where E : class {

      using (var request = BuildRequest(parameter)) {
        using (var response = await _httpClient.SendAsync(request))
          return ProcessResponse<E>((int)response.StatusCode, await response.Content.ReadAsStreamAsync());
      }
      //return JsonConvert.DeserializeObject<E>(response);
    }

#if NET5_0_OR_GREATER
    private E Post<T, E>(T parameter)
      where T : BaseCommand
      where E : class {

      using (var request = BuildRequest(parameter)) {
        using (var response = _httpClient.Send(request))
          return ProcessResponse<E>((int)response.StatusCode, response.Content.ReadAsStream());
      }
    }
#else

    private HttpWebRequest BuildWebRequest<T>(T parameter)
    where T : BaseCommand {
      parameter.TerminalKey = _termianlKey;
      parameter.Token = TokenGeneratorHelper.GenerateToken(parameter, _password);
      var request = WebRequest.CreateHttp(_baseUrl + parameter.CommandName);
      request.Method = "POST";
      request.ContentType = "application/json";

      var json = JsonConvert.SerializeObject(parameter, new JsonSerializerSettings {
        NullValueHandling = NullValueHandling.Ignore,
      });

      var postBytes = Encoding.UTF8.GetBytes(json);
      request.ContentLength = postBytes.Length;
      using (var stream = request.GetRequestStream()) {
        stream.Write(postBytes, 0, postBytes.Length);
      }

      return request;
    }

    private E Post<T, E>(T parameter)
      where T : BaseCommand
      where E : class {
      using (var response = (HttpWebResponse)BuildWebRequest(parameter).GetResponse()) {
        return ProcessResponse<E>((int)response.StatusCode, response.GetResponseStream());
      }
    }


#endif
  }
}
