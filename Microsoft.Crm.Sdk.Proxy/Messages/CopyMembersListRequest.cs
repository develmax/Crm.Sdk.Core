using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  copy the members from the source list to the target list without creating duplicates.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class CopyMembersListRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the ID of the source list. Required.</summary>
    /// <returns>Type: Returns_GuidThe ID of the source list that corresponds to the List.ListId attribute, which is the primary key for the List entity.</returns>
    public Guid SourceListId
    {
      get
      {
        return this.Parameters.Contains(nameof (SourceListId)) ? (Guid) this.Parameters[nameof (SourceListId)] : new Guid();
      }
      set
      {
        this.Parameters[nameof (SourceListId)] = (object) value;
      }
    }

    /// <summary>Gets or sets the ID of the target list. Required.</summary>
    /// <returns>Type: Returns_GuidThe ID of the target list that corresponds to the List.ListId attribute, which is the primary key for the List entity.</returns>
    public Guid TargetListId
    {
      get
      {
        return this.Parameters.Contains(nameof (TargetListId)) ? (Guid) this.Parameters[nameof (TargetListId)] : new Guid();
      }
      set
      {
        this.Parameters[nameof (TargetListId)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.CopyMembersListRequest"></see> class.</summary>
    public CopyMembersListRequest()
    {
      this.RequestName = "CopyMembersList";
      this.SourceListId = new Guid();
      this.TargetListId = new Guid();
    }
  }
}
