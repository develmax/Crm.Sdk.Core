namespace Microsoft.Crm.Sdk
{
  /// <summary>Contains integer values that are used for the SavedQuery.QueryType attribute.</summary>
  public static class SavedQueryQueryType
  {
    /// <summary>Specifies the main application view. Value = 0.</summary>
    public const int MainApplicationView = 0;
    /// <summary>An advanced search. Value = 1.</summary>
    public const int AdvancedSearch = 1;
    /// <summary>A sub-grid query. Value = 2.</summary>
    public const int SubGrid = 2;
    /// <summary>A quick find query, which defines the columns searched using the Search field in a list view. Value = 4.</summary>
    public const int QuickFindSearch = 4;
    /// <summary>A reporting query. Value = 8.</summary>
    public const int Reporting = 8;
    /// <summary>An offline filter for pn_crm_for_outlook_short. Value = 16.</summary>
    public const int OfflineFilters = 16;
    /// <summary>A lookup view. Value = 64.</summary>
    public const int LookupView = 64;
    /// <summary>Specifies the service management appointment book view. Value = 128.</summary>
    public const int SMAppointmentBookView = 128;
    /// <summary>A filter for pn_crm_for_outlook_short. Value = 256.</summary>
    public const int OutlookFilters = 256;
    /// <summary>An address book filter. Value = 512.</summary>
    public const int AddressBookFilters = 512;
    /// <summary>Specifies the main application view without a subject. Value = 1024.</summary>
    public const int MainApplicationViewWithoutSubject = 1024;
    /// <summary>A saved query used for workflow templates and e-mail templates. Value = 2048.</summary>
    public const int SavedQueryTypeOther = 2048;
    /// <summary>A view for a dialog (workflow process). Value = 4096.</summary>
    public const int InteractiveWorkflowView = 4096;
    /// <summary>An offline template for pn_crm_for_outlook_short. Value = 8192.</summary>
    public const int OfflineTemplate = 8192;
    public const int ExportFieldTranslationsView = 65536;
    /// <summary>A template for pn_crm_for_outlook_short. Value = 131072.</summary>
    public const int OutlookTemplate = 131072;
    /// <summary>A custom view. Value = 16384.</summary>
    public const int CustomDefinedView = 16384;
  }
}
