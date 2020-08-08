﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Messages.DeleteRelationshipRequest
// Assembly: Microsoft.Xrm.Sdk, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 917F618E-83AC-4359-819B-E0D742B6B85B
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Xrm.Sdk.dll

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  delete an entity relationship. </summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class DeleteRelationshipRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the name of the relationship to delete. Required.</summary>
    /// <returns>Type: Returns_StringThe name of the relationship to delete. Required.</returns>
    public string Name
    {
      get
      {
        return this.Parameters.Contains(nameof (Name)) ? (string) this.Parameters[nameof (Name)] : (string) null;
      }
      set
      {
        this.Parameters[nameof (Name)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Xrm.Sdk.Messages.DeleteRelationshipRequest"></see> class</summary>
    public DeleteRelationshipRequest()
    {
      this.RequestName = "DeleteRelationship";
      this.Name = (string) null;
    }
  }
}