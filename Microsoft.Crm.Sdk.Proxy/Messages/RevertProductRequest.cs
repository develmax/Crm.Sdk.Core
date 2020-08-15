using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to revert changes done to properties of a product family, product, or bundle record, and set it back to its last published (active) state.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RevertProductRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the target product family, product, or bundle record for which you want to revert the changes done to its properties since it was last published. Required.</summary>
    /// <returns>Type <see cref="T:Microsoft.Xrm.Sdk.EntityReference"></see>The target product family, product, or bundle record for which you want to revert the changes done to its properties since it was last published.</returns>
    public EntityReference Target
    {
      get
      {
        return this.Parameters.Contains(nameof (Target)) ? (EntityReference) this.Parameters[nameof (Target)] : (EntityReference) null;
      }
      set
      {
        this.Parameters[nameof (Target)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.RevertProductRequest"></see> class.</summary>
    public RevertProductRequest()
    {
      this.RequestName = "RevertProduct";
      this.Target = (EntityReference) null;
    }
  }
}
