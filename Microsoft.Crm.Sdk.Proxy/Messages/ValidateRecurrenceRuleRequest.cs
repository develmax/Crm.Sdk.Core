// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Sdk.Messages.ValidateRecurrenceRuleRequest
// Assembly: Microsoft.Crm.Sdk.Proxy, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F3ED665D-73A2-4475-A0DE-3A25E42323B8
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Crm.Sdk.Proxy.dll

using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  validate a rule for a recurring appointment.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class ValidateRecurrenceRuleRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the recurrence rule record to validate.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Entity"></see>The recurrence rule record to validate. This is an instance of the RecurrenceRule entity. </returns>
    public Entity Target
    {
      get
      {
        return this.Parameters.Contains(nameof (Target)) ? (Entity) this.Parameters[nameof (Target)] : (Entity) null;
      }
      set
      {
        this.Parameters[nameof (Target)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Crm.Sdk.Messages.ValidateRecurrenceRuleRequest"></see> class.</summary>
    public ValidateRecurrenceRuleRequest()
    {
      this.RequestName = "ValidateRecurrenceRule";
      this.Target = (Entity) null;
    }
  }
}
