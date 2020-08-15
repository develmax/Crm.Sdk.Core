using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  update a duplicate rule (duplicate detection rule) and its related duplicate rule conditions.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class CompoundUpdateDuplicateDetectionRuleRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the duplicate rule that you want updated. Required.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Entity"></see>The duplicate rule that you want updated. This is instance of a DuplicateRule class.</returns>
    public Entity Entity
    {
      get
      {
        return this.Parameters.Contains(nameof (Entity)) ? (Entity) this.Parameters[nameof (Entity)] : (Entity) null;
      }
      set
      {
        this.Parameters[nameof (Entity)] = (object) value;
      }
    }

    /// <summary>Gets or sets a collection of the duplicate rule conditions that you want updated. Required.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.EntityCollection"></see>The collection of the duplicate rule conditions that you want updated.</returns>
    public EntityCollection ChildEntities
    {
      get
      {
        return this.Parameters.Contains(nameof (ChildEntities)) ? (EntityCollection) this.Parameters[nameof (ChildEntities)] : (EntityCollection) null;
      }
      set
      {
        this.Parameters[nameof (ChildEntities)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.CompoundUpdateDuplicateDetectionRuleRequest"></see> class.</summary>
    public CompoundUpdateDuplicateDetectionRuleRequest()
    {
      this.RequestName = "CompoundUpdateDuplicateDetectionRule";
      this.Entity = (Entity) null;
      this.ChildEntities = (EntityCollection) null;
    }
  }
}
