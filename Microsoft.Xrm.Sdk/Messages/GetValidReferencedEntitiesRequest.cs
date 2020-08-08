// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Messages.GetValidReferencedEntitiesRequest
// Assembly: Microsoft.Xrm.Sdk, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 917F618E-83AC-4359-819B-E0D742B6B85B
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Xrm.Sdk.dll

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  retrieve a list of entity logical names that are valid as the primary entity (one) from the specified entity in a one-to-many relationship.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class GetValidReferencedEntitiesRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the logical name of the entity to get valid referenced entities. Optional.</summary>
    /// <returns>Type: Returns_StringThe logical name of the entity to get valid referenced entities. Optional.</returns>
    public string ReferencingEntityName
    {
      get
      {
        return this.Parameters.Contains(nameof (ReferencingEntityName)) ? (string) this.Parameters[nameof (ReferencingEntityName)] : (string) null;
      }
      set
      {
        this.Parameters[nameof (ReferencingEntityName)] = (object) value;
      }
    }

    /// <summary>constructor_initializes<see cref="T:Microsoft.Xrm.Sdk.Messages.GetValidReferencedEntitiesRequest"></see> class</summary>
    public GetValidReferencedEntitiesRequest()
    {
      this.RequestName = "GetValidReferencedEntities";
    }
  }
}
