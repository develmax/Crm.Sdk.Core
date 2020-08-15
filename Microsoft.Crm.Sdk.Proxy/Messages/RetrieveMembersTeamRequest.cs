using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>deprecated Use the <see cref="T:Microsoft.Xrm.Sdk.Messages.RetrieveMultipleRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RetrieveMembersTeamRequest : OrganizationRequest
  {
    /// <summary>deprecated</summary>
    /// <returns>Type:  Returns_Guid</returns>
    public Guid EntityId
    {
      get
      {
        return this.Parameters.Contains(nameof (EntityId)) ? (Guid) this.Parameters[nameof (EntityId)] : new Guid();
      }
      set
      {
        this.Parameters[nameof (EntityId)] = (object) value;
      }
    }

    /// <summary>deprecated</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Query.ColumnSet"></see></returns>
    public ColumnSet MemberColumnSet
    {
      get
      {
        return this.Parameters.Contains(nameof (MemberColumnSet)) ? (ColumnSet) this.Parameters[nameof (MemberColumnSet)] : (ColumnSet) null;
      }
      set
      {
        this.Parameters[nameof (MemberColumnSet)] = (object) value;
      }
    }

    /// <summary>deprecated</summary>
    public RetrieveMembersTeamRequest()
    {
      this.RequestName = "RetrieveMembersTeam";
      this.EntityId = new Guid();
      this.MemberColumnSet = (ColumnSet) null;
    }
  }
}
