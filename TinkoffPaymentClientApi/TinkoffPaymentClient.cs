using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using TinkoffPaymentClientApi.Commands;
using TinkoffPaymentClientApi.Enums;
using TinkoffPaymentClientApi.Helpers;
using TinkoffPaymentClientApi.Models;
using TinkoffPaymentClientApi.ResponseEntity;

namespace TinkoffPaymentClientApi {
  /// <summary>
  /// Клиент к API онлайн эквайринга Tinkoff
  /// https://oplata.tinkoff.ru/develop/api/payments/
  /// </summary>
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
        throw new ArgumentNullException(nameof(terminalKey), Properties.Resources.TinkoffPaymentClient_ShouldNotBeEmpty);
      }
      _termianlKey = terminalKey;
      if (string.IsNullOrEmpty(password)) {
        throw new ArgumentNullException(nameof(password), Properties.Resources.TinkoffPaymentClient_ShouldNotBeEmpty);
      }
      _password = password;
      if (string.IsNullOrEmpty(baseUrl)) {
        throw new ArgumentNullException(nameof(baseUrl), Properties.Resources.TinkoffPaymentClient_ShouldNotBeEmpty);
      }
      _baseUrl = baseUrl.TrimEnd('/') + "/";
      _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
    }

    /// <summary>
    /// Метод создает платеж: продавец получает ссылку на платежную форму и должен перенаправить по ней покупателя.
    /// </summary>
    /// <param name="init"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    public Task<PaymentResponse> InitAsync(Init init, CancellationToken token)
      => PostAsync<Init, PaymentResponse>(init, token);
    /// <inheritdoc cref="InitAsync(Commands.Init, CancellationToken)"/>
    public PaymentResponse Init(Init init)
      => Post<Init, PaymentResponse>(init);

    /// <summary>
    /// Метод осуществляет автоплатеж.
    /// <para>
    /// Всегда работает по типу одностадийной оплаты: во время выполнения метода на Notification URL будет отправлен синхронный запрос, на который требуется корректный ответ.
    /// </para>
    /// </summary>
    /// <param name="charge"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    public Task<PaymentResponse> ChargeAsync(Charge charge, CancellationToken token)
      => PostAsync<Charge, PaymentResponse>(charge, token);
    /// <inheritdoc cref="ChargeAsync(Commands.Charge, CancellationToken)"/>
    public PaymentResponse Charge(Charge charge)
      => Post<Charge, PaymentResponse>(charge);

    /// <summary>
    /// Подтверждает платеж и списывает ранее заблокированные средства.
    /// <para>
    /// Используется при двухстадийной оплате. При одностадийной оплате вызывается автоматически. Применим к платежу только в статусе AUTHORIZED и только один раз.
    /// </para>
    /// <para>
    /// Сумма подтверждения не может быть больше заблокированной. Если сумма подтверждения меньше заблокированной, будет выполнено частичное подтверждение.
    /// </para>
    /// </summary>
    /// <param name="confirm"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    public Task<ConfirmResponse> ConfirmAsync(Confirm confirm, CancellationToken token)
      => PostAsync<Confirm, ConfirmResponse>(confirm, token);
    /// <inheritdoc cref="ConfirmAsync(Commands.Confirm, CancellationToken)"/>
    public ConfirmResponse Confirm(Confirm confirm)
      => Post<Confirm, ConfirmResponse>(confirm);

    /// <summary>
    /// Отменяет платеж
    /// </summary>
    /// <param name="cancel"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    public Task<CancelResponse> CancelAsync(Cancel cancel, CancellationToken token)
      => PostAsync<Cancel, CancelResponse>(cancel, token);
    /// <inheritdoc cref="CancelAsync(Commands.Cancel, CancellationToken)"/>
    public CancelResponse Cancel(Cancel cancel)
      => Post<Cancel, CancelResponse>(cancel);

    /// <summary>
    /// Осуществляет проверку результатов прохождения 3-D Secure и при успешном результате прохождения 3-D Secure подтверждает инициированный платеж.
    /// <para>
    /// При использовании одностадийной оплаты осуществляет списание денежных средств с карты покупателя. При двухстадийной оплате осуществляет блокировку указанной суммы на карте покупателя.
    /// </para>
    /// </summary>
    /// <param name="submit3ds"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    public Task<Submit3DSAuthorizationResponse> Submit3DSAuthorizationAsync(Submit3DSAuthorization submit3ds, CancellationToken token)
      => PostAsync<Submit3DSAuthorization, Submit3DSAuthorizationResponse>(submit3ds, false, token);
    /// <inheritdoc cref="Submit3DSAuthorizationAsync(Commands.Submit3DSAuthorization, CancellationToken)"/>
    public Submit3DSAuthorizationResponse Submit3DSAuthorization(Submit3DSAuthorization submit3ds)
      => Post<Submit3DSAuthorization, Submit3DSAuthorizationResponse>(submit3ds, false);

    /// <summary>
    /// Отправляет все неотправленные уведомления
    /// </summary>
    /// <param name="resend"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    public Task<ResendResponse> ResendAsync(Resend? resend = null, CancellationToken? token = null)
      => PostAsync<Resend, ResendResponse>(resend ?? new Resend(), token ?? CancellationToken.None);
    /// <inheritdoc cref="ResendAsync(Commands.Resend?, CancellationToken?)"/>
    public ResendResponse Resend(Resend? resend = null)
      => Post<Resend, ResendResponse>(resend ?? new Resend());

    /// <summary>
    /// Возвращает текущий статус платежа
    /// </summary>
    /// <param name="getState"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    public Task<GetStateResponse> GetStateAsync(GetState getState, CancellationToken token)
      => PostAsync<GetState, GetStateResponse>(getState, token);
    /// <inheritdoc cref="GetStateAsync(Commands.GetState, CancellationToken)"/>
    public GetStateResponse GetState(GetState getState)
      => Post<GetState, GetStateResponse>(getState);

    /// <summary>
    /// Метод подтверждает платеж передачей реквизитов, а также списывает средства с карты покупателя при одностадийной оплате и блокирует указанную сумму при двухстадийной.
    /// <para>
    /// Используется, если у площадки есть сертификация PCI DSS и собственная платежная форма.
    /// </para>
    /// </summary>
    /// <param name="finish"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    public Task<FinishAuthorizeResponse> FinishAuthorizeAsync(FinishAuthorize finish, CancellationToken token)
      => PostAsync<FinishAuthorize, FinishAuthorizeResponse>(finish, token);
    /// <inheritdoc cref="FinishAuthorizeAsync(FinishAuthorize, CancellationToken)"/>
    public FinishAuthorizeResponse FinishAuthorize(FinishAuthorize finish)
      => Post<FinishAuthorize, FinishAuthorizeResponse>(finish);

    /// <summary>
    /// Метод позволяет отправить закрывающий чек в кассу.
    /// Условия метода:
    /// <list type="number">
    /// <item>Закрывающий чек может быть отправлен если платежная сессия по первому чеку находится в статусе <see cref="EStatusResponse.Confirmed"/>.</item>
    /// <item>В платежной сессии был передан объект <see cref="Receipt"/>.</item>
    /// <item>В объекте <see cref="Receipt"/> был передан хотя бы один объект <see cref="ReceiptItem.PaymentMethod"/> <see cref="EPaymentMethod.FullPrepayment"/> или <see cref="EPaymentMethod.Prepayment"/> или <see cref="EPaymentMethod.Advance"/></item>
    /// </list>
    /// </summary>
    /// <param name="sendClosingReceipt"></param>
    /// <param name="token"></param>
    /// <returns></returns>
    public Task<SendClosingReceiptResponse> SendClosingReceiptAsync(SendClosingReceipt sendClosingReceipt, CancellationToken token)
      => PostAsync<SendClosingReceipt, SendClosingReceiptResponse>(sendClosingReceipt, token);
    /// <inheritdoc cref="SendClosingReceiptAsync(SendClosingReceipt, CancellationToken)"/>
    public SendClosingReceiptResponse SendClosingReceipt(SendClosingReceipt sendClosingReceipt)
      => Post<SendClosingReceipt, SendClosingReceiptResponse>(sendClosingReceipt);

    /// <summary>
    /// Метод регистрирует покупателя и его данные в системе продавца.
    /// </summary>
    /// <param name="addCustomer"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task<CustomerResponse> AddCustomerAsync(AddCustomer addCustomer, CancellationToken cancellationToken)
      => PostAsync<AddCustomer, CustomerResponse>(addCustomer, cancellationToken);
    /// <inheritdoc cref="AddCustomerAsync(Commands.AddCustomer,CancellationToken)"/>
    public CustomerResponse AddCustomer(AddCustomer addCustomer)
      => Post<AddCustomer, CustomerResponse>(addCustomer);

    /// <summary>
    /// Метод возвращает список сохраненных карт зарегистрированного покупателя
    /// </summary>
    /// <param name="getCardList"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task<IEnumerable<CardListResponse>> GetCardListAsync(GetCardList getCardList, CancellationToken cancellationToken)
      => PostAsync<GetCardList, IEnumerable<CardListResponse>>(getCardList, cancellationToken);
    /// <inheritdoc cref="GetCardListAsync(Commands.GetCardList, CancellationToken)"/>
    public IEnumerable<CardListResponse> GetCardList(GetCardList getCardList)
      => Post<GetCardList, IEnumerable<CardListResponse>>(getCardList);

    /// <summary>
    /// Метод удаляет привязанную карту покупателя
    /// </summary>
    /// <param name="removeCard"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task<RemoveCardResponse> RemoveCardAsync(RemoveCard removeCard, CancellationToken cancellationToken)
      => PostAsync<RemoveCard, RemoveCardResponse>(removeCard, cancellationToken);
    /// <inheritdoc cref="RemoveCardAsync(Commands.RemoveCard, CancellationToken)"/>
    public RemoveCardResponse RemoveCard(RemoveCard removeCard)
      => Post<RemoveCard, RemoveCardResponse>(removeCard);

    /// <summary>
    /// Метод регистрирует покупателя и его данные в системе продавца.
    /// </summary>
    /// <returns></returns>
    public Task<GetCustomerResponse> GetCustomerAsync(GetCustomer getCustomer, CancellationToken cancellationToken)
      => PostAsync<GetCustomer, GetCustomerResponse>(getCustomer, cancellationToken);
    /// <inheritdoc cref="GetCustomerAsync(Commands.GetCustomer,CancellationToken)"/>
    public GetCustomerResponse GetCustomer(GetCustomer getCustomer)
      => Post<GetCustomer, GetCustomerResponse>(getCustomer);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="removeCustomer"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task<CustomerResponse> RemoveCustomerAsync(RemoveCustomer removeCustomer, CancellationToken cancellationToken)
      => PostAsync<RemoveCustomer, CustomerResponse>(removeCustomer, cancellationToken);
    /// <inheritdoc cref="RemoveCustomerAsync(Commands.RemoveCustomer, CancellationToken)"/>
    public CustomerResponse RemoveCustomer(RemoveCustomer removeCustomer)
      => Post<RemoveCustomer, CustomerResponse>(removeCustomer);

    /// <summary>
    /// Метод возвращает статус заказа.
    /// https://www.tinkoff.ru/kassa/develop/api/payments/checkorder-description/
    /// </summary>
    /// <param name="checkOrder"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task<CheckOrderResponse> CheckOrderAsync(CheckOrder checkOrder, CancellationToken cancellationToken)
      => PostAsync<CheckOrder, CheckOrderResponse>(checkOrder, cancellationToken);

    /// <inheritdoc cref="CheckOrderAsync(Commands.CheckOrder, CancellationToken)"/>
    public CheckOrderResponse CheckOrder(CheckOrder checkOrder)
      => Post<CheckOrder, CheckOrderResponse>(checkOrder);

    private HttpRequestMessage BuildRequest<T>(T parameter, bool json, out string requestBody)
    where T: BaseCommand {
      parameter.TerminalKey = _termianlKey;
      parameter.Token = TokenGeneratorHelper.GenerateToken(parameter, _password);
      var request = new HttpRequestMessage(HttpMethod.Post, _baseUrl + parameter.CommandName);

      var data = JsonConvert.SerializeObject(parameter, new JsonSerializerSettings {
        NullValueHandling = NullValueHandling.Ignore,
      });
      requestBody = data;
      request.Content = json
        ? (HttpContent)new StringContent(data, Encoding.UTF8, "application/json")
        : (HttpContent)new FormUrlEncodedContent(JsonConvert.DeserializeObject<Dictionary<string, string>>(data)!);

      return request;
    }
    private static string ReadToEnd(Stream stream) {
      using (var reader = new StreamReader(stream)) {
        return reader.ReadToEnd();
      }
    }

    private E ProcessResponse<T, E>(int statusCode, string request, Stream bodyStream) where E : class {
      var body = ReadToEnd(bodyStream);
      try {
        if (statusCode == 200)
          return JsonConvert.DeserializeObject<E>(body)!;
      } catch(Exception ex) {
        throw new TinkoffPaymentClientException (string.Format(Properties.Resources.ProcessResponse_ErrorOccuredWhileProcessing0For12Body3,
            typeof(E).Name,
            typeof(T).Name,
            ex.Message,
            body),
          _baseUrl,
          statusCode,
          request,
          body,
          ex);
      }


      throw new TinkoffPaymentClientException(string.Format(Properties.Resources.ProcessResponse_WrongAnswerReveivedFrom0For1Status2Body3,
          _baseUrl, 
          typeof(T).Name,
          statusCode,
          body),
        _baseUrl,
        statusCode,
        request,
        body
        );
    }
    private Task<E> PostAsync<T, E>(T parameter, CancellationToken token)
      where T : BaseCommand
      where E : class
      => PostAsync<T, E>(parameter, true, token);

    private async Task<E> PostAsync<T, E>(T parameter, bool json, CancellationToken token)
      where T : BaseCommand
      where E : class {

      using (var request = BuildRequest(parameter, json, out var requestBody)) {
        using (var response = await _httpClient.SendAsync(request, token))
          return ProcessResponse<T, E>((int)response.StatusCode, requestBody, await response.Content.ReadAsStreamAsync());
      }
      //return JsonConvert.DeserializeObject<E>(response);
    }

