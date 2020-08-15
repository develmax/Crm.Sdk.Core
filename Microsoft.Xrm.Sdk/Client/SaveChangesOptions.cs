using System;

namespace Microsoft.Xrm.Sdk.Client
{
  /// <summary>Describes how the <see cref="M:Microsoft.Xrm.Sdk.Client.OrganizationServiceContext.SaveChanges"></see> method behaves when an error occurs while updating data in pn_microsoftcrm.</summary>
  [Flags]
  public enum SaveChangesOptions
  {
    /// <summary>The <see cref="M:Microsoft.Xrm.Sdk.Client.OrganizationServiceContext.SaveChanges"></see> method should throw an exception when an error occurs while updating data in pn_microsoftcrm. Value = 0.</summary>
    None = 0,
    /// <summary>The <see cref="M:Microsoft.Xrm.Sdk.Client.OrganizationServiceContext.SaveChanges"></see> method should continue applying changes to tracked entities in pn_microsoftcrm even if an action fails. Value = 1.</summary>
    ContinueOnError = 1,
  }
}
