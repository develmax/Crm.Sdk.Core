using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
    /// <summary>Used to return aggregate, group by, and aliased values from a query.</summary>
    [DataContract(Name = "AliasedValue", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
    [KnownType("GetKnownAliasedValueTypes")]
    public sealed class AliasedValue : IExtensibleDataObject
    {
        private ExtensionDataObject _extensionDataObject;

        /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Xrm.Sdk.AliasedValue"></see> class.</summary>
        public AliasedValue()
        {
        }

        /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Xrm.Sdk.AliasedValue"></see> class.</summary>
        /// <param name="value">Type: Returns_Object. The value returned by the query.</param>
        /// <param name="attributeLogicalName">Type: Returns_String. The attribute on which the aggregate, group by, or select operation was performed.</param>
        /// <param name="entityLogicalName">Type: Returns_String. The name of the entity the attribute belongs to.</param>
        public AliasedValue(string entityLogicalName, string attributeLogicalName, object value)
        {
            this.AttributeLogicalName = attributeLogicalName;
            this.EntityLogicalName = entityLogicalName;
            this.Value = value;
        }

        /// <summary>Gets the name of the attribute on which the aggregate, group by, or select operation was performed.</summary>
        /// <returns>Type: Returns_String
        /// The name of the attribute on which the aggregate, group by, or select operation was performed.</returns>
        [DataMember]
        public string AttributeLogicalName { get; internal set; }

        /// <summary>Gets the name of the entity the attribute belongs to.</summary>
        /// <returns>Type: Returns_String
        /// The name of the entity the attribute belongs to.</returns>
        [DataMember]
        public string EntityLogicalName { get; internal set; }

        /// <summary>Gets the value returned by the query.</summary>
        /// <returns>Type: Returns_ObjectThe value returned by the query.</returns>
        [DataMember]
        public object Value { get; internal set; }

        internal bool NeedFormatting { get; set; }

        internal int ReturnType { get; set; }

        private static IEnumerable<Type> GetKnownAliasedValueTypes()
        {
            List<Type> knownTypes = new List<Type>();
            KnownTypesProvider.AddKnownAttributeTypes(knownTypes);
            return (IEnumerable<Type>)knownTypes;
        }

        /// <summary>ExtensionData</summary>
        /// <returns>Type: Returns_ExtensionDataObjectThe extension data.</returns>
        public ExtensionDataObject ExtensionData
        {
            get
            {
                return this._extensionDataObject;
            }
            set
            {
                this._extensionDataObject = value;
            }
        }
    }
}