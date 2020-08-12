// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Sdk.Messages.IsComponentCustomizableRequest
// Assembly: Microsoft.Crm.Sdk.Proxy, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F3ED665D-73A2-4475-A0DE-3A25E42323B8
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Crm.Sdk.Proxy.dll

using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  determine whether a solution component is customizable. </summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class IsComponentCustomizableRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the ID of the solution component. Required.</summary>
    /// <returns>Type: Returns_GuidThe ID of the solution component. This corresponds to the SolutionComponent. SolutionComponentId attribute, which is the primary key for the SolutionComponent entity.</returns>
    public Guid ComponentId
    {
      get
      {
        return this.Parameters.Contains(nameof (ComponentId)) ? (Guid) this.Parameters[nameof (ComponentId)] : new Guid();
      }
      set
      {
        this.Parameters[nameof (ComponentId)] = (object) value;
      }
    }

    /// <summary>Gets or sets the value that represents the solution component. Required.</summary>
    /// <returns>Type: Returns_Int32The value that represents the solution component. Required.</returns>
    public int ComponentType
    {
      get
      {
        return this.Parameters.Contains(nameof (ComponentType)) ? (int) this.Parameters[nameof (ComponentType)] : 0;
      }
      set
      {
        this.Parameters[nameof (ComponentType)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Crm.Sdk.Messages.IsComponentCustomizableRequest"></see> class.</summary>
    public IsComponentCustomizableRequest()
    {
      this.RequestName = "IsComponentCustomizable";
      this.ComponentId = new Guid();
      this.ComponentType = 0;
    }
  }
}
