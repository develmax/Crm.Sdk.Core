using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  retrieve information about all global option sets. </summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class RetrieveAllOptionSetsRequest : OrganizationRequest
  {
    /// <summary>Gets or sets whether to retrieve the metadata that has not been published. Required.</summary>
    /// <returns>Type: Returns_Booleantrue if the metadata that has not been published should be retrieved; otherwise, false.</returns>
    public bool RetrieveAsIfPublished
    {
      get
      {
        return this.Parameters.Contains(nameof (RetrieveAsIfPublished)) && (bool) this.Parameters[nameof (RetrieveAsIfPublished)];
      }
      set
      {
        this.Parameters[nameof (RetrieveAsIfPublished)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Xrm.Sdk.Messages.RetrieveAllOptionSetsRequest"></see> class</summary>
    public RetrieveAllOptionSetsRequest()
    {
      this.RequestName = "RetrieveAllOptionSets";
      this.RetrieveAsIfPublished = false;
    }
  }
}
