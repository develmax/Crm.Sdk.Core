using Microsoft.Xrm.Sdk;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the details of changes to entity attributes.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class AttributeAuditDetail : AuditDetail
  {
    private Dictionary<int, string> _deletedAttributes;
    private DataCollection<string> _invalidNewValueAttributes;

    /// <summary>Gets or sets a collection of former values for an entity attribute.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Entity"></see>The collection of former values for an entity attribute.</returns>
    [DataMember]
    public Entity OldValue { get; set; }

    /// <summary>Gets or sets a collection of new values for an entity attribute.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Entity"></see>The collection of new values for an entity attribute.</returns>
    [DataMember]
    public Entity NewValue { get; set; }

    /// <summary>Gets a collection of attempted attribute changes that are not valid.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.DataCollection`1"></see>The data collection of attempted attribute changes.</returns>
    [DataMember]
    public DataCollection<string> InvalidNewValueAttributes
    {
      get
      {
        if (this._invalidNewValueAttributes == null)
          this._invalidNewValueAttributes = new DataCollection<string>();
        return this._invalidNewValueAttributes;
      }
    }

    /// <summary>Gets a list of deleted attributes.</summary>
    /// <returns>Type: Returns_DictionaryA dictionary containing the deleted attributes.</returns>
    [DataMember(Order = 60)]
    public Dictionary<int, string> DeletedAttributes
    {
      get
      {
        if (this._deletedAttributes == null)
          this._deletedAttributes = new Dictionary<int, string>();
        return this._deletedAttributes;
      }
    }

    [DataMember(Order = 70)]
    public int LocLabelLanguageCode { get; set; }
  }
}
