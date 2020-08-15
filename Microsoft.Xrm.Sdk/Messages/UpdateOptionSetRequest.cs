using Microsoft.Xrm.Sdk.Metadata;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to update the definition of a global option set. </summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class UpdateOptionSetRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the metadata for the global option set. Required.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Metadata.OptionSetMetadataBase"></see>the metadata for the global option set. Required.</returns>
    public OptionSetMetadataBase OptionSet
    {
      get
      {
        return this.Parameters.Contains(nameof (OptionSet)) ? (OptionSetMetadataBase) this.Parameters[nameof (OptionSet)] : (OptionSetMetadataBase) null;
      }
      set
      {
        this.Parameters[nameof (OptionSet)] = (object) value;
      }
    }

    /// <summary>Gets or sets whether the label metadata will be merged or overwritten. Required.</summary>
    /// <returns>Type: Returns_Booleantrue if the label metadata will be merged or overwritten; otherwise, false.</returns>
    public bool MergeLabels
    {
      get
      {
        return this.Parameters.Contains(nameof (MergeLabels)) && (bool) this.Parameters[nameof (MergeLabels)];
      }
      set
      {
        this.Parameters[nameof (MergeLabels)] = (object) value;
      }
    }

    /// <summary>Gets or sets the name of a solution to associate the global option set with. Optional.</summary>
    /// <returns>Type: Returns_StringThe name of a solution to associate the global option set with. Optional.</returns>
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

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Xrm.Sdk.Messages.UpdateOptionSetRequest"></see> class</summary>
    public UpdateOptionSetRequest()
    {
      this.RequestName = "UpdateOptionSet";
      this.OptionSet = (OptionSetMetadataBase) null;
      this.MergeLabels = false;
    }
  }
}
