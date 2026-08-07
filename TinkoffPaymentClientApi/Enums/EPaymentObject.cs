namespace TinkoffPaymentClientApi.Enums;

/// <summary>
/// Предмет расчета
/// </summary>
public static class EPaymentObject
{
	/// <summary>
	/// Товар
	/// </summary>
	public const string Commodity = "commodity";
	/// <summary>
	/// Подакцизный товар
	/// </summary>
	public const string Excise = "excise";
	/// <summary>
	/// Работа
	/// </summary>
	public const string Job = "job";
	/// <summary>
	/// Услуга
	/// </summary>
	public const string Service = "service";
	/// <summary>
	/// Ставка азартной игры
	/// </summary>
	public const string GamblingBet = "gambling_bet";
	/// <summary>
	/// Выигрыш азартной игры
	/// </summary>
	public const string GamblingPrize = "gambling_prize";
	/// <summary>
	/// Лотерейный билет
	/// </summary>
	public const string Lottery = "lottery";
	/// <summary>
	/// Выигрыш лотереи
	/// </summary>
	public const string LotteryPrize = "lottery_prize";
	/// <summary>
	/// Предоставление результатов интеллектуальной деятельности
	/// </summary>
	public const string IntellectualActivity = "intellectual_activity";
	/// <summary>
	/// Платеж
	/// </summary>
	public const string Payment = "payment";
	/// <summary>
	/// Агентское вознаграждение
	/// </summary>
	public const string AgentCommission = "agent_commission";
	/// <summary>
	/// Составной предмет расчета
	/// </summary>
	public const string Composite = "composite";
	/// <summary>
	/// Иной предмет расчета
	/// </summary>
	public const string Another = "another";
}
