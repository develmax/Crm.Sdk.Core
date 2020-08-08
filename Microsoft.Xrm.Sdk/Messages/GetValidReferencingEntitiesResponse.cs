// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Messages.GetValidReferencingEntitiesResponse
// Assembly: Microsoft.Xrm.Sdk, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 917F618E-83AC-4359-819B-E0D742B6B85B
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Xrm.Sdk.dll

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Xrm.Sdk.Messages.GetValidReferencingEntitiesRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class GetValidReferencingEntitiesResponse : OrganizationResponse
  {
    /// <summary>Gets the array of valid entity names that can be the related entity in a many-to-many relationship.</summary>
    /// <returns>Type: Returns_String[]The array of valid entity names that can be the related entity in a many-to-many relationship.</returns>
    public string[] EntityNames
    {
      get
      {
        return this.Results.Contains(nameof (EntityNames)) ? (string[]) this.Results[nameof (EntityNames)] : (string[]) null;
      }
    }
  }
}
