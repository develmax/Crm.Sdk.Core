using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Metadata
{
    /// <summary>Contains one of the possible values for an attribute of type Status.</summary>
    [DataContract(Name = "StatusOptionMetadata", Namespace = "http://schemas.microsoft.com/xrm/2011/Metadata")]
    public sealed class StatusOptionMetadata : OptionMetadata
    {
        private int? _state;
        private string _transitionData;

        /// <summary>constructor_initializes<see cref="T:Microsoft.Xrm.Sdk.Metadata.StatusOptionMetadata"></see> class</summary>
        public StatusOptionMetadata()
        {
        }

        /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.Metadata.StatusOptionMetadata"></see> class</summary>
        /// <param name="state">Type: Returns_Nullable&lt;Returns_Int32&gt;.
        /// The state of the option.</param>
        /// <param name="value">Type: Returns_Int32.
        /// The value of the option.</param>
        public StatusOptionMetadata(int value, int? state)
            : base(value)
        {
            this.State = state;
        }

        /// <summary>Gets or sets the state that this status is associated with.</summary>
        /// <returns>Type: Returns_Nullable&lt;Returns_Int32&gt;
        /// The state that this status is associated with.</returns>
        [DataMember]
        public int? State
        {
            get
            {
                return this._state;
            }
            set
            {
                this._state = value;
            }
        }

        /// <summary>Gets or sets the status transitions allowed for this status.</summary>
        /// <returns>Type: Returns_String
        /// The encoded XML document that defines the allowed transitions.</returns>
        [DataMember]
        public string TransitionData
        {
            get
            {
                return this._transitionData;
            }
            set
            {
                this._transitionData = value;
            }
        }
    }
}