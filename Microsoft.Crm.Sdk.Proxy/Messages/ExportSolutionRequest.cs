using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to export a solution. </summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class ExportSolutionRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the unique name of the solution to be exported. Required.</summary>
    /// <returns>Type: Returns_StringThe unique name of the solution to be exported. Required.</returns>
    public string SolutionName
    {
      get
      {
        return this.Parameters.Contains(nameof (SolutionName)) ? (string) this.Parameters[nameof (SolutionName)] : (string) null;
      }
      set
      {
        this.Parameters[nameof (SolutionName)] = (object) value;
      }
    }

    /// <summary>Gets or sets whether the solution should be exported as a managed solution. Required.</summary>
    /// <returns>Type: Returns_Booleantrue if the solution should be exported as a managed solution; otherwise, false.</returns>
    public bool Managed
    {
      get
      {
        return this.Parameters.Contains(nameof (Managed)) && (bool) this.Parameters[nameof (Managed)];
      }
      set
      {
        this.Parameters[nameof (Managed)] = (object) value;
      }
    }

    /// <summary>Get or set a value indicating the version that the exported solution will support. </summary>
    /// <returns>Type: Returns_StringA value indicating the version that the exported solution will support. Optional.</returns>
    public string TargetVersion
    {
      get
      {
        return this.Parameters.Contains(nameof (TargetVersion)) ? (string) this.Parameters[nameof (TargetVersion)] : (string) null;
      }
      set
      {
        this.Parameters[nameof (TargetVersion)] = (object) value;
      }
    }

    /// <summary>Gets or sets whether auto numbering settings should be included in the solution being exported. Optional.</summary>
    /// <returns>Type: Returns_Booleantrue if the auto numbering settings should be included in the solution being exported; otherwise, false.</returns>
    public bool ExportAutoNumberingSettings
    {
      get
      {
        return this.Parameters.Contains(nameof (ExportAutoNumberingSettings)) && (bool) this.Parameters[nameof (ExportAutoNumberingSettings)];
      }
      set
      {
        this.Parameters[nameof (ExportAutoNumberingSettings)] = (object) value;
      }
    }

    /// <summary>Gets or sets whether calendar settings should be included in the solution being exported. Optional.</summary>
    /// <returns>Type: Returns_Booleantrue if the calendar settings should be included in the solution being exported; otherwise, false.</returns>
    public bool ExportCalendarSettings
    {
      get
      {
        return this.Parameters.Contains(nameof (ExportCalendarSettings)) && (bool) this.Parameters[nameof (ExportCalendarSettings)];
      }
      set
      {
        this.Parameters[nameof (ExportCalendarSettings)] = (object) value;
      }
    }

    /// <summary>Gets or sets whether customization settings should be included in the solution being exported. Optional.</summary>
    /// <returns>Type: Returns_Booleantrue if the customization settings should be included in the solution being exported; otherwise, false.</returns>
    public bool ExportCustomizationSettings
    {
      get
      {
        return this.Parameters.Contains(nameof (ExportCustomizationSettings)) && (bool) this.Parameters[nameof (ExportCustomizationSettings)];
      }
      set
      {
        this.Parameters[nameof (ExportCustomizationSettings)] = (object) value;
      }
    }

    /// <summary>Gets or sets whether email tracking settings should be included in the solution being exported. Optional.</summary>
    /// <returns>Type: Returns_Booleantrue if the email tracking settings should be included in the solution being exported; otherwise, false.</returns>
    public bool ExportEmailTrackingSettings
    {
      get
      {
        return this.Parameters.Contains(nameof (ExportEmailTrackingSettings)) && (bool) this.Parameters[nameof (ExportEmailTrackingSettings)];
      }
      set
      {
        this.Parameters[nameof (ExportEmailTrackingSettings)] = (object) value;
      }
    }

    /// <summary>Gets or sets whether general settings should be included in the solution being exported. Optional.</summary>
    /// <returns>Type: Returns_Booleantrue if the general settings should be included in the solution being exported; otherwise, false.</returns>
    public bool ExportGeneralSettings
    {
      get
      {
        return this.Parameters.Contains(nameof (ExportGeneralSettings)) && (bool) this.Parameters[nameof (ExportGeneralSettings)];
      }
      set
      {
        this.Parameters[nameof (ExportGeneralSettings)] = (object) value;
      }
    }

    /// <summary>Gets or sets whether marketing settings should be included in the solution being exported. Optional.</summary>
    /// <returns>Type: Returns_Booleantrue if the marketing settings should be included in the solution being exported; otherwise, false.</returns>
    public bool ExportMarketingSettings
    {
      get
      {
        return this.Parameters.Contains(nameof (ExportMarketingSettings)) && (bool) this.Parameters[nameof (ExportMarketingSettings)];
      }
      set
      {
        this.Parameters[nameof (ExportMarketingSettings)] = (object) value;
      }
    }

    /// <summary>Gets or sets whether outlook synchronization settings should be included in the solution being exported. Optional.</summary>
    /// <returns>Type: Returns_Booleantrue if the outlook synchronization settings should be included in the solution being exported; otherwise, false.</returns>
    public bool ExportOutlookSynchronizationSettings
    {
      get
      {
        return this.Parameters.Contains(nameof (ExportOutlookSynchronizationSettings)) && (bool) this.Parameters[nameof (ExportOutlookSynchronizationSettings)];
      }
      set
      {
        this.Parameters[nameof (ExportOutlookSynchronizationSettings)] = (object) value;
      }
    }

    /// <summary>Gets or sets whether relationship role settings should be included in the solution being exported. Optional.</summary>
    /// <returns>Type: Returns_Booleantrue if the relationship role settings should be included in the solution being exported; otherwise, false.</returns>
    public bool ExportRelationshipRoles
    {
      get
      {
        return this.Parameters.Contains(nameof (ExportRelationshipRoles)) && (bool) this.Parameters[nameof (ExportRelationshipRoles)];
      }
      set
      {
        this.Parameters[nameof (ExportRelationshipRoles)] = (object) value;
      }
    }

    /// <summary>Gets or sets whether ISV.Config settings should be included in the solution being exported. Optional.</summary>
    /// <returns>Type: Returns_Booleantrue if the ISV.Config settings should be included in the solution being exported; otherwise, false.</returns>
    public bool ExportIsvConfig
    {
      get
      {
        return this.Parameters.Contains(nameof (ExportIsvConfig)) && (bool) this.Parameters[nameof (ExportIsvConfig)];
      }
      set
      {
        this.Parameters[nameof (ExportIsvConfig)] = (object) value;
      }
    }

    /// <summary>Gets or sets whether sales settings should be included in the solution being exported. Optional.</summary>
    /// <returns>Type: Returns_Booleantrue if the sales settings should be included in the solution being exported; otherwise, false.</returns>
    public bool ExportSales
    {
      get
      {
        return this.Parameters.Contains(nameof (ExportSales)) && (bool) this.Parameters[nameof (ExportSales)];
      }
      set
      {
        this.Parameters[nameof (ExportSales)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.ExportSolutionRequest"></see> class</summary>
    public ExportSolutionRequest()
    {
      this.RequestName = "ExportSolution";
      this.SolutionName = (string) null;
      this.Managed = false;
    }
  }
}
