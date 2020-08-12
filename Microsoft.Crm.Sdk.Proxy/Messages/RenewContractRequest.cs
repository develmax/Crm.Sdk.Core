// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Sdk.Messages.RenewContractRequest
// Assembly: Microsoft.Crm.Sdk.Proxy, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F3ED665D-73A2-4475-A0DE-3A25E42323B8
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Crm.Sdk.Proxy.dll

using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to renew a contract and create the contract details for a new contract.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RenewContractRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the ID of the contract to be renewed. Required.</summary>
    /// <returns>Type: Returns_GuidThe ID of the contract to be renewed. This corresponds to the Contract.ContractId attribute, which is the primary key for the Contract entity.</returns>
    public Guid ContractId
    {
      get
      {
        return this.Parameters.Contains(nameof (ContractId)) ? (Guid) this.Parameters[nameof (ContractId)] : new Guid();
      }
      set
      {
        this.Parameters[nameof (ContractId)] = (object) value;
      }
    }

    /// <summary>Gets or sets the status of the contract.</summary>
    /// <returns>Type: Returns_Int32The status of the contract.</returns>
    public int Status
    {
      get
      {
        return this.Parameters.Contains(nameof (Status)) ? (int) this.Parameters[nameof (Status)] : 0;
      }
      set
      {
        this.Parameters[nameof (Status)] = (object) value;
      }
    }

    /// <summary>Gets or sets a value that indicates whether the canceled line items of the original contract should be included in the renewed contract. Required.</summary>
    /// <returns>Type: Returns_BooleanIndicates whether the canceled line items of the original contract should be included in the renewed contract. true to include canceled line items; otherwise, false. The default is false.</returns>
    public bool IncludeCanceledLines
    {
      get
      {
        return this.Parameters.Contains(nameof (IncludeCanceledLines)) && (bool) this.Parameters[nameof (IncludeCanceledLines)];
      }
      set
      {
        this.Parameters[nameof (IncludeCanceledLines)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.RenewContractRequest"></see> class.</summary>
    public RenewContractRequest()
    {
      this.RequestName = "RenewContract";
      this.ContractId = new Guid();
      this.Status = 0;
      this.IncludeCanceledLines = false;
    }
  }
}
