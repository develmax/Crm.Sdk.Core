// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Messages.RetrieveAttributeResponse
// Assembly: Microsoft.Xrm.Sdk, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 917F618E-83AC-4359-819B-E0D742B6B85B
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Xrm.Sdk.dll

using Microsoft.Xrm.Sdk.Metadata;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Xrm.Sdk.Messages.RetrieveAttributeRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class RetrieveAttributeResponse : OrganizationResponse
  {
    /// <summary>Gets the metadata for the requested attribute.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Metadata.AttributeMetadata"></see>The metadata for the requested attribute.</returns>
    public AttributeMetadata AttributeMetadata
    {
      get
      {
        return this.Results.Contains(nameof (AttributeMetadata)) ? (AttributeMetadata) this.Results[nameof (AttributeMetadata)] : (AttributeMetadata) null;
      }
    }
  }
}
