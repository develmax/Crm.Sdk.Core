using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains a collection of <see cref="T:Microsoft.Crm.Sdk.Messages.AuditDetail"></see> objects.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class AuditDetailCollection : IExtensibleDataObject
  {
    private ExtensionDataObject _extensionDataObject;
    private DataCollection<AuditDetail> _auditDetails;

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.AuditDetailCollection"></see> class.</summary>
    public AuditDetailCollection()
    {
      this._auditDetails = new DataCollection<AuditDetail>();
    }

    /// <summary>Gets or sets the element at the specified index.</summary>
    /// <returns>Type:<see cref="T:Microsoft.Crm.Sdk.Messages.AuditDetail"></see>
    /// The element at the specified index.</returns>
    /// <param name="index">Type: Returns_Int32. The element index.</param>
    public AuditDetail this[int index]
    {
      get
      {
        return this._auditDetails[index];
      }
      set
      {
        this._auditDetails[index] = value;
      }
    }

    /// <summary>Adds an <see cref="T:Microsoft.Crm.Sdk.Messages.AuditDetail"></see> object to the <see cref="P:Microsoft.Crm.Sdk.Messages.AuditDetailCollection.AuditDetails"></see> collection.</summary>
    /// <param name="auditDetail">An object that contains change details.</param>
    public void Add(AuditDetail auditDetail)
    {
      this._auditDetails.Add(auditDetail);
    }

    /// <summary>Gets the AuditDetail collection.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.DataCollection`1"></see>&lt;<see cref="T:Microsoft.Crm.Sdk.Messages.AuditDetail"></see>&gt;The collection of <see cref="T:Microsoft.Crm.Sdk.Messages.AuditDetail"></see> instances.</returns>
    [DataMember]
    public DataCollection<AuditDetail> AuditDetails
    {
      get
      {
        if (this._auditDetails == null)
          this._auditDetails = new DataCollection<AuditDetail>();
        return this._auditDetails;
      }
      private set
      {
        this._auditDetails = value;
      }
    }

    /// <summary>Indicates the number of elements in the <see cref="P:Microsoft.Crm.Sdk.Messages.AuditDetailCollection.AuditDetails"></see> collection.</summary>
    /// <returns>Type: Returns_Int32The number of elements in the collection.</returns>
    public int Count
    {
      get
      {
        return this._auditDetails.Count;
      }
    }

    /// <summary>Indicates whether more records exist.</summary>
    /// <returns>Type: Returns_Booleantrue if more records exist; otherwise, false.</returns>
    [DataMember]
    public bool MoreRecords { get; set; }

    /// <summary>Gets or sets a paging cookie.</summary>
    /// <returns>Type: Returns_String
    /// The paging cookie value.</returns>
    [DataMember]
    public string PagingCookie { get; set; }

    /// <summary>Gets or sets the total record count in the collection.</summary>
    /// <returns>Type: Returns_Int32The total record count in the collection.</returns>
    [DataMember]
    public int TotalRecordCount { get; set; }

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
