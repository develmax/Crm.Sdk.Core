using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Represents a proposed appointment time and date as a result of the <see cref="T:Microsoft.Crm.Sdk.Messages.SearchRequest"></see> message.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class AppointmentProposal : IExtensibleDataObject
  {
    private ExtensionDataObject _extensionDataObject;

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Crm.Sdk.Messages.AppointmentProposal"></see> class.</summary>
    public AppointmentProposal()
    {
    }

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Crm.Sdk.Messages.AppointmentProposal"></see> class setting the start, end, site ID, site name, and proposal parties.</summary>
    /// <param name="start">Type: Returns_Nullable&lt;Returns_DateTime&gt;. The proposed appointment start date and time.</param>
    /// <param name="proposalParties">Type: <see cref="T:Microsoft.Crm.Sdk.Messages.ProposalParty"></see>[]. An array of parties needed for the proposed appointment.</param>
    /// <param name="end">Type: Returns_Nullable&lt;Returns_DateTime&gt;. The proposed appointment end date and time.</param>
    /// <param name="siteId">Type: Returns_Guid. The ID of the site for the proposed appointment.</param>
    /// <param name="siteName">Type: Returns_String. The name of the site for the proposed appointment.</param>
    public AppointmentProposal(
      DateTime? start,
      DateTime? end,
      Guid siteId,
      string siteName,
      ProposalParty[] proposalParties)
    {
      this.Start = start;
      this.End = end;
      this.SiteId = siteId;
      this.SiteName = siteName;
      this.ProposalParties = proposalParties;
    }

    /// <summary>Gets or sets the proposed appointment start date and time.</summary>
    /// <returns>Type: Returns_Nullable&lt;Returns_DateTime&gt;The proposed appointment start date and time.</returns>
    [DataMember]
    public DateTime? Start { get; set; }

    /// <summary>Gets or sets the proposed appointment end date and time.</summary>
    /// <returns>Type: Returns_Nullable&lt;Returns_DateTime&gt;The proposed appointment end date and time.</returns>
    [DataMember]
    public DateTime? End { get; set; }

    /// <summary>Gets or sets the ID of the site for the proposed appointment.</summary>
    /// <returns>Type: Returns_Guid
    /// The ID of the site for the proposed appointment.</returns>
    [DataMember]
    public Guid SiteId { get; set; }

    /// <summary>Gets or sets the name of the site for the proposed appointment.</summary>
    /// <returns>Type: Returns_String
    /// The name of the site for the proposed appointment.</returns>
    [DataMember]
    public string SiteName { get; set; }

    /// <summary>Gets or sets an array of parties needed for the proposed appointment.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Crm.Sdk.Messages.ProposalParty"></see>[]The array of parties needed for the proposed appointment.</returns>
    [DataMember]
    public ProposalParty[] ProposalParties { get; set; }

    /// <summary>ExtensionData</summary>
    /// <returns>Type: Returns_ExtensionDataObject</returns>
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
