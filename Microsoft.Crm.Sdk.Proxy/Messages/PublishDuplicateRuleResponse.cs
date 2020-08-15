using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Crm.Sdk.Messages.PublishDuplicateRuleRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class PublishDuplicateRuleResponse : OrganizationResponse
  {
    /// <summary>Gets the ID of the asynchronous job for publishing a duplicate detection rule.</summary>
    /// <returns>Type: Returns_GuidThe ID of the asynchronous job for publishing a duplicate detection rule.</returns>
    public Guid JobId
    {
      get
      {
        return this.Results.Contains(nameof (JobId)) ? (Guid) this.Results[nameof (JobId)] : new Guid();
      }
    }
  }
}
