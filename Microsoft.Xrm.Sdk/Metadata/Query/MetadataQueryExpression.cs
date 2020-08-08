using Microsoft.Xrm.Sdk.Query;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata.Query
{
    /// <summary>Represents the abstract base class for constructing a metadata query.</summary>
    [KnownType(typeof(LabelQueryExpression))]
    [DataContract(Name = "MetadataQueryExpression", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata/Query")]
    [KnownType(typeof(EntityQueryExpression))]
    [KnownType(typeof(AttributeQueryExpression))]
    [KnownType(typeof(RelationshipQueryExpression))]
    public abstract class MetadataQueryExpression : MetadataQueryBase
    {
        /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.Metadata.Query.MetadataQueryExpression"></see> class.</summary>
        protected MetadataQueryExpression()
        {
            this.Criteria = new MetadataFilterExpression(LogicalOperator.And);
        }

        /// <summary>Gets or sets the filter criteria for the metadata query.</summary>
        /// <returns>Returns <see cref="T:Microsoft.Xrm.Sdk.Metadata.Query.MetadataFilterExpression"></see>The filter criteria for the metadata query.</returns>
        [DataMember]
        public MetadataFilterExpression Criteria { get; set; }

        /// <summary>Gets or sets the properties to be returned by the query.</summary>
        /// <returns>Returns <see cref="T:Microsoft.Xrm.Sdk.Metadata.Query.MetadataPropertiesExpression"></see>The properties to be returned by the query.</returns>
        [DataMember]
        public MetadataPropertiesExpression Properties { get; set; }
    }
}