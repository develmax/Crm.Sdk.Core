// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Messages.CanManyToManyResponse
// Assembly: Microsoft.Xrm.Sdk, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 917F618E-83AC-4359-819B-E0D742B6B85B
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Xrm.Sdk.dll

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Xrm.Sdk.Messages.CanManyToManyRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class CanManyToManyResponse : OrganizationResponse
  {
    /// <summary>Gets the result of the request to see whether the entity can participate in a many-to-many relationship.</summary>
    /// <returns>Type: Returns_Booleantrue if the the entity can participate in a many-to-many relationship.; otherwise, false.</returns>
    public bool CanManyToMany
    {
      get
      {
        return this.Results.Contains(nameof (CanManyToMany)) && (bool) this.Results[nameof (CanManyToMany)];
      }
    }
  }
}
