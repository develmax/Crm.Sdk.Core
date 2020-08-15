using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  remove the parent for a system user (user) record.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RemoveParentRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the target systemuser (user) record for the operation.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.EntityReference"></see>The target systemuser (user) record for the operation. This must be an entity reference to a systemuser (user) record.</returns>
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

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Crm.Sdk.Messages.RemoveParentRequest"></see> class.</summary>
    public RemoveParentRequest()
    {
      this.RequestName = "RemoveParent";
      this.Target = (EntityReference) null;
    }
  }
}
