namespace TinkoffPaymentClientApi.Enums {
  /// <summary>
  /// Тип сохраненной карты
  /// </summary>
  public enum ECardType {
    /// <summary>
    /// списания
    /// </summary>
    Debiting = 0,
    /// <summary>
    /// пополнения
    /// </summary>
    Refill = 1,
    /// <summary>
    /// списания и пополнения
    /// </summary>
    RefillAndDebiting = 2,
  }
}
