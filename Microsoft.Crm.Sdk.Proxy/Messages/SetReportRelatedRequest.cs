using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data needed to link an instance of a report entity to related entities.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class SetReportRelatedRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the ID of the report. Required.</summary>
    /// <returns>Type: Returns_GuidThe ID of the report. This corresponds to the Report.ReportId attribute, which is the primary key for the report entity. </returns>
    public Guid ReportId
    {
      get
      {
        return this.Parameters.Contains(nameof (ReportId)) ? (Guid) this.Parameters[nameof (ReportId)] : new Guid();
      }
      set
      {
        this.Parameters[nameof (ReportId)] = (object) value;
      }
    }

    /// <summary>Gets or sets an array of entity type codes for the related entities. Required.</summary>
    /// <returns>Type: Returns_Int32[]The array of entity type codes for the related entities.</returns>
    public int[] Entities
    {
      get
      {
        return this.Parameters.Contains(nameof (Entities)) ? (int[]) this.Parameters[nameof (Entities)] : (int[]) null;
      }
      set
      {
        this.Parameters[nameof (Entities)] = (object) value;
      }
    }

    /// <summary>Gets or sets an array of report category codes. Required.</summary>
    /// <returns>Type: Returns_Int32[]The array of report category codes.</returns>
    public int[] Categories
    {
      get
      {
        return this.Parameters.Contains(nameof (Categories)) ? (int[]) this.Parameters[nameof (Categories)] : (int[]) null;
      }
      set
      {
        this.Parameters[nameof (Categories)] = (object) value;
      }
    }

    /// <summary>Gets or sets an array of report visibility codes. Required.</summary>
    /// <returns>Type: Returns_Int32[]The array of report visibility codes.</returns>
    public int[] Visibility
    {
      get
      {
        return this.Parameters.Contains(nameof (Visibility)) ? (int[]) this.Parameters[nameof (Visibility)] : (int[]) null;
      }
      set
      {
        this.Parameters[nameof (Visibility)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.SetReportRelatedRequest"></see> class.</summary>
    public SetReportRelatedRequest()
    {
      this.RequestName = "SetReportRelated";
      this.ReportId = new Guid();
      this.Entities = (int[]) null;
      this.Categories = (int[]) null;
      this.Visibility = (int[]) null;
    }
  }
}
