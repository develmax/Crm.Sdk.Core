using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>deprecated Contains the data that is needed to convert a product to a kit.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class ConvertProductToKitRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the ID of the product. Required.</summary>
    /// <returns>Type: Returns_GuidThe ID of the product that corresponds to the Product.ProductId attribute, which is the primary key for the Product entity.</returns>
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

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.ConvertProductToKitRequest"></see> class.</summary>
    public ConvertProductToKitRequest()
    {
      this.RequestName = "ConvertProductToKit";
      this.ProductId = new Guid();
    }
  }
}
