using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the possible values for propagation ownership options.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public enum PropagationOwnershipOptions
  {
    /// <summary>There is no change in ownership for the created activities. Value = 0.</summary>
    [EnumMember] None,
    /// <summary>All created activities are assigned to the caller of the API. Value = 1.</summary>
    [EnumMember] Caller,
    /// <summary>Created activities are assigned to respective owners of target members. Value = 2.</summary>
    [EnumMember] ListMemberOwner,
  }
}
