using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace TinkoffPaymentClientApi {


  /// <summary>
  /// Исключение при обработке запроса к платежному шлюзу
  /// </summary>
  [Serializable]
  public class TinkoffPaymentClientException : Exception {
    public TinkoffPaymentClientException(string message,
      string baseUrl,
      int statusCode,
      string request,
      string response) : base(message) { 
      BaseUrl = baseUrl;
      StatusCode = statusCode;
      Request = request;
      Response = response;
    }
    public TinkoffPaymentClientException(string message,
      string baseUrl,
      int statusCode,
      string request,
      string response,
      Exception inner) : base(message, inner) { 
      BaseUrl = baseUrl;
      StatusCode = statusCode;
      Request = request;
      Response = response;
    }

    protected TinkoffPaymentClientException(
      SerializationInfo info,
      StreamingContext context) : base(info, context) {
      BaseUrl = info.GetString(nameof(BaseUrl))!;
      StatusCode = info.GetInt32(nameof(StatusCode))!;
      Request = info.GetString(nameof(Request))!;
      Response = info.GetString(nameof(Response))!;
    }

    public override void GetObjectData(SerializationInfo info, StreamingContext context) {
      base.GetObjectData(info, context);
      info.AddValue(nameof(BaseUrl),BaseUrl);
      info.AddValue(nameof(StatusCode),StatusCode);
      info.AddValue(nameof(Request),Request);
      info.AddValue(nameof(Response),Response);
    }

    /// <summary>
    /// Базовый адрес платежного шлюза
    /// </summary>
    public string BaseUrl { get; }
    /// <summary>
    /// Код ответа от сервера
    /// </summary>
    public int StatusCode { get; }
    /// <summary>
    /// Тело запроса
    /// </summary>
    public string Request { get; }
    /// <summary>
    /// Тело ответа
    /// </summary>
    public string Response { get; }
  }
}
