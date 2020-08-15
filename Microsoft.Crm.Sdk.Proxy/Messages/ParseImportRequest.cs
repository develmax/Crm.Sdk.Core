using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  submit an asynchronous job that parses all import files that are associated with the specified import (data import). </summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class ParseImportRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the ID of the import (data import) that is associated with the asynchronous job that parses all import files for this import. Required.</summary>
    /// <returns>Type: Returns_GuidThe ID of the import (data import) that is associated with the asynchronous job that parses all import files for this import. This corresponds to the Import.ImportId attribute, which is the primary key for the Import entity.</returns>
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

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.ParseImportRequest"></see> class.</summary>
    public ParseImportRequest()
    {
      this.RequestName = "ParseImport";
      this.ImportId = new Guid();
    }
  }
}
