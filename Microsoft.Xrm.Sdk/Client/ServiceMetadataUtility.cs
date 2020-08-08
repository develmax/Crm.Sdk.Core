//using Microsoft.IdentityModel.Protocols.WSTrust.Bindings;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
//using System.IdentityModel.Tokens;
using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Security;
using System.ServiceModel.Security.Tokens;
using System.Xml;

namespace Microsoft.Xrm.Sdk.Client
{
    internal static class ServiceMetadataUtility
    {
        /*public static IssuerEndpointDictionary RetrieveIssuerEndpoints(
          EndpointAddress issuerMetadataAddress)
        {
            IssuerEndpointDictionary endpointDictionary = new IssuerEndpointDictionary();
            MetadataSet metadata = ServiceMetadataUtility.CreateMetadataClient(issuerMetadataAddress.Uri.Scheme).GetMetadata(issuerMetadataAddress.Uri, MetadataExchangeClientMode.HttpGet);
            if (metadata != null)
            {
                foreach (ServiceEndpoint importAllEndpoint in (Collection<ServiceEndpoint>)new WsdlImporter(metadata).ImportAllEndpoints())
                {
                    if (!(importAllEndpoint.Binding is NetTcpBinding))
                    {
                        TokenServiceCredentialType serviceCredentialType = TokenServiceCredentialType.None;
                        TrustVersion trustVersion = TrustVersion.Default;
                        if (importAllEndpoint.Binding is WS2007HttpBinding binding)
                        {
                            SecurityBindingElement securityBindingElement = binding.CreateBindingElements().Find<SecurityBindingElement>();
                            if (securityBindingElement != null)
                            {
                                trustVersion = securityBindingElement.MessageSecurityVersion.TrustVersion;
                                if (trustVersion == TrustVersion.WSTrust13)
                                {
                                    if (binding.Security.Message.ClientCredentialType == MessageCredentialType.UserName)
                                        serviceCredentialType = TokenServiceCredentialType.Username;
                                    else if (binding.Security.Message.ClientCredentialType == MessageCredentialType.Certificate)
                                        serviceCredentialType = TokenServiceCredentialType.Certificate;
                                    else if (binding.Security.Message.ClientCredentialType == MessageCredentialType.Windows)
                                        serviceCredentialType = TokenServiceCredentialType.Windows;
                                }
                            }
                        }
                        else
                        {
                            SecurityBindingElement securityElement = importAllEndpoint.Binding.CreateBindingElements().Find<SecurityBindingElement>();
                            if (securityElement != null)
                            {
                                trustVersion = securityElement.MessageSecurityVersion.TrustVersion;
                                if (trustVersion == TrustVersion.WSTrust13)
                                {
                                    IssuedSecurityTokenParameters issuedTokenParameters = ServiceMetadataUtility.GetIssuedTokenParameters(securityElement);
                                    if (issuedTokenParameters != null)
                                    {
                                        if (issuedTokenParameters.KeyType == SecurityKeyType.SymmetricKey)
                                            serviceCredentialType = TokenServiceCredentialType.SymmetricToken;
                                        else if (issuedTokenParameters.KeyType == SecurityKeyType.AsymmetricKey)
                                            serviceCredentialType = TokenServiceCredentialType.AsymmetricToken;
                                        else if (issuedTokenParameters.KeyType == SecurityKeyType.BearerKey)
                                            serviceCredentialType = TokenServiceCredentialType.Bearer;
                                    }
                                    else if (ServiceMetadataUtility.GetKerberosTokenParameters(securityElement) != null)
                                        serviceCredentialType = TokenServiceCredentialType.Kerberos;
                                }
                            }
                        }
                        if (serviceCredentialType != TokenServiceCredentialType.None)
                        {
                            string key = serviceCredentialType.ToString();
                            if (!endpointDictionary.ContainsKey(key))
                                endpointDictionary.Add(key, new IssuerEndpoint()
                                {
                                    IssuerAddress = importAllEndpoint.Address,
                                    IssuerBinding = importAllEndpoint.Binding,
                                    IssuerMetadataAddress = issuerMetadataAddress,
                                    CredentialType = serviceCredentialType,
                                    TrustVersion = trustVersion
                                });
                        }
                    }
                }
            }
            return endpointDictionary;
        }*/

