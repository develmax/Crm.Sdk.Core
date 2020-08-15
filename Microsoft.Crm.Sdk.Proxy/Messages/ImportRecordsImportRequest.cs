using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  submit an asynchronous job that uploads the transformed data into pn_microsoftcrm.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class ImportRecordsImportRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the ID of the data import (import) that is associated with the asynchronous import records job. Required.</summary>
    /// <returns>Type: Returns_GuidThe ID of the data import (import) that is associated with the asynchronous import records job. This corresponds to the Import.ImportId attribute, which is the primary key for the Import entity.</returns>
    public Guid ImportId
    {
      get
      {
        return this.Parameters.Contains(nameof (ImportId)) ? (Guid) this.Parameters[nameof (ImportId)] : new Guid();
      }
      set
      {
        this.Parameters[nameof (ImportId)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.ImportRecordsImportRequest"></see> class.</summary>
    public ImportRecordsImportRequest()
    {
      this.RequestName = "ImportRecordsImport";
      this.ImportId = new Guid();
    }
  }
}
