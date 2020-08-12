//using Microsoft.IdentityModel.Protocols.WSTrust;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
//using System.IdentityModel.Tokens;
using System.Linq;
using System.Security;
using System.Security.Permissions;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Security;
using System.Text;
//using Microsoft.IdentityModel.Tokens;

namespace Microsoft.Xrm.Sdk.Client
{
    [SecuritySafeCritical]
    [SecurityPermission(SecurityAction.Demand, Unrestricted = true)]
    internal sealed class ServiceConfiguration<TService> //: IEndpointSwitch
    {
        private static object _lockObject = new object();
        //private TokenServiceCredentialType _tokenEndpointType = TokenServiceCredentialType.AsymmetricToken;
        //internal const string DefaultRequestType = "http://docs.oasis-open.org/ws-sx/ws-trust/200512/Issue";
        private ServiceEndpoint currentServiceEndpoint;

        //public bool EndpointAutoSwitchEnabled { get; set; }

        /*public string GetAlternateEndpointAddress(string host)
        {
            int startIndex = host.IndexOf('.');
            return host.Insert(startIndex, "." + this.AlternateEndpointToken);
        }*/

        /*public void OnEndpointSwitchRequiredEvent()
        {
            this.HandleEndpointEvent(this.EndpointSwitchRequired, this.CurrentServiceEndpoint.Address.Uri == this.PrimaryEndpoint ? this.AlternateEndpoint : this.PrimaryEndpoint, this.CurrentServiceEndpoint.Address.Uri);
        }

        public void OnEndpointSwitchedEvent()
        {
            this.HandleEndpointEvent(this.EndpointSwitched, this.CurrentServiceEndpoint.Address.Uri, this.CurrentServiceEndpoint.Address.Uri == this.PrimaryEndpoint ? this.AlternateEndpoint : this.PrimaryEndpoint);
        }*/

        /*private void HandleEndpointEvent(
          EventHandler<EndpointSwitchEventArgs> tmp,
          Uri newUrl,
          Uri previousUrl)
        {
            if (tmp == null)
                return;
            EndpointSwitchEventArgs e = new EndpointSwitchEventArgs();
            lock (ServiceConfiguration<TService>._lockObject)
            {
                e.NewUrl = newUrl;
                e.PreviousUrl = previousUrl;
            }
            tmp((object)this, e);
        }

        public event EventHandler<EndpointSwitchEventArgs> EndpointSwitched;

        public event EventHandler<EndpointSwitchEventArgs> EndpointSwitchRequired;*/

        public string AlternateEndpointToken { get; set; }

        public Uri AlternateEndpoint { get; internal set; }

        public Uri PrimaryEndpoint { get; internal set; }

        /*private void SetEndpointSwitchingBehavior()
        {
            if (this.ServiceEndpointMetadata.ServiceUrls == null)
                return;
            this.PrimaryEndpoint = this.ServiceEndpointMetadata.ServiceUrls.PrimaryEndpoint;
            bool flag1 = false;
            bool flag2 = true;
            if (!this.ServiceEndpointMetadata.ServiceUrls.GeneratedFromAlternate)
            {
                FailoverPolicy failoverPolicy = this.CurrentServiceEndpoint.Binding.CreateBindingElements().Find<FailoverPolicy>();
                if (failoverPolicy != null && failoverPolicy.PolicyElements.ContainsKey("FailoverAvailable"))
                {
                    flag1 = Convert.ToBoolean(failoverPolicy.PolicyElements["FailoverAvailable"], (IFormatProvider)CultureInfo.InvariantCulture);
                    flag2 = Convert.ToBoolean(failoverPolicy.PolicyElements["EndpointEnabled"], (IFormatProvider)CultureInfo.InvariantCulture);
                }
            }
            else
                flag1 = true;
            if (!flag1)
                return;
            this.AlternateEndpoint = this.ServiceEndpointMetadata.ServiceUrls.AlternateEndpoint;
            if (flag2)
                return;
            //this.SwitchEndpoint();
        }*/

        public bool IsPrimaryEndpoint
        {
            get
            {
                lock (ServiceConfiguration<TService>._lockObject)
                    return this.CurrentServiceEndpoint.Address.Uri != this.AlternateEndpoint;
            }
        }

        public bool CanSwitch(Uri currentUri)
        {
            ClientExceptionHelper.ThrowIfNull((object)currentUri, nameof(currentUri));
            lock (ServiceConfiguration<TService>._lockObject)
                return currentUri == this.CurrentServiceEndpoint.Address.Uri;
        }

        /*public bool HandleEndpointSwitch()
        {
            if (this.AlternateEndpoint != (Uri)null)
            {
                this.OnEndpointSwitchRequiredEvent();
                if (this.EndpointAutoSwitchEnabled)
                {
                    this.SwitchEndpoint();
                    return true;
                }
            }
            return false;
        }

        public void SwitchEndpoint()
        {
            if (this.AlternateEndpoint == (Uri)null)
                return;
            lock (ServiceConfiguration<TService>._lockObject)
            {
                this.CurrentServiceEndpoint.Address = !(this.CurrentServiceEndpoint.Address.Uri != this.AlternateEndpoint) ? new EndpointAddress(this.PrimaryEndpoint, this.CurrentServiceEndpoint.Address.Identity, this.CurrentServiceEndpoint.Address.Headers.ToArray()) : new EndpointAddress(this.AlternateEndpoint, this.CurrentServiceEndpoint.Address.Identity, this.CurrentServiceEndpoint.Address.Headers.ToArray());
                this.OnEndpointSwitchedEvent();
            }
        }*/

        internal static ServiceUrls CalculateEndpoints(Uri serviceUri)
        {
            ServiceUrls serviceUrls = new ServiceUrls();
            UriBuilder uriBuilder = new UriBuilder(serviceUri);
            string[] strArray1 = uriBuilder.Host.Split('.');
            if (strArray1[0].EndsWith("--s", StringComparison.OrdinalIgnoreCase))
            {
                serviceUrls.AlternateEndpoint = uriBuilder.Uri;
                strArray1[0] = strArray1[0].Remove(strArray1[0].Length - 3);
                uriBuilder.Host = string.Join(".", strArray1);
                serviceUrls.PrimaryEndpoint = uriBuilder.Uri;
                serviceUrls.GeneratedFromAlternate = true;
            }
            else
            {
                serviceUrls.PrimaryEndpoint = uriBuilder.Uri;
                string[] strArray2;
                (strArray2 = strArray1)[0] = strArray2[0] + "--s";
                uriBuilder.Host = string.Join(".", strArray1);
                serviceUrls.AlternateEndpoint = uriBuilder.Uri;
            }
            return serviceUrls;
        }

        public AuthenticationCredentials Authenticate(
          AuthenticationCredentials authenticationCredentials)
        {
            ClientExceptionHelper.ThrowIfNull((object)authenticationCredentials, nameof(authenticationCredentials));
            switch (this.AuthenticationType)
            {
                case AuthenticationProviderType.ActiveDirectory:
                    ServiceMetadataUtility.AdjustUserNameForWindows(authenticationCredentials.ClientCredentials);
                    return authenticationCredentials;
                /*case AuthenticationProviderType.Federation:
                    //return this.AuthenticateFederationInternal(authenticationCredentials);
                case AuthenticationProviderType.LiveId:
                    //return this.AuthenticateLiveIdInternal(authenticationCredentials);
                case AuthenticationProviderType.OnlineFederation:
                    //return this.ShouldAuthenticateWithLiveId<TService>(authenticationCredentials.ClientCredentials) ? this.AuthenticateHybridLiveIdInternal(authenticationCredentials) : this.AuthenticateOnlineFederationInternal(authenticationCredentials);*/
                default:
                    return authenticationCredentials;
            }
        }

