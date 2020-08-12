// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Sdk.Messages.InstantiateFiltersRequest
// Assembly: Microsoft.Crm.Sdk.Proxy, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F3ED665D-73A2-4475-A0DE-3A25E42323B8
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Crm.Sdk.Proxy.dll

using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  instantiate a set of filters for pn_crm_for_outlook_short for the specified user.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class InstantiateFiltersRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the set of filters to instantiate for the user.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.EntityReferenceCollection"></see>The set of filters to instantiate for the user. This must be a collection of entity references for the SavedQuery entity and the SavedQuery.Type attribute value for each must be <see cref="F:Microsoft.Crm.Sdk.SavedQueryQueryType.OutlookFilters"></see> or <see cref="F:Microsoft.Crm.Sdk.SavedQueryQueryType.OfflineFilters"></see>.</returns>
    public EntityReferenceCollection TemplateCollection
    {
      get
      {
        return this.Parameters.Contains(nameof (TemplateCollection)) ? (EntityReferenceCollection) this.Parameters[nameof (TemplateCollection)] : (EntityReferenceCollection) null;
      }
      set
      {
        this.Parameters[nameof (TemplateCollection)] = (object) value;
      }
    }

    /// <summary>Gets or sets the ID of the user that will own the user query records created.</summary>
    /// <returns>Type: Returns_GuidThe user that will own the user query records created. This corresponds to the SystemUser.SystemUserId property, which is the primary key for the SystemUser entity.</returns>
    public Guid UserId
    {
      get
      {
        return this.Parameters.Contains(nameof (UserId)) ? (Guid) this.Parameters[nameof (UserId)] : new Guid();
      }
      set
      {
        this.Parameters[nameof (UserId)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.InstantiateFiltersRequest"></see> class.</summary>
    public InstantiateFiltersRequest()
    {
      this.RequestName = "InstantiateFilters";
      this.TemplateCollection = (EntityReferenceCollection) null;
      this.UserId = new Guid();
    }
  }
}
