using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that describes the scheduling strategy for an <see cref="T:Microsoft.Crm.Sdk.Messages.AppointmentRequest"></see> and that overrides the default constraints.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class ObjectiveRelation : IExtensibleDataObject
  {
    private ExtensionDataObject _extensionDataObject;

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Crm.Sdk.Messages.ObjectiveRelation"></see> class.</summary>
    public ObjectiveRelation()
    {
    }

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Crm.Sdk.Messages.ObjectiveRelation"></see> class.</summary>
    /// <param name="resourceSpecId">Type: Returns_Guid. The ID of the resource specification.</param>
    /// <param name="objectiveExpression">Type: Returns_String. The search strategy to use in the appointment request.</param>
    public ObjectiveRelation(Guid resourceSpecId, string objectiveExpression)
    {
      this.ResourceSpecId = resourceSpecId;
      this.ObjectiveExpression = objectiveExpression;
    }

    /// <summary>Gets or sets the ID of the resource specification.</summary>
    /// <returns>Type: Returns_GuidThe ID of the resource specification. The <see cref="P:Microsoft.Crm.Sdk.Messages.ObjectiveRelation.ResourceSpecId"></see> property corresponds to the ResourceSpec.ResourceSpecId property, which is the primary key for the resource specification entity.</returns>
    [DataMember]
    public Guid ResourceSpecId { get; set; }

    /// <summary>Gets or sets the search strategy to use in the appointment request for the <see cref="T:Microsoft.Crm.Sdk.Messages.SearchRequest"></see> message.</summary>
    /// <returns>Type: Returns_StringThe search strategy to use in the appointment request.</returns>
    [DataMember]
    public string ObjectiveExpression { get; set; }

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
