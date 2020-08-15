using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  submit an asynchronous job to unpublish a duplicate rule.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class UnpublishDuplicateRuleRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the ID of the duplicate rule to be unpublished. Required.</summary>
    /// <returns>Type: Returns_GuidThe ID of the duplicate rule to be unpublished. This corresponds to the DuplicateRule.DuplicateRuleId attribute, which is the primary key for the DuplicateRule entity.</returns>
    public Guid DuplicateRuleId
    {
      get
      {
        return this.Parameters.Contains(nameof (DuplicateRuleId)) ? (Guid) this.Parameters[nameof (DuplicateRuleId)] : new Guid();
      }
      set
      {
        this.Parameters[nameof (DuplicateRuleId)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Crm.Sdk.Messages.UnpublishDuplicateRuleRequest"></see> class.</summary>
    public UnpublishDuplicateRuleRequest()
    {
      this.RequestName = "UnpublishDuplicateRule";
      this.DuplicateRuleId = new Guid();
    }
  }
}
