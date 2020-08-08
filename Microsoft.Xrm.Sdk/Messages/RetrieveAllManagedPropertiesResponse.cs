// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Messages.RetrieveAllManagedPropertiesResponse
// Assembly: Microsoft.Xrm.Sdk, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 917F618E-83AC-4359-819B-E0D742B6B85B
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Xrm.Sdk.dll

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Xrm.Sdk.Messages.RetrieveAllManagedPropertiesRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class RetrieveAllManagedPropertiesResponse : OrganizationResponse
  {
    /// <summary>Gets an array of managed property definitions.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Metadata.ManagedPropertyMetadata"></see>[]An array of managed property definitions.</returns>
    public Microsoft.Xrm.Sdk.Metadata.ManagedPropertyMetadata[] ManagedPropertyMetadata
    {
      get
      {
        return this.Results.Contains(nameof (ManagedPropertyMetadata)) ? (Microsoft.Xrm.Sdk.Metadata.ManagedPropertyMetadata[]) this.Results[nameof (ManagedPropertyMetadata)] : (Microsoft.Xrm.Sdk.Metadata.ManagedPropertyMetadata[]) null;
      }
    }
  }
}
