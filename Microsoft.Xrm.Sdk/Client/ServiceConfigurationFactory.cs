using Microsoft.Xrm.Sdk.Discovery;
using System;
using System.Reflection;

namespace Microsoft.Xrm.Sdk.Client
{
    /// <summary>Represents a client factory for creating service configurations.</summary>
    public static class ServiceConfigurationFactory
    {
        /// <summary>Creates a service configuration.</summary>
        /// <returns>Type:  <see cref="T:Microsoft.Xrm.Sdk.Client.IServiceConfiguration`1"></see>A service configuration object.</returns>
        /// <param name="serviceUri">Specifies the service’s URI.</param>
        public static IServiceConfiguration<TService> CreateConfiguration<TService>(
          Uri serviceUri)
        {
            return ServiceConfigurationFactory.CreateConfiguration<TService>(serviceUri, false, (Assembly)null);
        }

        /// <summary>Creates a service configuration</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Client.IServiceConfiguration`1"></see>A service configuration object.</returns>
        /// <param name="serviceUri">Specifies the web service’s URI.</param>
        /// <param name="assembly">An assembly containing proxy types.</param>
        /// <param name="enableProxyTypes">True to enable proxy types; otherwise, False.</param>
        public static IServiceConfiguration<TService> CreateConfiguration<TService>(
          Uri serviceUri,
          bool enableProxyTypes,
          Assembly assembly)
        {
            if (serviceUri != (Uri)null)
            {
                if (typeof(TService) == typeof(IDiscoveryService))
                    return new DiscoveryServiceConfiguration(serviceUri) as IServiceConfiguration<TService>;
                if (typeof(TService) == typeof(IOrganizationService))
                    return new OrganizationServiceConfiguration(serviceUri, enableProxyTypes, assembly) as IServiceConfiguration<TService>;
            }
            return (IServiceConfiguration<TService>)null;
        }

        /// <summary>Creates a service management.</summary>
        /// <returns>Type:  <see cref="T:Microsoft.Xrm.Sdk.Client.IServiceManagement`1"></see>A service management object.</returns>
        /// <param name="serviceUri">Specifies the service’s URI.</param>
        public static IServiceManagement<TService> CreateManagement<TService>(
          Uri serviceUri)
        {
            return ServiceConfigurationFactory.CreateManagement<TService>(serviceUri, false, (Assembly)null);
        }

        /// <summary>Creates a service management.</summary>
        /// <returns>Type:  <see cref="T:Microsoft.Xrm.Sdk.Client.IServiceManagement`1"></see>A service management object.</returns>
        /// <param name="serviceUri">Specifies the service’s URI.</param>
        /// <param name="assembly">An assembly containing proxy types.</param>
        /// <param name="enableProxyTypes">True to enable proxy types; otherwise, False.</param>
        public static IServiceManagement<TService> CreateManagement<TService>(
          Uri serviceUri,
          bool enableProxyTypes,
          Assembly assembly)
        {
            if (serviceUri != (Uri)null)
            {
                if (typeof(TService) == typeof(IDiscoveryService))
                    return new DiscoveryServiceConfiguration(serviceUri) as IServiceManagement<TService>;
                if (typeof(TService) == typeof(IOrganizationService))
                    return new OrganizationServiceConfiguration(serviceUri, enableProxyTypes, assembly) as IServiceManagement<TService>;
            }
            return (IServiceManagement<TService>)null;
        }
    }
}
