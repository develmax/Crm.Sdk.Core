// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Sdk.Messages.RetrieveEntityRibbonRequest
// Assembly: Microsoft.Crm.Sdk.Proxy, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F3ED665D-73A2-4475-A0DE-3A25E42323B8
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Crm.Sdk.Proxy.dll

using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  retrieve ribbon definitions for an entity.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RetrieveEntityRibbonRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the logical name of an entity in order to retrieve a ribbon definition. Required.</summary>
    /// <returns>Type: Returns_StringThe logical name of an entity in order to retrieve a ribbon definition. Required.</returns>
    public string EntityName
    {
      get
      {
        return this.Parameters.Contains(nameof (EntityName)) ? (string) this.Parameters[nameof (EntityName)] : (string) null;
      }
      set
      {
        this.Parameters[nameof (EntityName)] = (object) value;
      }
    }

    /// <summary>Gets or sets a filter to retrieve a specific set of ribbon definitions for an entity. Required.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Crm.Sdk.Messages.RibbonLocationFilters"></see>A filter to retrieve a specific set of ribbon definitions for an entity. Required.</returns>
    public RibbonLocationFilters RibbonLocationFilter
    {
      get
      {
        return this.Parameters.Contains(nameof (RibbonLocationFilter)) ? (RibbonLocationFilters) this.Parameters[nameof (RibbonLocationFilter)] : (RibbonLocationFilters) 0;
      }
      set
      {
        this.Parameters[nameof (RibbonLocationFilter)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Crm.Sdk.Messages.RetrieveEntityRibbonRequest"></see> class.</summary>
    public RetrieveEntityRibbonRequest()
    {
      this.RequestName = "RetrieveEntityRibbon";
      this.EntityName = (string) null;
      this.RibbonLocationFilter = (RibbonLocationFilters) 0;
    }
  }
}
