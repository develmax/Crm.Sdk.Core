
using System;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Security;

namespace Microsoft.Xrm.Sdk.Client
{
    /// <summary>Provides an abstract base class to encapsulate service connection operations and user authentication management.</summary>
    public abstract class ServiceProxy<TService> : IDisposable where TService : class
    {
        private TimeSpan _timeout = ServiceDefaults.DefaultTimeout;
        private Microsoft.Xrm.Sdk.Client.ServiceChannel<TService> _serviceChannel;
        private System.ServiceModel.ChannelFactory<TService> _channelFactory;
        private bool _autoCloseChannel;

        internal ServiceProxy()
        {
        }

        /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Xrm.Sdk.Client.ServiceProxy`1"></see> class using a service management and security token response.</summary>
        /// <param name="serviceManagement">Type: <see cref="T:Microsoft.Xrm.Sdk.Client.IServiceManagement`1"></see>. A service management.</param>
        /// <param name="securityTokenResponse">Type: <see cref="T:Microsoft.Xrm.Sdk.Client.SecurityTokenResponse"></see>. A security token response.</param>
        /*protected ServiceProxy(
          IServiceManagement<TService> serviceManagement,
          SecurityTokenResponse securityTokenResponse)
          : this(serviceManagement as IServiceConfiguration<TService>, securityTokenResponse)
        {
        }*/

        /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Xrm.Sdk.Client.ServiceProxy`1"></see> class using a service configuration and security token response. </summary>
        /// <param name="serviceConfiguration">Type: <see cref="T:Microsoft.Xrm.Sdk.Client.IServiceConfiguration`1"></see>. A service configuration.</param>
        /// <param name="securityTokenResponse">Type: <see cref="T:Microsoft.Xrm.Sdk.Client.SecurityTokenResponse"></see>. A security token response.</param>
        /*protected ServiceProxy(
          IServiceConfiguration<TService> serviceConfiguration,
          SecurityTokenResponse securityTokenResponse)
        {
            ClientExceptionHelper.ThrowIfNull((object)serviceConfiguration, nameof(serviceConfiguration));
            ClientExceptionHelper.ThrowIfNull((object)serviceConfiguration.CurrentServiceEndpoint, "serviceConfiguration.CurrentServiceEndpoint");
            ClientExceptionHelper.ThrowIfNull((object)securityTokenResponse, nameof(securityTokenResponse));
            ClientExceptionHelper.ThrowIfNull((object)securityTokenResponse.Token, "securityTokenResponse.Token");
            this.ServiceConfiguration = serviceConfiguration;
            this.SecurityTokenResponse = securityTokenResponse;
            this.IsAuthenticated = true;
            this.SetDefaultEndpointSwitchBehavior();
        }*/

        /// <summary>constructor_initializes<see cref="T:Microsoft.Xrm.Sdk.Client.ServiceProxy`1"></see> class using a service management and client logon credentials.</summary>
        /// <param name="serviceManagement">Type: <see cref="T:Microsoft.Xrm.Sdk.Client.IServiceManagement`1"></see>. A service management.</param>
        /// <param name="clientCredentials">Type: Returns_ClientCredentials. The logon credentials of the client.</param>
        protected ServiceProxy(
          IServiceManagement<TService> serviceManagement,
          ClientCredentials clientCredentials)
          : this(serviceManagement as IServiceConfiguration<TService>, clientCredentials)
        {
        }

        /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Xrm.Sdk.Client.ServiceProxy`1"></see> class using a service configuration and client logon credentials.</summary>
        /// <param name="serviceConfiguration">Type: <see cref="T:Microsoft.Xrm.Sdk.Client.IServiceConfiguration`1"></see>. A service configuration.</param>
        /// <param name="clientCredentials">Type: Returns_ClientCredentials. The logon credentials of the client.</param>
        protected ServiceProxy(
          IServiceConfiguration<TService> serviceConfiguration,
          ClientCredentials clientCredentials)
        {
            ClientExceptionHelper.ThrowIfNull((object)serviceConfiguration, nameof(serviceConfiguration));
            ClientExceptionHelper.ThrowIfNull((object)serviceConfiguration.CurrentServiceEndpoint, "serviceConfiguration.CurrentServiceEndpoint");
            this.ServiceConfiguration = serviceConfiguration;
            this.SetClientCredentials(clientCredentials);
            this.IsAuthenticated = true;
            //this.SetDefaultEndpointSwitchBehavior();
        }