        /*private AuthenticationCredentials AuthenticateFederationInternal(
          AuthenticationCredentials authenticationCredentials)
        {
            if (authenticationCredentials.SecurityTokenResponse != null)
                return this.AuthenticateFederationTokenInternal(authenticationCredentials);
            if (authenticationCredentials.AppliesTo == (Uri)null)
                authenticationCredentials.AppliesTo = this.CurrentServiceEndpoint.Address.Uri;
            authenticationCredentials.EndpointType = this.GetCredentialsEndpointType(authenticationCredentials.ClientCredentials);
            authenticationCredentials.IssuerEndpoints = authenticationCredentials.HomeRealm != (Uri)null ? this.CrossRealmIssuerEndpoints[authenticationCredentials.HomeRealm] : this.IssuerEndpoints;
            authenticationCredentials.SecurityTokenResponse = this.AuthenticateInternal(authenticationCredentials);
            return authenticationCredentials;
        }*/

        /*private AuthenticationCredentials AuthenticateFederationTokenInternal(
          AuthenticationCredentials authenticationCredentials)
        {
            AuthenticationCredentials authenticationCredentials1 = new AuthenticationCredentials();
            authenticationCredentials1.SupportingCredentials = authenticationCredentials;
            if (authenticationCredentials.AppliesTo == (Uri)null)
                authenticationCredentials.AppliesTo = this.CurrentServiceEndpoint.Address.Uri;
            authenticationCredentials.EndpointType = this._tokenEndpointType;
            authenticationCredentials.KeyType = string.Empty;
            authenticationCredentials.IssuerEndpoints = this.IssuerEndpoints;
            authenticationCredentials1.SecurityTokenResponse = this.AuthenticateInternal(authenticationCredentials);
            return authenticationCredentials1;
        }*/

        /*private AuthenticationCredentials AuthenticateLiveIdInternal(
          AuthenticationCredentials authenticationCredentials)
        {
            ClientExceptionHelper.ThrowIfNull((object)authenticationCredentials.ClientCredentials, "authenticationCredentials.ClientCredentials");
            ClientExceptionHelper.ThrowIfNullOrEmpty(authenticationCredentials.ClientCredentials.UserName.UserName, "authenticationCredentials.ClientCredentials.UserName.UserName");
            ClientExceptionHelper.ThrowIfNullOrEmpty(authenticationCredentials.ClientCredentials.UserName.Password, "authenticationCredentials.ClientCredentials.UserName.Password");
            ClientExceptionHelper.ThrowIfNull((object)authenticationCredentials.SupportingCredentials, "authenticationCredentials.SupportingCredentials");
            ClientExceptionHelper.ThrowIfNull((object)(this.PolicyConfiguration as OnlinePolicyConfiguration), "onlinePolicy");
            AuthenticationCredentials authenticationCredentials1 = new AuthenticationCredentials();
            //if (authenticationCredentials.SupportingCredentials.SecurityTokenResponse == null)
            {
                /*ClientExceptionHelper.ThrowIfNull((object)authenticationCredentials.SupportingCredentials.ClientCredentials, "authenticationCredentials.SupportingCredentials.ClientCredentials");
                ClientExceptionHelper.ThrowIfNullOrEmpty(authenticationCredentials.SupportingCredentials.ClientCredentials.UserName.UserName, "authenticationCredentials.SupportingCredentials.ClientCredentials.UserName.UserName");
                ClientExceptionHelper.ThrowIfNullOrEmpty(authenticationCredentials.SupportingCredentials.ClientCredentials.UserName.Password, "authenticationCredentials.SupportingCredentials.ClientCredentials.UserName.Password");#1#
                //authenticationCredentials.SupportingCredentials.SecurityTokenResponse = this.AuthenticateDevice(authenticationCredentials.SupportingCredentials.ClientCredentials);
            }
            /*ClientExceptionHelper.ThrowIfNull((object)authenticationCredentials.SupportingCredentials.SecurityTokenResponse, "deviceTokenResponse");
            authenticationCredentials1.SupportingCredentials = authenticationCredentials;
            authenticationCredentials1.SecurityTokenResponse = this.Authenticate(authenticationCredentials.ClientCredentials, authenticationCredentials.SupportingCredentials.SecurityTokenResponse);#1#
            return authenticationCredentials1;
        }*/

        /*private AuthenticationCredentials AuthenticateHybridLiveIdInternal(
          AuthenticationCredentials authenticationCredentials)
        {
            ClientExceptionHelper.ThrowIfNull((object)authenticationCredentials.ClientCredentials, "authenticationCredentials.ClientCredentials");
            ClientExceptionHelper.ThrowIfNullOrEmpty(authenticationCredentials.ClientCredentials.UserName.UserName, "authenticationCredentials.ClientCredentials.UserName.UserName");
            ClientExceptionHelper.ThrowIfNullOrEmpty(authenticationCredentials.ClientCredentials.UserName.Password, "authenticationCredentials.ClientCredentials.UserName.Password");
            ClientExceptionHelper.ThrowIfNull((object)authenticationCredentials.SupportingCredentials, "authenticationCredentials.SupportingCredentials");
            ClientExceptionHelper.ThrowIfNull((object)(this.PolicyConfiguration as OnlinePolicyConfiguration), "onlinePolicy");
            AuthenticationCredentials authenticationCredentials1 = new AuthenticationCredentials();
            IdentityProviderTrustConfiguration liveTrustConfig = this.GetLiveTrustConfig<LiveIdentityProviderTrustConfiguration>();
            ClientExceptionHelper.ThrowIfNull((object)liveTrustConfig, "idp");
            EndpointAddress tokenEndpoint = new EndpointAddress(liveTrustConfig.Endpoint, new AddressHeader[0]);
            if (authenticationCredentials.SupportingCredentials.SecurityTokenResponse == null)
            {
                ClientExceptionHelper.ThrowIfNull((object)authenticationCredentials.SupportingCredentials.ClientCredentials, "authenticationCredentials.SupportingCredentials.ClientCredentials");
                ClientExceptionHelper.ThrowIfNullOrEmpty(authenticationCredentials.SupportingCredentials.ClientCredentials.UserName.UserName, "authenticationCredentials.SupportingCredentials.ClientCredentials.UserName.UserName");
                ClientExceptionHelper.ThrowIfNullOrEmpty(authenticationCredentials.SupportingCredentials.ClientCredentials.UserName.Password, "authenticationCredentials.SupportingCredentials.ClientCredentials.UserName.Password");
                authenticationCredentials.SupportingCredentials.SecurityTokenResponse = this.IssueHybridLiveId(authenticationCredentials.SupportingCredentials.ClientCredentials, (SecurityTokenResponse)null, string.Empty, liveTrustConfig, tokenEndpoint);
            }
            ClientExceptionHelper.ThrowIfNull((object)authenticationCredentials.SupportingCredentials.SecurityTokenResponse, "deviceTokenResponse");
            authenticationCredentials1.SupportingCredentials = authenticationCredentials;
            authenticationCredentials1.SecurityTokenResponse = this.IssueHybridLiveId(authenticationCredentials.ClientCredentials, authenticationCredentials.SupportingCredentials.SecurityTokenResponse, string.Empty, liveTrustConfig, tokenEndpoint);
            return authenticationCredentials1;
        }*/

