using System.ComponentModel;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Query
{
    /// <summary>Contains a query expressed in FetchXML.</summary>
    [DataContract(Name = "FetchExpression", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
    public sealed class FetchExpression : QueryBase
    {
        private string _query;

        /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Xrm.Sdk.Query.FetchExpression"></see> class.</summary>
        /// <param name="query">Type: Returns_String. The FetchXML query string.</param>
        public FetchExpression(string query)
        {
            this._query = query;
        }

        /// <summary>Gets or sets the FetchXML query string.</summary>
        /// <returns>Type: Returns_StringThe FetchXML query string.</returns>
        [DataMember]
        public string Query
        {
            get
            {
                return this._query;
            }
            set
            {
                this._query = value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal override void Accept(IQueryVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}