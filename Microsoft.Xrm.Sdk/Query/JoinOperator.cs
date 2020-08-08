using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Query
{
    /// <summary>Contains the possible values for a join operator in a <see cref="T:Microsoft.Xrm.Sdk.Query.LinkEntity"></see>. </summary>
    [DataContract(Name = "JoinOperator", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
    public enum JoinOperator
    {
        /// <summary>The values in the attributes being joined are compared using a comparison operator. Value = 0.</summary>
        [EnumMember] Inner,
        /// <summary>All instances of the entity in the FROM clause are returned if they meet WHERE or HAVING search conditions. Value = 1.</summary>
        [EnumMember] LeftOuter,
        /// <summary>Only one value of the two joined attributes is returned if an equal-join operation is performed and the two values are identical. Value = 0.</summary>
        [EnumMember] Natural,
    }
}