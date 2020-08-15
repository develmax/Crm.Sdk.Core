using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>deprecated Use the <see cref="T:Microsoft.Xrm.Sdk.Messages.RetrieveMultipleRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class ExecuteFetchRequest : OrganizationRequest
  {
    /// <summary>deprecated</summary>
    /// <returns>Type: Returns_String</returns>
    public string FetchXml
    {
      get
      {
        return this.Parameters.Contains(nameof (FetchXml)) ? (string) this.Parameters[nameof (FetchXml)] : (string) null;
      }
      set
      {
        this.Parameters[nameof (FetchXml)] = (object) value;
      }
    }

    /// <summary>deprecated</summary>
    public ExecuteFetchRequest()
    {
      this.RequestName = "ExecuteFetch";
      this.FetchXml = (string) null;
    }
  }
}