        /*[SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        [SuppressMessage("Microsoft.Usage", "CA9888:DisposeObjectsCorrectly", Justification = "Value is returned from method and cannot be disposed.")]
        private SecurityTokenResponse IssueHybridLiveId(
          ClientCredentials clientCredentials,
          SecurityTokenResponse deviceToken,
          string keyType,
          IdentityProviderTrustConfiguration idp,
          EndpointAddress tokenEndpoint)
        {
            ClientExceptionHelper.ThrowIfNull((object)clientCredentials, nameof(clientCredentials));
            ClientExceptionHelper.ThrowIfNull((object)idp, nameof(idp));
            ClientExceptionHelper.ThrowIfNull((object)tokenEndpoint, nameof(tokenEndpoint));
            string uri = deviceToken == null ? idp.LiveIdAppliesTo : idp.AppliesTo;
            ClientExceptionHelper.ThrowIfNull((object)idp.Binding, "idp.Binding");
            LiveIdTrustChannelFactory trustChannelFactory = (LiveIdTrustChannelFactory)null;
            Microsoft.IdentityModel.Protocols.WSTrust.WSTrustChannel communicationObject = (Microsoft.IdentityModel.Protocols.WSTrust.WSTrustChannel)null;
            try
            {
                trustChannelFactory = new LiveIdTrustChannelFactory(idp.Binding, tokenEndpoint, idp);
                trustChannelFactory.Credentials.UserName.UserName = clientCredentials.UserName.UserName;
                trustChannelFactory.Credentials.UserName.Password = clientCredentials.UserName.Password;
                if (deviceToken != null)
                    trustChannelFactory.DeviceTokenResponse = deviceToken;
                lock (ServiceConfiguration<TService>._lockObject)
                    trustChannelFactory.ConfigureChannelFactory<Microsoft.IdentityModel.Protocols.WSTrust.IWSTrustChannelContract>();
                communicationObject = (Microsoft.IdentityModel.Protocols.WSTrust.WSTrustChannel)trustChannelFactory.CreateChannel();
                Microsoft.IdentityModel.Protocols.WSTrust.RequestSecurityToken requestSecurityToken = new Microsoft.IdentityModel.Protocols.WSTrust.RequestSecurityToken(idp.IssueRequestType);
                requestSecurityToken.AppliesTo = new EndpointAddress(uri);
                Microsoft.IdentityModel.Protocols.WSTrust.RequestSecurityToken rst = requestSecurityToken;
                if (!string.IsNullOrEmpty(keyType))
                    rst.KeyType = keyType;
                Microsoft.IdentityModel.Protocols.WSTrust.RequestSecurityTokenResponse rstr = (Microsoft.IdentityModel.Protocols.WSTrust.RequestSecurityTokenResponse)null;
                SecurityToken securityToken = communicationObject.Issue(rst, out rstr);
                return new SecurityTokenResponse()
                {
                    Token = securityToken,
                    Response = rstr
                };
            }
            finally
            {
                if (trustChannelFactory != null)
                    trustChannelFactory.Close(true);
                if (communicationObject != null)
                    communicationObject.Close(true);
            }
        }*/

        /*private AuthenticationCredentials AuthenticateOnlineFederationInternal(
          AuthenticationCredentials authenticationCredentials)
        {
            OnlinePolicyConfiguration policyConfiguration = this.PolicyConfiguration as OnlinePolicyConfiguration;
            ClientExceptionHelper.ThrowIfNull((object)policyConfiguration, "onlinePolicy");
            OrgIdentityProviderTrustConfiguration trustConfiguration = policyConfiguration.OnlineProviders.Values.OfType<OrgIdentityProviderTrustConfiguration>().FirstOrDefault<OrgIdentityProviderTrustConfiguration>();
            ClientExceptionHelper.ThrowIfNull((object)trustConfiguration, "liveTrustConfig");
            if (authenticationCredentials.SecurityTokenResponse != null)
                return this.AuthenticateOnlineFederationTokenInternal((IdentityProviderTrustConfiguration)trustConfiguration, authenticationCredentials);
            bool flag = true;
            if (authenticationCredentials.HomeRealm == (Uri)null)
            {
                IdentityProvider identityProvider = !string.IsNullOrEmpty(authenticationCredentials.UserPrincipalName) ? this.GetIdentityProvider(authenticationCredentials.UserPrincipalName) : this.GetIdentityProvider(authenticationCredentials.ClientCredentials);
                ClientExceptionHelper.ThrowIfNull((object)identityProvider, "identityProvider");
                authenticationCredentials.HomeRealm = identityProvider.ServiceUrl;
                flag = identityProvider.IdentityProviderType == IdentityProviderType.OrgId;
                if (flag)
                    ClientExceptionHelper.Assert((policyConfiguration.OnlineProviders.ContainsKey(authenticationCredentials.HomeRealm) ? 1 : 0) != 0, "Online Identity Provider NOT found!  {0}", (object)identityProvider.ServiceUrl);
            }
            if (flag)
            {
                this.AuthenticateWithOrgIdForACS(authenticationCredentials, new Uri(policyConfiguration.SecureTokenServiceIdentifier, UriKind.RelativeOrAbsolute));
                return this.AuthenticateTokenWithACSForCrm(authenticationCredentials, this.CurrentServiceEndpoint.Address.Uri.GetServiceRoot(), (Uri)null);
            }
            this.AuthenticateWithADFSForOrgId(authenticationCredentials, trustConfiguration.Identifier);
            return this.AuthenticateTokenWithACSForCrm(this.AuthenticateFederatedTokenWithOrgIdForACS(authenticationCredentials, new Uri(policyConfiguration.SecureTokenServiceIdentifier, UriKind.RelativeOrAbsolute), trustConfiguration.Endpoint.GetServiceRoot()), this.CurrentServiceEndpoint.Address.Uri.GetServiceRoot(), (Uri)null);
        }*/

        /*private AuthenticationCredentials AuthenticateFederatedTokenWithOrgIdForACS(
          AuthenticationCredentials authenticationCredentials,
          Uri identifier,
          Uri homeRealmUri)
        {
            ClientExceptionHelper.ThrowIfNull((object)identifier, nameof(identifier));
            ClientExceptionHelper.ThrowIfNull((object)homeRealmUri, nameof(homeRealmUri));
            ClientExceptionHelper.ThrowIfNull((object)authenticationCredentials.SecurityTokenResponse, "authenticationCredentials.SecurityTokenResponse");
            AuthenticationCredentials authenticationCredentials1 = new AuthenticationCredentials()
            {
                SupportingCredentials = authenticationCredentials,
                AppliesTo = identifier,
                IssuerEndpoints = this.CrossRealmIssuerEndpoints[homeRealmUri],
                EndpointType = TokenServiceCredentialType.SymmetricToken
            };
            authenticationCredentials1.SecurityTokenResponse = this.AuthenticateInternal(authenticationCredentials1);
            return authenticationCredentials1;
        }*/

        /*private void AuthenticateWithADFSForOrgId(
          AuthenticationCredentials authenticationCredentials,
          Uri identifier)
        {
            authenticationCredentials.AppliesTo = identifier;
            authenticationCredentials.KeyType = "http://docs.oasis-open.org/ws-sx/ws-trust/200512/Bearer";
            authenticationCredentials.EndpointType = this.GetCredentialsEndpointType(authenticationCredentials.ClientCredentials);
            authenticationCredentials.IssuerEndpoints = this.CrossRealmIssuerEndpoints[authenticationCredentials.HomeRealm];
            authenticationCredentials.SecurityTokenResponse = this.AuthenticateInternal(authenticationCredentials);
        }*/

