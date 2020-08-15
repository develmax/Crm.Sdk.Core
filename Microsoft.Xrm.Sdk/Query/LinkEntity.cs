using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Query
{
    /// <summary>Specifies the links between multiple entity types used in creating complex queries.</summary>
    [DataContract(Name = "LinkEntity", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
    public sealed class LinkEntity : IExtensibleDataObject
    {
        private string _linkFromEntityName;
        private string _linkFromAttributeName;
        private string _linkToEntityName;
        private string _linkToAttributeName;
        private JoinOperator _joinOperator;
        private FilterExpression _linkCriteria;
        private string _entityAlias;
        private ColumnSet _columns;
        private DataCollection<LinkEntity> _linkEntities;
        private ExtensionDataObject _extensionDataObject;

        /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.Query.LinkEntity"></see> class.</summary>
        public LinkEntity()
          : this((string)null, (string)null, (string)null, (string)null, JoinOperator.Inner)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.Query.LinkEntity"></see> class setting the required properties.</summary>
        /// <param name="linkToAttributeName">Type: Returns_String. The name of the attribute to link to.</param>
        /// <param name="joinOperator">Type: <see cref="T:Microsoft.Xrm.Sdk.Query.JoinOperator"></see>. The join operator.</param>
        /// <param name="linkFromEntityName">Type: Returns_String. The logical name of the entity to link from.</param>
        /// <param name="linkToEntityName">Type: Returns_String. The logical name of the entity to link to.</param>
        /// <param name="linkFromAttributeName">Type: Returns_String. The name of the attribute to link from.</param>
        public LinkEntity(
          string linkFromEntityName,
          string linkToEntityName,
          string linkFromAttributeName,
          string linkToAttributeName,
          JoinOperator joinOperator)
        {
            this._linkFromEntityName = linkFromEntityName;
            this._linkToEntityName = linkToEntityName;
            this._linkFromAttributeName = linkFromAttributeName;
            this._linkToAttributeName = linkToAttributeName;
            this._joinOperator = joinOperator;
            this._columns = new ColumnSet();
            this._linkCriteria = new FilterExpression();
        }

        /// <summary>Gets or sets the logical name of the attribute of the entity that you are linking from.</summary>
        /// <returns>Type: Returns_String
        /// The logical name of the attribute of the entity that you are linking from.</returns>
        [DataMember]
        public string LinkFromAttributeName
        {
            get
            {
                return this._linkFromAttributeName;
            }
            set
            {
                this._linkFromAttributeName = value;
            }
        }

        /// <summary>Gets or sets the logical name of the entity that you are linking from.</summary>
        /// <returns>Type: Returns_String
        /// The logical name of the entity that you are linking from.</returns>
        [DataMember]
        public string LinkFromEntityName
        {
            get
            {
                return this._linkFromEntityName;
            }
            set
            {
                this._linkFromEntityName = value;
            }
        }

        /// <summary>Gets or sets the logical name of the entity that you are linking to.</summary>
        /// <returns>Type: Returns_String
        /// The logical name of the entity that you are linking to.</returns>
        [DataMember]
        public string LinkToEntityName
        {
            get
            {
                return this._linkToEntityName;
            }
            set
            {
                this._linkToEntityName = value;
            }
        }

        /// <summary>Gets or sets the logical name of the attribute of the entity that you are linking to.</summary>
        /// <returns>Type: Returns_String
        /// The logical name of the attribute of the entity that you are linking to.</returns>
        [DataMember]
        public string LinkToAttributeName
        {
            get
            {
                return this._linkToAttributeName;
            }
            set
            {
                this._linkToAttributeName = value;
            }
        }

        /// <summary>Gets or sets the join operator.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Query.JoinOperator"></see>The join operator.</returns>
        [DataMember]
        public JoinOperator JoinOperator
        {
            get
            {
                return this._joinOperator;
            }
            set
            {
                this._joinOperator = value;
            }
        }

        /// <summary>Gets or sets the complex condition and logical filter expressions that filter the results of the query.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Query.FilterExpression"></see>The complex condition and logical filter expressions that filter the results of the query.</returns>
        [DataMember]
        public FilterExpression LinkCriteria
        {
            get
            {
                return this._linkCriteria;
            }
            set
            {
                this._linkCriteria = value;
            }
        }

        /// <summary>Gets the links between multiple entity types.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.DataCollection`1"></see>&lt;<see cref="T:Microsoft.Xrm.Sdk.Query.LinkEntity"></see>&gt;The collection of links between entities.</returns>
        [DataMember]
        public DataCollection<LinkEntity> LinkEntities
        {
            get
            {
                if (this._linkEntities == null)
                    this._linkEntities = new DataCollection<LinkEntity>();
                return this._linkEntities;
            }
      [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Called via reflection")] private set
            {
                this._linkEntities = value;
            }
        }

        /// <summary>Gets or sets the column set.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Query.ColumnSet"></see>The set of columns (fields) to be returned for the query.</returns>
        [DataMember]
        public ColumnSet Columns
        {
            get
            {
                if (this._columns == null)
                    this._columns = new ColumnSet();
                return this._columns;
            }
            set
            {
                this._columns = value;
            }
        }

        /// <summary>Gets or sets the alias for the entity.</summary>
        /// <returns>Type: Returns_String
        /// The alias for the entity.</returns>
        [DataMember]
        public string EntityAlias
        {
            get
            {
                return this._entityAlias;
            }
            set
            {
                this._entityAlias = value;
            }
        }

        internal void Accept(IQueryVisitor visitor)
        {
            visitor.Visit(this);
        }

        /// <summary>Adds a link, setting the link to entity name, the link from attribute name and the link to attribute name.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Query.LinkEntity"></see>The link entity that was created.</returns>
        /// <param name="linkToAttributeName">Type: Returns_String. The name of the attribute to link to.</param>
        /// <param name="linkToEntityName">Type: Returns_String. The name of the entity to link to.</param>
        /// <param name="linkFromAttributeName">Type: Returns_String. The name of the attribute to link from.</param>
        public LinkEntity AddLink(
          string linkToEntityName,
          string linkFromAttributeName,
          string linkToAttributeName)
        {
            return this.AddLink(linkToEntityName, linkFromAttributeName, linkToAttributeName, JoinOperator.Inner);
        }

        /// <summary>Adds a link setting the link to entity name, the link from attribute name, the link to attribute name, and the join operator.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Query.LinkEntity"></see>The link entity that was created.</returns>
        /// <param name="linkToAttributeName">Type: Returns_String. The name of the attribute to link to.</param>
        /// <param name="joinOperator">Type: <see cref="T:Microsoft.Xrm.Sdk.Query.JoinOperator"></see>. The join operator.</param>
        /// <param name="linkToEntityName">Type: Returns_String. The name of the entity to link to.</param>
        /// <param name="linkFromAttributeName">Type: Returns_String. The name of the attribute to link from.</param>
        public LinkEntity AddLink(
          string linkToEntityName,
          string linkFromAttributeName,
          string linkToAttributeName,
          JoinOperator joinOperator)
        {
            LinkEntity linkEntity = new LinkEntity(this._linkFromEntityName, linkToEntityName, linkFromAttributeName, linkToAttributeName, joinOperator);
            this.LinkEntities.Add(linkEntity);
            return linkEntity;
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