#if NET5_0_OR_GREATER
    private E Post<T, E>(T parameter, bool json = true)
      where T : BaseCommand
      where E : class {

      using (var request = BuildRequest(parameter, json, out var requestBody)) {
        using (var response = _httpClient.Send(request))
          return ProcessResponse<T, E>((int)response.StatusCode, requestBody, response.Content.ReadAsStream());
      }
    }
#else

    private HttpWebRequest BuildWebRequest<T>(T parameter, bool json, out string requestBody)
    where T : BaseCommand {
      parameter.TerminalKey = _termianlKey;
      parameter.Token = TokenGeneratorHelper.GenerateToken(parameter, _password);
      var request = WebRequest.CreateHttp(_baseUrl + parameter.CommandName);
      request.Method = "POST";
      request.ContentType = json ? "application/json" : "x-www-form-urlencoded";

      var data = JsonConvert.SerializeObject(parameter, new JsonSerializerSettings {
        NullValueHandling = NullValueHandling.Ignore,
      });

      if (!json)
        data = UrlEncode(data);
      requestBody = data;

      var postBytes = Encoding.UTF8.GetBytes(data);
      request.ContentLength = postBytes.Length;
      using (var stream = request.GetRequestStream()) {
        stream.Write(postBytes, 0, postBytes.Length);
      }

      return request;
    }

    private string UrlEncode(string data) {
      var dic = JsonConvert.DeserializeObject<Dictionary<string, string>>(data)!;
      var sb = new StringBuilder();
      foreach (var kv in dic)
        sb.AppendFormat("{0}={1}&", kv.Key, WebUtility.UrlEncode(kv.Value));

      return sb.ToString();
    }

    private E Post<T, E>(T parameter, bool json = true)
      where T : BaseCommand
      where E : class {
      using (var response = (HttpWebResponse)BuildWebRequest(parameter, json, out var requestBody).GetResponse()) {
        return ProcessResponse<T, E>((int)response.StatusCode, requestBody, response.GetResponseStream());
      }
    }


#endif
  }
}
