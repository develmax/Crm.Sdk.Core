// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Sdk.Messages.ConvertSalesOrderToInvoiceRequest
// Assembly: Microsoft.Crm.Sdk.Proxy, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F3ED665D-73A2-4475-A0DE-3A25E42323B8
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Crm.Sdk.Proxy.dll

using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to convert a sales order to an invoice.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class ConvertSalesOrderToInvoiceRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the ID of the sales order (order) to convert. Required.</summary>
    /// <returns>Type: Returns_GuidThe ID of the sales order (order) to convert that corresponds to the SalesOrder.SalesOrderId attribute, which is the primary key for the SalesOrder entity.</returns>
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

    /// <summary>Gets or sets the collection of attributes to retrieve from the resulting invoice. Required.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Query.ColumnSet"></see>The collection of attributes to retrieve from the resulting invoice.</returns>
    public ColumnSet ColumnSet
    {
      get
      {
        return this.Parameters.Contains(nameof (ColumnSet)) ? (ColumnSet) this.Parameters[nameof (ColumnSet)] : (ColumnSet) null;
      }
      set
      {
        this.Parameters[nameof (ColumnSet)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.ConvertSalesOrderToInvoiceRequest"></see> class.</summary>
    public ConvertSalesOrderToInvoiceRequest()
    {
      this.RequestName = "ConvertSalesOrderToInvoice";
      this.SalesOrderId = new Guid();
      this.ColumnSet = (ColumnSet) null;
    }
  }
}
