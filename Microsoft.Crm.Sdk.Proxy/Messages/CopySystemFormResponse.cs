using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Crm.Sdk.Messages.CopySystemFormRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class CopySystemFormResponse : OrganizationResponse
  {
    /// <summary>Gets the ID of the system form that the original was copied to.</summary>
    /// <returns>Type: Returns_Guid
    /// If no Target was specified, this is the ID of the system form that the original was copied to. It corresponds to the SystemForm.FormId attribute, which is the primary key for the SystemForm entity.</returns>
    public Guid Id
    {
      get
      {
        return this.Results.Contains(nameof (Id)) ? (Guid) this.Results[nameof (Id)] : new Guid();
      }
    }
  }
}
