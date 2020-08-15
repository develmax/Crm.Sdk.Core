using System.ComponentModel;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Query
{
    /// <summary>Specifies a number of pages and a number of entity instances per page to return from the query.  </summary>
    [DataContract(Name = "PagingInfo", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
    public sealed class PagingInfo : IExtensibleDataObject
    {
        private int _pageNumber;
        private int _count;
        private string _pagingCookie;
        private bool _returnTotalRecordCount;
        private ExtensionDataObject _extensionDataObject;

        /// <summary>Gets or sets the number of pages returned from the query.</summary>
        /// <returns>Type: Returns_Int32
        /// The number of pages returned from the query.</returns>
        [DataMember]
        public int PageNumber
        {
            get
            {
                return this._pageNumber;
            }
            set
            {
                this._pageNumber = value;
            }
        }

        /// <summary>Gets or sets the number of entity instances returned per page.</summary>
        /// <returns>Type: Returns_Int32
        /// The number of entity instances returned per page.</returns>
        [DataMember]
        public int Count
        {
            get
            {
                return this._count;
            }
            set
            {
                this._count = value;
            }
        }

        /// <summary>Sets whether the total number of records should be returned from the query.</summary>
        /// <returns>Type: Returns_Booleantrue if the <see cref="P:Microsoft.Xrm.Sdk.EntityCollection.TotalRecordCount"></see> should be set when the query is executed; otherwise, false.</returns>
        [DataMember]
        public bool ReturnTotalRecordCount
        {
            get
            {
                return this._returnTotalRecordCount;
            }
            set
            {
                this._returnTotalRecordCount = value;
            }
        }

        /// <summary>Gets or sets the info used to page large result sets.</summary>
        /// <returns>Type: Returns_String
        /// The info used to page large result sets.</returns>
        [DataMember]
        public string PagingCookie
        {
            get
            {
                return this._pagingCookie;
            }
            set
            {
                this._pagingCookie = value;
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