        /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Xrm.Sdk.Client.ServiceProxy`1"></see> class using a service URI, a home realm URI, client logon credentials, and pn_Windows_Live device credentials.</summary>
        /// <param name="deviceCredentials">Type: Returns_ClientCredentials. The credentials of a device registered with pn_Windows_Live. Only required when authenticating with pn_CRM_Online, otherwise use null.</param>
        /// <param name="homeRealmUri">Type: Returns_URI. The URI of the WS-Trust metadata endpoint of a second ADFS instance.</param>
        /// <param name="uri">Type: Returns_URI. The URI of the service.</param>
        /// <param name="clientCredentials">Type: Returns_ClientCredentials. The client’s logon credentials.</param>
        protected ServiceProxy(
          Uri uri,
          Uri homeRealmUri,
          ClientCredentials clientCredentials,
          ClientCredentials deviceCredentials)
        {
            ClientExceptionHelper.ThrowIfNull((object)uri, nameof(uri));
            this.IsAuthenticated = false;
            this.ServiceConfiguration = ServiceConfigurationFactory.CreateConfiguration<TService>(uri);
            this.SetClientCredentials(clientCredentials);
            this.HomeRealmUri = homeRealmUri;
            //this.DeviceCredentials = deviceCredentials;
            //this.SetDefaultEndpointSwitchBehavior();
        }

        /// <summary>Closes the service channel and channel factory if they are open, and then invokes <see cref="M:Microsoft.Xrm.Sdk.Client.ServiceProxy`1.AuthenticateCore"></see>.</summary>
        public void Authenticate()
        {
            if (this._serviceChannel != null)
            {
                this._serviceChannel.Close();
                this._serviceChannel.Dispose();
                this._serviceChannel = (Microsoft.Xrm.Sdk.Client.ServiceChannel<TService>)null;
            }
            if (this._channelFactory != null)
            {
                this.RemoveChannelFactoryEvents();
                this._channelFactory.Close(true);
                this._channelFactory = (System.ServiceModel.ChannelFactory<TService>)null;
            }
            this.AuthenticateCore();
        }

        /// <summary>Invokes <see cref="M:Microsoft.Xrm.Sdk.Client.ServiceProxy`1.AuthenticateCrossRealmCore"></see>.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Client.SecurityTokenResponse"></see>A security token response.</returns>
        /*public SecurityTokenResponse AuthenticateCrossRealm()
        {
            return this.AuthenticateCrossRealmCore();
        }

        /// <summary>Invokes <see cref="M:Microsoft.Xrm.Sdk.Client.ServiceProxy`1.AuthenticateDeviceCore"></see>.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Client.SecurityTokenResponse"></see>A security token response.</returns>
        public SecurityTokenResponse AuthenticateDevice()
        {
            return this.AuthenticateDeviceCore();
        }*/

        /// <summary>Gets a service configuration.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Client.IServiceConfiguration`1"></see>A service configuration.</returns>
        public IServiceConfiguration<TService> ServiceConfiguration { get; private set; }

        /// <summary>Gets a service management.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Client.IServiceManagement`1"></see>A service management.</returns>
        public IServiceManagement<TService> ServiceManagement
        {
            get
            {
                return this.ServiceConfiguration as IServiceManagement<TService>;
            }
        }

        /// <summary>Gets the endpoint switch information from the web service configuration.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Client.IEndpointSwitch"></see>The endpoint switch information from the web service configuration.</returns>
        /*public IEndpointSwitch EndpointSwitch
        {
            get
            {
                return this.ServiceConfiguration as IEndpointSwitch;
            }
        }*/

