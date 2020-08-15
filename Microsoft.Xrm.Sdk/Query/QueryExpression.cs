using System.ComponentModel;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Query
{
    /// <summary>Contains a complex query expressed in a hierarchy of expressions.</summary>
    [DataContract(Name = "QueryExpression", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
    public sealed class QueryExpression : QueryBase
    {
        private ColumnSet _columnSet;
        private string _entityName;
        private bool _distinct;
        private bool _noLock;
        private PagingInfo _pageInfo;
        private DataCollection<LinkEntity> _linkEntities;
        private FilterExpression _criteria;
        private DataCollection<OrderExpression> _orders;
        private int? _topCount;

        /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.Query.QueryExpression"></see> class.</summary>
        public QueryExpression()
          : this((string)null)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.Query.QueryExpression"></see> class setting the entity name.</summary>
        /// <param name="entityName">Type: Returns_String. The name of the entity. </param>
        public QueryExpression(string entityName)
        {
            this._entityName = entityName;
            this._criteria = new FilterExpression();
            this._pageInfo = new PagingInfo();
            this._columnSet = new ColumnSet();
        }

        /// <summary>Gets or sets whether the results of the query contain duplicate entity instances.</summary>
        /// <returns>Type: Returns_Booleantrue if the results of the query contain duplicate entity instances; otherwise, false.</returns>
        [DataMember]
        public bool Distinct
        {
            get
            {
                return this._distinct;
            }
            set
            {
                this._distinct = value;
            }
        }

        /// <summary>Gets or sets a value that indicates that no shared locks are issued against the data that would prohibit other transactions from modifying the data in the records returned from the query.</summary>
        /// <returns>Type: Returns_Booleantrue if there are no shared locks are issued against the data that would prohibit other transactions from modifying the data in the records returned from the query; otherwise, false.</returns>
        [DataMember(Order = 50)]
        public bool NoLock
        {
            get
            {
                return this._noLock;
            }
            set
            {
                this._noLock = value;
            }
        }

        /// <summary>Gets or sets the number of pages and the number of entity instances per page returned from the query.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Query.PagingInfo"></see>The number of pages and the number of entity instances per page returned from the query.A query can contain either <see cref="P:Microsoft.Xrm.Sdk.Query.QueryExpression.PageInfo"></see> or <see cref="P:Microsoft.Xrm.Sdk.Query.QueryExpression.TopCount"></see> property values. If both are specified, an error will be thrown.</returns>
        [DataMember]
        public PagingInfo PageInfo
        {
            get
            {
                return this._pageInfo;
            }
            set
            {
                this._pageInfo = value;
            }
        }

        /// <summary>Gets a collection of the links between multiple entity types.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.DataCollection`1"></see>&lt;<see cref="T:Microsoft.Xrm.Sdk.Query.LinkEntity"></see>&gt;The collection of links between entities for the query.</returns>
        [DataMember]
        public DataCollection<LinkEntity> LinkEntities
        {
            get
            {
                if (this._linkEntities == null)
                    this._linkEntities = new DataCollection<LinkEntity>();
                return this._linkEntities;
            }
            private set
            {
                this._linkEntities = value;
            }
        }

        /// <summary>Gets or sets the complex condition and logical filter expressions that filter the results of the query.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Query.FilterExpression"></see>The query condition and filter criteria.</returns>
        [DataMember]
        public FilterExpression Criteria
        {
            get
            {
                return this._criteria;
            }
            set
            {
                this._criteria = value;
            }
        }

        /// <summary>Gets the order in which the entity instances are returned from the query.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.DataCollection`1"></see>&lt;<see cref="T:Microsoft.Xrm.Sdk.Query.OrderExpression"></see>&gt;The order expression that defines the order in which the entity instances are returned from the query.</returns>
        [DataMember]
        public DataCollection<OrderExpression> Orders
        {
            get
            {
                if (this._orders == null)
                    this._orders = new DataCollection<OrderExpression>();
                return this._orders;
            }
            private set
            {
                this._orders = value;
            }
        }

        /// <summary>Gets or sets the logical name of the entity.</summary>
        /// <returns>Type: Returns_String
        /// The logical name of the primary entity for the query.</returns>
        [DataMember]
        public string EntityName
        {
            get
            {
                return this._entityName;
            }
            set
            {
                this._entityName = value;
            }
        }

        /// <summary>Gets or sets the columns to include.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Query.ColumnSet"></see>The set of columns to return in the query results.</returns>
        [DataMember]
        public ColumnSet ColumnSet
        {
            get
            {
                return this._columnSet;
            }
            set
            {
                this._columnSet = value;
            }
        }

        /// <summary>Gets or sets the number of rows to be returned.</summary>
        /// <returns>Type: Returns_Int32The number of rows to be returned.</returns>
        [DataMember(EmitDefaultValue = false, Order = 50)]
        public int? TopCount
        {
            get
            {
                return this._topCount;
            }
            set
            {
                this._topCount = value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal override void Accept(IQueryVisitor visitor)
        {
            visitor.Visit(this);
        }

        /// <summary>Adds the specified order expression to the query expression.</summary>
        /// <param name="attributeName">Type: Returns_String. The name of the attribute.</param>
        /// <param name="orderType">Type: <see cref="T:Microsoft.Xrm.Sdk.Query.OrderType"></see>. The order type.</param>
        public void AddOrder(string attributeName, OrderType orderType)
        {
            this.Orders.Add(new OrderExpression(attributeName, orderType));
        }

        /// <summary>Adds the specified link to the query expression setting the entity name to link to, the attribute name to link from and the attribute name to link to.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Query.LinkEntity"></see>The link entity instance created and added to the query expression.</returns>
        /// <param name="linkToAttributeName">Type: Returns_String. The name of the attribute to link to.</param>
        /// <param name="linkToEntityName">Type: Returns_String. The name of entity to link from.</param>
        /// <param name="linkFromAttributeName">Type: Returns_String. The name of the attribute to link from.</param>
        public LinkEntity AddLink(
          string linkToEntityName,
          string linkFromAttributeName,
          string linkToAttributeName)
        {
            return this.AddLink(linkToEntityName, linkFromAttributeName, linkToAttributeName, JoinOperator.Inner);
        }

        /// <summary>Adds the specified link to the query expression setting the entity name to link to, the attribute name to link from and the attribute name to link to.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Query.LinkEntity"></see>The link entity instance created and added to the query expression.</returns>
        /// <param name="linkToAttributeName">Type: Returns_String. The name of the attribute to link to.</param>
        /// <param name="joinOperator">Type: <see cref="T:Microsoft.Xrm.Sdk.Query.JoinOperator"></see>. The join operator.</param>
        /// <param name="linkToEntityName">Type: Returns_String. The name of entity to link from.</param>
        /// <param name="linkFromAttributeName">Type: Returns_String. The name of the attribute to link from.</param>
        public LinkEntity AddLink(
          string linkToEntityName,
          string linkFromAttributeName,
          string linkToAttributeName,
          JoinOperator joinOperator)
        {
            LinkEntity linkEntity = new LinkEntity(this.EntityName, linkToEntityName, linkFromAttributeName, linkToAttributeName, joinOperator);
            this.LinkEntities.Add(linkEntity);
            return linkEntity;
        }
    }
}
