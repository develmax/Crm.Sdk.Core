using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to set the state of an entity record.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class SetStateRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the entity. Required.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.EntityReference"></see>The entity.</returns>
    public EntityReference EntityMoniker
    {
      get
      {
        return this.Parameters.Contains(nameof (EntityMoniker)) ? (EntityReference) this.Parameters[nameof (EntityMoniker)] : (EntityReference) null;
      }
      set
      {
        this.Parameters[nameof (EntityMoniker)] = (object) value;
      }
    }

    /// <summary>Gets or sets the state of the entity record. Required.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.OptionSetValue"></see>The state of the entity record.</returns>
    public OptionSetValue State
    {
      get
      {
        return this.Parameters.Contains(nameof (State)) ? (OptionSetValue) this.Parameters[nameof (State)] : (OptionSetValue) null;
      }
      set
      {
        this.Parameters[nameof (State)] = (object) value;
      }
    }

    /// <summary>Gets or sets the status that corresponds to the State property. Required.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.OptionSetValue"></see>The status that corresponds to the State property.</returns>
    public OptionSetValue Status
    {
      get
      {
        return this.Parameters.Contains(nameof (Status)) ? (OptionSetValue) this.Parameters[nameof (Status)] : (OptionSetValue) null;
      }
      set
      {
        this.Parameters[nameof (Status)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.SetStateRequest"></see> class.</summary>
    public SetStateRequest()
    {
      this.RequestName = "SetState";
      this.EntityMoniker = (EntityReference) null;
      this.State = (OptionSetValue) null;
      this.Status = (OptionSetValue) null;
    }
  }
}
