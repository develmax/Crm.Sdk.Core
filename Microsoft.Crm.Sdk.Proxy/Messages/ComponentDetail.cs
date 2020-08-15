using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Provides additional information about the solution components that are related to a missing component.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class ComponentDetail : IExtensibleDataObject
  {
    private ExtensionDataObject _extensionDataObject;

    /// <summary>constructor_initializes<see cref="T:Microsoft.Crm.Sdk.Messages.ComponentDetail"></see> class.</summary>
    public ComponentDetail()
    {
      this.Type = 0;
      this.SchemaName = string.Empty;
      this.DisplayName = string.Empty;
      this.Id = Guid.Empty;
      this.ParentSchemaName = string.Empty;
      this.ParentDisplayName = string.Empty;
      this.ParentId = Guid.Empty;
      this.Solution = string.Empty;
    }

    /// <summary>Gets or sets the component type of the solution component.</summary>
    /// <returns>Type: Returns_Int32
    /// The component type of the solution component.</returns>
    [DataMember]
    public int Type { get; set; }

    /// <summary>Gets or sets the schema name of the solution component.</summary>
    /// <returns>Type: Returns_String
    /// The schema name of the solution component.</returns>
    [DataMember]
    public string SchemaName { get; set; }

    /// <summary>Gets or sets the display name of the solution component.</summary>
    /// <returns>Type: Returns_String
    /// The display name of the solution component.</returns>
    [DataMember]
    public string DisplayName { get; set; }

    /// <summary>Gets or sets the ID of the solution component.</summary>
    /// <returns>Type: Returns_Guid
    /// The ID of the solution component.</returns>
    [DataMember]
    public Guid Id { get; set; }

    /// <summary>Gets or sets the schema name of the parent solution component.</summary>
    /// <returns>Type: Returns_String
    /// The schema name of the parent solution component..</returns>
    [DataMember]
    public string ParentSchemaName { get; set; }

    /// <summary>Gets or sets the display name of the parent solution component.</summary>
    /// <returns>Type: Returns_String
    /// The display name of the parent solution component.</returns>
    [DataMember]
    public string ParentDisplayName { get; set; }

    /// <summary>Gets or sets the ID of the parent solution component.</summary>
    /// <returns>Type: Returns_Guid
    /// The ID of the parent solution component.</returns>
    [DataMember]
    public Guid ParentId { get; set; }

    /// <summary>Gets or sets the name of the solution.</summary>
    /// <returns>Type: Returns_String
    /// The name of the solution.</returns>
    [DataMember]
    public string Solution { get; set; }

    /// <summary>Gets or sets the structure that contains extra data.</summary>
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