        /// <summary>Gets the login credentials of the client.</summary>
        /// <returns>Type: Returns_ClientCredentialsThe login credentials of the client.</returns>
        public ClientCredentials ClientCredentials { get; private set; }

        /// <summary>Gets or sets the UPN that is an Internet-style login name for a user based on the Internet standard RFC 822.</summary>
        /// <returns>Type: Returns_StringThe UPN that is an Internet-style login name for a user based on the Internet standard RFC 822.</returns>
        public string UserPrincipalName { get; set; }

        /// <summary>Gets the security token response.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Client.SecurityTokenResponse"></see>The security token response.</returns>
        /*public SecurityTokenResponse SecurityTokenResponse { get; protected set; }

        /// <summary>Gets the security token response of the home realm.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Client.SecurityTokenResponse"></see>The security token response of the home realm.</returns>
        public SecurityTokenResponse HomeRealmSecurityTokenResponse { get; protected set; }*/

        /// <summary>Gets the home realm URI.</summary>
        /// <returns>Type: Returns_URIThe home realm URI.</returns>
        public Uri HomeRealmUri { get; private set; }

        /// <summary>Gets the pn_Windows_Live credentials of a registered device.</summary>
        /// <returns>Type: Returns_ClientCredentialsThe pn_Windows_Live credentials of a registered device..</returns>
        //public ClientCredentials DeviceCredentials { get; private set; }

        /// <summary>Gets the communication channel used to access a pn_microsoftcrm service.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Client.ServiceChannel`1"></see>The communication channel used to access a pn_microsoftcrm service.</returns>
        public Microsoft.Xrm.Sdk.Client.ServiceChannel<TService> ServiceChannel
        {
            get
            {
                this.ValidateAuthentication();
                return this._serviceChannel;
            }
        }

        /// <summary>Gets or sets the maximum amount of time a single channel operation has to complete before a timeout fault is raised on a service channel binding.</summary>
        /// <returns>Type: Returns_TimeSpanThe maximum amount of time a single channel operation has to complete before a timeout fault is raised on a service channel binding.</returns>
        public TimeSpan Timeout
        {
            get
            {
                return this._timeout;
            }
            set
            {
                this._timeout = value;
                this.RefreshChannelManagers();
            }
        }

        /// <summary>Gets a value indicating if the WCF channel has been authenticated.</summary>
        /// <returns>Type: Returns_Booleantrue if the created WCF channel has been authenticated, otherwise false.</returns>
        public bool IsAuthenticated { get; private set; }

        internal bool AutoCloseChannel
        {
            get
            {
                return this._autoCloseChannel;
            }
            set
            {
                this._autoCloseChannel = value;
            }
        }

        //internal string AppliesTo { get; set; }

        /// <summary>Authenticates a user in a realm other than the realm that the pn_microsoftcrm server is located in.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Client.SecurityTokenResponse"></see>A security token response.</returns>
        /*protected virtual SecurityTokenResponse AuthenticateCrossRealmCore()
        {
            ClientExceptionHelper.ThrowIfNull((object)this.ServiceConfiguration, "ServiceConfiguration");
            ClientExceptionHelper.ThrowIfNull((object)this.HomeRealmUri, "HomeRealmUri");
            if (this.AppliesTo == null)
            {
                ClientExceptionHelper.ThrowIfNull((object)this.ServiceConfiguration.PolicyConfiguration, "ServiceConfiguration.PolicyConfiguration");
                ClientExceptionHelper.ThrowIfNullOrEmpty(this.ServiceConfiguration.PolicyConfiguration.SecureTokenServiceIdentifier, "ServiceConfiguration.PolicyConfiguration.SecureTokenServiceIdentifier");
                this.AppliesTo = this.ServiceConfiguration.PolicyConfiguration.SecureTokenServiceIdentifier;
            }
            return this.ServiceConfiguration.AuthenticateCrossRealm(this.ClientCredentials, this.AppliesTo, this.HomeRealmUri);
        }*/

