// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Messages.RetrieveDataEncryptionKeyRequest
// Assembly: Microsoft.Xrm.Sdk, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 917F618E-83AC-4359-819B-E0D742B6B85B
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Xrm.Sdk.dll

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to retrieve the data encryption key value.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class RetrieveDataEncryptionKeyRequest : OrganizationRequest
  {
    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.Messages.RetrieveDataEncryptionKeyRequest"></see> class.</summary>
    public RetrieveDataEncryptionKeyRequest()
    {
      this.RequestName = "RetrieveDataEncryptionKey";
    }
  }
}
