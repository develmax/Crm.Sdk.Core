namespace Microsoft.Xrm.Sdk.Client
{
  /// <summary>Describes the synchronization option for sending or receiving entity data to or from a data service using the <see cref="T:Microsoft.Xrm.Sdk.Client.OrganizationServiceContext"></see>.</summary>
  public enum MergeOption
  {
    /// <summary>New pn_microsoftcrm entities are appended. Existing entities or their original values are not be modified. No client-side changes are lost in this merge. This is the default behavior. Value = 0.</summary>
    AppendOnly,
    /// <summary>All current values on the client are overwritten with current values from the Web service regardless of whether they have been changed on the client. Value = 1.</summary>
    OverwriteChanges,
    /// <summary>Current values that have been changed on the client are not modified, but any unchanged values are updated with current values from the Web service. No client-side changes are lost in this merge. Value = 2.</summary>
    PreserveChanges,
    /// <summary>pn_microsoftcrm entities are always loaded from persisted storage. Any attribute changes made to entities in the <see cref="T:Microsoft.Xrm.Sdk.Client.OrganizationServiceContext"></see> are overwritten by the data source values. Value = 3.</summary>
    NoTracking,
  }
}
