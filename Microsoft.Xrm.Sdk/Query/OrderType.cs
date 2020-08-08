using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Query
{
    /// <summary>Contains the possible values for the order type in an <see cref="T:Microsoft.Xrm.Sdk.Query.OrderExpression"></see>. </summary>
    [DataContract(Name = "OrderType", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
    public enum OrderType
    {
        /// <summary>The values of the specified attribute should be sorted in ascending order, from lowest to highest. Value = 0.</summary>
        [EnumMember] Ascending,
        /// <summary>The values of the specified attribute should be sorted in descending order, from highest to lowest. Value = 1.</summary>
        [EnumMember] Descending,
    }
}