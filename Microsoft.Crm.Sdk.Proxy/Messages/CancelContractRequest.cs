﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Sdk.Messages.CancelContractRequest
// Assembly: Microsoft.Crm.Sdk.Proxy, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F3ED665D-73A2-4475-A0DE-3A25E42323B8
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Crm.Sdk.Proxy.dll

using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to cancel a contract.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class CancelContractRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the ID of the contract. Required.</summary>
    /// <returns>Type: Returns_GuidThe ID of the contract that corresponds to the Contract.ContractId attribute, which is the primary key for the Contract entity.</returns>
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

    /// <summary>Gets or sets the contract cancellation date. Required.</summary>
    /// <returns>Type: Returns_DateTimeThe contract cancellation date.</returns>
    public DateTime CancelDate
    {
      get
      {
        return this.Parameters.Contains(nameof (CancelDate)) ? (DateTime) this.Parameters[nameof (CancelDate)] : new DateTime();
      }
      set
      {
        this.Parameters[nameof (CancelDate)] = (object) value;
      }
    }

    /// <summary>Gets or sets the status of the contract. Required.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.OptionSetValue"></see>The status of the contract.</returns>
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

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.CancelContractRequest"></see> class.</summary>
    public CancelContractRequest()
    {
      this.RequestName = "CancelContract";
      this.ContractId = new Guid();
      this.CancelDate = new DateTime();
      this.Status = (OptionSetValue) null;
    }
  }
}
