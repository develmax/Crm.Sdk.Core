using System;
using System.ServiceModel.Description;

namespace Microsoft.Xrm.Sdk.Client
{
    /// <summary>Represents client-side user logon credentials.</summary>
    public sealed class AuthenticationCredentials
    {
        private ClientCredentials _clientCredentials = new ClientCredentials();

        /// <summary>Gets or sets the scope that a security token request applies to, as defined in the WS-Trust specification.</summary>
        /// <returns>Type: Returns_URI The scope that a security token request applies to.</returns>
        //public Uri AppliesTo { get; set; }

        /// <summary>Gets or sets the identity provider address.</summary>
        /// <returns>Type: Returns_URI The identity provider address.</returns>
        //public Uri HomeRealm { get; set; }

        /// <summary>Gets or sets the UPN that is an internet-style login name for a user based on the Internet standard RFC 822.</summary>
        /// <returns>Type: Returns_StringThe UPN.</returns>
        //public string UserPrincipalName { get; set; }

        /// <summary>Gets or sets the service credential authentication settings for use on the client side of communication.</summary>
        /// <returns>Type: Returns_ClientCredentials The service credential authentication settings.</returns>
        public ClientCredentials ClientCredentials
        {
            get
            {
                return this._clientCredentials;
            }
            set
            {
                this._clientCredentials = value;
            }
        }

        /// <summary>Gets or sets the security token response.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Client.SecurityTokenResponse"></see>The security token response.</returns>
        //public SecurityTokenResponse SecurityTokenResponse { get; set; }

        /// <summary>Gets or sets additional credentials required by the site.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Client.AuthenticationCredentials"></see>The additional credentials required by the site.</returns>
        //public AuthenticationCredentials SupportingCredentials { get; set; }

        /*internal IssuerEndpoint IssuerEndpoint
        {
            get
            {
                return this.IssuerEndpoints == null ? (IssuerEndpoint)null : this.IssuerEndpoints.GetIssuerEndpoint(this.EndpointType);
            }
        }*/

        //internal TokenServiceCredentialType EndpointType { get; set; }

        //internal string RequestType { get; set; }

        //internal string KeyType { get; set; }

        //internal IssuerEndpointDictionary IssuerEndpoints { get; set; }
    }
}