        /*private void AuthenticateWithOrgIdForACS(
          AuthenticationCredentials authenticationCredentials,
          Uri identifier)
        {
            authenticationCredentials.AppliesTo = identifier;
            authenticationCredentials.EndpointType = this.GetCredentialsEndpointType(authenticationCredentials.ClientCredentials);
            authenticationCredentials.IssuerEndpoints = this.CrossRealmIssuerEndpoints[authenticationCredentials.HomeRealm];
            authenticationCredentials.EndpointType = TokenServiceCredentialType.Username;
            authenticationCredentials.SecurityTokenResponse = this.AuthenticateInternal(authenticationCredentials);
        }*/

        /*private AuthenticationCredentials AuthenticateTokenWithACSForCrm(
          AuthenticationCredentials authenticationCredentials,
          Uri appliesTo,
          Uri acsEndpoint = null)
        {
            ClientExceptionHelper.ThrowIfNull((object)authenticationCredentials.SecurityTokenResponse, "authenticationCredentials.SecurityTokenResponse");
            AuthenticationCredentials authenticationCredentials1 = new AuthenticationCredentials()
            {
                SupportingCredentials = authenticationCredentials,
                AppliesTo = appliesTo,
                IssuerEndpoints = !(acsEndpoint != (Uri)null) ? this.IssuerEndpoints : this.CrossRealmIssuerEndpoints[acsEndpoint],
                KeyType = "http://docs.oasis-open.org/ws-sx/ws-trust/200512/Bearer",
                EndpointType = TokenServiceCredentialType.AsymmetricToken
            };
            authenticationCredentials1.SecurityTokenResponse = this.Issue(authenticationCredentials1);
            return authenticationCredentials1;
        }*/

        /*private AuthenticationCredentials AuthenticateOnlineFederationTokenInternal(
          IdentityProviderTrustConfiguration liveTrustConfig,
          AuthenticationCredentials authenticationCredentials)
        {
            AuthenticationCredentials authenticationCredentials1 = new AuthenticationCredentials();
            authenticationCredentials1.SupportingCredentials = authenticationCredentials;
            string appliesTo = authenticationCredentials.AppliesTo != (Uri)null ? authenticationCredentials.AppliesTo.AbsoluteUri : liveTrustConfig.AppliesTo;
            Uri uri = authenticationCredentials.HomeRealm;
            if ((object)uri == null)
                uri = liveTrustConfig.Endpoint.GetServiceRoot();
            Uri crossRealmSts = uri;
            authenticationCredentials1.SecurityTokenResponse = this.AuthenticateCrossRealm(authenticationCredentials.SecurityTokenResponse.Token, appliesTo, crossRealmSts);
            return authenticationCredentials1;
        }*/

        /*internal IdentityProvider GetIdentityProvider(
          ClientCredentials clientCredentials)
        {
            string userPrincipalName = string.Empty;
            if (!string.IsNullOrWhiteSpace(clientCredentials.UserName.UserName))
                userPrincipalName = this.ExtractUserName(clientCredentials.UserName.UserName);
            else if (!string.IsNullOrWhiteSpace(clientCredentials.Windows.ClientCredential.UserName))
                userPrincipalName = this.ExtractUserName(clientCredentials.Windows.ClientCredential.UserName);
            ClientExceptionHelper.Assert(!string.IsNullOrEmpty(userPrincipalName), "clientCredentials.UserName.UserName or clientCredentials.Windows.ClientCredential.UserName MUST be populated!");
            return this.GetIdentityProvider(userPrincipalName);
        }*/

        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        private string ExtractUserName(string userName)
        {
            return !userName.Contains<char>('@') ? string.Empty : userName;
        }

        public PolicyConfiguration PolicyConfiguration { get; set; }

        public ServiceEndpointMetadata ServiceEndpointMetadata { get; private set; }

        private ServiceConfiguration()
        {
        }

        /*private bool ClaimsEnabledService
        {
            get
            {
                return this.AuthenticationType == AuthenticationProviderType.Federation || this.AuthenticationType == AuthenticationProviderType.OnlineFederation;
            }
        }*/

        public ServiceConfiguration(Uri serviceUri)
          : this(serviceUri, true)
        {
        }

        internal ServiceConfiguration(Uri serviceUri, bool checkForSecondary)
        {
            this.ServiceUri = serviceUri;
            //this.ServiceEndpointMetadata = ServiceMetadataUtility.RetrieveServiceEndpointMetadata(typeof(TService), this.ServiceUri, checkForSecondary);
            /*ClientExceptionHelper.ThrowIfNull((object)this.ServiceEndpointMetadata, nameof(ServiceEndpointMetadata));
            if (this.ServiceEndpointMetadata.ServiceEndpoints.Count == 0)
            {
                StringBuilder stringBuilder = new StringBuilder();
                if (this.ServiceEndpointMetadata.MetadataConversionErrors.Count > 0)
                {
                    foreach (var metadataConversionError in this.ServiceEndpointMetadata.MetadataConversionErrors)
                        stringBuilder.Append(metadataConversionError.Message);
                }
                throw new InvalidOperationException(ClientExceptionHelper.FormatMessage(0, (object)"The provided uri did not return any Service Endpoints!\n{0}", (object)stringBuilder.ToString()));
            }*/

            /*ServiceEndpointMetadata serviceEndpointMetadata = new ServiceEndpointMetadata();
            serviceEndpointMetadata.ServiceUrls = ServiceConfiguration<IOrganizationService>.CalculateEndpoints(new Uri("https://bcs.crm39.t-global.bcs/BCS/XRMServices/2011/Organization.svc"));
            Uri address = new Uri(serviceUri.AbsoluteUri + "?wsdl");*/

            System.ServiceModel.BasicHttpBinding binding = new System.ServiceModel.BasicHttpBinding();
            //binding.Security.Mode = System.ServiceModel.BasicHttpSecurityMode.TransportCredentialOnly;
            binding.Security.Transport.ClientCredentialType = System.ServiceModel.HttpClientCredentialType.Ntlm;
            binding.Security.Mode = System.ServiceModel.BasicHttpSecurityMode.Transport;

            string endPointAddress = serviceUri.AbsoluteUri + "/web";

            var endPoint = new System.ServiceModel.EndpointAddress(endPointAddress);

            this.ServiceEndpoints = new ServiceEndpointDictionary
                                    {
                                        {
                                            "Endpoint0",
                                            new ServiceEndpoint(new ContractDescription("IOrganizationService"),
                                                                binding,
                                                                endPoint)
                                        }
                                    };
                //this.ServiceEndpointMetadata.ServiceEndpoints;

            if (this.CurrentServiceEndpoint == null)
                return;
            //this.CrossRealmIssuerEndpoints = new CrossRealmIssuerEndpointCollection();
            this.SetAuthenticationConfiguration();
            /*if (checkForSecondary)
            {
                //this.SetEndpointSwitchingBehavior();
            }
            else*/
            {
                /*if (this.CurrentServiceEndpoint.Address.Uri != serviceUri)
                    ServiceMetadataUtility.ReplaceEndpointAddress(this.CurrentServiceEndpoint, serviceUri);*/
                this.PrimaryEndpoint = serviceUri;
            }
        }

        /*private void AddLiveIssuerEndpointsToCrossRealmIssuers(
          IdentityProviderTrustConfiguration identityProviderTrustConfiguration)
        {
            /*IssuerEndpointDictionary endpointDictionary = ServiceMetadataUtility.RetrieveLiveIdIssuerEndpoints(identityProviderTrustConfiguration);
            if (endpointDictionary == null)
                return;#1#
            //this.CrossRealmIssuerEndpoints[identityProviderTrustConfiguration.Endpoint.GetServiceRoot()] = endpointDictionary;
        }*/

