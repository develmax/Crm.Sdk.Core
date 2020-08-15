using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Crm.Sdk.Messages.ParseImportRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class ParseImportResponse : OrganizationResponse
  {
    /// <summary>Gets an ID of the asynchronous job that parses the import files for this import.</summary>
    /// <returns>Type: Returns_GuidID of the asynchronous job that parses the import files for this import.</returns>
    public Guid AsyncOperationId
    {
      get
      {
        return this.Results.Contains(nameof (AsyncOperationId)) ? (Guid) this.Results[nameof (AsyncOperationId)] : new Guid();
      }
    }
  }
}