        /// <summary>Checks a message security exception to determine if a service call should be attempted again.</summary>
        /// <returns>Type: Returns_Nullable&lt;Returns_Boolean&gt;true if the service call should be tried again; otherwise, false or null.</returns>
        /// <param name="retry">Type: Returns_Nullable&lt;Returns_Boolean&gt;. null if this is the first time the check is performed; otherwise, this is the second time and a retry should not be performed.</param>
        /// <param name="messageSecurityException">Type: Returns_MessageSecurityException. The exception to check.</param>
        [SuppressMessage("Microsoft.Design", "CA1011:ConsiderPassingBaseTypesAsParameters", Justification = "We want to explicitly call out that we only handle this exception.")]
        protected bool? ShouldRetry(MessageSecurityException messageSecurityException, bool? retry)
        {
            return !retry.HasValue && messageSecurityException.InnerException is FaultException innerException && (innerException.Code.IsSenderFault && innerException.Code.SubCode.Name == "BadContextToken") ? new bool?(true) : new bool?(false);
        }

        /// <summary>Authenticates the client and creates a new service channel.</summary>
        protected virtual void ValidateAuthentication()
        {
            if (!this.IsAuthenticated)
                this.Authenticate();
            if (this._serviceChannel != null && !this._serviceChannel.IsChannelInvalid)
                return;
            this.CreateNewServiceChannel();
        }

        /// <summary>Authenticates a device with pn_Windows_Live.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Client.SecurityTokenResponse"></see>A security token response.</returns>
        /*protected virtual SecurityTokenResponse AuthenticateDeviceCore()
        {
            if (this.ServiceConfiguration.AuthenticationType != AuthenticationProviderType.LiveId)
                return (SecurityTokenResponse)null;
            ClientExceptionHelper.ThrowIfNull((object)this.DeviceCredentials, "DeviceCredentials");
            return this.ServiceConfiguration.AuthenticateDevice(this.DeviceCredentials);
        }*/

        /// <summary>Authenticates the client with a service.</summary>
        protected virtual void AuthenticateCore()
        {
            ClientExceptionHelper.ThrowIfNull((object)this.ServiceConfiguration, "ServiceConfiguration");
            if (this.ServiceConfiguration.AuthenticationType == AuthenticationProviderType.ActiveDirectory)
            {
                this.IsAuthenticated = true;
            }
            else
            {
                if (this.ClientCredentials == null)
                    return;
               // SecurityTokenResponse securityTokenResponse = (SecurityTokenResponse)null;
                switch (this.ServiceConfiguration.AuthenticationType)
                {
                    /*case AuthenticationProviderType.Federation:
                        //securityTokenResponse = this.AuthenticateClaims();
                        break;
                    case AuthenticationProviderType.LiveId:
                        //securityTokenResponse = this.AuthenticateWithLiveId();
                        break;
                    case AuthenticationProviderType.OnlineFederation:
                        if (this.ServiceConfiguration.ShouldAuthenticateWithLiveId<TService>(this.ClientCredentials))
                        {
                            AuthenticationCredentials authenticationCredentials = new AuthenticationCredentials();
                            authenticationCredentials.ClientCredentials = this.ClientCredentials;
                            if (this.DeviceCredentials != null)
                            {
                                authenticationCredentials.SupportingCredentials = new AuthenticationCredentials();
                                authenticationCredentials.SupportingCredentials.ClientCredentials = this.DeviceCredentials;
                            }
                           // securityTokenResponse = this.ServiceManagement.Authenticate(authenticationCredentials).SecurityTokenResponse;
                            break;
                        }
                        //securityTokenResponse = this.AuthenticateOnlineFederation();
                        break;*/
                }
                /*ClientExceptionHelper.Assert(securityTokenResponse != null && securityTokenResponse.Token != null, "The user authentication failed!");
                this.SecurityTokenResponse = securityTokenResponse;*/
                this.IsAuthenticated = true;
            }
        }

