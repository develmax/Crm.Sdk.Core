using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  retrieve distinct values from the parse table for a column in the source file that contains list values.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class GetDistinctValuesImportFileRequest : OrganizationRequest
  {
    /// <summary>Gets or sets in ID of the import file that is associated with the source file. Required.</summary>
    /// <returns>Type: Returns_GuidThe ID of the import file that is associated with the source file. This corresponds to the ImportFile.ImportFileId attribute, which is the primary key for the ImportFile entity.</returns>
    public Guid ImportFileId
    {
      get
      {
        return this.Parameters.Contains(nameof (ImportFileId)) ? (Guid) this.Parameters[nameof (ImportFileId)] : new Guid();
      }
      set
      {
        this.Parameters[nameof (ImportFileId)] = (object) value;
      }
    }

    /// <summary>Gets or sets a column number in the CSV, XML Spreadsheet 2003 (.xml), or text source file for which the distinct values are returned. Required.</summary>
    /// <returns>Type: Returns_Int32.</returns>
    public int columnNumber
    {
      get
      {
        return this.Parameters.Contains(nameof (columnNumber)) ? (int) this.Parameters[nameof (columnNumber)] : 0;
      }
      set
      {
        this.Parameters[nameof (columnNumber)] = (object) value;
      }
    }

    /// <summary>Gets or sets the page number in the source file. Required.</summary>
    /// <returns>Type: Returns_Int32The page number in the source file.</returns>
    public int pageNumber
    {
      get
      {
        return this.Parameters.Contains(nameof (pageNumber)) ? (int) this.Parameters[nameof (pageNumber)] : 0;
      }
      set
      {
        this.Parameters[nameof (pageNumber)] = (object) value;
      }
    }

    /// <summary>Gets or sets the number of data records per page in the source file. Required.</summary>
    /// <returns>Type: Returns_Int32The number of data records per page in the source file. </returns>
    public int recordsPerPage
    {
      get
      {
        return this.Parameters.Contains(nameof (recordsPerPage)) ? (int) this.Parameters[nameof (recordsPerPage)] : 0;
      }
      set
      {
        this.Parameters[nameof (recordsPerPage)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.GetDistinctValuesImportFileRequest"></see> class.</summary>
    public GetDistinctValuesImportFileRequest()
    {
      this.RequestName = "GetDistinctValuesImportFile";
      this.ImportFileId = new Guid();
      this.columnNumber = 0;
      this.pageNumber = 0;
      this.recordsPerPage = 0;
    }
  }
}
