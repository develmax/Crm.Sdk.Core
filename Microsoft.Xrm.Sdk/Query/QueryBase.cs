using System.ComponentModel;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Query
{
    /// <summary>Represents the abstract base class for constructing a query. </summary>
    [KnownType(typeof(QueryExpression))]
    [KnownType(typeof(QueryByAttribute))]
    [KnownType(typeof(FetchExpression))]
    [DataContract(Name = "QueryBase", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
    public abstract class QueryBase : IExtensibleDataObject
    {
        private ExtensionDataObject _extensionDataObject;

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal abstract void Accept(IQueryVisitor visitor);

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