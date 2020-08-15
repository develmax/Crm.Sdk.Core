using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to copy an existing product family, product, or bundle under the same parent record.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class CloneProductRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the source product family, product, or bundle record that you want to clone.</summary>
    /// <returns>Type <see cref="T:Microsoft.Xrm.Sdk.EntityReference"></see>The source product family, product, or bundle record that you want to clone.</returns>
    public EntityReference Source
    {
      get
      {
        return this.Parameters.Contains(nameof (Source)) ? (EntityReference) this.Parameters[nameof (Source)] : (EntityReference) null;
      }
      set
      {
        this.Parameters[nameof (Source)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.CloneProductRequest"></see> class.</summary>
    public CloneProductRequest()
    {
      this.RequestName = "CloneProduct";
      this.Source = (EntityReference) null;
    }
  }
}