        private void SetAuthenticationConfiguration()
        {
            if (this.CurrentServiceEndpoint.Binding == null)
                return;
            AuthenticationPolicy xrmPolicy = this.CurrentServiceEndpoint.Binding.CreateBindingElements().Find<AuthenticationPolicy>();
            if (xrmPolicy == null || !xrmPolicy.PolicyElements.ContainsKey("AuthenticationType"))
                return;
            string policyElement1 = xrmPolicy.PolicyElements["AuthenticationType"];
            AuthenticationProviderType result;
            if (string.IsNullOrEmpty(policyElement1) || !Enum.TryParse<AuthenticationProviderType>(policyElement1, out result))
                return;
            switch (result)
            {
                /*case AuthenticationProviderType.Federation:
                    /*this.IssuerEndpoints = ServiceMetadataUtility.RetrieveIssuerEndpoints(AuthenticationProviderType.Federation, this.ServiceEndpoints, true);
                    this.PolicyConfiguration = (PolicyConfiguration)new ClaimsPolicyConfiguration(xrmPolicy);#1#
                    break;
                case AuthenticationProviderType.LiveId:
                    /*this.IssuerEndpoints = ServiceMetadataUtility.RetrieveIssuerEndpoints(AuthenticationProviderType.LiveId, this.ServiceEndpoints, false);
                    xrmPolicy.PolicyElements["LiveEndpoint"] = this.IssuerEndpoints[TokenServiceCredentialType.Username.ToString()].IssuerAddress.Uri.AbsoluteUri;
                    this.PolicyConfiguration = (PolicyConfiguration)new LiveIdPolicyConfiguration(xrmPolicy);#1#
                    break;
                case AuthenticationProviderType.OnlineFederation:
                    /*string policyElement2 = xrmPolicy.PolicyElements["SecureTokenServiceIdentifier"];
                    this.IssuerEndpoints = string.IsNullOrEmpty(policyElement2) ? ServiceMetadataUtility.RetrieveIssuerEndpoints(AuthenticationProviderType.OnlineFederation, this.ServiceEndpoints, true) : ServiceMetadataUtility.RetrieveACSIssuerEndpoints(new Uri(policyElement2));#1#
                    this.PolicyConfiguration = (PolicyConfiguration)new OnlineFederationPolicyConfiguration(xrmPolicy);
                    using (Dictionary<Uri, IdentityProviderTrustConfiguration>.ValueCollection.Enumerator enumerator = ((OnlinePolicyConfiguration)this.PolicyConfiguration).OnlineProviders.Values.GetEnumerator())
                    {
                        while (enumerator.MoveNext())
                            this.AddLiveIssuerEndpointsToCrossRealmIssuers(enumerator.Current);
                        break;
                    }*/
                default:
                    this.PolicyConfiguration = (PolicyConfiguration)new WindowsPolicyConfiguration(xrmPolicy);
                    break;
            }
        }

        public Uri ServiceUri { get; internal set; }

        public ServiceEndpoint CurrentServiceEndpoint
        {
            get
            {
                if (this.currentServiceEndpoint == null)
                {
                    foreach (ServiceEndpoint serviceEndpoint in this.ServiceEndpoints.Values)
                    {
                        if (this.ServiceUri.Port == serviceEndpoint.Address.Uri.Port && this.ServiceUri.Scheme == serviceEndpoint.Address.Uri.Scheme)
                        {
                            this.currentServiceEndpoint = serviceEndpoint;
                            break;
                        }
                    }
                }
                return this.currentServiceEndpoint;
            }
            set
            {
                this.currentServiceEndpoint = value;
            }
        }

        /*public IssuerEndpoint CurrentIssuer
        {
            get
            {
                return this.CurrentServiceEndpoint != null ? ServiceMetadataUtility.GetIssuer(this.CurrentServiceEndpoint.Binding) : (IssuerEndpoint)null;
            }
            set
            {
                if (this.CurrentServiceEndpoint == null)
                    return;
                this.CurrentServiceEndpoint.Binding = (Binding)ServiceMetadataUtility.SetIssuer(this.CurrentServiceEndpoint.Binding, value);
            }
        }*/

        public AuthenticationProviderType AuthenticationType
        {
            get
            {
                if (this.PolicyConfiguration is WindowsPolicyConfiguration)
                    return AuthenticationProviderType.ActiveDirectory;
                /*if (this.PolicyConfiguration is ClaimsPolicyConfiguration)
                    return AuthenticationProviderType.Federation;
                if (this.PolicyConfiguration is LiveIdPolicyConfiguration)
                    return AuthenticationProviderType.LiveId;*/
                return /*this.PolicyConfiguration is OnlineFederationPolicyConfiguration ? AuthenticationProviderType.OnlineFederation :*/ AuthenticationProviderType.None;
            }
        }

        public ServiceEndpointDictionary ServiceEndpoints { get; internal set; }

        //public IssuerEndpointDictionary IssuerEndpoints { get; internal set; }

        //public CrossRealmIssuerEndpointCollection CrossRealmIssuerEndpoints { get; internal set; }

        [SuppressMessage("Microsoft.Usage", "CA9888:DisposeObjectsCorrectly", Justification = "Value is returned from method and cannot be disposed.")]
        public ChannelFactory<TService> CreateChannelFactory(
          ClientAuthenticationType clientAuthenticationType)
        {
            ClientExceptionHelper.ThrowIfNull((object)this.CurrentServiceEndpoint, "CurrentServiceEndpoint");
            /*if (this.ClaimsEnabledService)
            {
                IssuerEndpoint issuerEndpoint = this.IssuerEndpoints.GetIssuerEndpoint(clientAuthenticationType == ClientAuthenticationType.SecurityToken ? this._tokenEndpointType : TokenServiceCredentialType.Kerberos);
                if (issuerEndpoint != null)
                {
                    /*lock (ServiceConfiguration<TService>._lockObject)
                        this.CurrentServiceEndpoint.Binding = (Binding)ServiceMetadataUtility.SetIssuer(this.CurrentServiceEndpoint.Binding, issuerEndpoint);#1#
                }
            }*/
            ChannelFactory<TService> localChannelFactory = this.CreateLocalChannelFactory();
            //localChannelFactory.Credentials.SupportInteractive = false;
            return localChannelFactory;
        }

        [SuppressMessage("Microsoft.Usage", "CA9888:DisposeObjectsCorrectly", Justification = "Value is returned from method and cannot be disposed.")]
        public ChannelFactory<TService> CreateChannelFactory(
          ClientCredentials clientCredentials)
        {
            ClientExceptionHelper.ThrowIfNull((object)this.CurrentServiceEndpoint, "CurrentServiceEndpoint");
            /*if (this.ClaimsEnabledService)
            {
                IssuerEndpoint issuerEndpoint = this.IssuerEndpoints.GetIssuerEndpoint(this.GetCredentialsEndpointType(clientCredentials));
                if (issuerEndpoint != null)
                {
                    /*lock (ServiceConfiguration<TService>._lockObject)
                        this.CurrentServiceEndpoint.Binding = (Binding)ServiceMetadataUtility.SetIssuer(this.CurrentServiceEndpoint.Binding, issuerEndpoint);#1#
                }
            }*/
            ChannelFactory<TService> localChannelFactory = this.CreateLocalChannelFactory();
            this.ConfigureCredentials((ChannelFactory)localChannelFactory, clientCredentials);
            //localChannelFactory.Credentials.SupportInteractive = clientCredentials != null && clientCredentials.SupportInteractive;
            return localChannelFactory;
        }

