using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  retrieve a list of the solution component dependencies that can prevent you from uninstalling a managed solution. </summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RetrieveDependenciesForUninstallRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the name of the managed solution. Required.</summary>
    /// <returns>Type: Returns_StringThe name of the managed solution. Required.</returns>
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

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Crm.Sdk.Messages.RetrieveDependenciesForUninstallRequest"></see> class.</summary>
    public RetrieveDependenciesForUninstallRequest()
    {
      this.RequestName = "RetrieveDependenciesForUninstall";
      this.SolutionUniqueName = (string) null;
    }
  }
}
