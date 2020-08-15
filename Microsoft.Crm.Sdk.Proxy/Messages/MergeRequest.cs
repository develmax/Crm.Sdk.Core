using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to merge the information from two entity records of the same type.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class MergeRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the target of the merge operation. Required.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.EntityReference"></see>The target of the merge operation.</returns>
    public EntityReference Target
    {
      get
      {
        return this.Parameters.Contains(nameof (Target)) ? (EntityReference) this.Parameters[nameof (Target)] : (EntityReference) null;
      }
      set
      {
        this.Parameters[nameof (Target)] = (object) value;
      }
    }

    /// <summary>Gets or sets the ID of the entity record from which to merge data. Required.</summary>
    /// <returns>Type:  Returns_GuidThe ID of the entity record from which to merge data.</returns>
    public Guid SubordinateId
    {
      get
      {
        return this.Parameters.Contains(nameof (SubordinateId)) ? (Guid) this.Parameters[nameof (SubordinateId)] : new Guid();
      }
      set
      {
        this.Parameters[nameof (SubordinateId)] = (object) value;
      }
    }

    /// <summary>Gets or sets additional entity attributes to be set during the merge operation for accounts, contacts, or leads. This property is not applied when merging Incidents. Optional.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Entity"></see>The additional entity attributes to be set during the merge operation.</returns>
    public Entity UpdateContent
    {
      get
      {
        return this.Parameters.Contains(nameof (UpdateContent)) ? (Entity) this.Parameters[nameof (UpdateContent)] : (Entity) null;
      }
      set
      {
        this.Parameters[nameof (UpdateContent)] = (object) value;
      }
    }

    /// <summary>Gets or sets a value that indicates whether to check if the parent information is different for the two entity records. Required.</summary>
    /// <returns>Type:  Returns_BooleanIndicates whether to check if the parent information is different for the two entity records. True to check if the parent information is different for the two entity records, otherwise, false.</returns>
    public bool PerformParentingChecks
    {
      get
      {
        return this.Parameters.Contains(nameof (PerformParentingChecks)) && (bool) this.Parameters[nameof (PerformParentingChecks)];
      }
      set
      {
        this.Parameters[nameof (PerformParentingChecks)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.MergeRequest"></see> class.</summary>
    public MergeRequest()
    {
      this.RequestName = "Merge";
      this.Target = (EntityReference) null;
      this.SubordinateId = new Guid();
      this.UpdateContent = (Entity) null;
      this.PerformParentingChecks = false;
    }
  }
}
