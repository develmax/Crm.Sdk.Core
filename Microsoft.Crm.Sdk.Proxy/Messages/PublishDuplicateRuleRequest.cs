using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  submit an asynchronous job to publish a duplicate rule.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class PublishDuplicateRuleRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the ID of the duplicate rule to be published. Required.</summary>
    /// <returns>Type: Returns_GuidThe ID of the duplicate rule to be published. This corresponds to the DuplicateRule.DuplicateRuleId attribute, which is the primary key for the DuplicateRule entity.</returns>
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

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Crm.Sdk.Messages.PublishDuplicateRuleRequest"></see> class.</summary>
    public PublishDuplicateRuleRequest()
    {
      this.RequestName = "PublishDuplicateRule";
      this.DuplicateRuleId = new Guid();
    }
  }
}
