using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Identifies a pn_MS_SQL_Server  partition that is used to store changes to entity data records.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class AuditPartitionDetail : IExtensibleDataObject
  {
    private ExtensionDataObject _extensionDataObject;

    /// <summary>Gets or sets the sequence (serial) number of the partition.</summary>
    /// <returns>Type: Returns_Int32The sequence (serial) number of the partition.</returns>
    [DataMember]
    public int PartitionNumber { get; set; }

    /// <summary>Gets or sets the creation date and time of the first audit record in the partition.</summary>
    /// <returns>Type: Returns_Nullable&lt;Returns_DateTime&gt;The creation date and time of the first audit record in the partition.</returns>
    [DataMember]
    public DateTime? StartDate { get; set; }

    /// <summary>Gets or sets the end date and time for the last audit record in the partition.</summary>
    /// <returns>Type: Returns_Nullable&lt;Returns_DateTime&gt;
    /// The date and time of the last audit record in the partition.</returns>
    [DataMember]
    public DateTime? EndDate { get; set; }

    /// <summary>Gets or sets the size, in bytes, of the partition.</summary>
    /// <returns>Type: Returns_Int64The size, in bytes, of the partition.</returns>
    [DataMember]
    public long Size { get; set; }

    /// <summary>ExtensionData</summary>
    /// <returns>Type:  Returns_ExtensionDataObjectA structure that contains extra data.</returns>
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
