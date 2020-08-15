using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Provides a base class for storing the details of data changes.</summary>
  [KnownType(typeof (ShareAuditDetail))]
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  [KnownType(typeof (AttributeAuditDetail))]
  [KnownType(typeof (RelationshipAuditDetail))]
  public class AuditDetail : IExtensibleDataObject
  {
    private ExtensionDataObject _extensionDataObject;

    /// <summary>Gets or sets the related Audit record that contains the change details.</summary>
    /// <returns>Type:  <see cref="T:Microsoft.Xrm.Sdk.Entity"></see> The audit record.</returns>
    [DataMember]
    public Entity AuditRecord { get; set; }

    /// <summary>Gets or sets the structure that contains extra data. Optional.</summary>
    /// <returns>Type:  Returns_ExtensionDataObject.</returns>
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
