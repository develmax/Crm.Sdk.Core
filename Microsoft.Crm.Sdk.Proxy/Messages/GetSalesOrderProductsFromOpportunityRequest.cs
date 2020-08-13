﻿// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Sdk.Messages.GetSalesOrderProductsFromOpportunityRequest
// Assembly: Microsoft.Crm.Sdk.Proxy, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F3ED665D-73A2-4475-A0DE-3A25E42323B8
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Crm.Sdk.Proxy.dll

using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  retrieve the products from an opportunity and copy them to the sales order (order).</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class GetSalesOrderProductsFromOpportunityRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the ID of the opportunity.</summary>
    /// <returns>Type: Returns_GuidThe ID of the opportunity. This corresponds to the Opportunity.OpportunityId attribute, which is the primary key for the Opportunity entity.</returns>
    public Guid OpportunityId
    {
      get
      {
        return this.Parameters.Contains(nameof (OpportunityId)) ? (Guid) this.Parameters[nameof (OpportunityId)] : new Guid();
      }
      set
      {
        this.Parameters[nameof (OpportunityId)] = (object) value;
      }
    }

    /// <summary>Gets or sets the ID of the sales order (order).</summary>
    /// <returns>Type: Returns_GuidThe ID of the sales order (order). This corresponds to the SalesOrder.SalesOrderId attribute, which is the primary key for the SalesOrder entity.</returns>
    public Guid SalesOrderId
    {
      get
      {
        return this.Parameters.Contains(nameof (SalesOrderId)) ? (Guid) this.Parameters[nameof (SalesOrderId)] : new Guid();
      }
      set
      {
        this.Parameters[nameof (SalesOrderId)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Crm.Sdk.Messages.GetSalesOrderProductsFromOpportunityRequest"></see> class.</summary>
    public GetSalesOrderProductsFromOpportunityRequest()
    {
      this.RequestName = "GetSalesOrderProductsFromOpportunity";
      this.OpportunityId = new Guid();
      this.SalesOrderId = new Guid();
    }
  }
}