        /*private SecurityTokenResponse AuthenticateOnlineFederation()
        {
            OnlinePolicyConfiguration policyConfiguration = this.ServiceConfiguration.PolicyConfiguration as OnlinePolicyConfiguration;
            ClientExceptionHelper.ThrowIfNull((object)policyConfiguration, "onlinePolicy");
            OrgIdentityProviderTrustConfiguration trustConfiguration = policyConfiguration.OnlineProviders.Values.OfType<OrgIdentityProviderTrustConfiguration>().FirstOrDefault<OrgIdentityProviderTrustConfiguration>();
            ClientExceptionHelper.ThrowIfNull((object)trustConfiguration, "liveTrustConfig");
            bool flag = true;
            if (this.HomeRealmUri == (Uri)null)
            {
                string userPrincipalName = this.UserPrincipalName;
                if (string.IsNullOrEmpty(userPrincipalName))
                {
                    if (string.IsNullOrEmpty(this.ClientCredentials.Windows.ClientCredential.UserName))
                    {
                        ClientExceptionHelper.ThrowIfNullOrEmpty(this.ClientCredentials.UserName.UserName, "ClientCredentials.UserName.UserName");
                        userPrincipalName = this.ClientCredentials.UserName.UserName;
                    }
                    else
                        userPrincipalName = this.ClientCredentials.Windows.ClientCredential.UserName;
                }
                IdentityProvider identityProvider = this.ServiceConfiguration.GetIdentityProvider(userPrincipalName);
                ClientExceptionHelper.ThrowIfNull((object)identityProvider, "identityProvider");
                this.HomeRealmUri = identityProvider.ServiceUrl;
                flag = identityProvider.IdentityProviderType == IdentityProviderType.OrgId;
                if (flag)
                    ClientExceptionHelper.Assert((policyConfiguration.OnlineProviders.ContainsKey(this.HomeRealmUri) ? 1 : 0) != 0, "Online Identity Provider NOT found!  {0}", (object)this.HomeRealmUri);
            }
            if (flag)
                return this.ServiceConfiguration.AuthenticateCrossRealm(this.ClientCredentials, trustConfiguration.AppliesTo, this.HomeRealmUri);
            this.AppliesTo = trustConfiguration.Identifier.AbsoluteUri;
            this.HomeRealmSecurityTokenResponse = this.AuthenticateCrossRealm();
            ClientExceptionHelper.Assert(this.HomeRealmSecurityTokenResponse != null && this.HomeRealmSecurityTokenResponse.Token != null, "The user authentication failed!");
            return this.ServiceConfiguration.AuthenticateCrossRealm(this.HomeRealmSecurityTokenResponse.Token, trustConfiguration.AppliesTo, trustConfiguration.Endpoint.GetServiceRoot());
        }*/

        /*private SecurityTokenResponse AuthenticateClaims()
        {
            if (!(this.HomeRealmUri != (Uri)null))
                return this.ServiceConfiguration.Authenticate(this.ClientCredentials);
            this.HomeRealmSecurityTokenResponse = this.AuthenticateCrossRealm();
            ClientExceptionHelper.Assert(this.HomeRealmSecurityTokenResponse != null && this.HomeRealmSecurityTokenResponse.Token != null, "The user authentication failed!");
            return this.ServiceConfiguration.Authenticate(this.HomeRealmSecurityTokenResponse.Token);
        }

        private SecurityTokenResponse AuthenticateWithLiveId()
        {
            SecurityTokenResponse deviceSecurityToken = this.AuthenticateDevice();
            ClientExceptionHelper.Assert(deviceSecurityToken != null && deviceSecurityToken.Token != null, "The device authentication failed!");
            return deviceSecurityToken != null ? this.ServiceConfiguration.Authenticate(this.ClientCredentials, deviceSecurityToken) : (SecurityTokenResponse)null;
        }*/

