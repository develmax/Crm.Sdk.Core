using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>internal</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RetrieveFormXmlResponse : OrganizationResponse
  {
    /// <summary>internal</summary>
    /// <returns>Type: Returns_Stringinternal</returns>
    public string FormXml
    {
      get
      {
        return this.Results.Contains(nameof (FormXml)) ? (string) this.Results[nameof (FormXml)] : (string) null;
      }
    }

    /// <summary>internal</summary>
    /// <returns>Type: Returns_Int32internal</returns>
    public int CustomizationLevel
    {
      get
      {
        return this.Results.Contains(nameof (CustomizationLevel)) ? (int) this.Results[nameof (CustomizationLevel)] : 0;
      }
    }

    /// <summary>internal</summary>
    /// <returns>Type: Returns_Int32internal</returns>
    public int ComponentState
    {
      get
      {
        return this.Results.Contains(nameof (ComponentState)) ? (int) this.Results[nameof (ComponentState)] : 0;
      }
    }

    /// <summary>internal</summary>
    /// <returns>Type: Returns_Guidinternal</returns>
    public Guid SolutionId
    {
      get
      {
        return this.Results.Contains(nameof (SolutionId)) ? (Guid) this.Results[nameof (SolutionId)] : new Guid();
      }
    }
  }
}
