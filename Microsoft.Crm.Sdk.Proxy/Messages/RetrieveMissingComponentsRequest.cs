using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  retrieve a list of missing components in the target organization. </summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RetrieveMissingComponentsRequest : OrganizationRequest
  {
    /// <summary>Gets or sets a file for a solution. Required.</summary>
    /// <returns>Type: Returns_Byte[]A file for a solution</returns>
    public byte[] CustomizationFile
    {
      get
      {
        return this.Parameters.Contains(nameof (CustomizationFile)) ? (byte[]) this.Parameters[nameof (CustomizationFile)] : (byte[]) null;
      }
      set
      {
        this.Parameters[nameof (CustomizationFile)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Crm.Sdk.Messages.RetrieveMissingComponentsRequest"></see> class.</summary>
    public RetrieveMissingComponentsRequest()
    {
      this.RequestName = "RetrieveMissingComponents";
      this.CustomizationFile = (byte[]) null;
    }
  }
}
