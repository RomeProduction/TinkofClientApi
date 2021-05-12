using System.Runtime.Serialization;

namespace TinkoffPaymentClientApi.Enums {
  /// <summary>
  /// Статус карты
  /// </summary>
  public enum ECardStatus {
    /// <summary>
    /// Активная
    /// </summary>
    [EnumMember(Value = "A")]
    Active,
    /// <summary>
    /// Неактивная
    /// </summary>
    [EnumMember(Value = "I")]
    Inactive,
    /// <summary>
    /// Удаленная
    /// </summary>
    [EnumMember(Value = "D")]
    Deleted
  }
}
