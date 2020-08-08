using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Query
{
    /// <summary>Contains the possible values for an operator in a <see cref="T:Microsoft.Xrm.Sdk.Query.FilterExpression"></see>. </summary>
    [DataContract(Name = "LogicalOperator", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
    public enum LogicalOperator
    {
        /// <summary>A logical AND operation is performed. Value = 0.</summary>
        [EnumMember] And,
        /// <summary>A logical OR operation is performed. Value = 1.</summary>
        [EnumMember] Or,
    }
}