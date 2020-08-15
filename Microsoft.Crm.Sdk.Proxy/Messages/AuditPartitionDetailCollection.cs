using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains a data collection of <see cref="T:Microsoft.Crm.Sdk.Messages.AuditDetail"></see> objects. </summary>
  [CollectionDataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class AuditPartitionDetailCollection : DataCollection<AuditPartitionDetail>, IExtensibleDataObject
  {
    private ExtensionDataObject _extensionDataObject;

    /// <summary>Gets or sets whether the partition change list is a logical collection.</summary>
    /// <returns>Type: Returns_Booleantrue if the audit partition list is a logical collection; otherwise, false.</returns>
    [DataMember]
    public bool IsLogicalCollection { get; set; }

    /// <summary>ExtensionData</summary>
    /// <returns>Returns_String</returns>
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
