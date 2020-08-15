using System;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
  /// <summary>Represents a fault at a service endpoint in the cloud.</summary>
  [DataContract(Name = "ServiceEndpointFault", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  [Serializable]
  public sealed class ServiceEndpointFault : IExtensibleDataObject
  {
    private string _message;
    private ErrorDetailCollection _details;
    [NonSerialized]
    private ExtensionDataObject _extensionDataObject;

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.ServiceEndpointFault"></see> class.</summary>
    public ServiceEndpointFault()
    {
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.ServiceEndpointFault"></see> class with the specified fault reason.</summary>
    /// <param name="message">Type: Returns_String. The reason for the fault.</param>
    public ServiceEndpointFault(string message)
    {
      this._message = message;
    }

    /// <summary>Gets the message for the fault.</summary>
    /// <returns>Type: Returns_StringThe message for the fault.</returns>
    [DataMember]
    public string Message
    {
      get
      {
        return this._message;
      }
      set
      {
        this._message = value;
      }
    }

    /// <summary>Gets the details of the fault.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.ErrorDetailCollection"></see>The details of the fault.</returns>
    [DataMember]
    public ErrorDetailCollection ErrorDetails
    {
      get
      {
        if (this._details == null)
          this._details = new ErrorDetailCollection();
        return this._details;
      }
      set
      {
        this._details = value;
      }
    }

    /// <summary>ExtensionData</summary>
    /// <returns>Type: Returns_ExtensionDataObjectThe extension data.</returns>
    public ExtensionDataObject ExtensionData
    {
      get
      {
        return this._extensionDataObject;
      }
      set
      {
        this._extensionDataObject = value;
      }
    }
  }
}