        /// <summary>Closes a validated service channel.</summary>
        /// <param name="forceClose">Type: Returns_Boolean.  true if the  service channel should be forced to close; otherwise, false.</param>
        protected virtual void CloseChannel(bool forceClose)
        {
            if (!forceClose && !this.AutoCloseChannel || this._serviceChannel == null)
                return;
            this._serviceChannel.Close();
        }

        /// <summary>The maximum amount of time a single channel operation has to complete before a timeout fault is raised on a service channel binding.</summary>
        /// <param name="sendTimeout">Type: Returns_TimeSpan.A send operation timespan.</param>
        /// <param name="binding">Type: Returns_Binding. The target channel binding.</param>
        /// <param name="openTimeout">Type: Returns_TimeSpan. An open operation timespan.</param>
        /// <param name="closeTimeout">Type: Returns_TimeSpan.A close operation timespan.</param>
        protected static void SetBindingTimeout(
          Binding binding,
          TimeSpan sendTimeout,
          TimeSpan openTimeout,
          TimeSpan closeTimeout)
        {
            ClientExceptionHelper.ThrowIfNull((object)binding, nameof(binding));
            binding.OpenTimeout = openTimeout;
            binding.CloseTimeout = closeTimeout;
            binding.SendTimeout = sendTimeout;
        }

        /// <summary>Gets a WCF channel factory that manages a single channel instance.</summary>
        /// <returns>Type: Returns_ChannelFactory_GenericA WCF channel factory.</returns>
        protected System.ServiceModel.ChannelFactory<TService> ChannelFactory
        {
            get
            {
                if (this.IsChannelFactoryInvalid())
                {
                    this._channelFactory = /*this.SecurityTokenResponse != null ? this.ServiceConfiguration.CreateChannelFactory(ClientAuthenticationType.SecurityToken) :*/ this.ServiceConfiguration.CreateChannelFactory(this.ClientCredentials);
                    ServiceProxy<TService>.ConfigureEndpoint(this._channelFactory.Endpoint, this);
                }
                return this._channelFactory;
            }
        }

        internal static void ConfigureEndpoint(
          ServiceEndpoint endpoint,
          ServiceProxy<TService> serviceProxy)
        {
            ClientExceptionHelper.ThrowIfNull((object)endpoint, nameof(endpoint));
            ClientExceptionHelper.ThrowIfNull((object)serviceProxy, nameof(serviceProxy));
            foreach (OperationDescription operation in (Collection<OperationDescription>)endpoint.Contract.Operations)
            {
                DataContractSerializerOperationBehavior operationBehavior = operation.Behaviors.Find<DataContractSerializerOperationBehavior>();
                if (operationBehavior != null)
                    operationBehavior.MaxItemsInObjectGraph = int.MaxValue;
            }
            XrmBinding xrmBinding = new XrmBinding(endpoint.Binding);
            endpoint.Binding = (Binding)xrmBinding;
            xrmBinding.MaxReceivedMessageSize = (long)int.MaxValue;
            xrmBinding.MaxBufferSize = int.MaxValue;
            xrmBinding.ReaderQuotas.MaxStringContentLength = int.MaxValue;
            xrmBinding.ReaderQuotas.MaxArrayLength = int.MaxValue;
            xrmBinding.ReaderQuotas.MaxBytesPerRead = int.MaxValue;
            ServiceProxy<TService>.SetBindingTimeout((Binding)xrmBinding, serviceProxy.Timeout, serviceProxy.Timeout, serviceProxy.Timeout);
        }

        private void SetClientCredentials(ClientCredentials clientCredentials)
        {
            this.ClientCredentials = clientCredentials ?? new ClientCredentials();
            if (this.ServiceConfiguration.AuthenticationType != AuthenticationProviderType.ActiveDirectory)
                return;
            ServiceMetadataUtility.AdjustUserNameForWindows(this.ClientCredentials);
        }

