using System;

namespace TinkoffPaymentClientApi.Attributes {
  [AttributeUsage(AttributeTargets.Property)]
  internal class IgnoreTokenCalculateAttribute : Attribute {
    public IgnoreTokenCalculateAttribute(){}
  }
}