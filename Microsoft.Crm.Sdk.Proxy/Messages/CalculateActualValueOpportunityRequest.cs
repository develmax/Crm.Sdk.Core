// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Sdk.Messages.CalculateActualValueOpportunityRequest
// Assembly: Microsoft.Crm.Sdk.Proxy, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F3ED665D-73A2-4475-A0DE-3A25E42323B8
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Crm.Sdk.Proxy.dll

using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to calculate the value of an opportunity that is in the "Won" state.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class CalculateActualValueOpportunityRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the ID of the opportunity. Required.</summary>
    /// <returns>Type: Returns_GuidThe ID of the opportunity that corresponds to the Opportunity.OpportunityId attribute, which is the primary key for the Opportunity entity.</returns>
    public Guid OpportunityId
    {
      get
      {
        return this.Parameters.Contains(nameof (OpportunityId)) ? (Guid) this.Parameters[nameof (OpportunityId)] : new Guid();
      }
      set
      {
        this.Parameters[nameof (OpportunityId)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.CalculateActualValueOpportunityRequest"></see> class.</summary>
    public CalculateActualValueOpportunityRequest()
    {
      this.RequestName = "CalculateActualValueOpportunity";
      this.OpportunityId = new Guid();
    }
  }
}
