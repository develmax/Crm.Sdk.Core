using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>deprecated Use the <see cref="T:Microsoft.Xrm.Sdk.Messages.CreateRequest"></see> class. Creates a compound entity, such as a sales order (order), invoice, quote, or duplicate rule (duplicate detection rule); and its related entity, such as a sales order detail (order product), invoice detail (invoice product), quote detail (quote product), or duplicate rule condition. </summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class CompoundCreateRequest : OrganizationRequest
  {
    /// <summary>deprecated</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Entity"></see></returns>
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

    /// <summary>deprecated</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.EntityCollection"></see></returns>
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

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Crm.Sdk.Messages.CompoundCreateRequest"></see> class.</summary>
    public CompoundCreateRequest()
    {
      this.RequestName = "CompoundCreate";
      this.Entity = (Entity) null;
      this.ChildEntities = (EntityCollection) null;
    }
  }
}
