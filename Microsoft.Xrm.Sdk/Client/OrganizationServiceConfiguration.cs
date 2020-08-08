using System;
using System.Collections.Generic;
//using System.IdentityModel.Tokens;
using System.Net;
using System.Reflection;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
//using Microsoft.IdentityModel.Tokens;

namespace Microsoft.Xrm.Sdk.Client
{
    internal sealed class OrganizationServiceConfiguration : IServiceConfiguration<IOrganizationService>, /*IWebAuthentication<IOrganizationService>,*/ IServiceManagement<IOrganizationService>/*, IEndpointSwitch*/
    {
        private object _lockObject = new object();
        //private const string XrmServicesRoot = "xrmservices/";
        private ServiceConfiguration<IOrganizationService> service;

        private OrganizationServiceConfiguration()
        {
        }

        internal OrganizationServiceConfiguration(Uri serviceUri)
          : this(serviceUri, false, (Assembly)null)
        {
        }

        internal OrganizationServiceConfiguration(
          Uri serviceUri,
          bool enableProxyTypes,
          Assembly assembly)
        {
            try
            {
                this.service = new ServiceConfiguration<IOrganizationService>(serviceUri, true);
                if (enableProxyTypes && assembly != (Assembly)null)
                {
                    this.EnableProxyTypes(assembly);
                }
                else
                {
                    if (!enableProxyTypes)
                        return;
                    this.EnableProxyTypes();
                }
            }
            catch (InvalidOperationException ex)
            {
                bool flag = true;
                if (ex.InnerException is WebException innerException && innerException.Response is HttpWebResponse response && response.StatusCode == HttpStatusCode.Unauthorized)
                    flag = !this.AdjustServiceEndpoint(serviceUri);
                if (!flag)
                    return;
                throw;
            }
        }

        public void EnableProxyTypes()
        {
            ClientExceptionHelper.ThrowIfNull((object)this.CurrentServiceEndpoint, "CurrentServiceEndpoint");
            lock (this._lockObject)
            {
                if(this.CurrentServiceEndpoint.EndpointBehaviors.TryGetValue(typeof(ProxyTypesBehavior), out IEndpointBehavior proxyTypesBehavior))
                    this.CurrentServiceEndpoint.EndpointBehaviors.Remove((IEndpointBehavior)proxyTypesBehavior);
                this.CurrentServiceEndpoint.EndpointBehaviors.Add((IEndpointBehavior)new ProxyTypesBehavior());
            }
        }

        public void EnableProxyTypes(Assembly assembly)
        {
            ClientExceptionHelper.ThrowIfNull((object)assembly, nameof(assembly));
            ClientExceptionHelper.ThrowIfNull((object)this.CurrentServiceEndpoint, "CurrentServiceEndpoint");
            lock (this._lockObject)
            {
                if (this.CurrentServiceEndpoint.EndpointBehaviors.TryGetValue(typeof(ProxyTypesBehavior), out IEndpointBehavior proxyTypesBehavior))
                    this.CurrentServiceEndpoint.EndpointBehaviors.Remove((IEndpointBehavior)proxyTypesBehavior);
                this.CurrentServiceEndpoint.EndpointBehaviors.Add((IEndpointBehavior)new ProxyTypesBehavior(assembly));
            }
        }

        public ServiceEndpoint CurrentServiceEndpoint
        {
            get
            {
                return this.service.CurrentServiceEndpoint;
            }
            set
            {
                this.service.CurrentServiceEndpoint = value;
            }
        }

        /*public IssuerEndpoint CurrentIssuer
        {
            get
            {
                return this.service.CurrentIssuer;
            }
            set
            {
                this.service.CurrentIssuer = value;
            }
        }*/

        public AuthenticationProviderType AuthenticationType
        {
            get
            {
                return this.service.AuthenticationType;
            }
        }

        public ServiceEndpointDictionary ServiceEndpoints
        {
            get
            {
                return this.service.ServiceEndpoints;
            }
        }

        /*public IssuerEndpointDictionary IssuerEndpoints
        {
            get
            {
                return this.service.IssuerEndpoints;
            }
        }*/

        /*public CrossRealmIssuerEndpointCollection CrossRealmIssuerEndpoints
        {
            get
            {
                return this.service.CrossRealmIssuerEndpoints;
            }
        }*/

        public ChannelFactory<IOrganizationService> CreateChannelFactory()
        {
            return this.service.CreateChannelFactory(ClientAuthenticationType.Kerberos);
        }

        public ChannelFactory<IOrganizationService> CreateChannelFactory(
          ClientAuthenticationType clientAuthenticationType)
        {
            return this.service.CreateChannelFactory(clientAuthenticationType);
        }

        public ChannelFactory<IOrganizationService> CreateChannelFactory(
          ClientCredentials clientCredentials)
        {
            return this.service.CreateChannelFactory(clientCredentials);
        }

