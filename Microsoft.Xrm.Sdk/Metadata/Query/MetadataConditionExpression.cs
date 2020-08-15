using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata.Query
{
    /// <summary>Contains a condition expression used to filter the results of the metadata query.</summary>
    [KnownType("GetKnownConditionValueTypes")]
    [DataContract(Name = "MetadataConditionExpression", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata/Query")]
    public sealed class MetadataConditionExpression : IExtensibleDataObject
    {
        /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Xrm.Sdk.Metadata.Query.MetadataConditionExpression"></see> class.</summary>
        public MetadataConditionExpression()
        {
        }

        /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Xrm.Sdk.Metadata.Query.MetadataConditionExpression"></see> class.</summary>
        /// <param name="conditionOperator">Type: <see cref="T:Microsoft.Xrm.Sdk.Metadata.Query.MetadataConditionOperator"></see>. The condition operator.</param>
        /// <param name="propertyName">Type: Returns_String. The name of the metadata property in the condition expression.</param>
        /// <param name="value">Type: Returns_Object The value for the metadata property.</param>
        public MetadataConditionExpression(
          string propertyName,
          MetadataConditionOperator conditionOperator,
          object value)
        {
            this.PropertyName = propertyName;
            this.ConditionOperator = conditionOperator;
            this.Value = value;
        }

        /// <summary>Gets or sets the name of the metadata property in the condition expression.</summary>
        /// <returns>Type: Returns_String
        /// The name of the metadata property in the condition expression.</returns>
        [DataMember]
        public string PropertyName { get; set; }

        /// <summary>Gets or sets the condition operator.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Metadata.Query.MetadataConditionOperator"></see>.  The condition operator.</returns>
        [DataMember]
        public MetadataConditionOperator ConditionOperator { get; set; }

        /// <summary>Gets or sets the value for the metadata property.</summary>
        /// <returns>Type: Returns_Object The value for the metadata property.</returns>
        [DataMember]
        public object Value { get; set; }

        /// <summary>ExtensionData</summary>
        /// <returns>Type: Returns_ExtensionDataObjectThe extension data.</returns>
        public ExtensionDataObject ExtensionData { get; set; }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Called by runtime to get known types")]
        private static IEnumerable<Type> GetKnownConditionValueTypes()
        {
            return (IEnumerable<Type>)KnownTypesProvider.GetKnownMetadataEnumTypes();
        }
    }
}