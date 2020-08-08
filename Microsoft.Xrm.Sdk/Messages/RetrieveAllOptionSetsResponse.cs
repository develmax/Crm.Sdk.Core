// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Messages.RetrieveAllOptionSetsResponse
// Assembly: Microsoft.Xrm.Sdk, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 917F618E-83AC-4359-819B-E0D742B6B85B
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Xrm.Sdk.dll

using Microsoft.Xrm.Sdk.Metadata;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Xrm.Sdk.Messages.RetrieveAllOptionSetsRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class RetrieveAllOptionSetsResponse : OrganizationResponse
  {
    /// <summary>Gets an array of definitions for each global option set.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Metadata.OptionSetMetadataBase"></see>[]An array of definitions for each global option set.</returns>
    public OptionSetMetadataBase[] OptionSetMetadata
    {
      get
      {
        return this.Results.Contains(nameof (OptionSetMetadata)) ? (OptionSetMetadataBase[]) this.Results[nameof (OptionSetMetadata)] : (OptionSetMetadataBase[]) null;
      }
    }
  }
}
