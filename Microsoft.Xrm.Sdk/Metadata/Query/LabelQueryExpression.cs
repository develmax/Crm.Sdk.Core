using System.ComponentModel;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata.Query
{
    /// <summary>Defines the languages for the labels to be retrieved for metadata items that have labels.</summary>
    [DataContract(Name = "LabelQueryExpression", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata/Query")]
    public sealed class LabelQueryExpression : MetadataQueryBase
    {
        private DataCollection<int> _filterLanguages;
        private int? _missingLabelBehavior;

        /// <summary>Gets the LCID values for localized labels to be retrieved for metadata items.</summary>
        /// <returns>Type <see cref="T:Microsoft.Xrm.Sdk.DataCollection`1"></see>&lt;Returns_Int32&gt;The LCID values for localized labels to be retrieved for metadata items.</returns>
        [DataMember]
        public DataCollection<int> FilterLanguages
        {
            get
            {
                return this._filterLanguages ?? (this._filterLanguages = new DataCollection<int>());
            }
            private set
            {
                this._filterLanguages = value;
            }
        }

        /// <summary>When this optional parameter is set to 1, the query will include labels for the base language if the label for the requested language is not there.</summary>
        /// <returns>Type: Returns_Int32.</returns>
        [DataMember(Order = 60)]
        public int? MissingLabelBehavior
        {
            get
            {
                return this._missingLabelBehavior;
            }
            set
            {
                this._missingLabelBehavior = value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal override void Accept(IMetadataQueryExpressionVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}