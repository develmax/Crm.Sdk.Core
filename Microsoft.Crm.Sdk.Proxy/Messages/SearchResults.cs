using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the results from the <see cref="T:Microsoft.Crm.Sdk.Messages.SearchRequest"></see> message.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class SearchResults : IExtensibleDataObject
  {
    private ExtensionDataObject _extensionDataObject;

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Crm.Sdk.Messages.SearchResults"></see> class.</summary>
    public SearchResults()
    {
      this.Proposals = new AppointmentProposal[0];
    }

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Crm.Sdk.Messages.SearchResults"></see> class setting the proposals and trace info properties.</summary>
    /// <param name="proposals">The set of proposed appointments that meet the appointment request criteria.</param>
    /// <param name="traceInfo">The results of the search.</param>
    public SearchResults(AppointmentProposal[] proposals, TraceInfo traceInfo)
    {
      this.Proposals = proposals;
      this.TraceInfo = traceInfo;
    }

    /// <summary>Gets the set of proposed appointments that meet the appointment request criteria.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Crm.Sdk.Messages.AppointmentProposal"></see>The set of proposed appointments that meet the appointment request criteria.</returns>
    [DataMember]
    public AppointmentProposal[] Proposals { get; set; }

    /// <summary>Gets information regarding the results of the search.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Crm.Sdk.Messages.TraceInfo"></see>The information regarding the results of the search.</returns>
    [DataMember]
    public TraceInfo TraceInfo { get; set; }

    /// <summary>ExtensionData</summary>
    /// <returns>Type: Returns_ExtensionDataObjectThe the structure that contains extra data.</returns>
    public ExtensionDataObject ExtensionData
    {
      get
      {
        return this._extensionDataObject;
      }
      set
      {
        this._extensionDataObject = value;
      }
    }
  }
}
