using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Crm.Sdk.Messages.BackgroundSendEmailRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class BackgroundSendEmailResponse : OrganizationResponse
  {
    /// <summary>Gets the resulting emails. Required.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.EntityCollection"></see>The collection of resulting emails.</returns>
    public EntityCollection EntityCollection
    {
      get
      {
        return this.Results.Contains(nameof (EntityCollection)) ? (EntityCollection) this.Results[nameof (EntityCollection)] : (EntityCollection) null;
      }
    }

    /// <summary>Gets a value that indicates whether the email has attachments. Required.</summary>
    /// <returns>Type: Returns_Booleantrue if the email has attachments; otherwise, false.</returns>
    public bool[] HasAttachments
    {
      get
      {
        return this.Results.Contains(nameof (HasAttachments)) ? (bool[]) this.Results[nameof (HasAttachments)] : (bool[]) null;
      }
    }
  }
}
