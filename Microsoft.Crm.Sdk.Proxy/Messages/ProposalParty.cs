using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Represents a party (user, team, or resource) that is needed for the proposed appointment.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class ProposalParty : IExtensibleDataObject
  {
    private ExtensionDataObject _extensionDataObject;

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Crm.Sdk.Messages.ProposalParty"></see> class.</summary>
    public ProposalParty()
    {
    }

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Crm.Sdk.Messages.ProposalParty"></see> class that sets the resource and resource specification IDs, the display and entity names, and the required effort, as measured by percentage of time.</summary>
    /// <param name="effortRequired">Type: Returns_Double. The percentage of time that is required to perform the service.</param>
    /// <param name="resourceSpecId">Type: Returns_Guid. The ID of the resource specification that is represented by this party.</param>
    /// <param name="entityName">Type: Returns_String. The logical name of the type of entity that is represented by this party.</param>
    /// <param name="displayName">Type: Returns_String. The display name for the party.</param>
    /// <param name="resourceId">Type: Returns_Guid. The ID of the resource that is represented by this party.</param>
    public ProposalParty(
      Guid resourceId,
      Guid resourceSpecId,
      string displayName,
      string entityName,
      double effortRequired)
    {
      this.ResourceId = resourceId;
      this.ResourceSpecId = resourceSpecId;
      this.DisplayName = displayName;
      this.EntityName = entityName;
      this.EffortRequired = effortRequired;
    }

    /// <summary>Gets or sets the ID of the resource that is represented by this party.</summary>
    /// <returns>Type: Returns_Guid
    /// The ID of the resource that is represented by this party. This corresponds to the Resource.ResourceId attribute, which is the primary key for the Resource entity.</returns>
    [DataMember]
    public Guid ResourceId { get; set; }

    /// <summary>Gets or sets the ID of the resource specification that is represented by this party.</summary>
    /// <returns>Type: Returns_Guid
    /// The ID of the resource specification that is represented by this party. This corresponds to the ResourceSpec.ResourceSpecId attribute, which is the primary key for the ResourceSpec entity.</returns>
    [DataMember]
    public Guid ResourceSpecId { get; set; }

    /// <summary>Gets or sets the display name for the party.</summary>
    /// <returns>Type: Returns_StringThe display name for the party.</returns>
    [DataMember]
    public string DisplayName { get; set; }

    /// <summary>Gets or sets the logical name of the type of entity that is represented by this party.</summary>
    /// <returns>Type: Returns_StringThe logical name of the type of entity that is represented by this party.</returns>
    [DataMember]
    public string EntityName { get; set; }

    /// <summary>Gets or sets the percentage of time that is required to perform the service.</summary>
    /// <returns>Type: Returns_DoubleThe percentage of time that is required to perform the service.</returns>
    [DataMember]
    public double EffortRequired { get; set; }

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
