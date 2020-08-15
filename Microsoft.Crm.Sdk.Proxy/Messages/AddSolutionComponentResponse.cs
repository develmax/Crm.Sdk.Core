using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Crm.Sdk.Messages.AddSolutionComponentRequest"></see> message.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class AddSolutionComponentResponse : OrganizationResponse
  {
    /// <summary>Returns the ID of the new solution component record.</summary>
    /// <returns>Type: Returns_Guid
    /// The ID of the new solution component record. This corresponds to the SolutionComponent. SolutionComponentId attribute, which is the primary key for the SolutionComponent entity.</returns>
    public Guid id
    {
      get
      {
        return this.Results.Contains(nameof (id)) ? (Guid) this.Results[nameof (id)] : new Guid();
      }
    }
  }
}
