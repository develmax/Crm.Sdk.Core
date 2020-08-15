using System;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Xrm.Sdk.Messages.CreateManyToManyRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class CreateManyToManyResponse : OrganizationResponse
  {
    /// <summary>Gets the ID of the many-to-many entity relationship that is created.</summary>
    /// <returns>Type: Returns_Guid The ID of the many-to-many entity relationship that is created. This corresponds to the <see cref="P:Microsoft.Xrm.Sdk.Metadata.MetadataBase.MetadataId"></see>. </returns>
    public Guid ManyToManyRelationshipId
    {
      get
      {
        return this.Results.Contains(nameof (ManyToManyRelationshipId)) ? (Guid) this.Results[nameof (ManyToManyRelationshipId)] : new Guid();
      }
    }
  }
}