        /*[SuppressMessage("Microsoft.Security", "CA2141:TransparentMethodsMustNotSatisfyLinkDemandsFxCopRule")]
        public static IssuerEndpointDictionary RetrieveACSIssuerEndpoints(
          Uri trustUrl)
        {
            IssuerEndpointDictionary endpointDictionary1 = new IssuerEndpointDictionary();
            IssuerEndpointDictionary endpointDictionary2 = endpointDictionary1;
            string key1 = TokenServiceCredentialType.SymmetricToken.ToString();
            IssuerEndpoint issuerEndpoint1 = new IssuerEndpoint();
            issuerEndpoint1.CredentialType = TokenServiceCredentialType.SymmetricToken;
            issuerEndpoint1.IssuerAddress = new EndpointAddress(new Uri(trustUrl.AbsoluteUri + "v2/wstrust/13/issuedtoken-symmetric"), new AddressHeader[0]);
            issuerEndpoint1.TrustVersion = TrustVersion.WSTrust13;
            IssuerEndpoint issuerEndpoint2 = issuerEndpoint1;
            IssuedTokenWSTrustBinding tokenWsTrustBinding1 = new IssuedTokenWSTrustBinding();
            tokenWsTrustBinding1.TrustVersion = TrustVersion.WSTrust13;
            tokenWsTrustBinding1.SecurityMode = SecurityMode.TransportWithMessageCredential;
            tokenWsTrustBinding1.KeyType = SecurityKeyType.SymmetricKey;
            IssuedTokenWSTrustBinding tokenWsTrustBinding2 = tokenWsTrustBinding1;
            issuerEndpoint2.IssuerBinding = (Binding)tokenWsTrustBinding2;
            IssuerEndpoint issuerEndpoint3 = issuerEndpoint1;
            endpointDictionary2.Add(key1, issuerEndpoint3);
            IssuerEndpointDictionary endpointDictionary3 = endpointDictionary1;
            string key2 = TokenServiceCredentialType.Bearer.ToString();
            IssuerEndpoint issuerEndpoint4 = new IssuerEndpoint();
            issuerEndpoint4.CredentialType = TokenServiceCredentialType.Bearer;
            issuerEndpoint4.IssuerAddress = new EndpointAddress(new Uri(trustUrl.AbsoluteUri + "v2/wstrust/13/issuedtoken-bearer"), new AddressHeader[0]);
            issuerEndpoint4.TrustVersion = TrustVersion.WSTrust13;
            IssuerEndpoint issuerEndpoint5 = issuerEndpoint4;
            IssuedTokenWSTrustBinding tokenWsTrustBinding3 = new IssuedTokenWSTrustBinding();
            tokenWsTrustBinding3.TrustVersion = TrustVersion.WSTrust13;
            tokenWsTrustBinding3.SecurityMode = SecurityMode.TransportWithMessageCredential;
            tokenWsTrustBinding3.KeyType = SecurityKeyType.BearerKey;
            IssuedTokenWSTrustBinding tokenWsTrustBinding4 = tokenWsTrustBinding3;
            issuerEndpoint5.IssuerBinding = (Binding)tokenWsTrustBinding4;
            IssuerEndpoint issuerEndpoint6 = issuerEndpoint4;
            endpointDictionary3.Add(key2, issuerEndpoint6);
            IssuerEndpointDictionary endpointDictionary4 = endpointDictionary1;
            string key3 = TokenServiceCredentialType.AsymmetricToken.ToString();
            IssuerEndpoint issuerEndpoint7 = new IssuerEndpoint();
            issuerEndpoint7.CredentialType = TokenServiceCredentialType.AsymmetricToken;
            issuerEndpoint7.IssuerAddress = new EndpointAddress(new Uri(trustUrl.AbsoluteUri + "v2/wstrust/13/issuedtoken-asymmetric"), new AddressHeader[0]);
            issuerEndpoint7.TrustVersion = TrustVersion.WSTrust13;
            IssuerEndpoint issuerEndpoint8 = issuerEndpoint7;
            IssuedTokenWSTrustBinding tokenWsTrustBinding5 = new IssuedTokenWSTrustBinding();
            tokenWsTrustBinding5.TrustVersion = TrustVersion.WSTrust13;
            tokenWsTrustBinding5.SecurityMode = SecurityMode.TransportWithMessageCredential;
            tokenWsTrustBinding5.KeyType = SecurityKeyType.AsymmetricKey;
            IssuedTokenWSTrustBinding tokenWsTrustBinding6 = tokenWsTrustBinding5;
            issuerEndpoint8.IssuerBinding = (Binding)tokenWsTrustBinding6;
            IssuerEndpoint issuerEndpoint9 = issuerEndpoint7;
            endpointDictionary4.Add(key3, issuerEndpoint9);
            return endpointDictionary1;
        }*/