        private void CreateNewServiceChannel()
        {
            this.ChannelFactory.Faulted += new EventHandler(this.Factory_Faulted);
            this.ChannelFactory.Opened += new EventHandler(this.Factory_Opened);
            this.ChannelFactory.Closed += new EventHandler(this.Factory_Closed);
            //this.ChannelFactory.Credentials.ServiceCertificate.Authentication.CertificateValidationMode = System.ServiceModel.Security.X509CertificateValidationMode.None;
            this._serviceChannel = /*this.SecurityTokenResponse == null || this.SecurityTokenResponse.Token == null ?*/ new Microsoft.Xrm.Sdk.Client.ServiceChannel<TService>(this.ChannelFactory) /*: (Microsoft.Xrm.Sdk.Client.ServiceChannel<TService>)new ServiceFederatedChannel<TService>(this.ChannelFactory, this.SecurityTokenResponse.Token)*/;
            this._serviceChannel.Timeout = this.Timeout;
        }

        private void RefreshChannelManagers()
        {
            if (this._channelFactory != null)
                ServiceProxy<TService>.SetBindingTimeout(this._channelFactory.Endpoint.Binding, this._timeout, this._timeout, this._timeout);
            if (this._serviceChannel == null)
                return;
            this._serviceChannel.Timeout = this._timeout;
        }

        private bool IsChannelFactoryInvalid()
        {
            if (this._channelFactory != null)
            {
                switch (this._channelFactory.State)
                {
                    case CommunicationState.Created:
                    case CommunicationState.Opening:
                    case CommunicationState.Opened:
                        return false;
                }
            }
            return true;
        }

        private void RemoveChannelFactoryEvents()
        {
            if (this._channelFactory == null)
                return;
            this._channelFactory.Faulted -= new EventHandler(this.Factory_Faulted);
            this._channelFactory.Opened -= new EventHandler(this.Factory_Opened);
            this._channelFactory.Closed -= new EventHandler(this.Factory_Closed);
        }

        private void Factory_Faulted(object sender, EventArgs e)
        {
            this.OnFactoryFaulted(new ChannelFaultedEventArgs("The Factory has entered a faulted state.", (Exception)null));
            if (this._channelFactory == null)
                return;
            this.RemoveChannelFactoryEvents();
            this._channelFactory.Close(true);
            this._channelFactory = (System.ServiceModel.ChannelFactory<TService>)null;
        }

        /// <summary>Event handler virtual method for a channel factory that is in a faulted state.</summary>
        /// <param name="args">Type: <see cref="T:Microsoft.Xrm.Sdk.Client.ChannelFaultedEventArgs"></see>. Faulted channel event arguments.</param>
        protected virtual void OnFactoryFaulted(ChannelFaultedEventArgs args)
        {
            if (this.FactoryFaulted == null)
                return;
            this.FactoryFaulted((object)this, args);
        }

        private void Factory_Closed(object sender, EventArgs e)
        {
            this.OnFactoryClosed(new ChannelEventArgs("The Factory has entered a closed state."));
        }

        /// <summary>Event handler virtual method for a channel factory that is in a closed state.</summary>
        /// <param name="args">Type: <see cref="T:Microsoft.Xrm.Sdk.Client.ChannelEventArgs"></see>. Channel events arguments.</param>
        protected virtual void OnFactoryClosed(ChannelEventArgs args)
        {
            if (this.FactoryClosed == null)
                return;
            this.FactoryClosed((object)this, args);
        }

        private void Factory_Opened(object sender, EventArgs e)
        {
            this.OnFactoryOpened(new ChannelEventArgs("The Factory has entered an opened state."));
        }

        /// <summary>Event handler virtual method for a channel factory that is in an opened state.</summary>
        /// <param name="args">Type: <see cref="T:Microsoft.Xrm.Sdk.Client.ChannelEventArgs"></see>. Channel event arguments.</param>
        protected virtual void OnFactoryOpened(ChannelEventArgs args)
        {
            if (this.FactoryOpened == null)
                return;
            this.FactoryOpened((object)this, args);
        }

        /// <summary>Occurs when a channel factory is faulted.</summary>
        public event EventHandler<ChannelFaultedEventArgs> FactoryFaulted;

