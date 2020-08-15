using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.crm.Sdk.Messages.RetrieveMissingComponentsRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RetrieveMissingComponentsResponse : OrganizationResponse
  {
    /// <summary>Gets an array of MissingComponent records.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Crm.Sdk.Messages.MissingComponent"></see>[]An array of MissingComponent records.</returns>
    public MissingComponent[] MissingComponents
    {
      get
      {
        return this.Results.Contains(nameof (MissingComponents)) ? (MissingComponent[]) this.Results[nameof (MissingComponents)] : (MissingComponent[]) null;
      }
    }
  }
}
