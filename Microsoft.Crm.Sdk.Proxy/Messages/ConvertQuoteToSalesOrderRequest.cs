using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to convert a quote to a sales order.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class ConvertQuoteToSalesOrderRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the ID of the quote to convert. Required.</summary>
    /// <returns>Type: Returns_GuidThe ID of the quote to convert that corresponds to the Quote.QuoteId attribute, which is the primary key for the Quote entity..</returns>
    public Guid QuoteId
    {
      get
      {
        return this.Parameters.Contains(nameof (QuoteId)) ? (Guid) this.Parameters[nameof (QuoteId)] : new Guid();
      }
      set
      {
        this.Parameters[nameof (QuoteId)] = (object) value;
      }
    }

    /// <summary>Gets or sets the collection of attributes to retrieve in the resulting sales order (order). Required.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Query.ColumnSet"></see>The collection of attributes to retrieve in the resulting sales order (order).</returns>
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

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.ConvertQuoteToSalesOrderRequest"></see> class.</summary>
    public ConvertQuoteToSalesOrderRequest()
    {
      this.RequestName = "ConvertQuoteToSalesOrder";
      this.QuoteId = new Guid();
      this.ColumnSet = (ColumnSet) null;
    }
  }
}
