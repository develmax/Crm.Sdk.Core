using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the possible sources of a bulk operation.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public enum BulkOperationSource
  {
    /// <summary>The bulk operation is to distribute a quick campaign to members of a list of accounts, contacts, or leads that are selected by a query. Value = 0.</summary>
    [EnumMember] QuickCampaign,
    /// <summary>The bulk operation is for distributing a campaign activity to members of a list. Value = 1.</summary>
    [EnumMember] CampaignActivity,
  }
}
