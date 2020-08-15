using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the possible values for the depth of a privilege within a role. This enumeration is used to compare and set values in records returned from Fetch or QueryExpression queries. If you use LINQ, the privilege depth is returned as a bit mask. In this case you can use the following constants to determine the privilege depth. public const int BASIC_MASK = 0x00000001; public const int LOCAL_MASK = 0x00000002; public const int DEEP_MASK = 0x00000004; public const int GLOBAL_MASK = 0x00000008;</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public enum PrivilegeDepth
  {
    /// <summary>Indicates basic privileges. Users who have basic privileges can only use privileges to perform actions on objects that are owned by, or shared with, the user. Value = 0.</summary>
    [EnumMember] Basic,
    /// <summary>Indicates local privileges. Users who have local privileges can only use privileges to perform actions on data and objects that are in the user's current business unit. Value = 1.</summary>
    [EnumMember] Local,
    /// <summary>Indicates deep privileges. Users who have deep privileges can perform actions on all objects in the user's current business units and all objects down the hierarchy of business units. Value = 2.</summary>
    [EnumMember] Deep,
    /// <summary>Indicates global privileges. Users who have global privileges can perform actions on data and objects anywhere within the organization regardless of the business unit or user to which it belongs. Value = 3.</summary>
    [EnumMember] Global,
  }
}
