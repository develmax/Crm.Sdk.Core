using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  copy an existing contract and its line items.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class CloneContractRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the ID of the contract to be copied. Required.</summary>
    /// <returns>Type: Returns_GuidThe ID of the contract to be copied that corresponds to the Contract.ContractId attribute, which is the primary key for the Contract entity.</returns>
    public Guid ContractId
    {
      get
      {
        return this.Parameters.Contains(nameof (ContractId)) ? (Guid) this.Parameters[nameof (ContractId)] : new Guid();
      }
      set
      {
        this.Parameters[nameof (ContractId)] = (object) value;
      }
    }

    /// <summary>Gets or sets a value that indicates whether the canceled line items of the originating contract are to be included in the copy (clone). Required.</summary>
    /// <returns>Type: Returns_Booleantrue to include canceled line items, otherwise, false (default).</returns>
    public bool IncludeCanceledLines
    {
      get
      {
        return this.Parameters.Contains(nameof (IncludeCanceledLines)) && (bool) this.Parameters[nameof (IncludeCanceledLines)];
      }
      set
      {
        this.Parameters[nameof (IncludeCanceledLines)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.CloneContractRequest"></see> class.</summary>
    public CloneContractRequest()
    {
      this.RequestName = "CloneContract";
      this.ContractId = new Guid();
      this.IncludeCanceledLines = false;
    }
  }
}
