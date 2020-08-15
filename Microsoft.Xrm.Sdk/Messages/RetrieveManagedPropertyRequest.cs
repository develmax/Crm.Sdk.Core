using System;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  retrieve a managed property definition.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class RetrieveManagedPropertyRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the name of the managed property. Optional.</summary>
    /// <returns>Type: Returns_StringThe name of the managed property. Optional.</returns>
    public string LogicalName
    {
      get
      {
        return this.Parameters.Contains(nameof (LogicalName)) ? (string) this.Parameters[nameof (LogicalName)] : (string) null;
      }
      set
      {
        this.Parameters[nameof (LogicalName)] = (object) value;
      }
    }

    /// <summary>Gets or sets the ID of the managed property. Required,</summary>
    /// <returns>Type: Returns_GuidThe ID of the managed property. This corresponds to the <see cref="T:Microsoft.Xrm.Sdk.Metadata.MetadataBase"></see>.<see cref="P:Microsoft.Xrm.Sdk.Metadata.MetadataBase.MetadataId"></see> for the managed property.</returns>
    public Guid MetadataId
    {
      get
      {
        return this.Parameters.Contains(nameof (MetadataId)) ? (Guid) this.Parameters[nameof (MetadataId)] : new Guid();
      }
      set
      {
        this.Parameters[nameof (MetadataId)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Xrm.Sdk.Messages.RetrieveManagedPropertyRequest"></see> class</summary>
    public RetrieveManagedPropertyRequest()
    {
      this.RequestName = "RetrieveManagedProperty";
      this.MetadataId = new Guid();
    }
  }
}
