using System;
using System.Collections.Generic;
using System.Text;
using TinkoffPaymentClientApi.Enums;

namespace TinkoffPaymentClientApi.Models {
  /// <summary>
  /// Данные об агенте
  /// </summary>
  public class AgentData {
    /// <summary>
    /// Признак агента
    /// </summary>
    public EAgentSign? AgentSign { get; set; }

    /// <summary>
    /// Наименование операции. Обязателен в случае если <see cref="AgentSign"/> принимает одно из значений:
    /// <list type="bullet">
    /// <item><see cref="EAgentSign.BankPayingAgent"/></item>
    /// <item><see cref="EAgentSign.BankPayingSubagent"/></item>
    /// </list>
    /// </summary>
    public string OperationName { get; set; }

    /// <summary>
    /// Телефоны платежного агента. Обязателен в случае если <see cref="AgentSign"/> принимает одно из значений:
    /// <list type="bullet">
    /// <item><see cref="EAgentSign.BankPayingAgent"/></item>
    /// <item><see cref="EAgentSign.BankPayingSubagent"/></item>
    /// <item><see cref="EAgentSign.PayingAgent"/></item>
    /// <item><see cref="EAgentSign.PayingSubagent"/></item>
    /// </list>
    /// </summary>
    public List<string> Phones { get; set; }

    /// <summary>
    /// Телефоны оператора по приему платежей. Обязателен в случае если <see cref="AgentSign"/> принимает одно из значений:
    /// <list type="bullet">
    /// <item><see cref="EAgentSign.PayingAgent"/></item>
    /// <item><see cref="EAgentSign.PayingSubagent"/></item>
    /// </list>
    /// </summary>
    public List<string> ReceiverPhones { get; set; }

    /// <summary>
    /// Телефоны оператора перевода. Обязателен в случае если <see cref="AgentSign"/> принимает одно из значений:
    /// <list type="bullet">
    /// <item><see cref="EAgentSign.BankPayingAgent"/></item>
    /// <item><see cref="EAgentSign.BankPayingSubagent"/></item>
    /// </list>
    /// </summary>
    public List<string> TransferPhones { get; set; }

    /// <summary>
    /// Наименование оператора перевода. Обязателен в случае если <see cref="AgentSign"/> принимает одно из значений:
    /// <list type="bullet">
    /// <item><see cref="EAgentSign.BankPayingAgent"/></item>
    /// <item><see cref="EAgentSign.BankPayingSubagent"/></item>
    /// </list>
    /// </summary>
    public string OperatorName { get; set; }

    /// <summary>
    /// Адрес оператора перевода. Обязателен в случае если <see cref="AgentSign"/> принимает одно из значений:
    /// <list type="bullet">
    /// <item><see cref="EAgentSign.BankPayingAgent"/></item>
    /// <item><see cref="EAgentSign.BankPayingSubagent"/></item>
    /// </list>
    /// </summary>
    public string OperatorAddress { get; set; }

    /// <summary>
    /// ИНН оператора перевода. Обязателен в случае если <see cref="AgentSign"/> принимает одно из значений:
    /// <list type="bullet">
    /// <item><see cref="EAgentSign.BankPayingAgent"/></item>
    /// <item><see cref="EAgentSign.BankPayingSubagent"/></item>
    /// </list>
    /// </summary>
    public string OperatorInn { get; set; }
  }
}
