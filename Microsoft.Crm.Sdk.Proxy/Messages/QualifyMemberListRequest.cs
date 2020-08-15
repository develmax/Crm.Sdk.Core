using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to qualify the specified list and either override the list members or remove them according to the specified option.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class QualifyMemberListRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the ID of the list to qualify. Required.</summary>
    /// <returns>Type: Returns_GuidThe ID of the list to qualify. This corresponds to the List.ListId attribute, which is the primary key for the List entity.</returns>
    public Guid ListId
    {
      get
      {
        return this.Parameters.Contains(nameof (ListId)) ? (Guid) this.Parameters[nameof (ListId)] : new Guid();
      }
      set
      {
        this.Parameters[nameof (ListId)] = (object) value;
      }
    }

    /// <summary>Gets or sets an array of IDs of the members to qualify. Required.</summary>
    /// <returns>Type: Returns_Guid[]The array of IDs of the members to qualify.</returns>
    public Guid[] MembersId
    {
      get
      {
        return this.Parameters.Contains(nameof (MembersId)) ? (Guid[]) this.Parameters[nameof (MembersId)] : (Guid[]) null;
      }
      set
      {
        this.Parameters[nameof (MembersId)] = (object) value;
      }
    }

    /// <summary>Gets or sets a value that indicates whether to override or remove the members from the list. Required.</summary>
    /// <returns>Type:  Returns_BooleanIndicates whether to override or remove the members from the list. true, to override; false, to remove.</returns>
    public bool OverrideorRemove
    {
      get
      {
        return this.Parameters.Contains(nameof (OverrideorRemove)) && (bool) this.Parameters[nameof (OverrideorRemove)];
      }
      set
      {
        this.Parameters[nameof (OverrideorRemove)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.QualifyMemberListRequest"></see> class.</summary>
    public QualifyMemberListRequest()
    {
      this.RequestName = "QualifyMemberList";
      this.ListId = new Guid();
      this.MembersId = (Guid[]) null;
      this.OverrideorRemove = false;
    }
  }
}
