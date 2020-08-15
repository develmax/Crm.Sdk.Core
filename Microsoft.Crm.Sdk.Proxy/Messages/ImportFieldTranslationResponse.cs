using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Crm.Sdk.Messages.ImportFieldTranslationRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class ImportFieldTranslationResponse : OrganizationResponse
  {
    /// <summary>Gets the ID of the import job that will be created to perform this import.</summary>
    /// <returns>Type: Returns_GuidThe ID of the import job that will be created to perform this import. This corresponds to the ImportJob.ImportJobId attribute, which is the primary key for the ImportJob entity.</returns>
    public Guid JobId
    {
      get
      {
        return this.Results.Contains(nameof (JobId)) ? (Guid) this.Results[nameof (JobId)] : new Guid();
      }
    }
  }
}