        /*[SuppressMessage("Microsoft.Security", "CA2141:TransparentMethodsMustNotSatisfyLinkDemandsFxCopRule")]
        public static IssuerEndpointDictionary RetrieveLiveIdIssuerEndpoints(
          IdentityProviderTrustConfiguration identityProviderTrustConfiguration)
        {
            IssuerEndpointDictionary endpointDictionary = new IssuerEndpointDictionary();
            endpointDictionary.Add(TokenServiceCredentialType.Username.ToString(), new IssuerEndpoint()
            {
                CredentialType = TokenServiceCredentialType.Username,
                IssuerAddress = new EndpointAddress(identityProviderTrustConfiguration.Endpoint.AbsoluteUri),
                IssuerBinding = identityProviderTrustConfiguration.Binding
            });
            IssuedTokenWSTrustBinding tokenWsTrustBinding1 = new IssuedTokenWSTrustBinding();
            tokenWsTrustBinding1.TrustVersion = identityProviderTrustConfiguration.TrustVersion;
            tokenWsTrustBinding1.SecurityMode = identityProviderTrustConfiguration.SecurityMode;
            IssuedTokenWSTrustBinding tokenWsTrustBinding2 = tokenWsTrustBinding1;
            tokenWsTrustBinding2.KeyType = SecurityKeyType.BearerKey;
            endpointDictionary.Add(TokenServiceCredentialType.SymmetricToken.ToString(), new IssuerEndpoint()
            {
                CredentialType = TokenServiceCredentialType.SymmetricToken,
                IssuerAddress = new EndpointAddress(identityProviderTrustConfiguration.Endpoint.AbsoluteUri),
                IssuerBinding = (Binding)tokenWsTrustBinding2
            });
            return endpointDictionary;
        }*/

        /*public static IssuerEndpointDictionary RetrieveDefaultIssuerEndpoint(
          AuthenticationProviderType authenticationProviderType,
          IssuerEndpoint issuer)
        {
            IssuerEndpointDictionary endpointDictionary = new IssuerEndpointDictionary();
            if (issuer != null && issuer.IssuerAddress != (EndpointAddress)null)
            {
                TokenServiceCredentialType serviceCredentialType;
                switch (authenticationProviderType)
                {
                    /*case AuthenticationProviderType.Federation:
                        serviceCredentialType = TokenServiceCredentialType.Kerberos;
                        break;
                    case AuthenticationProviderType.LiveId:
                        serviceCredentialType = TokenServiceCredentialType.Username;
                        break;
                    case AuthenticationProviderType.OnlineFederation:
                        serviceCredentialType = TokenServiceCredentialType.Username;
                        break;#1#
                    default:
                        serviceCredentialType = TokenServiceCredentialType.Kerberos;
                        break;
                }
                endpointDictionary.Add(serviceCredentialType.ToString(), new IssuerEndpoint()
                {
                    CredentialType = serviceCredentialType,
                    IssuerAddress = issuer.IssuerAddress,
                    IssuerBinding = issuer.IssuerBinding
                });
            }
            return endpointDictionary;
        }*/

        /*[SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "We don't care about the actual exception, just want to ignore it for now.")]
        public static IssuerEndpointDictionary RetrieveIssuerEndpoints(
          AuthenticationProviderType authenticationProviderType,
          ServiceEndpointDictionary endpoints,
          bool queryMetadata)
        {
            foreach (ServiceEndpoint serviceEndpoint in endpoints.Values)
            {
                try
                {
                    IssuerEndpoint issuer = ServiceMetadataUtility.GetIssuer(serviceEndpoint.Binding);
                    if (issuer != null)
                        return queryMetadata && issuer.IssuerMetadataAddress != (EndpointAddress)null ? ServiceMetadataUtility.RetrieveIssuerEndpoints(issuer.IssuerMetadataAddress) : ServiceMetadataUtility.RetrieveDefaultIssuerEndpoint(authenticationProviderType, issuer);
                }
                catch (Exception ex)
                {
                }
            }
            return new IssuerEndpointDictionary();
        }*/

