// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Sdk.Messages.VerifyProcessStateDataRequest
// Assembly: Microsoft.Crm.Sdk.Proxy, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F3ED665D-73A2-4475-A0DE-3A25E42323B8
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Crm.Sdk.Proxy.dll

using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>internal</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class VerifyProcessStateDataRequest : OrganizationRequest
  {
    /// <summary>internal</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.EntityReference"></see></returns>
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

    /// <summary>internal</summary>
    /// <returns>Type: Returns_String</returns>
    public string ProcessState
    {
      get
      {
        return this.Parameters.Contains(nameof (ProcessState)) ? (string) this.Parameters[nameof (ProcessState)] : (string) null;
      }
      set
      {
        this.Parameters[nameof (ProcessState)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.VerifyProcessStateDataRequest"></see> class.</summary>
    public VerifyProcessStateDataRequest()
    {
      this.RequestName = "VerifyProcessStateData";
      this.Target = (EntityReference) null;
      this.ProcessState = (string) null;
    }
  }
}
