using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata.Query
{
    /// <summary>Specifies the properties for which non-null values are returned from a query.</summary>
    [DataContract(Name = "MetadataPropertiesExpression", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata/Query")]
    public sealed class MetadataPropertiesExpression : IExtensibleDataObject
    {
        private DataCollection<string> _propertyNames;

        /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Xrm.Sdk.Metadata.Query.MetadataPropertiesExpression"></see> class.</summary>
        public MetadataPropertiesExpression()
        {
        }

        /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Xrm.Sdk.Metadata.Query.MetadataPropertiesExpression"></see> class.</summary>
        /// <param name="propertyNames">Type: Returns_String[]. The strings representing the metadata properties to retrieve.</param>
        public MetadataPropertiesExpression(params string[] propertyNames)
        {
            this.PropertyNames.AddRange(propertyNames);
        }

        /// <summary>ExtensionData</summary>
        /// <returns>Type: Returns_ExtensionDataObjectThe extension data.</returns>
        public ExtensionDataObject ExtensionData { get; set; }

        /// <summary>Gets or sets whether to retrieve all the properties of a metadata object.</summary>
        /// <returns>Type: Returns_Booleantrue to specify to retrieve all metadata object properties; false to retrieve only specified metadata object properties.</returns>
        [DataMember]
        public bool AllProperties { get; set; }

        /// <summary>Gets or sets a collection of strings representing the metadata properties to retrieve.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.DataCollection`1"></see>&lt;Returns_String&gt; The collection of strings representing the metadata properties to retrieve.</returns>
        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly", Justification = "The requirement is to allow callers to change this collection property's value")]
        [DataMember]
        public DataCollection<string> PropertyNames
        {
            get
            {
                return this._propertyNames ?? (this._propertyNames = new DataCollection<string>());
            }
            internal set
            {
                this._propertyNames = value;
            }
        }
    }
}