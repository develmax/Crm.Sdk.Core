using System;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Discovery
{
    /// <summary>Contains the response from processing <see cref="T:Microsoft.Xrm.Sdk.Discovery.RetrieveUserIdByExternalIdRequest"></see>. </summary>
    [DataContract(Name = "RetrieveUserIdByExternalIdResponse", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts/Discovery")]
    public sealed class RetrieveUserIdByExternalIdResponse : DiscoveryResponse
    {
        private Guid _userId;

        /// <summary>Gets or sets the ID of the pn_CRM_Online system user.</summary>
        /// <returns>Type: Returns_GuidThe ID of the user.</returns>
        [DataMember]
        public Guid UserId
        {
            get
            {
                return this._userId;
            }
            set
            {
                this._userId = value;
            }
        }
    }
}