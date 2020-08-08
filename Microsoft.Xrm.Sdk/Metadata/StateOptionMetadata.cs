using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
    /// <summary>Contains data to define an option for the options in a State attribute.</summary>
    [DataContract(Name = "StateOptionMetadata", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
    public sealed class StateOptionMetadata : OptionMetadata
    {
        private int? _defaultStatus;
        private string _invariantName;

        /// <summary>Gets or sets the default status value associated with this state.</summary>
        /// <returns>Type: Returns_Nullable&lt;Returns_Int32&gt;
        /// The default status value associated with this state.</returns>
        [DataMember]
        public int? DefaultStatus
        {
            get
            {
                return this._defaultStatus;
            }
            set
            {
                this._defaultStatus = value;
            }
        }

        /// <summary>Gets or sets the name of the state that does not change.</summary>
        /// <returns>Type: Returns_String
        /// The name of the state that does not change.</returns>
        [DataMember]
        public string InvariantName
        {
            get
            {
                return this._invariantName;
            }
            set
            {
                this._invariantName = value;
            }
        }
    }
}