        /*public static IssuerEndpoint GetIssuer(Binding binding)
        {
            if (binding == null)
                return (IssuerEndpoint)null;
            IssuedSecurityTokenParameters issuedTokenParameters = ServiceMetadataUtility.GetIssuedTokenParameters(binding.CreateBindingElements().Find<SecurityBindingElement>());
            if (issuedTokenParameters == null)
                return (IssuerEndpoint)null;
            return new IssuerEndpoint()
            {
                IssuerAddress = issuedTokenParameters.IssuerAddress,
                IssuerBinding = issuedTokenParameters.IssuerBinding,
                IssuerMetadataAddress = issuedTokenParameters.IssuerMetadataAddress
            };
        }*/

        /*private static KerberosSecurityTokenParameters GetKerberosTokenParameters(
          SecurityBindingElement securityElement)
        {
            return securityElement != null && securityElement.EndpointSupportingTokenParameters != null && (securityElement.EndpointSupportingTokenParameters.Endorsing != null && securityElement.EndpointSupportingTokenParameters.Endorsing.Count > 0) ? securityElement.EndpointSupportingTokenParameters.Endorsing[0] as KerberosSecurityTokenParameters : (KerberosSecurityTokenParameters)null;
        }*/

        /*private static IssuedSecurityTokenParameters GetIssuedTokenParameters(
          SecurityBindingElement securityElement)
        {
            if (securityElement != null && securityElement.EndpointSupportingTokenParameters != null)
            {
                if (securityElement.EndpointSupportingTokenParameters.Endorsing != null && securityElement.EndpointSupportingTokenParameters.Endorsing.Count > 0)
                {
                    if (securityElement.EndpointSupportingTokenParameters.Endorsing[0] is IssuedSecurityTokenParameters securityTokenParameters)
                        return securityTokenParameters;
                    if (securityElement.EndpointSupportingTokenParameters.Endorsing[0] is SecureConversationSecurityTokenParameters securityTokenParameters)
                    {
                        if (securityTokenParameters.BootstrapSecurityBindingElement.EndpointSupportingTokenParameters.Endorsing.Count > 0)
                            return securityTokenParameters.BootstrapSecurityBindingElement.EndpointSupportingTokenParameters.Endorsing[0] as IssuedSecurityTokenParameters;
                        if (securityTokenParameters.BootstrapSecurityBindingElement.EndpointSupportingTokenParameters.Signed.Count > 0)
                            return securityTokenParameters.BootstrapSecurityBindingElement.EndpointSupportingTokenParameters.Signed[0] as IssuedSecurityTokenParameters;
                    }
                }
                else if (securityElement.EndpointSupportingTokenParameters.Signed != null && securityElement.EndpointSupportingTokenParameters.Signed.Count > 0)
                    return securityElement.EndpointSupportingTokenParameters.Signed[0] as IssuedSecurityTokenParameters;
            }
            return (IssuedSecurityTokenParameters)null;
        }*/

        /*public static CustomBinding SetIssuer(
          Binding binding,
          IssuerEndpoint issuerEndpoint)
        {
            BindingElementCollection bindingElements = binding.CreateBindingElements();
            IssuedSecurityTokenParameters issuedTokenParameters = ServiceMetadataUtility.GetIssuedTokenParameters(bindingElements.Find<SecurityBindingElement>());
            if (issuedTokenParameters != null)
            {
                issuedTokenParameters.IssuerAddress = issuerEndpoint.IssuerAddress;
                issuedTokenParameters.IssuerBinding = issuerEndpoint.IssuerBinding;
                if (issuerEndpoint.IssuerMetadataAddress != (EndpointAddress)null)
                    issuedTokenParameters.IssuerMetadataAddress = issuerEndpoint.IssuerMetadataAddress;
            }
            return new CustomBinding((IEnumerable<BindingElement>)bindingElements);
        }*/

