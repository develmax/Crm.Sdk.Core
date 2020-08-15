using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Specifies the results of a scheduling operation using the <see cref="T:Microsoft.Crm.Sdk.Messages.ValidateRequest"></see>, <see cref="T:Microsoft.Crm.Sdk.Messages.BookRequest"></see>, or <see cref="T:Microsoft.Crm.Sdk.Messages.RescheduleRequest"></see> message.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class ErrorInfo : IExtensibleDataObject
  {
    private ExtensionDataObject _extensionDataObject;

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.ErrorInfo"></see> class.</summary>
    public ErrorInfo()
    {
      this.ResourceList = new ResourceInfo[0];
      this.ErrorCode = "";
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.ErrorInfo"></see> class setting the error code and resource list.</summary>
    /// <param name="resourceList">Type: <see cref="T:Microsoft.Crm.Sdk.Messages.ResourceInfo"></see>[]. The array of information about a resource that has a scheduling problem for an appointment.</param>
    /// <param name="errorCode">Type: Returns_String. The reason for a scheduling failure.</param>
    public ErrorInfo(string errorCode, ResourceInfo[] resourceList)
    {
      this.ResourceList = resourceList;
      this.ErrorCode = errorCode;
    }

    /// <summary>Gets or sets the array of information about a resource that has a scheduling problem for an appointment.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Crm.Sdk.Messages.ResourceInfo"></see>[]The array of information about a resource that has a scheduling problem for an appointment.</returns>
    [DataMember]
    public ResourceInfo[] ResourceList { get; set; }

    /// <summary>Gets or sets the reason for a scheduling failure.</summary>
    /// <returns>Type: Returns_StringThe reason for a scheduling failure.</returns>
    [DataMember]
    public string ErrorCode { get; set; }

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
