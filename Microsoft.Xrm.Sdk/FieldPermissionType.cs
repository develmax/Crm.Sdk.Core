using System;
using System.Globalization;

namespace Microsoft.Xrm.Sdk
{
    /// <summary>Defines the possible field permission types.</summary>
    public static class FieldPermissionType
    {
        /// <summary>The action is not allowed. Value = 0.</summary>
        public const int NotAllowed = 0;
        /// <summary>The action is allowed. Value = 4.</summary>
        public const int Allowed = 4;

        /// <summary>Validates the field permission value.</summary>
        /// <param name="value">Type: Returns_Int32. The value to validate.</param>
        public static void Validate(int value)
        {
            if (value != 4 && value != 0)
                throw new ArgumentOutOfRangeException(nameof(value), string.Format((IFormatProvider)CultureInfo.InvariantCulture, "Value {0} is not a valid FieldPermissionType", (object)value));
        }
    }
}