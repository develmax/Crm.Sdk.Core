using Microsoft.Xrm.Sdk.Query;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata.Query
{
    /// <summary>Specifies complex condition and logical filter expressions used for filtering the results of a metadata query.</summary>
    [DataContract(Name = "MetadataFilterExpression", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata/Query")]
    public sealed class MetadataFilterExpression : IExtensibleDataObject
    {
        private DataCollection<MetadataConditionExpression> _conditions;
        private DataCollection<MetadataFilterExpression> _filters;

        /// <summary>ExtensionData</summary>
        /// <returns>Type: Returns_ExtensionDataObjectThe extension data.</returns>
        public ExtensionDataObject ExtensionData { get; set; }

        /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.Metadata.Query.MetadataFilterExpression"></see> class.</summary>
        public MetadataFilterExpression()
        {
        }

        /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.Metadata.Query.MetadataFilterExpression"></see> class.</summary>
        /// <param name="filterOperator">Type: <see cref="T:Microsoft.Xrm.Sdk.Query.LogicalOperator"></see>. The filter operator</param>
        public MetadataFilterExpression(LogicalOperator filterOperator)
        {
            this.FilterOperator = filterOperator;
        }

        /// <summary>Gets condition expressions that include metadata properties, condition operators and values.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.DataCollection`1"></see>&lt;<see cref="T:Microsoft.Xrm.Sdk.Metadata.Query.MetadataConditionExpression"></see>&gt;The collection of metadata condition expressions.</returns>
        [DataMember]
        public DataCollection<MetadataConditionExpression> Conditions
        {
            get
            {
                return this._conditions ?? (this._conditions = new DataCollection<MetadataConditionExpression>());
            }
            private set
            {
                this._conditions = value;
            }
        }

        /// <summary>Gets or sets the logical AND/OR filter operator.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Query.LogicalOperator"></see>The filter operator.</returns>
        [DataMember]
        public LogicalOperator FilterOperator { get; set; }

        /// <summary>Gets a collection of logical filter expressions that filter the results of the metadata query.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.DataCollection`1"></see>&lt;<see cref="T:Microsoft.Xrm.Sdk.Metadata.Query.MetadataFilterExpression"></see>&gt;.</returns>
        [DataMember]
        public DataCollection<MetadataFilterExpression> Filters
        {
            get
            {
                return this._filters ?? (this._filters = new DataCollection<MetadataFilterExpression>());
            }
            private set
            {
                this._filters = value;
            }
        }
    }
}