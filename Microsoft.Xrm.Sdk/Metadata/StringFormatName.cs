using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
    /// <summary>Specifies the format of a <see cref="T:Microsoft.Xrm.Sdk.Metadata.StringAttributeMetadata"></see> attribute using the <see cref="P:Microsoft.Xrm.Sdk.Metadata.StringAttributeMetadata.FormatName"></see> property.</summary>
    [DataContract(Name = "StringFormatName", Namespace = "http://schemas.microsoft.com/xrm/2013/Metadata")]
    public sealed class StringFormatName : ConstantsBase<string>
    {
        /// <summary>Specifies to display the <see cref="T:Microsoft.Xrm.Sdk.Metadata.StringAttributeMetadata"></see> as an email address.</summary>
        [SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "StringFormatName is immutable")]
        public static readonly StringFormatName Email = ConstantsBase<string>.Add<StringFormatName>(nameof(Email));
        /// <summary>Specifies to display the <see cref="T:Microsoft.Xrm.Sdk.Metadata.StringAttributeMetadata"></see> as text.</summary>
        [SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "StringFormatName is immutable")]
        public static readonly StringFormatName Text = ConstantsBase<string>.Add<StringFormatName>(nameof(Text));
        /// <summary>Specifies to display the <see cref="T:Microsoft.Xrm.Sdk.Metadata.StringAttributeMetadata"></see> as a text area.</summary>
        [SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "StringFormatName is immutable")]
        public static readonly StringFormatName TextArea = ConstantsBase<string>.Add<StringFormatName>(nameof(TextArea));
        /// <summary>Specifies to display the <see cref="T:Microsoft.Xrm.Sdk.Metadata.StringAttributeMetadata"></see> as a URL.</summary>
        [SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "StringFormatName is immutable")]
        public static readonly StringFormatName Url = ConstantsBase<string>.Add<StringFormatName>(nameof(Url));
        /// <summary>Specifies to display the <see cref="T:Microsoft.Xrm.Sdk.Metadata.StringAttributeMetadata"></see> as a ticker symbol.</summary>
        [SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "StringFormatName is immutable")]
        public static readonly StringFormatName TickerSymbol = ConstantsBase<string>.Add<StringFormatName>(nameof(TickerSymbol));
        /// <summary>Specifies to display the <see cref="T:Microsoft.Xrm.Sdk.Metadata.StringAttributeMetadata"></see> as an phonetic guide.</summary>
        [SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "StringFormatName is immutable")]
        public static readonly StringFormatName PhoneticGuide = ConstantsBase<string>.Add<StringFormatName>(nameof(PhoneticGuide));
        /// <summary>Specifies to display the <see cref="T:Microsoft.Xrm.Sdk.Metadata.StringAttributeMetadata"></see> as a version number.</summary>
        [SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "StringFormatName is immutable")]
        public static readonly StringFormatName VersionNumber = ConstantsBase<string>.Add<StringFormatName>(nameof(VersionNumber));
        /// <summary>Specifies to display the <see cref="T:Microsoft.Xrm.Sdk.Metadata.StringAttributeMetadata"></see> as an phone number.</summary>
        [SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "StringFormatName is immutable")]
        public static readonly StringFormatName Phone = ConstantsBase<string>.Add<StringFormatName>(nameof(Phone));

        [SuppressMessage("Microsoft.Performance", "CA1810:InitializeReferenceTypeStaticFieldsInline")]
        static StringFormatName()
        {
        }

        /// <summary>Converts a string into a <see cref="T:Microsoft.Xrm.Sdk.Metadata.StringFormatName"></see></summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Metadata.StringFormatName"></see>A <see cref="T:Microsoft.Xrm.Sdk.Metadata.StringFormatName"></see> that represents the converted Returns_String.</returns>
        /// <param name="formatName">Type: Returns_String. Specifies a StringFormatName.</param>
        [SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates", Justification = "Clients who do not support operator overloading can use the constructor")]
        public static implicit operator StringFormatName(string formatName)
        {
            StringFormatName stringFormatName = new StringFormatName();
            stringFormatName.Value = formatName;
            return stringFormatName;
        }

        protected override bool ValueExistsInList(string value)
        {
            return ConstantsBase<string>.ValidValues.Contains<string>(value, (IEqualityComparer<string>)StringComparer.OrdinalIgnoreCase);
        }

        /// <summary>Determines whether two instances are equal.</summary>
        /// <returns>Type: Returns_Booleantrue if the specified <see cref="T:Microsoft.Xrm.Sdk.Metadata.StringFormatName"></see> is equal to the <see cref="T:Microsoft.Xrm.Sdk.Metadata.StringFormatName"></see> object; otherwise, false.</returns>
        /// <param name="obj">Type: Returns_Object. The <see cref="T:Microsoft.Xrm.Sdk.Metadata.StringFormatName"></see> to compare with the current <see cref="T:Microsoft.Xrm.Sdk.Metadata.StringFormatName"></see>.</param>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (obj is string strB)
                return 0 == string.Compare(this.Value, strB, StringComparison.OrdinalIgnoreCase);
            StringFormatName stringFormatName = obj as StringFormatName;
            return !(stringFormatName == (StringFormatName)null) && 0 == string.Compare(this.Value, stringFormatName.Value, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>Indicates whether two StringFormatName instances are the same.</summary>
        /// <returns>Type: Returns_Booleantrue if the values of stringFormatA and stringFormatB are the same; otherwise, false.</returns>
        /// <param name="stringFormatA">Type: <see cref="T:Microsoft.Xrm.Sdk.Metadata.StringFormatName"></see>. Specifies a StringFormatName.</param>
        /// <param name="stringFormatB">Type: <see cref="T:Microsoft.Xrm.Sdk.Metadata.StringFormatName"></see>. Specifies a StringFormatName.</param>
        public static bool operator ==(StringFormatName stringFormatA, StringFormatName stringFormatB)
        {
            if (object.ReferenceEquals((object)stringFormatA, (object)stringFormatB))
                return true;
            return (object)stringFormatA != null && (object)stringFormatB != null && stringFormatA.Equals((object)stringFormatB);
        }

        /// <summary>Indicates whether two StringFormatName instances are different.</summary>
        /// <returns>Type: Returns_Booleantrue if the values of stringFormatA and stringFormatB are different; otherwise, false.</returns>
        /// <param name="stringFormatA">Type: <see cref="T:Microsoft.Xrm.Sdk.Metadata.StringFormatName"></see>. Specifies a StringFormatName.</param>
        /// <param name="stringFormatB">Type: <see cref="T:Microsoft.Xrm.Sdk.Metadata.StringFormatName"></see>. Specifies a StringFormatName.</param>
        public static bool operator !=(StringFormatName stringFormatA, StringFormatName stringFormatB)
        {
            return !(stringFormatA == stringFormatB);
        }

        /// <summary>Returns a hash code value for this type.</summary>
        /// <returns>Type: Returns_Int32
        /// The hash code for the current StringFormatName.</returns>
        public override int GetHashCode()
        {
            return this.Value.GetHashCode();
        }
    }
}
