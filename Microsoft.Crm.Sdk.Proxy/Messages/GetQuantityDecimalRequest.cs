// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Sdk.Messages.GetQuantityDecimalRequest
// Assembly: Microsoft.Crm.Sdk.Proxy, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F3ED665D-73A2-4475-A0DE-3A25E42323B8
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Crm.Sdk.Proxy.dll

using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  get the quantity decimal value of a product for the specified entity in the target.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class GetQuantityDecimalRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the target record for this request. Required.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.EntityReference"></see>The target record for this request. This must be an entity reference for Invoice, Opportunity, Quote, or Salesorder entity.</returns>
    public EntityReference Target
    {
      get
      {
        return this.Parameters.Contains(nameof (Target)) ? (EntityReference) this.Parameters[nameof (Target)] : (EntityReference) null;
      }
      set
      {
        this.Parameters[nameof (Target)] = (object) value;
      }
    }

    /// <summary>Gets or sets the ID of the product. Required.</summary>
    /// <returns>Type: Returns_GuidThe ID of the product. This corresponds to the Product.ProductId attribute, which is the primary key for the Product entity.</returns>
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

    /// <summary>Gets or sets the ID of the unit of measure (unit). Required.</summary>
    /// <returns>Type: Returns_GuidThe ID of the unit of measure (unit). This corresponds to the UoM.UoMId attribute, which is the primary key for the UoM entity.</returns>
    public Guid UoMId
    {
      get
      {
        return this.Parameters.Contains(nameof (UoMId)) ? (Guid) this.Parameters[nameof (UoMId)] : new Guid();
      }
      set
      {
        this.Parameters[nameof (UoMId)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Crm.Sdk.Messages.GetQuantityDecimalRequest"></see> class.</summary>
    public GetQuantityDecimalRequest()
    {
      this.RequestName = "GetQuantityDecimal";
      this.Target = (EntityReference) null;
      this.ProductId = new Guid();
      this.UoMId = new Guid();
    }
  }
}
