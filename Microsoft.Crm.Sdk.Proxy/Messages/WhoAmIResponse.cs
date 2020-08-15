using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Crm.Sdk.Messages.WhoAmIRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class WhoAmIResponse : OrganizationResponse
  {
    /// <summary>Gets the ID of the user who is logged on.</summary>
    /// <returns>Type: Returns_GuidThe ID of the user who is currently logged on or the user under whose context the executed code is running. This corresponds to the SystemUser.SystemUserId attribute, which is the primary key for the SystemUser entity. </returns>
    public Guid UserId
    {
      get
      {
        return this.Results.Contains(nameof (UserId)) ? (Guid) this.Results[nameof (UserId)] : new Guid();
      }
    }

    /// <summary>Gets the ID of the business to which the logged on user belongs.</summary>
    /// <returns>Type: Returns_GuidThe ID of the business to which the logged on user belongs. This corresponds to the BusinessUnit.BusinessUnitId attribute, which is the primary key for the BusinessUnit entity.</returns>
    public Guid BusinessUnitId
    {
      get
      {
        return this.Results.Contains(nameof (BusinessUnitId)) ? (Guid) this.Results[nameof (BusinessUnitId)] : new Guid();
      }
    }

    /// <summary>Gets the ID of the organization that the user belongs to.</summary>
    /// <returns>Type: Returns_GuidID of the organization that the user belongs to. This corresponds to the Organization.OrganizationId attribute, which is the primary key for the Organization entity.</returns>
    public Guid OrganizationId
    {
      get
      {
        return this.Results.Contains(nameof (OrganizationId)) ? (Guid) this.Results[nameof (OrganizationId)] : new Guid();
      }
    }
  }
}
