using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains data regarding the resources used by an organization.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class OrganizationResources : IExtensibleDataObject
  {
    private ExtensionDataObject _extensionDataObject;

    /// <summary>Gets the current number of active users.</summary>
    /// <returns>Type: Returns_Int32the current number of active users.</returns>
    [DataMember]
    public int CurrentNumberOfActiveUsers { get; set; }

    /// <summary>Gets the maximum number of active users.</summary>
    /// <returns>Type: Returns_Int32The maximum number of active users.</returns>
    [DataMember]
    public int MaxNumberOfActiveUsers { get; set; }

    /// <summary>Gets the current number of non-interactive users.</summary>
    /// <returns>Type: Returns_Int32the current number of non-interactive users.</returns>
    [DataMember]
    public int CurrentNumberOfNonInteractiveUsers { get; set; }

    /// <summary>Gets the maximum number of non-interactive users.</summary>
    /// <returns>Type: Returns_Int32The maximum number of non-interactive users.</returns>
    [DataMember]
    public int MaxNumberOfNonInteractiveUsers { get; set; }

    /// <summary>Gets the current number of custom entities.</summary>
    /// <returns>Type: Returns_Int32the current number of custom entities.</returns>
    [DataMember]
    public int CurrentNumberOfCustomEntities { get; set; }

    /// <summary>Gets the maximum number of custom entities.</summary>
    /// <returns>Type: Returns_Int32the maximum number of custom entities.</returns>
    [DataMember]
    public int MaxNumberOfCustomEntities { get; set; }

    /// <summary>Gets the current number of published workflows.</summary>
    /// <returns>Type: Returns_Int32the current number of published workflows.</returns>
    [DataMember]
    public int CurrentNumberOfPublishedWorkflows { get; set; }

    /// <summary>Gets the maximum number of published workflows.</summary>
    /// <returns>Type: Returns_Int32The maximum number of published workflows.</returns>
    [DataMember]
    public int MaxNumberOfPublishedWorkflows { get; set; }

    /// <summary>Gets the current storage used by the organization.</summary>
    /// <returns>Type: Returns_Int32the current storage used by the organization.</returns>
    [DataMember]
    public int CurrentStorage { get; set; }

    /// <summary>Gets the maximum storage allowed for the organization.</summary>
    /// <returns>Type: Returns_Int32The maximum storage allowed for the organization.</returns>
    [DataMember]
    public int MaxStorage { get; set; }

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
