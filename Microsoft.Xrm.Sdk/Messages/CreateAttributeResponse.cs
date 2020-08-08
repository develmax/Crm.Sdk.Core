// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Messages.CreateAttributeResponse
// Assembly: Microsoft.Xrm.Sdk, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 917F618E-83AC-4359-819B-E0D742B6B85B
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Xrm.Sdk.dll

using System;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Xrm.Sdk.Messages.CreateAttributeRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class CreateAttributeResponse : OrganizationResponse
  {
    /// <summary>Gets the <see cref="P:Microsoft.Xrm.Sdk.Metadata.MetadataBase.MetadataId"></see> of the attribute that is created.</summary>
    /// <returns>Type: Returns_Guid
    /// The <see cref="P:Microsoft.Xrm.Sdk.Metadata.MetadataBase.MetadataId"></see> of the attribute that is created. This is the unique identifier of the attribute.</returns>
    public Guid AttributeId
    {
      get
      {
        return this.Results.Contains(nameof (AttributeId)) ? (Guid) this.Results[nameof (AttributeId)] : new Guid();
      }
    }
  }
}
