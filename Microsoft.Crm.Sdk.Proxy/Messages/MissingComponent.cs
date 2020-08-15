using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data to describe a solution component that is required by a solution but not found in the system.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class MissingComponent : IExtensibleDataObject
  {
    private ExtensionDataObject _extensionDataObject;

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Crm.Sdk.Messages.MissingComponent"></see> class.</summary>
    public MissingComponent()
    {
      this.RequiredComponent = new ComponentDetail();
      this.DependentComponent = new ComponentDetail();
    }

    /// <summary>Gets or sets information about the required solution component that is missing.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Crm.Sdk.Messages.ComponentDetail"></see>Information about the required solution component that is missing..</returns>
    [DataMember]
    public ComponentDetail RequiredComponent { get; set; }

    /// <summary>Gets or sets information about the solution component in the solution file that is dependent on a missing solution component.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Crm.Sdk.Messages.ComponentDetail"></see>Information about the solution component in the solution file that is dependent on a missing solution component..</returns>
    [DataMember]
    public ComponentDetail DependentComponent { get; set; }

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
