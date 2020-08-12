// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Sdk.Messages.RetrieveSharedPrincipalsAndAccessRequest
// Assembly: Microsoft.Crm.Sdk.Proxy, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F3ED665D-73A2-4475-A0DE-3A25E42323B8
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Crm.Sdk.Proxy.dll

using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to retrieve all security principals (users or teams) that have access to, and access rights for, the specified record.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RetrieveSharedPrincipalsAndAccessRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the target record for which you want to retrieve security principals (users and teams) and their access rights. </summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.EntityReference"></see>The target record for which you want to retrieve security principals (users and teams) and their access rights. This property must be an entity reference for an entity that supports this message. For a list of supported entity types, see the <see cref="T:Microsoft.Crm.Sdk.Messages.RetrieveSharedPrincipalsAndAccessRequest"></see> class.</returns>
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

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.RetrieveSharedPrincipalsAndAccessRequest"></see> class.</summary>
    public RetrieveSharedPrincipalsAndAccessRequest()
    {
      this.RequestName = "RetrieveSharedPrincipalsAndAccess";
      this.Target = (EntityReference) null;
    }
  }
}
