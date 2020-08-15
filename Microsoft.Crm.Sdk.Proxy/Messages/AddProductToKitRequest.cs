using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>deprecated Use the ProductAssociation entity. Contains the data that is needed to add a product to a kit.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class AddProductToKitRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the ID of the kit. Required.</summary>
    /// <returns>Type: Returns_Guid
    /// The ID of the kit that corresponds to the Product.ProductId attribute, which is the primary key for the Product entity.</returns>
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

    /// <summary>Gets or sets the ID of the product. Required.</summary>
    /// <returns>Type: Returns_Guid
    /// The ID of the product that corresponds to the Product.ProductId attribute, which is the primary key for the Product entity.</returns>
    public Guid ProductId
    {
      get
      {
        return this.Parameters.Contains(nameof (ProductId)) ? (Guid) this.Parameters[nameof (ProductId)] : new Guid();
      }
      set
      {
        this.Parameters[nameof (ProductId)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.AddProductToKitRequest"></see> class.</summary>
    public AddProductToKitRequest()
    {
      this.RequestName = "AddProductToKit";
      this.KitId = new Guid();
      this.ProductId = new Guid();
    }
  }
}