        /*public SecurityTokenResponse AuthenticateCrossRealm(
          ClientCredentials clientCredentials,
          string appliesTo,
          Uri crossRealmSts)
        {
            if (!(crossRealmSts != (Uri)null))
                return (SecurityTokenResponse)null;
            AuthenticationCredentials authenticationCredentials = new AuthenticationCredentials();
            authenticationCredentials.AppliesTo = !string.IsNullOrWhiteSpace(appliesTo) ? new Uri(appliesTo) : (Uri)null;
            authenticationCredentials.KeyType = string.Empty;
            authenticationCredentials.ClientCredentials = clientCredentials;
            authenticationCredentials.SecurityTokenResponse = (SecurityTokenResponse)null;
            IdentityProviderTrustConfiguration trustConfiguration = this.TryGetOnlineTrustConfiguration(crossRealmSts);
            authenticationCredentials.EndpointType = trustConfiguration != null ? TokenServiceCredentialType.Username : this.GetCredentialsEndpointType(clientCredentials);
            authenticationCredentials.IssuerEndpoints = this.CrossRealmIssuerEndpoints[crossRealmSts];
            if (this.AuthenticationType == AuthenticationProviderType.OnlineFederation && trustConfiguration == null)
                authenticationCredentials.KeyType = "http://docs.oasis-open.org/ws-sx/ws-trust/200512/Bearer";
            return this.AuthenticateInternal(authenticationCredentials);
        }*/

        /*public SecurityTokenResponse AuthenticateCrossRealm(
          SecurityToken securityToken,
          string appliesTo,
          Uri crossRealmSts)
        {
            if (!(crossRealmSts != (Uri)null))
                return (SecurityTokenResponse)null;
            AuthenticationCredentials authenticationCredentials = new AuthenticationCredentials();
            authenticationCredentials.AppliesTo = !string.IsNullOrWhiteSpace(appliesTo) ? new Uri(appliesTo) : (Uri)null;
            authenticationCredentials.KeyType = string.Empty;
            authenticationCredentials.ClientCredentials = (ClientCredentials)null;
            authenticationCredentials.SecurityTokenResponse = new SecurityTokenResponse()
            {
                Token = securityToken
            };
            bool flag = true;
            if (this.AuthenticationType == AuthenticationProviderType.OnlineFederation)
            {
                IdentityProviderTrustConfiguration trustConfiguration = this.TryGetOnlineTrustConfiguration(crossRealmSts);
                if (trustConfiguration != null && trustConfiguration.Endpoint.GetServiceRoot() == crossRealmSts)
                {
                    authenticationCredentials.EndpointType = TokenServiceCredentialType.SymmetricToken;
                    flag = false;
                }
            }
            if (flag)
                authenticationCredentials.EndpointType = this._tokenEndpointType;
            authenticationCredentials.IssuerEndpoints = this.CrossRealmIssuerEndpoints[crossRealmSts];
            return this.AuthenticateInternal(authenticationCredentials);
        }*/

        /*private IdentityProviderTrustConfiguration TryGetOnlineTrustConfiguration()
        {
            return !(this.PolicyConfiguration is OnlinePolicyConfiguration policyConfiguration) ? (IdentityProviderTrustConfiguration)null : (IdentityProviderTrustConfiguration)policyConfiguration.OnlineProviders.Values.OfType<OrgIdentityProviderTrustConfiguration>().FirstOrDefault<OrgIdentityProviderTrustConfiguration>();
        }*/

        /*private IdentityProviderTrustConfiguration GetLiveTrustConfig<T>() where T : IdentityProviderTrustConfiguration
        {
            OnlinePolicyConfiguration policyConfiguration = this.PolicyConfiguration as OnlinePolicyConfiguration;
            ClientExceptionHelper.ThrowIfNull((object)policyConfiguration, "liveConfiguration");
            IdentityProviderTrustConfiguration trustConfiguration = (IdentityProviderTrustConfiguration)policyConfiguration.OnlineProviders.Values.OfType<T>().FirstOrDefault<T>();
            ClientExceptionHelper.ThrowIfNull((object)trustConfiguration, "liveTrustConfig");
            return trustConfiguration;
        }*/

        /*private IdentityProviderTrustConfiguration GetOnlineTrustConfiguration(
          Uri crossRealmSts)
        {
            OnlineFederationPolicyConfiguration policyConfiguration = this.PolicyConfiguration as OnlineFederationPolicyConfiguration;
            ClientExceptionHelper.ThrowIfNull((object)policyConfiguration, "liveFederationConfiguration");
            return policyConfiguration.OnlineProviders.ContainsKey(crossRealmSts) ? policyConfiguration.OnlineProviders[crossRealmSts] : (IdentityProviderTrustConfiguration)null;
        }*/

        /*private IdentityProviderTrustConfiguration TryGetOnlineTrustConfiguration(
          Uri crossRealmSts)
        {
            return this.PolicyConfiguration is OnlineFederationPolicyConfiguration policyConfiguration && policyConfiguration.OnlineProviders.ContainsKey(crossRealmSts) ? policyConfiguration.OnlineProviders[crossRealmSts] : (IdentityProviderTrustConfiguration)null;
        }*/

        /*public SecurityTokenResponse Authenticate(
          ClientCredentials clientCredentials)
        {
            if (this.CurrentServiceEndpoint != null)
            {
                AuthenticationCredentials authenticationCredentials = this.Authenticate(new AuthenticationCredentials()
                {
                    ClientCredentials = clientCredentials
                });
                if (authenticationCredentials != null && authenticationCredentials.SecurityTokenResponse != null)
                    return authenticationCredentials.SecurityTokenResponse;
            }
            return (SecurityTokenResponse)null;
        }*/

        /*internal SecurityTokenResponse Authenticate(
          ClientCredentials clientCredentials,
          Uri uri,
          string keyType)
        {
            return this.AuthenticateInternal(new AuthenticationCredentials()
            {
                AppliesTo = uri,
                EndpointType = this.GetCredentialsEndpointType(clientCredentials),
                KeyType = keyType,
                IssuerEndpoints = this.IssuerEndpoints,
                ClientCredentials = clientCredentials,
                SecurityTokenResponse = (SecurityTokenResponse)null
            });
        }*/

        /*public SecurityTokenResponse Authenticate(SecurityToken securityToken)
        {
            ClientExceptionHelper.ThrowIfNull((object)securityToken, nameof(securityToken));
            if (this.AuthenticationType == AuthenticationProviderType.OnlineFederation)
            {
                IdentityProviderTrustConfiguration trustConfiguration = this.TryGetOnlineTrustConfiguration();
                return trustConfiguration == null ? (SecurityTokenResponse)null : this.AuthenticateCrossRealm(securityToken, trustConfiguration.AppliesTo, trustConfiguration.Endpoint.GetServiceRoot());
            }
            if (this.CurrentServiceEndpoint == null)
                return (SecurityTokenResponse)null;
            return this.AuthenticateInternal(new AuthenticationCredentials()
            {
                AppliesTo = this.CurrentServiceEndpoint.Address.Uri,
                EndpointType = this._tokenEndpointType,
                KeyType = string.Empty,
                IssuerEndpoints = this.IssuerEndpoints,
                ClientCredentials = (ClientCredentials)null,
                SecurityTokenResponse = new SecurityTokenResponse()
                {
                    Token = securityToken
                }
            });
        }*/

        /*internal SecurityTokenResponse Authenticate(
          SecurityToken securityToken,
          Uri uri,
          string keyType)
        {
            ClientExceptionHelper.ThrowIfNull((object)securityToken, nameof(securityToken));
            if (!(uri != (Uri)null))
                return (SecurityTokenResponse)null;
            return this.AuthenticateInternal(new AuthenticationCredentials()
            {
                AppliesTo = uri.GetServiceRoot(),
                EndpointType = this._tokenEndpointType,
                KeyType = keyType,
                IssuerEndpoints = this.IssuerEndpoints,
                ClientCredentials = (ClientCredentials)null,
                SecurityTokenResponse = new SecurityTokenResponse()
                {
                    Token = securityToken
                }
            });
        }*/

