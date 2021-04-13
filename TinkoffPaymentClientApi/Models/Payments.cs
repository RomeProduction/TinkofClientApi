using System;

namespace TinkoffPaymentClientApi.Models {
  /// <summary>
  /// Данные об оплате чека
  /// </summary>
  public class Payments {
    /// <summary>
    /// Вид оплаты "Наличные". Сумма к оплате в копейках не более 14 знаков.
    /// </summary>
    public UInt64? Cash { get; set; }
    /// <summary>
    /// Вид оплаты "Безналичный". Сумма к оплате в копейках не более 14 знаков.
    /// </summary>
    public UInt64 Electronic { get; set; }
    /// <summary>
    /// Вид оплаты "Предварительная оплата (Аванс)". Сумма к оплате в копейках не более 14 знаков.
    /// </summary>
    public UInt64? AdvancePayment { get; set; }
    /// <summary>
    /// Вид оплаты "Постоплата (Кредит)". Сумма к оплате в копейках не более 14 знаков.
    /// </summary>
    public UInt64? Credit { get; set; }
    /// <summary>
    /// Вид оплаты "Иная форма оплаты". Сумма к оплате в копейках не более 14 знаков.
    /// </summary>
    public UInt64? Provision { get; set; }

  }
}
