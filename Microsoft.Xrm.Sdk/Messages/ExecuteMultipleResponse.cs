﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Messages.ExecuteMultipleResponse
// Assembly: Microsoft.Xrm.Sdk, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 917F618E-83AC-4359-819B-E0D742B6B85B
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Xrm.Sdk.dll

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Xrm.Sdk.Messages.ExecuteMultipleRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class ExecuteMultipleResponse : OrganizationResponse
  {
    /// <summary>Gets a value that indicates if processing at least one of the individual message requests resulted in a fault.</summary>
    /// <returns>Type: Returns_Booleantrue if at least one of the individual message requests resulted in a fault; otherwise, false. </returns>
    public bool IsFaulted
    {
      get
      {
        return this.Results.Contains(nameof (IsFaulted)) && (bool) this.Results[nameof (IsFaulted)];
      }
    }

    /// <summary>Gets the collection of responses.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.ExecuteMultipleResponseItemCollection"></see>The collection of responses.</returns>
    public ExecuteMultipleResponseItemCollection Responses
    {
      get
      {
        return this.Results.Contains(nameof (Responses)) ? (ExecuteMultipleResponseItemCollection) this.Results[nameof (Responses)] : (ExecuteMultipleResponseItemCollection) null;
      }
    }
  }
}
