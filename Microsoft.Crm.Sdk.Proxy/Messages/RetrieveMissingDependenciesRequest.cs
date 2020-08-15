using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  retrieve any required solution components that are not included in the solution. </summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RetrieveMissingDependenciesRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the name of the solution. Required.</summary>
    /// <returns>Type: Returns_StringThe name of the solution. Required.</returns>
    public string SolutionUniqueName
    {
      get
      {
        return this.Parameters.Contains(nameof (SolutionUniqueName)) ? (string) this.Parameters[nameof (SolutionUniqueName)] : (string) null;
      }
      set
      {
        this.Parameters[nameof (SolutionUniqueName)] = (object) value;
      }
    }

    /// <summary>constructor_initializes<see cref="T:Microsoft.Crm.Sdk.Messages.RetrieveMissingDependenciesRequest"></see> class</summary>
    public RetrieveMissingDependenciesRequest()
    {
      this.RequestName = "RetrieveMissingDependencies";
      this.SolutionUniqueName = (string) null;
    }
  }
}
