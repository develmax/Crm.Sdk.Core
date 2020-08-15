using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Query
{
    /// <summary>Contains a query that is expressed as a set of attribute and value pairs.  </summary>
    [DataContract(Name = "QueryByAttribute", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
    [SuppressMessage("Microsoft.Naming", "CA1711:IdentifiersShouldNotHaveIncorrectSuffix", Justification = "Suffix is correct")]
    public sealed class QueryByAttribute : QueryBase
    {
        private string _entityName;
        private DataCollection<string> _attributes;
        private DataCollection<object> _attributeValues;
        private PagingInfo _pageInfo;
        private ColumnSet _columnSet;
        private DataCollection<OrderExpression> _orders;
        private int? _topCount;

        /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.Query.QueryByAttribute"></see> class.</summary>
        public QueryByAttribute()
        {
            this._columnSet = new ColumnSet();
            this._pageInfo = new PagingInfo();
        }

        /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.Query.QueryByAttribute"></see> class.</summary>
        /// <param name="entityName">Type: Returns_String. The logical name of the entity to query.</param>
        public QueryByAttribute(string entityName)
        {
            this.EntityName = entityName;
        }

        /// <summary>Gets or sets the logical name of the entity to query.</summary>
        /// <returns>Type: Returns_StringThe logical name of the entity.</returns>
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

        /// <summary>Gets the set of attributes selected in the query.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.DataCollection`1"></see>&lt;Returns_String&gt;
        /// The collection of attributes selected in the query.</returns>
        [DataMember]
        public DataCollection<string> Attributes
        {
            get
            {
                if (this._attributes == null)
                    this._attributes = new DataCollection<string>();
                return this._attributes;
            }
            private set
            {
                this._attributes = value;
            }
        }

        /// <summary>Gets the attribute values to look for when the query is executed.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.DataCollection`1"></see>&lt;Returns_Object&gt;A collection that defines the attribute values to look for when the query is executed.</returns>
        [DataMember]
        public DataCollection<object> Values
        {
            get
            {
                if (this._attributeValues == null)
                    this._attributeValues = new DataCollection<object>();
                return this._attributeValues;
            }
            private set
            {
                this._attributeValues = value;
            }
        }

        /// <summary>Gets or sets the number of pages and the number of entity instances per page returned from the query.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Query.PagingInfo"></see>The number of pages and the number of entity instances per page returned from the query.A query can contain either <see cref="P:Microsoft.Xrm.Sdk.Query.QueryByAttribute.PageInfo"></see> or <see cref="P:Microsoft.Xrm.Sdk.Query.QueryByAttribute.TopCount"></see> property values. If both are specified, an error will be thrown.</returns>
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

        /// <summary>Gets or sets the column set.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Query.ColumnSet"></see>The set of columns (fields) to be returned, used <see cref="P:Microsoft.Xrm.Sdk.Query.QueryByAttribute.Attributes"></see> collection.</returns>
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

        /// <summary>Gets the order in which the entity instances are returned from the query. </summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.DataCollection`1"></see>&lt;<see cref="T:Microsoft.Xrm.Sdk.Query.OrderExpression"></see>&gt;A collection that defines the order in which the entity instances are returned from the query.</returns>
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

        /// <summary>Gets or sets the number of rows to be returned.</summary>
        /// <returns>Type: Returns_Int32The number of rows to be returned.</returns>
        [DataMember(Order = 50)]
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

        /// <summary>Adds an order to the orders collection.</summary>
        /// <param name="attributeName">Type: Returns_String. The logical name of the attribute.</param>
        /// <param name="orderType">Type: <see cref="T:Microsoft.Xrm.Sdk.Query.OrderType"></see>. The order for that attribute.</param>
        public void AddOrder(string attributeName, OrderType orderType)
        {
            this.Orders.Add(new OrderExpression(attributeName, orderType));
        }

        /// <summary>Adds an attribute value to the attributes collection.</summary>
        /// <param name="value">Type: Returns_Object. The attribute value.</param>
        /// <param name="attributeName">Type: Returns_String. The logical name of the attribute.</param>
        public void AddAttributeValue(string attributeName, object value)
        {
            this.Attributes.Add(attributeName);
            this.Values.Add(value);
        }
    }
}
