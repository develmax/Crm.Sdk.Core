using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>deprecated Contains the data that is needed to convert a kit to a product.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class ConvertKitToProductRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the ID of the kit. Required.</summary>
    /// <returns>Type: Returns_GuidThe ID of the kit that corresponds to the Product.ProductId attribute, which is the primary key for the Product entity.</returns>
    public Guid KitId
    {
      get
      {
        return this.Parameters.Contains(nameof (KitId)) ? (Guid) this.Parameters[nameof (KitId)] : new Guid();
      }
      set
      {
        this.Parameters[nameof (KitId)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.ConvertKitToProductRequest"></see> class.</summary>
    public ConvertKitToProductRequest()
    {
      this.RequestName = "ConvertKitToProduct";
      this.KitId = new Guid();
    }
  }
}