        /*public SecurityTokenResponse AuthenticateDevice(
          ClientCredentials clientCredentials)
        {
            return /*this.AuthenticationType == AuthenticationProviderType.LiveId ? this.AuthenticateLiveIdInternal(clientCredentials, (SecurityTokenResponse)null, string.Empty) :#1# (SecurityTokenResponse)null;
        }

        public SecurityTokenResponse Authenticate(
          ClientCredentials clientCredentials,
          SecurityTokenResponse deviceTokenResponse)
        {
            return this.Authenticate(clientCredentials, deviceTokenResponse, string.Empty);
        }

        public SecurityTokenResponse Authenticate(
          ClientCredentials clientCredentials,
          SecurityTokenResponse deviceTokenResponse,
          string keyType)
        {
            if (deviceTokenResponse == null && this.CurrentServiceEndpoint != null)
            {
                AuthenticationCredentials authenticationCredentials = this.Authenticate(new AuthenticationCredentials()
                {
                    ClientCredentials = clientCredentials
                });
                if (authenticationCredentials != null && authenticationCredentials.SecurityTokenResponse != null)
                    return authenticationCredentials.SecurityTokenResponse;
            }
            return /*this.AuthenticationType == AuthenticationProviderType.LiveId ? this.AuthenticateLiveIdInternal(clientCredentials, deviceTokenResponse, keyType) :#1# (SecurityTokenResponse)null;
        }*/

        /*[SuppressMessage("Microsoft.Usage", "CA9888:DisposeObjectsCorrectly", Justification = "Value is returned from method and cannot be disposed.")]
        private SecurityTokenResponse AuthenticateLiveIdInternal(
          ClientCredentials clientCredentials,
          SecurityTokenResponse deviceToken,
          string keyType)
        {
            ClientExceptionHelper.Assert(this.AuthenticationType == AuthenticationProviderType.LiveId, "Authenticate is not supported when not in claims mode with LiveId!");
            ClientExceptionHelper.ThrowIfNull((object)clientCredentials, nameof(clientCredentials));
            ClientExceptionHelper.ThrowIfNull((object)(this.PolicyConfiguration as OnlinePolicyConfiguration), "liveConfiguration");
            IdentityProviderTrustConfiguration liveTrustConfig = this.GetLiveTrustConfig<LiveIdentityProviderTrustConfiguration>();
            IssuerEndpoint issuerEndpoint = this.IssuerEndpoints.GetIssuerEndpoint(TokenServiceCredentialType.Username);
            string uri = deviceToken == null ? liveTrustConfig.LiveIdAppliesTo : liveTrustConfig.AppliesTo;
            if (issuerEndpoint == null)
                return (SecurityTokenResponse)null;
            string empty = string.Empty;
            Binding binding = liveTrustConfig.Binding;
            string issueRequestType = liveTrustConfig.IssueRequestType;
            ClientExceptionHelper.ThrowIfNull((object)binding, "issuerBinding");
            LiveIdTrustChannelFactory trustChannelFactory = (LiveIdTrustChannelFactory)null;
            Microsoft.IdentityModel.Protocols.WSTrust.WSTrustChannel communicationObject = (Microsoft.IdentityModel.Protocols.WSTrust.WSTrustChannel)null;
            try
            {
                trustChannelFactory = new LiveIdTrustChannelFactory(binding, issuerEndpoint.IssuerAddress, liveTrustConfig);
                trustChannelFactory.Credentials.UserName.UserName = clientCredentials.UserName.UserName;
                trustChannelFactory.Credentials.UserName.Password = clientCredentials.UserName.Password;
                if (deviceToken != null)
                    trustChannelFactory.DeviceTokenResponse = deviceToken;
                lock (ServiceConfiguration<TService>._lockObject)
                    trustChannelFactory.ConfigureChannelFactory<Microsoft.IdentityModel.Protocols.WSTrust.IWSTrustChannelContract>();
                communicationObject = (Microsoft.IdentityModel.Protocols.WSTrust.WSTrustChannel)trustChannelFactory.CreateChannel();
                Microsoft.IdentityModel.Protocols.WSTrust.RequestSecurityToken requestSecurityToken = new Microsoft.IdentityModel.Protocols.WSTrust.RequestSecurityToken(issueRequestType);
                requestSecurityToken.AppliesTo = new EndpointAddress(uri);
                Microsoft.IdentityModel.Protocols.WSTrust.RequestSecurityToken rst = requestSecurityToken;
                if (!string.IsNullOrEmpty(keyType))
                    rst.KeyType = keyType;
                Microsoft.IdentityModel.Protocols.WSTrust.RequestSecurityTokenResponse rstr = (Microsoft.IdentityModel.Protocols.WSTrust.RequestSecurityTokenResponse)null;
                SecurityToken securityToken = communicationObject.Issue(rst, out rstr);
                return new SecurityTokenResponse()
                {
                    Token = securityToken,
                    Response = rstr
                };
            }
            finally
            {
                if (trustChannelFactory != null)
                    trustChannelFactory.Close(true);
                if (communicationObject != null)
                    communicationObject.Close(true);
            }
        }*/

        /*public IdentityProvider GetIdentityProvider(string userPrincipalName)
        {
            //IdentityProviderTrustConfiguration trustConfiguration = this.TryGetOnlineTrustConfiguration();
            return /*trustConfiguration == null ?#1# (IdentityProvider)null /*: IdentityProviderLookup.Instance.GetIdentityProvider(trustConfiguration.Endpoint.GetServiceRoot(), trustConfiguration.Endpoint.GetServiceRoot(), userPrincipalName)#1#;
        }*/

        /*private SecurityTokenResponse AuthenticateInternal(
          AuthenticationCredentials authenticationCredentials)
        {
            ClientExceptionHelper.Assert(this.AuthenticationType == AuthenticationProviderType.Federation || this.AuthenticationType == AuthenticationProviderType.OnlineFederation, "Authenticate is not supported when not in claims mode!");
            if (this.ClaimsEnabledService)
            {
                if (authenticationCredentials.IssuerEndpoint.CredentialType != TokenServiceCredentialType.Kerberos)
                    return this.Issue(authenticationCredentials);
                bool flag = false;
                int num = 0;
                do
                {
                    try
                    {
                        return this.Issue(authenticationCredentials);
                    }
                    catch (SecurityTokenValidationException ex)
                    {
                        flag = false;
                        if (authenticationCredentials.IssuerEndpoints.ContainsKey(TokenServiceCredentialType.Windows.ToString()))
                        {
                            authenticationCredentials.EndpointType = TokenServiceCredentialType.Windows;
                            flag = ++num < 2;
                        }
                    }
                    catch (SecurityNegotiationException ex)
                    {
                        flag = ++num < 2;
                    }
                    catch (FaultException ex)
                    {
                        if (authenticationCredentials.IssuerEndpoints.ContainsKey(TokenServiceCredentialType.Windows.ToString()))
                        {
                            authenticationCredentials.EndpointType = TokenServiceCredentialType.Windows;
                            flag = ++num < 2;
                        }
                    }
                }
                while (flag);
            }
            return (SecurityTokenResponse)null;
        }*/

