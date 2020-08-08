﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Messages.DeleteAttributeRequest
// Assembly: Microsoft.Xrm.Sdk, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 917F618E-83AC-4359-819B-E0D742B6B85B
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Xrm.Sdk.dll

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  delete an attribute.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class DeleteAttributeRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the logical name of the attribute to delete. Required.</summary>
    /// <returns>Type: Returns_StringThe logical name of the attribute to delete. Required.</returns>
    public string LogicalName
    {
      get
      {
        return this.Parameters.Contains(nameof (LogicalName)) ? (string) this.Parameters[nameof (LogicalName)] : (string) null;
      }
      set
      {
        this.Parameters[nameof (LogicalName)] = (object) value;
      }
    }

    /// <summary>Gets or sets the logical name of the entity that contains the attribute. Required.</summary>
    /// <returns>Type: Returns_StringThe logical name of the entity that contains the attribute. Required.</returns>
    public string EntityLogicalName
    {
      get
      {
        return this.Parameters.Contains(nameof (EntityLogicalName)) ? (string) this.Parameters[nameof (EntityLogicalName)] : (string) null;
      }
      set
      {
        this.Parameters[nameof (EntityLogicalName)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Xrm.Sdk.Messages.DeleteAttributeRequest"></see> class</summary>
    public DeleteAttributeRequest()
    {
      this.RequestName = "DeleteAttribute";
      this.LogicalName = (string) null;
      this.EntityLogicalName = (string) null;
    }
  }
}
