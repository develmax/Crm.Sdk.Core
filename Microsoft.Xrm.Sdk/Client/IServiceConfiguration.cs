using System;
//using System.IdentityModel.Tokens;
using System.ServiceModel;
using System.ServiceModel.Description;
//using Microsoft.IdentityModel.Tokens;

namespace Microsoft.Xrm.Sdk.Client
{
    /// <summary>Represents a configured pn_microsoftcrm service.</summary>
    public interface IServiceConfiguration<TService>
    {
        /// <summary>Gets or sets the endpoint used by the Secure Token Service (STS) to issue the trusted token.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Client.IssuerEndpoint"></see>The endpoint used by the Secure Token Service (STS) to issue the trusted token.</returns>
        //IssuerEndpoint CurrentIssuer { get; set; }

        /// <summary>Gets or sets the current endpoint in use by a service.</summary>
        /// <returns>Type: Returns_ServiceEndpointThe current endpoint in use by a service.</returns>
        ServiceEndpoint CurrentServiceEndpoint { get; set; }

        /// <summary>Gets the type of authentication in use by the identity provider of the service.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Client.AuthenticationProviderType"></see>Thee type of authentication being used.</returns>
        AuthenticationProviderType AuthenticationType { get; }

        /// <summary>Gets the available endpoints of the service.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Client.ServiceEndpointDictionary"></see>The available endpoints of the service.</returns>
        ServiceEndpointDictionary ServiceEndpoints { get; }

        /// <summary>Gets the available endpoints of the security token service (STS).</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Client.IssuerEndpointDictionary"></see>The available endpoints of the security token service (STS).</returns>
        //IssuerEndpointDictionary IssuerEndpoints { get; }

        /// <summary>Gets the available endpoints of the user’s home realm identity provider.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Client.CrossRealmIssuerEndpointCollection"></see>The available endpoints.</returns>
        //CrossRealmIssuerEndpointCollection CrossRealmIssuerEndpoints { get; }

        /// <summary>Gets the policy configuration that identifies a Secure Token Service (STS).</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Client.PolicyConfiguration"></see>The policy configuration.</returns>
        PolicyConfiguration PolicyConfiguration { get; }

        /// <summary>Creates a client factory that uses the default Kerberos credentials.</summary>
        /// <returns>Type: Returns_ChannelFactory_Generic&lt;TService&gt;The channel factory.</returns>
        ChannelFactory<TService> CreateChannelFactory();

        /// <summary>Creates a WCF channel factory with a specified type of authentication.</summary>
        /// <returns>Type: Returns_ChannelFactory_Generic&lt;TService&gt;The channel factory.</returns>
        /// <param name="clientAuthenticationType">Type: <see cref="T:Microsoft.Xrm.Sdk.Client.ClientAuthenticationType"></see>. Specifies the type of authentication.</param>
        ChannelFactory<TService> CreateChannelFactory(
          ClientAuthenticationType clientAuthenticationType);

        /// <summary>Creates a WCF channel factory that supports passing the client credentials, regardless of whether in federation authentication mode or not.</summary>
        /// <returns>Type: Returns_ChannelFactory_Generic&lt; TService&gt;The channel factory.</returns>
        /// <param name="clientCredentials">Type: Returns_ClientCredentials. Specifies client authentication credentials.</param>
        ChannelFactory<TService> CreateChannelFactory(ClientCredentials clientCredentials);

        /// <summary>Authenticates against the trusted pn_microsoftcrm Secure Token Service using client credentials. </summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Client.SecurityTokenResponse"></see>The security token response. </returns>
        /// <param name="clientCredentials">Type: Returns_ClientCredentials. Specifies a client credential instance containing either Windowshttp://msdn.microsoft.com/en-us/library/system.servicemodel.description.clientcredentials.windows.aspx credentials or UserNamehttp://msdn.microsoft.com/en-us/library/system.servicemodel.description.clientcredentials.username.aspx credentials.</param>
        //SecurityTokenResponse Authenticate(ClientCredentials clientCredentials);

        /// <summary>Authenticates against the trusted pn_microsoftcrm Secure Token Service using a security token.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Client.SecurityTokenResponse"></see>The security token response. </returns>
        /// <param name="securityToken">Type: Returns_SecurityToken. A security token retrieved from an identity provider other than the trusted pn_microsoftcrm Secure Token Service (when in federation mode).</param>
        //SecurityTokenResponse Authenticate(SecurityToken securityToken);

        /// <summary>Authenticates against a remote Secure Token Service (STS) using client credentials.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Client.SecurityTokenResponse"></see>The security token response.</returns>
        /// <param name="crossRealmSts">Type: Returns_URI. Specifies the URI of the cross realm STS metadata endpoint.</param>
        /// <param name="appliesTo">Type: Returns_String. Specifies the identifier of the STS to authenticate on behalf of.</param>
        /// <param name="clientCredentials">Type: Returns_ClientCredentials. Specifies a client credentials instance with the Windows  credentials or the UserName (.UserName and .Password) set.</param>
        /*SecurityTokenResponse AuthenticateCrossRealm(
          ClientCredentials clientCredentials,
          string appliesTo,
          Uri crossRealmSts);*/

        /// <summary>Authenticates against a remote Secure Token Service (STS) using a security token retrieved from an identity provider (when in federation mode).</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Client.SecurityTokenResponse"></see>
        /// The security token response.</returns>
        /// <param name="crossRealmSts">Type: Returns_URI. Specifies the URI of the cross realm STS metadata endpoint.</param>
        /// <param name="appliesTo">Type: Returns_String. Specifies the identifier of the STS to authenticate on behalf of.</param>
        /// <param name="securityToken">Type: Returns_SecurityToken. Specifies a security token issued from an identity provider.</param>
        /*SecurityTokenResponse AuthenticateCrossRealm(
          SecurityToken securityToken,
          string appliesTo,
          Uri crossRealmSts);*/

        /// <summary>Authenticates against pn_Windows_Live_ID  using client credentials and a security token response.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Client.SecurityTokenResponse"></see>The security token response.</returns>
        /// <param name="deviceSecurityToken">Type: <see cref="T:Microsoft.Xrm.Sdk.Client.SecurityTokenResponse"></see>. A security token response received from authenticating the user's device with pn_Windows_Live_ID.</param>
        /// <param name="clientCredentials">Type: Returns_ClientCredentials. Specifies a client credential instance containing UserNamehttp://msdn.microsoft.com/en-us/library/system.servicemodel.description.clientcredentials.username.aspx credentials where the UserName and Password properties are set.</param>
        /*SecurityTokenResponse Authenticate(
          ClientCredentials clientCredentials,
          SecurityTokenResponse deviceSecurityToken);*/

        /// <summary>Authenticates a registered device against pn_Windows_Live_ID.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Client.SecurityTokenResponse"></see>
        /// The security token response.</returns>
        /// <param name="clientCredentials">Type: Returns_ClientCredentials. Specifies a client credential instance.</param>
        /*SecurityTokenResponse AuthenticateDevice(
          ClientCredentials clientCredentials);*/

        /// <summary>Returns the identity provider used for a specified user when accessing a service.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Client.IdentityProvider"></see>The identity provider.</returns>
        /// <param name="userPrincipalName">Type: Returns_String. Specifies a user principal name (UPN).</param>
        //IdentityProvider GetIdentityProvider(string userPrincipalName);
    }
}
