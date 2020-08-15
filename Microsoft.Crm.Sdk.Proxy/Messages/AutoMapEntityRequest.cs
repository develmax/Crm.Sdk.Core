using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to generate a new set of attribute mappings based on the metadata.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class AutoMapEntityRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the ID of the entity map to overwrite when the automated mapping is performed. Required.</summary>
    /// <returns>Type: Returns_GuidThe ID of the entity map.</returns>
    public Guid EntityMapId
    {
      get
      {
        return this.Parameters.Contains(nameof (EntityMapId)) ? (Guid) this.Parameters[nameof (EntityMapId)] : new Guid();
      }
      set
      {
        this.Parameters[nameof (EntityMapId)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.AutoMapEntityRequest"></see> class.</summary>
    public AutoMapEntityRequest()
    {
      this.RequestName = "AutoMapEntity";
      this.EntityMapId = new Guid();
    }
  }
}
