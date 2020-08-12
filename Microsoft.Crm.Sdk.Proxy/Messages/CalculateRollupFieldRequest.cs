// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Sdk.Messages.CalculateRollupFieldRequest
// Assembly: Microsoft.Crm.Sdk.Proxy, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F3ED665D-73A2-4475-A0DE-3A25E42323B8
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Crm.Sdk.Proxy.dll

using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to calculate the value of a rollup attribute.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class CalculateRollupFieldRequest : OrganizationRequest
  {
    /// <summary>Gets or sets a reference to the record containing the rollup attribute to calculate. Required.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.EntityReference"></see>A reference to the record containing the rollup attribute to calculate.</returns>
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

    /// <summary>Gets or sets logical name of the attribute to calculate. Required.</summary>
    /// <returns>Type: Returns_StringThe logical name of the attribute to calculate.</returns>
    public string FieldName
    {
      get
      {
        return this.Parameters.Contains(nameof (FieldName)) ? (string) this.Parameters[nameof (FieldName)] : (string) null;
      }
      set
      {
        this.Parameters[nameof (FieldName)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.CalculateRollupFieldRequest"></see> class.</summary>
    public CalculateRollupFieldRequest()
    {
      this.RequestName = "CalculateRollupField";
      this.Target = (EntityReference) null;
      this.FieldName = (string) null;
    }
  }
}
