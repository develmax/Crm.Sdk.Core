﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Messages.ExecuteMultipleRequest
// Assembly: Microsoft.Xrm.Sdk, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 917F618E-83AC-4359-819B-E0D742B6B85B
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Xrm.Sdk.dll

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  execute one or more message requests as a single batch operation, and optionally return a collection of results.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class ExecuteMultipleRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the collection of message requests to execute.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.OrganizationRequestCollection"></see>The collection of message requests to execute.</returns>
    public OrganizationRequestCollection Requests
    {
      get
      {
        return this.Parameters.Contains(nameof (Requests)) ? (OrganizationRequestCollection) this.Parameters[nameof (Requests)] : (OrganizationRequestCollection) null;
      }
      set
      {
        this.Parameters[nameof (Requests)] = (object) value;
      }
    }

    /// <summary>Gets or sets the settings that define whether execution should continue if an error occurs and if responses for each message request processed are to be returned.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.ExecuteMultipleSettings"></see>Settings that define whether execution should continue if an error occurs and if responses are to be returned.</returns>
    public ExecuteMultipleSettings Settings
    {
      get
      {
        return this.Parameters.Contains(nameof (Settings)) ? (ExecuteMultipleSettings) this.Parameters[nameof (Settings)] : (ExecuteMultipleSettings) null;
      }
      set
      {
        this.Parameters[nameof (Settings)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Xrm.Sdk.Messages.ExecuteMultipleRequest"></see>.</summary>
    public ExecuteMultipleRequest()
    {
      this.RequestName = "ExecuteMultiple";
      this.Requests = (OrganizationRequestCollection) null;
      this.Settings = (ExecuteMultipleSettings) null;
    }
  }
}
