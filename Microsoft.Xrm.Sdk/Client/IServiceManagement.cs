
using System.ServiceModel;
using System.ServiceModel.Description;

namespace Microsoft.Xrm.Sdk.Client
{
    /// <summary>An interface which provides a simpler authentication experience.</summary>
    public interface IServiceManagement<TService>
    {
        /// <summary>Gets or sets the current endpoint in use by a service.</summary>
        /// <returns>Type: Returns_ServiceEndpointThe current endpoint in use by a service.</returns>
        ServiceEndpoint CurrentServiceEndpoint { get; set; }

        /// <summary>Gets the type of authentication in use by the identity provider of the service.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Client.AuthenticationProviderType"></see>The type of authentication used by the  identity provider.</returns>
        AuthenticationProviderType AuthenticationType { get; }

        /// <summary>Gets the available endpoints of the security token service (STS).</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Client.IssuerEndpointDictionary"></see>The available endpoints of the security token service (STS).</returns>
        //IssuerEndpointDictionary IssuerEndpoints { get; }

        /// <summary>Gets the available endpoints of the user’s home realm identity provider.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Client.CrossRealmIssuerEndpointCollection"></see>The available endpoints of the user’s home realm identity provider.</returns>
        //CrossRealmIssuerEndpointCollection CrossRealmIssuerEndpoints { get; }

        /// <summary>Gets the policy configuration that identifies a Secure Token Service (STS).</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Client.PolicyConfiguration"></see>The policy configuration that identifies a Secure Token Service (STS).</returns>
        PolicyConfiguration PolicyConfiguration { get; }

        /// <summary>Creates a WCF channel factory that uses the default Kerberos credentials.</summary>
        /// <returns>Type: Returns_ChannelFactory_Generic&lt;TService&gt; where TService: <see cref="T:Microsoft.Xrm.Sdk.Discovery.IDiscoveryService"></see> or <see cref="T:Microsoft.Xrm.Sdk.IOrganizationService"></see>The WCF channel factory.</returns>
        ChannelFactory<TService> CreateChannelFactory();

        /// <summary>Creates a WCF channel factory with a specified type of authentication.</summary>
        /// <returns>Type: Returns_ChannelFactory_Generic&lt;TService&gt; where TService: <see cref="T:Microsoft.Xrm.Sdk.Discovery.IDiscoveryService"></see> or <see cref="T:Microsoft.Xrm.Sdk.IOrganizationService"></see>The WCF channel factory.</returns>
        /// <param name="clientAuthenticationType">Type: <see cref="T:Microsoft.Xrm.Sdk.Client.ClientAuthenticationType"></see>. Specifies the type of authentication.</param>
        ChannelFactory<TService> CreateChannelFactory(
          ClientAuthenticationType clientAuthenticationType);

        /// <summary>Creates a WCF channel factory using specified client credentials.</summary>
        /// <returns>Type: Returns_ChannelFactory_Generic&lt;TService&gt; where TService: <see cref="T:Microsoft.Xrm.Sdk.Discovery.IDiscoveryService"></see> or <see cref="T:Microsoft.Xrm.Sdk.IOrganizationService"></see>The WCF channel factory.</returns>
        /// <param name="clientCredentials">Type: Returns_ClientCredentials. Specifies the client credentials to use.</param>
        ChannelFactory<TService> CreateChannelFactory(ClientCredentials clientCredentials);

        /// <summary>Authenticates the logged on user with the service.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Client.AuthenticationCredentials"></see>The user’s authentication credentials, including the final security token.</returns>
        /// <param name="authenticationCredentials">Type: <see cref="T:Microsoft.Xrm.Sdk.Client.AuthenticationCredentials"></see>. Specifies the user’s logon credentials.</param>
        AuthenticationCredentials Authenticate(
          AuthenticationCredentials authenticationCredentials);

        /// <summary>Returns the identity provider used for a specified user when accessing a service.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Client.IdentityProvider"></see>The identity provider used for a specified user when accessing a service.</returns>
        /// <param name="userPrincipalName">Type: Returns_String. Specifies a user principal name (UPN).</param>
        //IdentityProvider GetIdentityProvider(string userPrincipalName);
    }
}
