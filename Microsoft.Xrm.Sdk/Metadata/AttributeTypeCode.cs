using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
    /// <summary>Describes the type of an attribute.</summary>
    [DataContract(Name = "AttributeTypeCode", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
    public enum AttributeTypeCode
    {
        /// <summary>A Boolean attribute. Value = 0.</summary>
        [EnumMember(Value = "Boolean")] Boolean,
        /// <summary>An attribute that represents a customer. Value = 1.</summary>
        [EnumMember(Value = "Customer")] Customer,
        /// <summary>A date/time attribute. Value = 2.</summary>
        [EnumMember(Value = "DateTime")] DateTime,
        /// <summary>A decimal attribute. Value = 3.</summary>
        [EnumMember(Value = "Decimal")] Decimal,
        /// <summary>A double attribute. Value = 4.</summary>
        [EnumMember(Value = "Double")] Double,
        /// <summary>An integer attribute. Value = 5.</summary>
        [EnumMember(Value = "Integer")] Integer,
        /// <summary>A lookup attribute. Value = 6.</summary>
        [EnumMember(Value = "Lookup")] Lookup,
        /// <summary>A memo attribute. Value = 7.</summary>
        [EnumMember(Value = "Memo")] Memo,
        /// <summary>A money attribute. Value = 8.</summary>
        [EnumMember(Value = "Money")] Money,
        /// <summary>An owner attribute. Value = 9.</summary>
        [EnumMember(Value = "Owner")] Owner,
        /// <summary>A partylist attribute. Value = 10.</summary>
        [EnumMember(Value = "PartyList")] PartyList,
        /// <summary>A picklist attribute. Value = 11.</summary>
        [EnumMember(Value = "Picklist")] Picklist,
        /// <summary>A state attribute. Value = 12.</summary>
        [EnumMember(Value = "State")] State,
        /// <summary>A status attribute. Value = 13.</summary>
        [EnumMember(Value = "Status")] Status,
        /// <summary>A string attribute. Value = 14.</summary>
        [EnumMember(Value = "String")] String,
        /// <summary>An attribute that is an ID. Value = 15.</summary>
        [EnumMember(Value = "Uniqueidentifier")] Uniqueidentifier,
        /// <summary>An attribute that contains calendar rules. Value = 0x10.</summary>
        [EnumMember(Value = "CalendarRules")] CalendarRules,
        /// <summary>An attribute that is created by the system at run time. Value = 0x11.</summary>
        [EnumMember(Value = "Virtual")] Virtual,
        /// <summary>A big integer attribute. Value = 0x12.</summary>
        [EnumMember(Value = "BigInt")] BigInt,
        /// <summary>A managed property attribute. Value = 0x13.</summary>
        [EnumMember(Value = "ManagedProperty")] ManagedProperty,
        /// <summary>An entity name attribute. Value = 20.</summary>
        [EnumMember(Value = "EntityName")] EntityName,
    }
}
