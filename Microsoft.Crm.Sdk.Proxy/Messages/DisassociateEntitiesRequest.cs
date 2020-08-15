using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>deprecated Use the <see cref="T:Microsoft.Xrm.Sdk.Messages.DisassociateRequest"></see> class. Contains the data that is needed to  remove a link between two entity instances in a many-to-many relationship.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class DisassociateEntitiesRequest : OrganizationRequest
  {
    /// <summary>deprecated Use the <see cref="T:Microsoft.Xrm.Sdk.Messages.DisassociateRequest"></see> class and its members.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.EntityReference"></see>.</returns>
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

    /// <summary>deprecated Use the <see cref="T:Microsoft.Xrm.Sdk.Messages.DisassociateRequest"></see> class and its members.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.EntityReference"></see>.</returns>
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

    /// <summary>deprecated Use the <see cref="T:Microsoft.Xrm.Sdk.Messages.DisassociateRequest"></see> class and its members.</summary>
    /// <returns>Type:  Returns_String</returns>
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

    /// <summary>deprecatedInitializes a new instance of the  <see cref="T:Microsoft.Crm.Sdk.Messages.DisassociateEntitiesRequest"></see> class.</summary>
    public DisassociateEntitiesRequest()
    {
      this.RequestName = "DisassociateEntities";
      this.Moniker1 = (EntityReference) null;
      this.Moniker2 = (EntityReference) null;
      this.RelationshipName = (string) null;
    }
  }
}
