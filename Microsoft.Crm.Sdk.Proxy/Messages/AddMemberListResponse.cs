using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Crm.Sdk.Messages.AddMemberListRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class AddMemberListResponse : OrganizationResponse
  {
    /// <summary>Gets the ID of the resulting list member.</summary>
    /// <returns>Type:  Returns_GuidThe ID of the resulting list member that corresponds to the ListMember.ListMemberId property, which is the primary key for the ListMember intersect entity..</returns>
    public Guid Id
    {
      get
      {
        return this.Results.Contains(nameof (Id)) ? (Guid) this.Results[nameof (Id)] : new Guid();
      }
    }
  }
}
