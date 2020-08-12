// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Sdk.Messages.RetrieveMissingDependenciesRequest
// Assembly: Microsoft.Crm.Sdk.Proxy, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F3ED665D-73A2-4475-A0DE-3A25E42323B8
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Crm.Sdk.Proxy.dll

using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  retrieve any required solution components that are not included in the solution. </summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RetrieveMissingDependenciesRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the name of the solution. Required.</summary>
    /// <returns>Type: Returns_StringThe name of the solution. Required.</returns>
    public string SolutionUniqueName
    {
      get
      {
        return this.Parameters.Contains(nameof (SolutionUniqueName)) ? (string) this.Parameters[nameof (SolutionUniqueName)] : (string) null;
      }
      set
      {
        this.Parameters[nameof (SolutionUniqueName)] = (object) value;
      }
    }

    /// <summary>constructor_initializes<see cref="T:Microsoft.Crm.Sdk.Messages.RetrieveMissingDependenciesRequest"></see> class</summary>
    public RetrieveMissingDependenciesRequest()
    {
      this.RequestName = "RetrieveMissingDependencies";
      this.SolutionUniqueName = (string) null;
    }
  }
}
