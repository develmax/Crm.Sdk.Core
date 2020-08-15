using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>internal</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class VerifyProcessStateDataRequest : OrganizationRequest
  {
    /// <summary>internal</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.EntityReference"></see></returns>
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

    /// <summary>internal</summary>
    /// <returns>Type: Returns_String</returns>
    public string ProcessState
    {
      get
      {
        return this.Parameters.Contains(nameof (ProcessState)) ? (string) this.Parameters[nameof (ProcessState)] : (string) null;
      }
      set
      {
        this.Parameters[nameof (ProcessState)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.VerifyProcessStateDataRequest"></see> class.</summary>
    public VerifyProcessStateDataRequest()
    {
      this.RequestName = "VerifyProcessStateData";
      this.Target = (EntityReference) null;
      this.ProcessState = (string) null;
    }
  }
}