        /*public SecurityTokenResponse Authenticate(
          ClientCredentials clientCredentials)
        {
            return this.service.Authenticate(clientCredentials);
        }

        public SecurityTokenResponse Authenticate(SecurityToken securityToken)
        {
            return this.service.Authenticate(securityToken);
        }

        public SecurityTokenResponse Authenticate(
          ClientCredentials clientCredentials,
          SecurityTokenResponse deviceSecurityTokenResponse)
        {
            return this.service.Authenticate(clientCredentials, deviceSecurityTokenResponse);
        }

        public SecurityTokenResponse AuthenticateDevice(
          ClientCredentials clientCredentials)
        {
            return this.service.AuthenticateDevice(clientCredentials);
        }

        public SecurityTokenResponse AuthenticateCrossRealm(
          ClientCredentials clientCredentials,
          string appliesTo,
          Uri crossRealmSts)
        {
            return this.service.AuthenticateCrossRealm(clientCredentials, appliesTo, crossRealmSts);
        }

        public SecurityTokenResponse AuthenticateCrossRealm(
          SecurityToken securityToken,
          string appliesTo,
          Uri crossRealmSts)
        {
            return this.service.AuthenticateCrossRealm(securityToken, appliesTo, crossRealmSts);
        }*/

        public PolicyConfiguration PolicyConfiguration
        {
            get
            {
                return this.service.PolicyConfiguration;
            }
        }

        /*public IdentityProvider GetIdentityProvider(string userPrincipalName)
        {
            return this.service.GetIdentityProvider(userPrincipalName);
        }*/

        /*public SecurityTokenResponse Authenticate(
          ClientCredentials clientCredentials,
          Uri uri,
          string keyType)
        {
            return this.service.Authenticate(clientCredentials, uri, keyType);
        }

        public SecurityTokenResponse Authenticate(
          SecurityToken securityToken,
          Uri uri,
          string keyType)
        {
            return this.service.Authenticate(securityToken, uri, keyType);
        }*/

        private bool AdjustServiceEndpoint(Uri serviceUri)
        {
            Uri serviceUri1 = OrganizationServiceConfiguration.RemoveOrgName(serviceUri);
            if (serviceUri1 != (Uri)null)
            {
                this.service = new ServiceConfiguration<IOrganizationService>(serviceUri1);
                if (this.service != null && this.service.ServiceEndpoints != null)
                {
                    foreach (KeyValuePair<string, ServiceEndpoint> serviceEndpoint in (Dictionary<string, ServiceEndpoint>)this.service.ServiceEndpoints)
                        ServiceMetadataUtility.ReplaceEndpointAddress(serviceEndpoint.Value, serviceUri);
                    return true;
                }
            }
            return false;
        }


        private static Uri RemoveOrgName(Uri serviceUri)
        {
            if (!serviceUri.AbsolutePath.StartsWith("/xrmservices/", StringComparison.OrdinalIgnoreCase))
            {
                StringBuilder stringBuilder = new StringBuilder();
                for (int index = 2; index < serviceUri.Segments.Length; ++index)
                    stringBuilder.Append(serviceUri.Segments[index]);
                if (stringBuilder.Length > 0)
                {
                    serviceUri = new UriBuilder(serviceUri.GetComponents(UriComponents.SchemeAndServer, UriFormat.UriEscaped))
                    {
                        Path = stringBuilder.ToString()
                    }.Uri;
                    return serviceUri;
                }
            }
            return (Uri)null;
        }

        public AuthenticationCredentials Authenticate(
          AuthenticationCredentials authenticationCredentials)
        {
            return this.service.Authenticate(authenticationCredentials);
        }

        /*public bool EndpointAutoSwitchEnabled
        {
            get
            {
                return this.service.EndpointAutoSwitchEnabled;
            }
            set
            {
                this.service.EndpointAutoSwitchEnabled = value;
            }
        }*/

        /*public Uri AlternateEndpoint
        {
            get
            {
                return this.service.AlternateEndpoint;
            }
        }

        public Uri PrimaryEndpoint
        {
            get
            {
                return this.service.PrimaryEndpoint;
            }
        }*/

        /*public void SwitchEndpoint()
        {
            this.service.SwitchEndpoint();
        }

        public event EventHandler<EndpointSwitchEventArgs> EndpointSwitched
        {
            add
            {
                this.service.EndpointSwitched += value;
            }
            remove
            {
                this.service.EndpointSwitched -= value;
            }
        }

        public event EventHandler<EndpointSwitchEventArgs> EndpointSwitchRequired
        {
            add
            {
                this.service.EndpointSwitchRequired += value;
            }
            remove
            {
                this.service.EndpointSwitchRequired -= value;
            }
        }

        public bool HandleEndpointSwitch()
        {
            return this.service.HandleEndpointSwitch();
        }*/

        /*public bool IsPrimaryEndpoint
        {
            get
            {
                return this.service.IsPrimaryEndpoint;
            }
        }*/

        /*public bool CanSwitch(Uri currentUri)
        {
            return this.service.CanSwitch(currentUri);
        }*/
    }
}
