using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Crm.Sdk.Messages.BulkDetectDuplicatesRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class BulkDetectDuplicatesResponse : OrganizationResponse
  {
    /// <summary>Gets the ID of an asynchronous bulk detect duplicates job that detects and logs duplicate records.</summary>
    /// <returns>Type: Returns_GuidThe ID of an asynchronous bulk detect duplicates job that detects and logs duplicate records.</returns>
    public Guid JobId
    {
      get
      {
        return this.Results.Contains(nameof (JobId)) ? (Guid) this.Results[nameof (JobId)] : new Guid();
      }
    }
  }
}
