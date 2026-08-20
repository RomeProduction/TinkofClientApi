namespace TinkoffPaymentClientApi.Enums;


public static class EStatusResponse
{
	/// <summary>
	/// Создан
	/// </summary>
	public const string New = "NEW";
	/// <summary>
	/// Платежная форма открыта покупателем
	/// </summary>
	public const string FormShowed = "FORM_SHOWED";
	/// <summary>
	/// Просрочен
	/// </summary>
	public const string DeadlineExpired = "DEADLINE_EXPIRED";
	/// <summary>
	/// Отменен
	/// </summary>
	public const string Canceled = "CANCELED";
	/// <summary>
	/// Проверка платежных данных. Промежуточный.
	/// </summary>
	public const string Preauthorizing = "PREAUTHORIZING";
	/// <summary>
	/// Резервируется. Промежуточный.
	/// </summary>
	public const string Authorizing = "AUTHORIZING";
	/// <summary>
	/// Зарезервирован
	/// </summary>
	public const string Authorized = "AUTHORIZED";
	/// <summary>
	/// Не прошел авторизацию. Промежуточный.
	/// </summary>
	public const string AuthFail = "AUTH_FAIL";
	/// <summary>
	/// Отклонен
	/// </summary>
	public const string Rejected = "REJECTED";
	/// <summary>
	/// Проверяется по протоколу 3-D Secure
	/// </summary>
	public const string ThreeDSChecking = "3DS_CHECKING";
	/// <summary>
	/// Проверен по протоколу 3-D Secure. Промежуточный.
	/// </summary>
	public const string ThreeDSChecked = "3DS_CHECKED";
	/// <summary>
	/// Резервирование отменяется. Промежуточный.
	/// </summary>
	public const string Reversing = "REVERSING";
	/// <summary>
	/// Резервирование отменено частично
	/// </summary>
	public const string PartialReversed = "PARTIAL_REVERSED";
	/// <summary>
	/// Резервирование отменено
	/// </summary>
	public const string Reversed = "REVERSED";
	/// <summary>
	/// Подтверждается. Промежуточный.
	/// </summary>
	public const string Confirming = "CONFIRMING";
	/// <summary>
	/// Подтвержден
	/// </summary>
	public const string Confirmed = "CONFIRMED";
	/// <summary>
	/// Возвращается. Промежуточный.
	/// </summary>
	public const string Refunding = "REFUNDING";
	/// <summary>
	/// Возвращен частично
	/// </summary>
	public const string PartialRefunded = "PARTIAL_REFUNDED";
	/// <summary>
	/// Возвращен полностью
	/// </summary>
	public const string Refunded = "REFUNDED";
	/// <summary>
	/// Обработка возврата денежных средств по QR
	/// </summary>
	public const string AsyncRefunding = "ASYNC_REFUNDING";
	/// <summary>
	/// Клиент превысил количество попыток открытия формы
	/// </summary>
	public const string AttemptsExpired = "ATTEMPTS_EXPIRED";
}
