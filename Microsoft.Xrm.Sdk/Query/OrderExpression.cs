using System.ComponentModel;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Query
{
    /// <summary>Sets the order in which the entity instances are returned from the query.</summary>
    [DataContract(Name = "OrderExpression", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
    public sealed class OrderExpression : IExtensibleDataObject
    {
        private string _attributeName;
        private OrderType _orderType;
        private ExtensionDataObject _extensionDataObject;

        /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.Query.OrderExpression"></see> class.</summary>
        public OrderExpression()
        {
        }

        /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.Query.OrderExpression"></see> class setting the attribute name and the order type.</summary>
        /// <param name="attributeName">Type: Returns_String. The name of the attribute.</param>
        /// <param name="orderType">Type: <see cref="T:Microsoft.Xrm.Sdk.Query.OrderType"></see>. The order, ascending or descending.</param>
        public OrderExpression(string attributeName, OrderType orderType)
        {
            this._attributeName = attributeName;
            this._orderType = orderType;
        }

        /// <summary>Gets or sets the name of the attribute in the order expression.</summary>
        /// <returns>Type: Returns_String
        /// The name of the attribute in the order expression.</returns>
        [DataMember]
        public string AttributeName
        {
            get
            {
                return this._attributeName;
            }
            set
            {
                this._attributeName = value;
            }
        }

        /// <summary>Gets or sets the order, ascending or descending.</summary>
        /// <returns>Returns <see cref="T:Microsoft.Xrm.Sdk.Query.OrderType"></see>The order, ascending or descending.</returns>
        [DataMember]
        public OrderType OrderType
        {
            get
            {
                return this._orderType;
            }
            set
            {
                this._orderType = value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal void Accept(IQueryVisitor visitor)
        {
            visitor.Visit(this);
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