        /*private static void ParseEndpoints(
          ServiceEndpointDictionary serviceEndpoints,
          ServiceEndpointCollection serviceEndpointCollection)
        {
            serviceEndpoints.Clear();
            if (serviceEndpointCollection == null)
                return;
            foreach (ServiceEndpoint serviceEndpoint in (Collection<ServiceEndpoint>)serviceEndpointCollection)
            {
                if (ServiceMetadataUtility.IsEndpointSupported(serviceEndpoint))
                    serviceEndpoints.Add(serviceEndpoint.Name, serviceEndpoint);
            }
        }*/

        private static bool IsEndpointSupported(ServiceEndpoint endpoint)
        {
            return endpoint != null && !endpoint.Address.Uri.AbsolutePath.EndsWith("web", StringComparison.OrdinalIgnoreCase);
        }

        /*internal static ServiceEndpointMetadata RetrieveServiceEndpointMetadata(
          System.Type contractType,
          Uri serviceUri,
          bool checkForSecondary)
        {
            ServiceEndpointMetadata serviceEndpointMetadata = new ServiceEndpointMetadata();
            serviceEndpointMetadata.ServiceUrls = ServiceConfiguration<IOrganizationService>.CalculateEndpoints(serviceUri);
            Uri address = new Uri(serviceUri.AbsoluteUri + "?wsdl");
            MetadataExchangeClient metadataClient = ServiceMetadataUtility.CreateMetadataClient(address.Scheme);
            if (metadataClient != null)
            {
                try
                {
                    serviceEndpointMetadata.ServiceMetadata = metadataClient.GetMetadata(address, MetadataExchangeClientMode.HttpGet);
                }
                catch (InvalidOperationException ex)
                {
                    bool flag = true;
                    if (checkForSecondary && ex.InnerException is WebException innerException && (innerException.Status == WebExceptionStatus.NameResolutionFailure || innerException.Status == WebExceptionStatus.Timeout) && serviceEndpointMetadata.ServiceUrls != null)
                    {
                        if (serviceEndpointMetadata.ServiceUrls.PrimaryEndpoint == serviceUri)
                            flag = ServiceMetadataUtility.TryRetrieveMetadata(metadataClient, new Uri(serviceEndpointMetadata.ServiceUrls.AlternateEndpoint.AbsoluteUri + "?wsdl"), serviceEndpointMetadata);
                        else if (serviceEndpointMetadata.ServiceUrls.AlternateEndpoint == serviceUri)
                            flag = ServiceMetadataUtility.TryRetrieveMetadata(metadataClient, new Uri(serviceEndpointMetadata.ServiceUrls.PrimaryEndpoint.AbsoluteUri + "?wsdl"), serviceEndpointMetadata);
                    }
                    if (flag)
                        throw;
                }
            }
            ClientExceptionHelper.ThrowIfNull((object)serviceEndpointMetadata.ServiceMetadata, "STS Metadata");
            Collection<ContractDescription> contractCollection = ServiceMetadataUtility.CreateContractCollection(contractType);
            if (contractCollection != null)
            {
                WsdlImporter importer = new WsdlImporter(serviceEndpointMetadata.ServiceMetadata);
                KeyedByTypeCollection<IWsdlImportExtension> importExtensions = importer.WsdlImportExtensions;
                List<IPolicyImportExtension> policyImporter = ServiceMetadataUtility.AddSecurityBindingToPolicyImporter(importer);
                WsdlImporter wsdlImporter = new WsdlImporter(serviceEndpointMetadata.ServiceMetadata, (IEnumerable<IPolicyImportExtension>)policyImporter, (IEnumerable<IWsdlImportExtension>)importExtensions);
                foreach (ContractDescription contract in contractCollection)
                    wsdlImporter.KnownContracts.Add(ServiceMetadataUtility.GetPortTypeQName(contract), contract);
                ServiceEndpointCollection serviceEndpointCollection = wsdlImporter.ImportAllEndpoints();
                if (wsdlImporter.Errors.Count > 0)
                {
                    foreach (MetadataConversionError error in wsdlImporter.Errors)
                        serviceEndpointMetadata.MetadataConversionErrors.Add(error);
                }
                ServiceMetadataUtility.ParseEndpoints(serviceEndpointMetadata.ServiceEndpoints, serviceEndpointCollection);
            }
            return serviceEndpointMetadata;
        }*/

