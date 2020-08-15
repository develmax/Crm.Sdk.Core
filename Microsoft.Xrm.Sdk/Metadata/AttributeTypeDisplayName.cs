using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
    [DataContract(Name = "AttributeTypeDisplayName", Namespace = "http://schemas.microsoft.com/xrm/2013/Metadata")]
    public sealed class AttributeTypeDisplayName : ConstantsBase<string>
    {
        /// <summary>An attribute type that stores a Boolean value</summary>
        [SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "AttributeTypeDisplayName is immutable")]
        public static readonly AttributeTypeDisplayName BooleanType = ConstantsBase<string>.Add<AttributeTypeDisplayName>(nameof(BooleanType));
        /// <summary>An attribute type that stores an <see cref="T:Microsoft.Xrm.Sdk.EntityReference"></see> to either an Account or Contact.</summary>
        [SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "AttributeTypeDisplayName is immutable")]
        public static readonly AttributeTypeDisplayName CustomerType = ConstantsBase<string>.Add<AttributeTypeDisplayName>(nameof(CustomerType));
        /// <summary>An attribute type that stores a System.DateTime value</summary>
        [SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "AttributeTypeDisplayName is immutable")]
        public static readonly AttributeTypeDisplayName DateTimeType = ConstantsBase<string>.Add<AttributeTypeDisplayName>(nameof(DateTimeType));
        /// <summary>An attribute type that stores a Decimal value</summary>
        [SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "AttributeTypeDisplayName is immutable")]
        public static readonly AttributeTypeDisplayName DecimalType = ConstantsBase<string>.Add<AttributeTypeDisplayName>(nameof(DecimalType));
        /// <summary>An attribute type that stores a Double value</summary>
        [SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "AttributeTypeDisplayName is immutable")]
        public static readonly AttributeTypeDisplayName DoubleType = ConstantsBase<string>.Add<AttributeTypeDisplayName>(nameof(DoubleType));
        /// <summary>An attribute type that stores an Integer value</summary>
        [SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "AttributeTypeDisplayName is immutable")]
        public static readonly AttributeTypeDisplayName IntegerType = ConstantsBase<string>.Add<AttributeTypeDisplayName>(nameof(IntegerType));
        /// <summary>An attribute type that stores an <see cref="T:Microsoft.Xrm.Sdk.EntityReference"></see> value.</summary>
        [SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "AttributeTypeDisplayName is immutable")]
        public static readonly AttributeTypeDisplayName LookupType = ConstantsBase<string>.Add<AttributeTypeDisplayName>(nameof(LookupType));
        /// <summary>An attribute type that stores a String value</summary>
        [SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "AttributeTypeDisplayName is immutable")]
        public static readonly AttributeTypeDisplayName MemoType = ConstantsBase<string>.Add<AttributeTypeDisplayName>(nameof(MemoType));
        /// <summary>An attribute type that stores a Money value</summary>
        [SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "AttributeTypeDisplayName is immutable")]
        public static readonly AttributeTypeDisplayName MoneyType = ConstantsBase<string>.Add<AttributeTypeDisplayName>(nameof(MoneyType));
        /// <summary>An attribute type that stores an <see cref="T:Microsoft.Xrm.Sdk.EntityReference"></see> value to a Team or SystemUser record.</summary>
        [SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "AttributeTypeDisplayName is immutable")]
        public static readonly AttributeTypeDisplayName OwnerType = ConstantsBase<string>.Add<AttributeTypeDisplayName>(nameof(OwnerType));
        /// <summary>An attribute type that stores an <see cref="T:Microsoft.Xrm.Sdk.EntityCollection"></see>or ActivityParty[] value</summary>
        [SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "AttributeTypeDisplayName is immutable")]
        public static readonly AttributeTypeDisplayName PartyListType = ConstantsBase<string>.Add<AttributeTypeDisplayName>(nameof(PartyListType));
        /// <summary>An attribute type that stores an <see cref="T:Microsoft.Xrm.Sdk.OptionSetValue"></see>.</summary>
        [SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "AttributeTypeDisplayName is immutable")]
        public static readonly AttributeTypeDisplayName PicklistType = ConstantsBase<string>.Add<AttributeTypeDisplayName>(nameof(PicklistType));
        /// <summary>An attribute type that stores an <see cref="T:Microsoft.Xrm.Sdk.OptionSetValue"></see> representing the valid statecode values for an entity.</summary>
        [SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "AttributeTypeDisplayName is immutable")]
        public static readonly AttributeTypeDisplayName StateType = ConstantsBase<string>.Add<AttributeTypeDisplayName>(nameof(StateType));
        /// <summary>An attribute type that stores an <see cref="T:Microsoft.Xrm.Sdk.OptionSetValue"></see> representing the valid statuscode values for an entity.</summary>
        [SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "AttributeTypeDisplayName is immutable")]
        public static readonly AttributeTypeDisplayName StatusType = ConstantsBase<string>.Add<AttributeTypeDisplayName>(nameof(StatusType));
        /// <summary>An attribute type that stores a String value</summary>
        [SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "AttributeTypeDisplayName is immutable")]
        public static readonly AttributeTypeDisplayName StringType = ConstantsBase<string>.Add<AttributeTypeDisplayName>(nameof(StringType));
        /// <summary>An attribute type that stores a System.Guid value.</summary>
        [SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "AttributeTypeDisplayName is immutable")]
        public static readonly AttributeTypeDisplayName UniqueidentifierType = ConstantsBase<string>.Add<AttributeTypeDisplayName>(nameof(UniqueidentifierType));
        /// <summary>An attribute type that stores an <see cref="T:Microsoft.Xrm.Sdk.EntityCollection"></see> or CalendarRules[] value</summary>
        [SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "AttributeTypeDisplayName is immutable")]
        public static readonly AttributeTypeDisplayName CalendarRulesType = ConstantsBase<string>.Add<AttributeTypeDisplayName>(nameof(CalendarRulesType));
        /// <summary>An attribute type that represents a value not included within records.</summary>
        [SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "AttributeTypeDisplayName is immutable")]
        public static readonly AttributeTypeDisplayName VirtualType = ConstantsBase<string>.Add<AttributeTypeDisplayName>(nameof(VirtualType));
        /// <summary>An attribute type that stores a Long value</summary>
        [SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "AttributeTypeDisplayName is immutable")]
        public static readonly AttributeTypeDisplayName BigIntType = ConstantsBase<string>.Add<AttributeTypeDisplayName>(nameof(BigIntType));
        /// <summary>An attribute type that stores a <see cref="T:Microsoft.Xrm.Sdk.BooleanManagedProperty"></see> value.</summary>
        [SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "AttributeTypeDisplayName is immutable")]
        public static readonly AttributeTypeDisplayName ManagedPropertyType = ConstantsBase<string>.Add<AttributeTypeDisplayName>(nameof(ManagedPropertyType));
        /// <summary>An attribute type that stores a reference to a logical entity name value.</summary>
        [SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "AttributeTypeDisplayName is immutable")]
        public static readonly AttributeTypeDisplayName EntityNameType = ConstantsBase<string>.Add<AttributeTypeDisplayName>(nameof(EntityNameType));
        /// <summary>An attribute type that enables access to a specific image for an entity instance.</summary>
        [SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "AttributeTypeDisplayName is immutable")]
        public static readonly AttributeTypeDisplayName ImageType = ConstantsBase<string>.Add<AttributeTypeDisplayName>(nameof(ImageType));

        [SuppressMessage("Microsoft.Performance", "CA1810:InitializeReferenceTypeStaticFieldsInline")]
        static AttributeTypeDisplayName()
        {
        }

        /// <returns>Returns <see cref="T:Microsoft.Xrm.Sdk.Metadata.AttributeTypeDisplayName"></see>.</returns>
        [SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates", Justification = "Clients who do not support operator overloading can use the constructor")]
        public static implicit operator AttributeTypeDisplayName(
          string attributeTypeDisplayName)
        {
            AttributeTypeDisplayName attributeTypeDisplayName1 = new AttributeTypeDisplayName();
            attributeTypeDisplayName1.Value = attributeTypeDisplayName;
            return attributeTypeDisplayName1;
        }

        protected override bool ValueExistsInList(string value)
        {
            return ConstantsBase<string>.ValidValues.Contains<string>(value, (IEqualityComparer<string>)StringComparer.OrdinalIgnoreCase);
        }

        /// <returns>Returns <see cref="T:System.Boolean"></see>.</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (obj is string strB)
                return 0 == string.Compare(this.Value, strB, StringComparison.OrdinalIgnoreCase);
            AttributeTypeDisplayName attributeTypeDisplayName = obj as AttributeTypeDisplayName;
            return !(attributeTypeDisplayName == (AttributeTypeDisplayName)null) && 0 == string.Compare(this.Value, attributeTypeDisplayName.Value, StringComparison.OrdinalIgnoreCase);
        }

        /// <returns>Returns <see cref="T:System.Boolean"></see>.</returns>
        public static bool operator ==(
          AttributeTypeDisplayName attributeTypeDisplayNameA,
          AttributeTypeDisplayName attributeTypeDisplayNameB)
        {
            if (object.ReferenceEquals((object)attributeTypeDisplayNameA, (object)attributeTypeDisplayNameB))
                return true;
            return (object)attributeTypeDisplayNameA != null && (object)attributeTypeDisplayNameB != null && attributeTypeDisplayNameA.Equals((object)attributeTypeDisplayNameB);
        }

        /// <returns>Returns <see cref="T:System.Boolean"></see>.</returns>
        public static bool operator !=(
          AttributeTypeDisplayName attributeTypeDisplayNameA,
          AttributeTypeDisplayName attributeTypeDisplayNameB)
        {
            return !(attributeTypeDisplayNameA == attributeTypeDisplayNameB);
        }

        /// <returns>Returns <see cref="T:System.Int32"></see>.</returns>
        public override int GetHashCode()
        {
            return this.Value.GetHashCode();
        }
    }
}