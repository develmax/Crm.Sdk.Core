// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Sdk.Messages.AddProductToKitRequest
// Assembly: Microsoft.Crm.Sdk.Proxy, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F3ED665D-73A2-4475-A0DE-3A25E42323B8
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Crm.Sdk.Proxy.dll

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
