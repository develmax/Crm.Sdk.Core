using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  export all translations for a specific solution to a compressed file.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class ExportTranslationRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the unique name for the unmanaged solution to export translations for. Required.</summary>
    /// <returns>Type: Returns_StringThe unique name for the unmanaged solution to export translations for. Required.</returns>
    public string SolutionName
    {
      get
      {
        return this.Parameters.Contains(nameof (SolutionName)) ? (string) this.Parameters[nameof (SolutionName)] : (string) null;
      }
      set
      {
        this.Parameters[nameof (SolutionName)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Crm.Sdk.Messages.ExportTranslationRequest"></see> class</summary>
    public ExportTranslationRequest()
    {
      this.RequestName = "ExportTranslation";
      this.SolutionName = (string) null;
    }
  }
}
