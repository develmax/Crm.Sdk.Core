using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>deprecated Use the <see cref="T:Microsoft.Xrm.Sdk.Messages.UpdateRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class MakeAvailableToOrganizationTemplateRequest : OrganizationRequest
  {
    /// <summary>deprecated</summary>
    /// <returns>Type: Returns_Guid</returns>
    public Guid TemplateId
    {
      get
      {
        return this.Parameters.Contains(nameof (TemplateId)) ? (Guid) this.Parameters[nameof (TemplateId)] : new Guid();
      }
      set
      {
        this.Parameters[nameof (TemplateId)] = (object) value;
      }
    }

    /// <summary>deprecated</summary>
    public MakeAvailableToOrganizationTemplateRequest()
    {
      this.RequestName = "MakeAvailableToOrganizationTemplate";
      this.TemplateId = new Guid();
    }
  }
}
