// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Sdk.Messages.LoseOpportunityRequest
// Assembly: Microsoft.Crm.Sdk.Proxy, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F3ED665D-73A2-4475-A0DE-3A25E42323B8
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Crm.Sdk.Proxy.dll

using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to set the state of an opportunity to Lost.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class LoseOpportunityRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the opportunity close activity. Required.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Entity"></see>The opportunity close activity. This is an instance of the OpportunityClose class.</returns>
    public Entity OpportunityClose
    {
      get
      {
        return this.Parameters.Contains(nameof (OpportunityClose)) ? (Entity) this.Parameters[nameof (OpportunityClose)] : (Entity) null;
      }
      set
      {
        this.Parameters[nameof (OpportunityClose)] = (object) value;
      }
    }

    /// <summary>Gets or sets a status of the opportunity. Required.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.OptionSetValue"></see>The a status of the opportunity.</returns>
    public OptionSetValue Status
    {
      get
      {
        return this.Parameters.Contains(nameof (Status)) ? (OptionSetValue) this.Parameters[nameof (Status)] : (OptionSetValue) null;
      }
      set
      {
        this.Parameters[nameof (Status)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.LoseOpportunityRequest"></see> class.</summary>
    public LoseOpportunityRequest()
    {
      this.RequestName = "LoseOpportunity";
      this.OpportunityClose = (Entity) null;
      this.Status = (OptionSetValue) null;
    }
  }
}
