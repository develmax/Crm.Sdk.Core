// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Sdk.Messages.WinQuoteRequest
// Assembly: Microsoft.Crm.Sdk.Proxy, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F3ED665D-73A2-4475-A0DE-3A25E42323B8
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Crm.Sdk.Proxy.dll

using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to set the state of a quote to Won.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class WinQuoteRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the quote close activity associated with this state change. Required.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Entity"></see>The quote close activity associated with this state change. This must be an instance of the QuoteClose class, which is a subclass of the Entity class.</returns>
    public Entity QuoteClose
    {
      get
      {
        return this.Parameters.Contains(nameof (QuoteClose)) ? (Entity) this.Parameters[nameof (QuoteClose)] : (Entity) null;
      }
      set
      {
        this.Parameters[nameof (QuoteClose)] = (object) value;
      }
    }

    /// <summary>Gets or sets a new status of the quote. Required.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.OptionSetValue"></see>The new status of the quote.</returns>
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

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.WinQuoteRequest"></see> class.</summary>
    public WinQuoteRequest()
    {
      this.RequestName = "WinQuote";
      this.QuoteClose = (Entity) null;
      this.Status = (OptionSetValue) null;
    }
  }
}
