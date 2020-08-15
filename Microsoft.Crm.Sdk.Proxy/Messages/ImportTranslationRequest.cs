using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  import translations from a compressed file.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class ImportTranslationRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the compressed translations file. Required.</summary>
    /// <returns>Type: Returns_Byte[]The compressed translations file. Required.</returns>
    public byte[] TranslationFile
    {
      get
      {
        return this.Parameters.Contains(nameof (TranslationFile)) ? (byte[]) this.Parameters[nameof (TranslationFile)] : (byte[]) null;
      }
      set
      {
        this.Parameters[nameof (TranslationFile)] = (object) value;
      }
    }

    /// <summary>Gets or sets the ID of the import job that will be created to perform this import. Required.</summary>
    /// <returns>Type: Returns_GuidThe the ID of the import job that will be created to perform this import. This corresponds to the ImportJob.ImportJobId attribute, which is the primary key for the ImportJob entity.</returns>
    public Guid ImportJobId
    {
      get
      {
        return this.Parameters.Contains(nameof (ImportJobId)) ? (Guid) this.Parameters[nameof (ImportJobId)] : new Guid();
      }
      set
      {
        this.Parameters[nameof (ImportJobId)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Crm.Sdk.Messages.ImportTranslationRequest"></see> class</summary>
    public ImportTranslationRequest()
    {
      this.RequestName = "ImportTranslation";
      this.TranslationFile = (byte[]) null;
      this.ImportJobId = new Guid();
    }
  }
}
