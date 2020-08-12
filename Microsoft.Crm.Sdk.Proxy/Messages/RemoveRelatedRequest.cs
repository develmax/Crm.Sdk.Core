// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Sdk.Messages.RemoveRelatedRequest
// Assembly: Microsoft.Crm.Sdk.Proxy, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F3ED665D-73A2-4475-A0DE-3A25E42323B8
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Crm.Sdk.Proxy.dll

using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Use the <see cref="T:Microsoft.Xrm.Sdk.Messages.DisassociateRequest"></see> class. Contains the data that is needed to  remove the relationship between the specified records for specific relationships. </summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RemoveRelatedRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the target records from which you want to remove specific related records.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.EntityReference"></see>The the target records from which you want to remove specific related records. This array must contain a set of entity references where the entities participate in a relationship.</returns>
    public EntityReference[] Target
    {
      get
      {
        return this.Parameters.Contains(nameof (Target)) ? (EntityReference[]) this.Parameters[nameof (Target)] : (EntityReference[]) null;
      }
      set
      {
        this.Parameters[nameof (Target)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Crm.Sdk.Messages.RemoveRelatedRequest"></see> class.</summary>
    public RemoveRelatedRequest()
    {
      this.RequestName = "RemoveRelated";
      this.Target = (EntityReference[]) null;
    }
  }
}
