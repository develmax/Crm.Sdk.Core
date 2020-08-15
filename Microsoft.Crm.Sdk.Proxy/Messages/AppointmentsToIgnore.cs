using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Specifies the appointments to ignore in an appointment request from the <see cref="T:Microsoft.Crm.Sdk.Messages.SearchRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class AppointmentsToIgnore : IExtensibleDataObject
  {
    private ExtensionDataObject _extensionDataObject;

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Crm.Sdk.Messages.AppointmentsToIgnore"></see> class.</summary>
    public AppointmentsToIgnore()
    {
    }

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Crm.Sdk.Messages.AppointmentsToIgnore"></see> class setting the appointments and resource ID.</summary>
    /// <param name="appointments">Type: Returns_Guid[]. The array of IDs of appointments to ignore.</param>
    /// <param name="resourceId">Type: Returns_Guid. The resource for which appointments are to be ignored.</param>
    public AppointmentsToIgnore(Guid[] appointments, Guid resourceId)
    {
      this.Appointments = appointments;
      this.ResourceId = resourceId;
    }

    /// <summary>Gets or sets an array of IDs of appointments to ignore.</summary>
    /// <returns>Type: Returns_Guid[]
    /// The array of IDs of appointments to ignore.</returns>
    [DataMember]
    public Guid[] Appointments { get; set; }

    /// <summary>Gets or sets the resource for which appointments are to be ignored.</summary>
    /// <returns>Type: Returns_Guid
    /// The resource for which appointments are to be ignored.</returns>
    [DataMember]
    public Guid ResourceId { get; set; }

    /// <summary>ExtensionData</summary>
    /// <returns>Type: Returns_ExtensionDataObject.</returns>
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
