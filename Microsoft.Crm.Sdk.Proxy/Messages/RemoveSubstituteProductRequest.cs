using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>deprecated Use the ProductSubstitute entity.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RemoveSubstituteProductRequest : OrganizationRequest
  {
    /// <summary>deprecated Use the ProductSubstitute entity.</summary>
    /// <returns>Type: Returns_Guid</returns>
    public Guid ProductId
    {
      get
      {
        return this.Parameters.Contains(nameof (ProductId)) ? (Guid) this.Parameters[nameof (ProductId)] : new Guid();
      }
      set
      {
        this.Parameters[nameof (ProductId)] = (object) value;
      }
    }

    /// <summary>deprecated Use the ProductSubstitute entity.</summary>
    /// <returns>Type: Returns_Guid</returns>
    public Guid SubstituteId
    {
      get
      {
        return this.Parameters.Contains(nameof (SubstituteId)) ? (Guid) this.Parameters[nameof (SubstituteId)] : new Guid();
      }
      set
      {
        this.Parameters[nameof (SubstituteId)] = (object) value;
      }
    }

    /// <summary>deprecated Use the ProductSubstitute entity.</summary>
    public RemoveSubstituteProductRequest()
    {
      this.RequestName = "RemoveSubstituteProduct";
      this.ProductId = new Guid();
      this.SubstituteId = new Guid();
    }
  }
}