        /*private static List<IPolicyImportExtension> AddSecurityBindingToPolicyImporter(
          WsdlImporter importer)
        {
            List<IPolicyImportExtension> policyImportExtensionList = new List<IPolicyImportExtension>();
            KeyedByTypeCollection<IPolicyImportExtension> importExtensions = importer.PolicyImportExtensions;
            SecurityBindingElementImporter importer1 = importExtensions.Find<SecurityBindingElementImporter>();
            if (importer1 != null)
                importExtensions.Remove<SecurityBindingElementImporter>();
            else
                importer1 = new SecurityBindingElementImporter();
            policyImportExtensionList.Add((IPolicyImportExtension)new AuthenticationPolicyImporter(importer1));
            policyImportExtensionList.AddRange((IEnumerable<IPolicyImportExtension>)importExtensions);
            return policyImportExtensionList;
        }

        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Need to catch any exception here and fail.")]
        private static bool TryRetrieveMetadata(
          MetadataExchangeClient mcli,
          Uri serviceEndpoint,
          ServiceEndpointMetadata serviceEndpointMetadata)
        {
            bool flag = true;
            try
            {
                serviceEndpointMetadata.ServiceMetadata = mcli.GetMetadata(serviceEndpoint, MetadataExchangeClientMode.HttpGet);
                serviceEndpointMetadata.ServiceUrls.GeneratedFromAlternate = true;
                flag = false;
            }
            catch
            {
            }
            return flag;
        }*/

        /*private static XmlQualifiedName GetPortTypeQName(ContractDescription contract)
        {
            return new XmlQualifiedName(contract.Name, contract.Namespace);
        }

        private static Collection<ContractDescription> CreateContractCollection(
          System.Type contract)
        {
            return new Collection<ContractDescription>()
      {
        ContractDescription.GetContract(contract)
      };
        }*/

        /*private static MetadataExchangeClient CreateMetadataClient(string scheme)
        {
            WSHttpBinding wsHttpBinding = string.Compare(scheme, "https", StringComparison.OrdinalIgnoreCase) != 0 ? MetadataExchangeBindings.CreateMexHttpBinding() as WSHttpBinding : MetadataExchangeBindings.CreateMexHttpsBinding() as WSHttpBinding;
            wsHttpBinding.MaxReceivedMessageSize = (long)int.MaxValue;
            return new MetadataExchangeClient((Binding)wsHttpBinding)
            {
                ResolveMetadataReferences = true,
                MaximumResolvedReferences = 100
            };
        }*/

        public static void ReplaceEndpointAddress(ServiceEndpoint endpoint, Uri adddress)
        {
            endpoint.Address = new EndpointAddressBuilder(endpoint.Address)
            {
                Uri = adddress
            }.ToEndpointAddress();
        }

        internal static void AdjustUserNameForWindows(ClientCredentials clientCredentials)
        {
            ClientExceptionHelper.ThrowIfNull((object)clientCredentials, nameof(clientCredentials));
            if (string.IsNullOrWhiteSpace(clientCredentials.UserName.UserName))
                return;
            NetworkCredential networkCredential;
            if (clientCredentials.UserName.UserName.IndexOf('@') > -1)
            {
                string[] strArray = clientCredentials.UserName.UserName.Split('@');
                networkCredential = strArray.Length <= 1 ? new NetworkCredential(strArray[0], clientCredentials.UserName.Password) : new NetworkCredential(strArray[0], clientCredentials.UserName.Password, strArray[1]);
            }
            else if (clientCredentials.UserName.UserName.IndexOf('\\') > -1)
            {
                string[] strArray = clientCredentials.UserName.UserName.Split('\\');
                networkCredential = strArray.Length <= 1 ? new NetworkCredential(strArray[0], clientCredentials.UserName.Password) : new NetworkCredential(strArray[1], clientCredentials.UserName.Password, strArray[0]);
            }
            else
                networkCredential = new NetworkCredential(clientCredentials.UserName.UserName, clientCredentials.UserName.Password);
            clientCredentials.Windows.ClientCredential = networkCredential;
            clientCredentials.UserName.UserName = string.Empty;
            clientCredentials.UserName.Password = string.Empty;
        }
    }
}
