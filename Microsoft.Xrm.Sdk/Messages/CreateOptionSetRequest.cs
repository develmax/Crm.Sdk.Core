﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Messages.CreateOptionSetRequest
// Assembly: Microsoft.Xrm.Sdk, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 917F618E-83AC-4359-819B-E0D742B6B85B
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Xrm.Sdk.dll

using Microsoft.Xrm.Sdk.Metadata;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  create a new global option set.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class CreateOptionSetRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the definition of the global option set. Required.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Metadata.OptionSetMetadata"></see>The definition of the global option set. Required.</returns>
    public OptionSetMetadataBase OptionSet
    {
      get
      {
        return this.Parameters.Contains(nameof (OptionSet)) ? (OptionSetMetadataBase) this.Parameters[nameof (OptionSet)] : (OptionSetMetadataBase) null;
      }
      set
      {
        this.Parameters[nameof (OptionSet)] = (object) value;
      }
    }

    /// <summary>Gets or sets the name of the unmanaged solution you want to add this global option set to. Optional.</summary>
    /// <returns>Type: Returns_StringThe name of the unmanaged solution you want to add this global option set to. Optional.</returns>
    public string SolutionUniqueName
    {
      get
      {
        return this.Parameters.Contains(nameof (SolutionUniqueName)) ? (string) this.Parameters[nameof (SolutionUniqueName)] : (string) null;
      }
      set
      {
        this.Parameters[nameof (SolutionUniqueName)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Xrm.Sdk.Messages.CreateOptionSetRequest"></see>  class.</summary>
    public CreateOptionSetRequest()
    {
      this.RequestName = "CreateOptionSet";
      this.OptionSet = (OptionSetMetadataBase) null;
    }
  }
}
