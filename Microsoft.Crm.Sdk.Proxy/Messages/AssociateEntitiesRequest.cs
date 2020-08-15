using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>deprecated Use the <see cref="T:Microsoft.Xrm.Sdk.Messages.AssociateRequest"></see> class. Contains the data that is needed to  add a link between two entity instances in a many-to-many relationship.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class AssociateEntitiesRequest : OrganizationRequest
  {
    /// <summary>deprecated Use the <see cref="T:Microsoft.Xrm.Sdk.Messages.AssociateRequest"></see> class and its members.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.EntityReference"></see>The entity reference for the first record.</returns>
    public EntityReference Moniker1
    {
      get
      {
        return this.Parameters.Contains(nameof (Moniker1)) ? (EntityReference) this.Parameters[nameof (Moniker1)] : (EntityReference) null;
      }
      set
      {
        this.Parameters[nameof (Moniker1)] = (object) value;
      }
    }

    /// <summary>deprecated Use the <see cref="T:Microsoft.Xrm.Sdk.Messages.AssociateRequest"></see> class and its members.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.EntityReference"></see>The entity reference for the second record.</returns>
    public EntityReference Moniker2
    {
      get
      {
        return this.Parameters.Contains(nameof (Moniker2)) ? (EntityReference) this.Parameters[nameof (Moniker2)] : (EntityReference) null;
      }
      set
      {
        this.Parameters[nameof (Moniker2)] = (object) value;
      }
    }

    /// <summary>deprecated Use the <see cref="T:Microsoft.Xrm.Sdk.Messages.AssociateRequest"></see> class and its members.</summary>
    /// <returns>Type: Returns_StringThe name of the relationship between the two entities.</returns>
    public string RelationshipName
    {
      get
      {
        return this.Parameters.Contains(nameof (RelationshipName)) ? (string) this.Parameters[nameof (RelationshipName)] : (string) null;
      }
      set
      {
        this.Parameters[nameof (RelationshipName)] = (object) value;
      }
    }

    /// <summary>deprecated Use the <see cref="T:Microsoft.Xrm.Sdk.Messages.AssociateRequest"></see> class and its members.</summary>
    public AssociateEntitiesRequest()
    {
      this.RequestName = "AssociateEntities";
      this.Moniker1 = (EntityReference) null;
      this.Moniker2 = (EntityReference) null;
      this.RelationshipName = (string) null;
    }
  }
}