        /*[SuppressMessage("Microsoft.Usage", "CA9888:DisposeObjectsCorrectly", Justification = "Value is returned from method and cannot be disposed.")]
        private SecurityTokenResponse Issue(
          AuthenticationCredentials authenticationCredentials)
        {
            ClientExceptionHelper.ThrowIfNull((object)authenticationCredentials, nameof(authenticationCredentials));
            ClientExceptionHelper.ThrowIfNull((object)authenticationCredentials.IssuerEndpoint, "authenticationCredentials.IssuerEndpoint");
            ClientExceptionHelper.ThrowIfNull((object)authenticationCredentials.AppliesTo, "authenticationCredentials.AppliesTo");
            Microsoft.IdentityModel.Protocols.WSTrust.WSTrustChannelFactory trustChannelFactory = (Microsoft.IdentityModel.Protocols.WSTrust.WSTrustChannelFactory)null;
            Microsoft.IdentityModel.Protocols.WSTrust.WSTrustChannel communicationObject = (Microsoft.IdentityModel.Protocols.WSTrust.WSTrustChannel)null;
            try
            {
                authenticationCredentials.RequestType = authenticationCredentials.IssuerEndpoint.TrustVersion == TrustVersion.WSTrust13 ? "http://docs.oasis-open.org/ws-sx/ws-trust/200512/Issue" : "http://schemas.xmlsoap.org/ws/2005/02/trust/Issue";
                trustChannelFactory = new Microsoft.IdentityModel.Protocols.WSTrust.WSTrustChannelFactory(authenticationCredentials.IssuerEndpoint.IssuerBinding, authenticationCredentials.IssuerEndpoint.IssuerAddress);
                SecurityToken issuedToken = authenticationCredentials.SecurityTokenResponse == null || authenticationCredentials.SecurityTokenResponse.Token == null ? (authenticationCredentials.SupportingCredentials == null || authenticationCredentials.SupportingCredentials.SecurityTokenResponse == null || authenticationCredentials.SupportingCredentials.SecurityTokenResponse.Token == null ? (SecurityToken)null : authenticationCredentials.SupportingCredentials.SecurityTokenResponse.Token) : authenticationCredentials.SecurityTokenResponse.Token;
                if (issuedToken != null)
                    trustChannelFactory.Credentials.SupportInteractive = false;
                else
                    this.ConfigureCredentials((ChannelFactory)trustChannelFactory, authenticationCredentials.ClientCredentials);
                lock (ServiceConfiguration<TService>._lockObject)
                    trustChannelFactory.ConfigureChannelFactory<Microsoft.IdentityModel.Protocols.WSTrust.IWSTrustChannelContract>();
                communicationObject = issuedToken != null ? (Microsoft.IdentityModel.Protocols.WSTrust.WSTrustChannel)trustChannelFactory.CreateChannelWithIssuedToken(issuedToken) : (Microsoft.IdentityModel.Protocols.WSTrust.WSTrustChannel)trustChannelFactory.CreateChannel();
                if (communicationObject != null)
                {
                    Microsoft.IdentityModel.Protocols.WSTrust.RequestSecurityToken requestSecurityToken = new Microsoft.IdentityModel.Protocols.WSTrust.RequestSecurityToken(authenticationCredentials.RequestType);
                    requestSecurityToken.AppliesTo = new EndpointAddress(authenticationCredentials.AppliesTo, new AddressHeader[0]);
                    Microsoft.IdentityModel.Protocols.WSTrust.RequestSecurityToken rst = requestSecurityToken;
                    if (!string.IsNullOrEmpty(authenticationCredentials.KeyType))
                        rst.KeyType = authenticationCredentials.KeyType;
                    Microsoft.IdentityModel.Protocols.WSTrust.RequestSecurityTokenResponse rstr;
                    SecurityToken securityToken = communicationObject.Issue(rst, out rstr);
                    return new SecurityTokenResponse()
                    {
                        Token = securityToken,
                        Response = rstr
                    };
                }
            }
            finally
            {
                if (communicationObject != null)
                    communicationObject.Close(true);
                if (trustChannelFactory != null)
                    trustChannelFactory.Close(true);
            }
            return (SecurityTokenResponse)null;
        }*/

        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        private void ConfigureCredentials(
          ChannelFactory channelFactory,
          ClientCredentials clientCredentials)
        {
            if (clientCredentials == null)
                return;
            if (clientCredentials.ClientCertificate != null && clientCredentials.ClientCertificate.Certificate != null)
                channelFactory.Credentials.ClientCertificate.Certificate = clientCredentials.ClientCertificate.Certificate;
            else if (clientCredentials.UserName != null && !string.IsNullOrEmpty(clientCredentials.UserName.UserName))
            {
                channelFactory.Credentials.UserName.UserName = clientCredentials.UserName.UserName;
                channelFactory.Credentials.UserName.Password = clientCredentials.UserName.Password;
            }
            else
            {
                if (clientCredentials.Windows == null || clientCredentials.Windows.ClientCredential == null)
                    return;
                channelFactory.Credentials.Windows.ClientCredential = clientCredentials.Windows.ClientCredential;
                channelFactory.Credentials.Windows.AllowedImpersonationLevel = clientCredentials.Windows.AllowedImpersonationLevel;
                channelFactory.Credentials.ServiceCertificate.SslCertificateAuthentication =
                    new X509ServiceCertificateAuthentication
                    {
                        CertificateValidationMode = X509CertificateValidationMode.None,
                        RevocationMode = System.Security.Cryptography.X509Certificates.X509RevocationMode.NoCheck
                    };
                //channelFactory.Credentials.ServiceCertificate.Authentication.CertificateValidationMode = System.ServiceModel.Security.X509CertificateValidationMode.None;
            }
        }

        /*[SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic")]
        private TokenServiceCredentialType GetCredentialsEndpointType(
          ClientCredentials clientCredentials)
        {
            if (clientCredentials != null)
            {
                if (clientCredentials.UserName != null && !string.IsNullOrEmpty(clientCredentials.UserName.UserName))
                    return TokenServiceCredentialType.Username;
                if (clientCredentials.ClientCertificate != null && clientCredentials.ClientCertificate.Certificate != null)
                    return TokenServiceCredentialType.Certificate;
                if (clientCredentials.Windows != null && clientCredentials.Windows.ClientCredential != null)
                    return TokenServiceCredentialType.Kerberos;
            }
            return TokenServiceCredentialType.Kerberos;
        }*/

        [SuppressMessage("Microsoft.Usage", "CA9888:DisposeObjectsCorrectly", Justification = "Value is returned from method and cannot be disposed.")]
        private ChannelFactory<TService> CreateLocalChannelFactory()
        {
            lock (ServiceConfiguration<TService>._lockObject)
            {
                ServiceEndpoint endpoint = new ServiceEndpoint(this.CurrentServiceEndpoint.Contract, this.CurrentServiceEndpoint.Binding, this.CurrentServiceEndpoint.Address);
                foreach (IEndpointBehavior behavior in (Collection<IEndpointBehavior>)this.CurrentServiceEndpoint.EndpointBehaviors)
                    endpoint.EndpointBehaviors.Add(behavior);
                /*endpoint.IsSystemEndpoint = this.CurrentServiceEndpoint.IsSystemEndpoint;
                endpoint.ListenUri = this.CurrentServiceEndpoint.ListenUri;
                endpoint.ListenUriMode = this.CurrentServiceEndpoint.ListenUriMode;*/
                endpoint.Name = this.CurrentServiceEndpoint.Name;
                ChannelFactory<TService> channelFactory = new ChannelFactory<TService>(endpoint.Binding, endpoint.Address);
                /*if (this.ClaimsEnabledService || this.AuthenticationType == AuthenticationProviderType.LiveId)
                    channelFactory.ConfigureChannelFactory<TService>();
                channelFactory.Credentials.IssuedToken.CacheIssuedTokens = true;*/
                return channelFactory;
            }
        }
    }
}