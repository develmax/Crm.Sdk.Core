using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Crm.Sdk.Messages.FindParentResourceGroupRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class FindParentResourceGroupResponse : OrganizationResponse
  {
    /// <summary>Gets a value that indicates whether the parent resource group was found.</summary>
    /// <returns>Type: Returns_BooleanIndicates whether the parent resource group was found. true if the parent resource group was found; otherwise, false.</returns>
    public bool result
    {
      get
      {
        return this.Results.Contains(nameof (result)) && (bool) this.Results[nameof (result)];
      }
    }
  }
}
