using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains information about a resource that has a scheduling problem for an appointment.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class ResourceInfo : IExtensibleDataObject
  {
    private ExtensionDataObject _extensionDataObject;

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Crm.Sdk.Messages.ResourceInfo"></see> class.</summary>
    public ResourceInfo()
    {
      this.Id = Guid.Empty;
      this.DisplayName = (string) null;
    }

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Crm.Sdk.Messages.ResourceInfo"></see> class that sets the ID, entity name, and display name.</summary>
    /// <param name="name">Type: Returns_String. The display name for the resource.</param>
    /// <param name="entityName">Type: Returns_String. The logical name of the entity.</param>
    /// <param name="id">Type: Returns_Guid. The ID of the record that has a scheduling problem.</param>
    public ResourceInfo(Guid id, string entityName, string name)
    {
      this.Id = id;
      this.EntityName = entityName;
      this.DisplayName = name;
    }

    /// <summary>Gets or sets the ID of the record that has a scheduling problem.</summary>
    /// <returns>Type: Returns_Guid
    /// The ID of the record that has a scheduling problem.</returns>
    [DataMember]
    public Guid Id { get; set; }

    /// <summary>Gets or sets the display name for the resource.</summary>
    /// <returns>Type: Returns_String
    /// The display name for the resource found in the Resource.Name attribute.</returns>
    [DataMember]
    public string DisplayName { get; set; }

    /// <summary>Gets or sets the logical name of the entity.</summary>
    /// <returns>Type: Returns_String
    /// The logical name of the entity.</returns>
    [DataMember]
    public string EntityName { get; set; }

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