        /// <summary>Occurs when a channel factory is opened.</summary>
        public event EventHandler<ChannelEventArgs> FactoryOpened;

        /// <summary>Occurs when a channel factory is closed. </summary>
        public event EventHandler<ChannelEventArgs> FactoryClosed;

        protected bool? HandleFailover(BaseServiceFault fault, bool? retry)
        {
            return fault.ErrorCode == -2147176347 && this.HandleFailover(retry) ? new bool?(true) : new bool?(false);
        }

        protected bool HandleFailover(bool? retry)
        {
            if (!retry.HasValue)
            {
                /*if (!this.EndpointSwitch.CanSwitch(this.ChannelFactory.Endpoint.Address.Uri))
                {
                    this.Dispose(true);
                    return true;
                }
                if (this.EndpointSwitch.HandleEndpointSwitch())
                {
                    this.Dispose(true);
                    return true;
                }*/
            }
            return false;
        }

        /// <summary>Occurs when a failover recovery has completed and the organization’s current endpoint has been switched to an alternate endpoint.</summary>
        /*public event EventHandler<EndpointSwitchEventArgs> EndpointSwitched
        {
            add
            {
                this.EndpointSwitch.EndpointSwitched += value;
            }
            remove
            {
                this.EndpointSwitch.EndpointSwitched -= value;
            }
        }

        /// <summary>Occurs when a failover has occurred and a switch from the organization’s current endpoint to an alternate endpoint is required.</summary>
        public event EventHandler<EndpointSwitchEventArgs> EndpointSwitchRequired
        {
            add
            {
                this.EndpointSwitch.EndpointSwitchRequired += value;
            }
            remove
            {
                this.EndpointSwitch.EndpointSwitchRequired -= value;
            }
        }

        /// <summary>Gets or sets a value that enables automatic switching from the organization’s current endpoint to an alternate endpoint.</summary>
        /// <returns>Type: Returns_Booleantrue to enable automatic switching from the organization’s current endpoint to an alternate endpoint; otherwise, false.</returns>
        public bool EndpointAutoSwitchEnabled
        {
            get
            {
                return this.EndpointSwitch.EndpointAutoSwitchEnabled;
            }
            set
            {
                this.EndpointSwitch.EndpointAutoSwitchEnabled = value;
            }
        }*/

        /// <summary>Switches the organization’s current endpoint to an alternate endpoint, if one is available.</summary>
        /// <returns>Type: Returns_Booleantrue if the switch was successful; otherwise, false.</returns>
        /*public bool SwitchToAlternateEndpoint()
        {
            if (!this.EndpointAutoSwitchEnabled || !(this.EndpointSwitch.AlternateEndpoint != (Uri)null))
                return false;
            this.EndpointSwitch.SwitchEndpoint();
            return true;
        }*/

        /*private void SetDefaultEndpointSwitchBehavior()
        {
            this.EndpointAutoSwitchEnabled = this.EndpointSwitch.AlternateEndpoint != (Uri)null;
        }*/

        /// <summary>Custom implementation of Dispose that disposes the service channel and channel factory.</summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize((object)this);
        }

        /// <summary>Implicitly frees allocated service channel and service factory resources.</summary>
        ~ServiceProxy()
        {
            this.Dispose(false);
        }

        internal void DisposeFactory(bool disposing)
        {
            if (!disposing)
                return;
            if (this._channelFactory != null)
            {
                this.RemoveChannelFactoryEvents();
                this._channelFactory.Close(true);
            }
            this._channelFactory = (System.ServiceModel.ChannelFactory<TService>)null;
        }

        /// <summary>Custom implementation of Dispose that disposes the service channel and channel factory.</summary>
        /// <param name="disposing">Type: Returns_Boolean. </param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposing)
                return;
            this.DisposeFactory(disposing);
            if (this._serviceChannel != null)
                this._serviceChannel.Dispose();
            this._serviceChannel = (Microsoft.Xrm.Sdk.Client.ServiceChannel<TService>)null;
        }
    }
}
