using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data needed to create a relationship between a set of records that participate in specific relationships. </summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class SetRelatedRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the target records of the set related action. Required.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.EntityReference"></see>The target records of the set related action. This array must contain a set of entity references where the entities participate in a relationship.</returns>
    public EntityReference[] Target
    {
      get
      {
        return this.Parameters.Contains(nameof (Target)) ? (EntityReference[]) this.Parameters[nameof (Target)] : (EntityReference[]) null;
      }
      set
      {
        this.Parameters[nameof (Target)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Crm.Sdk.Messages.SetRelatedRequest"></see> class.</summary>
    public SetRelatedRequest()
    {
      this.RequestName = "SetRelated";
      this.Target = (EntityReference[]) null;
    }
  }
}
