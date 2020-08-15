using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Crm.Sdk.Messages.RemoveSolutionComponentRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RemoveSolutionComponentResponse : OrganizationResponse
  {
    /// <summary>Gets the ID value of the solution component that was removed.</summary>
    /// <returns>Type: Returns_GuidThe ID value of the solution component that was removed. This corresponds to the SolutionComponent.SolutionComponentId attribute, which is the primary key for the SolutionComponent entity.</returns>
    public Guid id
    {
      get
      {
        return this.Results.Contains(nameof (id)) ? (Guid) this.Results[nameof (id)] : new Guid();
      }
    }
  }
}
