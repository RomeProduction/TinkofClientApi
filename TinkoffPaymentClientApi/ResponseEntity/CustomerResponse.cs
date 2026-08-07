namespace TinkoffPaymentClientApi.ResponseEntity;

public class CustomerResponse : TinkoffResponse
{
	/// <summary>
	/// Идентификатор покупателя в системе продавца
	/// </summary>
	public string CustomerKey { get; set; } = string.Empty;
}
