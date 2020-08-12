// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Sdk.Messages.FulfillSalesOrderRequest
// Assembly: Microsoft.Crm.Sdk.Proxy, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F3ED665D-73A2-4475-A0DE-3A25E42323B8
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Crm.Sdk.Proxy.dll

using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  fulfill the sales order (order).</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class FulfillSalesOrderRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the order close activity associated with the sales order (order) to be fulfilled. Required.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Entity"></see>The order close activity associated with the sales order (order) to be fulfilled, which must be an instance of the OrderClose class.</returns>
    public Entity OrderClose
    {
      get
      {
        return this.Parameters.Contains(nameof (OrderClose)) ? (Entity) this.Parameters[nameof (OrderClose)] : (Entity) null;
      }
      set
      {
        this.Parameters[nameof (OrderClose)] = (object) value;
      }
    }

    /// <summary>Gets or sets a status of the sales order (order). Required.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.OptionSetValue"></see>The status of the sales order (order).</returns>
    public OptionSetValue Status
    {
      get
      {
        return this.Parameters.Contains(nameof (Status)) ? (OptionSetValue) this.Parameters[nameof (Status)] : (OptionSetValue) null;
      }
      set
      {
        this.Parameters[nameof (Status)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Crm.Sdk.Messages.FulfillSalesOrderRequest"></see> class.</summary>
    public FulfillSalesOrderRequest()
    {
      this.RequestName = "FulfillSalesOrder";
      this.OrderClose = (Entity) null;
      this.Status = (OptionSetValue) null;
    }
  }
}
