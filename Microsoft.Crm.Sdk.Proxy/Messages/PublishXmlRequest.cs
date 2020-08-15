using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  publish specified solution components. </summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class PublishXmlRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the XML that defines which solution components to publish in this request. Required.</summary>
    /// <returns>Type: Returns_Stringthe XML that defines which solution components to publish in this request. Required.</returns>
    public string ParameterXml
    {
      get
      {
        return this.Parameters.Contains(nameof (ParameterXml)) ? (string) this.Parameters[nameof (ParameterXml)] : (string) null;
      }
      set
      {
        this.Parameters[nameof (ParameterXml)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Crm.Sdk.Messages.PublishXmlRequest"></see> class</summary>
    public PublishXmlRequest()
    {
      this.RequestName = "PublishXml";
      this.ParameterXml = (string) null;
    }
  }
}
