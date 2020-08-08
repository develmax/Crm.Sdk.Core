using Microsoft.Xrm.Sdk.Query;
using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Security.Permissions;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Security;

namespace Microsoft.Xrm.Sdk.Client
{
    /// <summary>Implements <see cref="T:Microsoft.Xrm.Sdk.IOrganizationService"></see> and provides an authenticated WCF channel to the organization service.</summary>
    [SuppressMessage("Microsoft.Security", "CA9881:ClassesShouldBeSealed", Justification = "This class need to be instantiated by clients and be able to derive from it.")]
    public class OrganizationServiceProxy : ServiceProxy<IOrganizationService>, IOrganizationService
    {
        private string _xrmSdkAssemblyFileVersion;

        internal bool OfflinePlayback { get; set; }

        /// <summary>Gets or sets the ID of the user for whom SDK calls are made on behalf of.</summary>
        /// <returns>Type: Returns_Guid.The ID of the user for whom SDK calls are made on behalf of.</returns>
        public Guid CallerId { get; set; }

        internal int LanguageCodeOverride { get; set; }

        /// <summary>internal</summary>
        /// <returns>Type: Returns_String.</returns>
        public string SyncOperationType { get; set; }

        internal string ClientAppName { get; set; }

        internal string ClientAppVersion { get; set; }

        /// <summary>Gets or sets the version of the client.</summary>
        /// <returns>Type: Returns_String.The version of the client.</returns>
        public string SdkClientVersion { get; set; }

        internal OrganizationServiceProxy()
        {
        }

        /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.Client.OrganizationServiceProxy"></see> class using a organization service URI, home realm URI, and client and device credentials.</summary>
        /// <param name="deviceCredentials">Type: Returns_ClientCredentials. The Windows Live ID device credentials.</param>
        /// <param name="homeRealmUri">Type: Returns_URI. This parameter is set to a non-null value when a second ADFS instance is configured as an identity provider to the ADFS instance that pn_CRM_2011 has been configured with for claims authentication. The parameter value is the URI of the WS-Trust metadata endpoint of the second ADFS instance.</param>
        /// <param name="uri">Type: Returns_URI. The URI of the organization service.</param>
        /// <param name="clientCredentials">Type: Returns_ClientCredentials. The logon credentials of the client.</param>
        public OrganizationServiceProxy(
          Uri uri,
          Uri homeRealmUri,
          ClientCredentials clientCredentials,
          ClientCredentials deviceCredentials)
          : base(uri, homeRealmUri, clientCredentials, deviceCredentials)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.Client.OrganizationServiceProxy"></see> class using a service configuration and a security token response.</summary>
        /// <param name="serviceConfiguration">Type: <see cref="T:Microsoft.Xrm.Sdk.Client.IServiceConfiguration`1"></see>&lt;<see cref="T:Microsoft.Xrm.Sdk.IOrganizationService"></see>&gt;. A service configuration.</param>
        /// <param name="securityTokenResponse">Type: <see cref="T:Microsoft.Xrm.Sdk.Client.SecurityTokenResponse"></see>. A security token response.</param>
        /*public OrganizationServiceProxy(
          IServiceConfiguration<IOrganizationService> serviceConfiguration,
          SecurityTokenResponse securityTokenResponse)
          : base(serviceConfiguration, securityTokenResponse)
        {
        }*/

        /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.Client.OrganizationServiceProxy"></see> class using a service configuration and client credentials.</summary>
        /// <param name="serviceConfiguration">Type: <see cref="T:Microsoft.Xrm.Sdk.Client.IServiceConfiguration`1"></see>&lt;<see cref="T:Microsoft.Xrm.Sdk.IOrganizationService"></see>&gt;. A service configuration.</param>
        /// <param name="clientCredentials">Type: Returns_ClientCredentials. The logon credentials of the client.</param>
        public OrganizationServiceProxy(
          IServiceConfiguration<IOrganizationService> serviceConfiguration,
          ClientCredentials clientCredentials)
          : base(serviceConfiguration, clientCredentials)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.Client.OrganizationServiceProxy"></see> class using a service management and a security token response.</summary>
        /// <param name="serviceManagement">Type: <see cref="T:Microsoft.Xrm.Sdk.Client.IServiceManagement`1"></see>&lt;<see cref="T:Microsoft.Xrm.Sdk.IOrganizationService"></see>&gt;. A service management.</param>
        /// <param name="securityTokenResponse">Type: <see cref="T:Microsoft.Xrm.Sdk.Client.SecurityTokenResponse"></see>. A security token response.</param>
        /*public OrganizationServiceProxy(
          IServiceManagement<IOrganizationService> serviceManagement,
          SecurityTokenResponse securityTokenResponse)
          : this(serviceManagement as IServiceConfiguration<IOrganizationService>, securityTokenResponse)
        {
        }*/

        /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.Client.OrganizationServiceProxy"></see> class using a service configuration and client credentials.</summary>
        /// <param name="serviceManagement">Type: <see cref="T:Microsoft.Xrm.Sdk.Client.IServiceManagement`1"></see>&lt;<see cref="T:Microsoft.Xrm.Sdk.IOrganizationService"></see>&gt;. A service management.</param>
        /// <param name="clientCredentials">Type: Returns_ClientCredentials. The logon credentials of the client.</param>
        public OrganizationServiceProxy(
          IServiceManagement<IOrganizationService> serviceManagement,
          ClientCredentials clientCredentials)
          : this(serviceManagement as IServiceConfiguration<IOrganizationService>, clientCredentials)
        {
        }

        /// <summary>Enables support for the early-bound entity types.</summary>
        public void EnableProxyTypes()
        {
            ClientExceptionHelper.ThrowIfNull((object)this.ServiceConfiguration, "ServiceConfiguration");
            OrganizationServiceConfiguration serviceConfiguration = this.ServiceConfiguration as OrganizationServiceConfiguration;
            ClientExceptionHelper.ThrowIfNull((object)serviceConfiguration, "orgConfig");
            serviceConfiguration.EnableProxyTypes();
        }

        /// <summary>Enables support for the early-bound entity types exposed in a specified assembly.</summary>
        /// <param name="assembly">Type: Returns_Assembly. An assembly containing early-bound entity types.</param>
        public void EnableProxyTypes(Assembly assembly)
        {
            ClientExceptionHelper.ThrowIfNull((object)assembly, nameof(assembly));
            ClientExceptionHelper.ThrowIfNull((object)this.ServiceConfiguration, "ServiceConfiguration");
            OrganizationServiceConfiguration serviceConfiguration = this.ServiceConfiguration as OrganizationServiceConfiguration;
            ClientExceptionHelper.ThrowIfNull((object)serviceConfiguration, "orgConfig");
            serviceConfiguration.EnableProxyTypes(assembly);
        }

        [SuppressMessage("Microsoft.Security", "CA2141:TransparentMethodsMustNotSatisfyLinkDemandsFxCopRule")]
        [SuppressMessage("Microsoft.Security", "CA2143:TransparentMethodsShouldNotDemandFxCopRule")]
        //[PermissionSet(SecurityAction.Demand, Unrestricted = true)]
        internal string GetXrmSdkAssemblyFileVersion()
        {
            if (string.IsNullOrEmpty(this._xrmSdkAssemblyFileVersion))
            {
                string[] strArray = new string[1]
                {
          "Microsoft.Xrm.Sdk.dll"
                };
                Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
                foreach (string str in strArray)
                {
                    foreach (Assembly assembly in assemblies)
                    {
                        if (assembly.ManifestModule.Name.Equals(str, StringComparison.OrdinalIgnoreCase))
                            this._xrmSdkAssemblyFileVersion = FileVersionInfo.GetVersionInfo(assembly.Location).FileVersion;
                    }
                }
            }
            return this._xrmSdkAssemblyFileVersion;
        }

        /// <summary>internal</summary>
        /// <returns>Type: Returns_GuidThe ID of the created entity.</returns>
        protected internal virtual Guid CreateCore(Entity entity)
        {
            bool? retry = new bool?();
            do
            {
                bool forceClose = false;
                try
                {
                    using (new OrganizationServiceContextInitializer(this))
                        return this.ServiceChannel.Channel.Create(entity);
                }
                catch (MessageSecurityException ex)
                {
                    forceClose = true;
                    retry = this.ShouldRetry(ex, retry);
                    if (!retry.GetValueOrDefault())
                        throw;
                }
                catch (EndpointNotFoundException ex)
                {
                    forceClose = true;
                    retry = new bool?(this.HandleFailover(retry));
                    if (!retry.GetValueOrDefault())
                        throw;
                }
                catch (TimeoutException ex)
                {
                    forceClose = true;
                    retry = new bool?(this.HandleFailover(retry));
                    if (!retry.GetValueOrDefault())
                        throw;
                }
                catch (FaultException<OrganizationServiceFault> ex)
                {
                    forceClose = true;
                    retry = this.HandleFailover((BaseServiceFault)ex.Detail, retry);
                    if (!retry.GetValueOrDefault())
                        throw;
                }
                catch
                {
                    forceClose = true;
                    throw;
                }
                finally
                {
                    this.CloseChannel(forceClose);
                }
            }
            while (retry.HasValue && retry.Value);
            return Guid.Empty;
        }

        /// <summary>internal</summary>
        /// <returns>Type:  <see cref="T:Microsoft.Xrm.Sdk.Entity"></see>.</returns>
        protected internal virtual Entity RetrieveCore(
          string entityName,
          Guid id,
          ColumnSet columnSet)
        {
            bool? retry = new bool?();
            do
            {
                bool forceClose = false;
                try
                {
                    using (new OrganizationServiceContextInitializer(this))
                        return this.ServiceChannel.Channel.Retrieve(entityName, id, columnSet);
                }
                catch (MessageSecurityException ex)
                {
                    forceClose = true;
                    retry = this.ShouldRetry(ex, retry);
                    if (!retry.GetValueOrDefault())
                        throw;
                }
                catch (EndpointNotFoundException ex)
                {
                    forceClose = true;
                    retry = new bool?(this.HandleFailover(retry));
                    if (!retry.GetValueOrDefault())
                        throw;
                }
                catch (TimeoutException ex)
                {
                    forceClose = true;
                    retry = new bool?(this.HandleFailover(retry));
                    if (!retry.GetValueOrDefault())
                        throw;
                }
                catch (FaultException<OrganizationServiceFault> ex)
                {
                    forceClose = true;
                    retry = this.HandleFailover((BaseServiceFault)ex.Detail, retry);
                    if (!retry.GetValueOrDefault())
                        throw;
                }
                catch
                {
                    forceClose = true;
                    throw;
                }
                finally
                {
                    this.CloseChannel(forceClose);
                }
            }
            while (retry.HasValue && retry.Value);
            return (Entity)null;
        }

        /// <summary>internal</summary>
        protected internal virtual void UpdateCore(Entity entity)
        {
            bool? retry = new bool?();
            do
            {
                bool forceClose = false;
                try
                {
                    using (new OrganizationServiceContextInitializer(this))
                    {
                        this.ServiceChannel.Channel.Update(entity);
                        break;
                    }
                }
                catch (MessageSecurityException ex)
                {
                    forceClose = true;
                    retry = this.ShouldRetry(ex, retry);
                    if (!retry.GetValueOrDefault())
                        throw;
                }
                catch (EndpointNotFoundException ex)
                {
                    forceClose = true;
                    retry = new bool?(this.HandleFailover(retry));
                    if (!retry.GetValueOrDefault())
                        throw;
                }
                catch (TimeoutException ex)
                {
                    forceClose = true;
                    retry = new bool?(this.HandleFailover(retry));
                    if (!retry.GetValueOrDefault())
                        throw;
                }
                catch (FaultException<OrganizationServiceFault> ex)
                {
                    forceClose = true;
                    retry = this.HandleFailover((BaseServiceFault)ex.Detail, retry);
                    if (!retry.GetValueOrDefault())
                        throw;
                }
                catch
                {
                    forceClose = true;
                    throw;
                }
                finally
                {
                    this.CloseChannel(forceClose);
                }
            }
            while (retry.HasValue && retry.Value);
        }

        /// <summary>internal</summary>
        protected internal virtual void DeleteCore(string entityName, Guid id)
        {
            bool? retry = new bool?();
            do
            {
                bool forceClose = false;
                try
                {
                    using (new OrganizationServiceContextInitializer(this))
                    {
                        this.ServiceChannel.Channel.Delete(entityName, id);
                        break;
                    }
                }
                catch (MessageSecurityException ex)
                {
                    forceClose = true;
                    retry = this.ShouldRetry(ex, retry);
                    if (!retry.GetValueOrDefault())
                        throw;
                }
                catch (EndpointNotFoundException ex)
                {
                    forceClose = true;
                    retry = new bool?(this.HandleFailover(retry));
                    if (!retry.GetValueOrDefault())
                        throw;
                }
                catch (TimeoutException ex)
                {
                    forceClose = true;
                    retry = new bool?(this.HandleFailover(retry));
                    if (!retry.GetValueOrDefault())
                        throw;
                }
                catch (FaultException<OrganizationServiceFault> ex)
                {
                    forceClose = true;
                    retry = this.HandleFailover((BaseServiceFault)ex.Detail, retry);
                    if (!retry.GetValueOrDefault())
                        throw;
                }
                catch
                {
                    forceClose = true;
                    throw;
                }
                finally
                {
                    this.CloseChannel(forceClose);
                }
            }
            while (retry.HasValue && retry.Value);
        }

        /// <summary>internal</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.OrganizationResponse"></see>.</returns>
        protected internal virtual OrganizationResponse ExecuteCore(
          OrganizationRequest request)
        {
            bool? retry = new bool?();
            do
            {
                bool forceClose = false;
                try
                {
                    using (new OrganizationServiceContextInitializer(this))
                        return this.ServiceChannel.Channel.Execute(request);
                }
                catch (MessageSecurityException ex)
                {
                    forceClose = true;
                    retry = this.ShouldRetry(ex, retry);
                    if (!retry.GetValueOrDefault())
                        throw;
                }
                catch (EndpointNotFoundException ex)
                {
                    forceClose = true;
                    retry = new bool?(this.HandleFailover(retry));
                    if (!retry.GetValueOrDefault())
                        throw;
                }
                catch (TimeoutException ex)
                {
                    forceClose = true;
                    retry = new bool?(this.HandleFailover(retry));
                    if (!retry.GetValueOrDefault())
                        throw;
                }
                catch (FaultException<OrganizationServiceFault> ex)
                {
                    forceClose = true;
                    retry = this.HandleFailover((BaseServiceFault)ex.Detail, retry);
                    if (!retry.GetValueOrDefault())
                        throw;
                }
                catch
                {
                    forceClose = true;
                    throw;
                }
                finally
                {
                    this.CloseChannel(forceClose);
                }
            }
            while (retry.HasValue && retry.Value);
            return (OrganizationResponse)null;
        }

        /// <summary>internal</summary>
        protected internal virtual void AssociateCore(
          string entityName,
          Guid entityId,
          Relationship relationship,
          EntityReferenceCollection relatedEntities)
        {
            bool? retry = new bool?();
            do
            {
                bool forceClose = false;
                try
                {
                    using (new OrganizationServiceContextInitializer(this))
                    {
                        this.ServiceChannel.Channel.Associate(entityName, entityId, relationship, relatedEntities);
                        break;
                    }
                }
                catch (MessageSecurityException ex)
                {
                    forceClose = true;
                    retry = this.ShouldRetry(ex, retry);
                    if (!retry.GetValueOrDefault())
                        throw;
                }
                catch (EndpointNotFoundException ex)
                {
                    forceClose = true;
                    retry = new bool?(this.HandleFailover(retry));
                    if (!retry.GetValueOrDefault())
                        throw;
                }
                catch (TimeoutException ex)
                {
                    forceClose = true;
                    retry = new bool?(this.HandleFailover(retry));
                    if (!retry.GetValueOrDefault())
                        throw;
                }
                catch (FaultException<OrganizationServiceFault> ex)
                {
                    forceClose = true;
                    retry = this.HandleFailover((BaseServiceFault)ex.Detail, retry);
                    if (!retry.GetValueOrDefault())
                        throw;
                }
                catch
                {
                    forceClose = true;
                    throw;
                }
                finally
                {
                    this.CloseChannel(forceClose);
                }
            }
            while (retry.HasValue && retry.Value);
        }

        /// <summary>internal</summary>
        protected internal virtual void DisassociateCore(
          string entityName,
          Guid entityId,
          Relationship relationship,
          EntityReferenceCollection relatedEntities)
        {
            bool? retry = new bool?();
            do
            {
                bool forceClose = false;
                try
                {
                    using (new OrganizationServiceContextInitializer(this))
                    {
                        this.ServiceChannel.Channel.Disassociate(entityName, entityId, relationship, relatedEntities);
                        break;
                    }
                }
                catch (MessageSecurityException ex)
                {
                    forceClose = true;
                    retry = this.ShouldRetry(ex, retry);
                    if (!retry.GetValueOrDefault())
                        throw;
                }
                catch (EndpointNotFoundException ex)
                {
                    forceClose = true;
                    retry = new bool?(this.HandleFailover(retry));
                    if (!retry.GetValueOrDefault())
                        throw;
                }
                catch (TimeoutException ex)
                {
                    forceClose = true;
                    retry = new bool?(this.HandleFailover(retry));
                    if (!retry.GetValueOrDefault())
                        throw;
                }
                catch (FaultException<OrganizationServiceFault> ex)
                {
                    forceClose = true;
                    retry = this.HandleFailover((BaseServiceFault)ex.Detail, retry);
                    if (!retry.GetValueOrDefault())
                        throw;
                }
                catch
                {
                    forceClose = true;
                    throw;
                }
                finally
                {
                    this.CloseChannel(forceClose);
                }
            }
            while (retry.HasValue && retry.Value);
        }

        /// <summary>internal</summary>
        /// <returns>Type:  <see cref="T:Microsoft.Xrm.Sdk.EntityCollection"></see>.</returns>
        protected internal virtual EntityCollection RetrieveMultipleCore(QueryBase query)
        {
            bool? retry = new bool?();
            do
            {
                bool forceClose = false;
                try
                {
                    using (new OrganizationServiceContextInitializer(this))
                        return this.ServiceChannel.Channel.RetrieveMultiple(query);
                }
                catch (MessageSecurityException ex)
                {
                    forceClose = true;
                    retry = this.ShouldRetry(ex, retry);
                    if (!retry.GetValueOrDefault())
                        throw;
                }
                catch (EndpointNotFoundException ex)
                {
                    forceClose = true;
                    retry = new bool?(this.HandleFailover(retry));
                    if (!retry.GetValueOrDefault())
                        throw;
                }
                catch (TimeoutException ex)
                {
                    forceClose = true;
                    retry = new bool?(this.HandleFailover(retry));
                    if (!retry.GetValueOrDefault())
                        throw;
                }
                catch (FaultException<OrganizationServiceFault> ex)
                {
                    forceClose = true;
                    retry = this.HandleFailover((BaseServiceFault)ex.Detail, retry);
                    if (!retry.GetValueOrDefault())
                        throw;
                }
                catch
                {
                    forceClose = true;
                    throw;
                }
                finally
                {
                    this.CloseChannel(forceClose);
                }
            }
            while (retry.HasValue && retry.Value);
            return (EntityCollection)null;
        }

        /// <summary>Creates a record.</summary>
        /// <returns>Type: Returns_GuidThe ID of the created entity.</returns>
        /// <param name="entity">Type: <see cref="T:Microsoft.Xrm.Sdk.Entity"></see>. An entity instance that contains the properties to set in the newly created record.</param>
        public Guid Create(Entity entity)
        {
            return this.CreateCore(entity);
        }

        /// <summary>Retrieves a record.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Entity"></see>.The requested entity.</returns>
        /// <param name="id">Type: Returns_Guid. The ID of the record you want to retrieve.</param>
        /// <param name="columnSet">Type: <see cref="T:Microsoft.Xrm.Sdk.Query.ColumnSet"></see>. A query that specifies the set of columns, or attributes, to retrieve.</param>
        /// <param name="entityName">Type: Returns_String. The logical name of the entity specified in the entityId parameter.</param>
        public Entity Retrieve(string entityName, Guid id, ColumnSet columnSet)
        {
            return this.RetrieveCore(entityName, id, columnSet);
        }

        /// <summary>Updates an existing record.</summary>
        /// <param name="entity">Type: <see cref="T:Microsoft.Xrm.Sdk.Entity"></see>. An entity instance that has one or more properties set to be updated in the record.</param>
        public void Update(Entity entity)
        {
            this.UpdateCore(entity);
        }

        /// <summary>Deletes a record.</summary>
        /// <param name="id">Type: Returns_Guid. The ID of the record of the record to delete.</param>
        /// <param name="entityName">Type: Returns_String. The logical name of the entity specified in the entityId parameter.</param>
        public void Delete(string entityName, Guid id)
        {
            this.DeleteCore(entityName, id);
        }

        /// <summary>Executes a message in the form of a request, and returns a response.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.OrganizationResponse"></see>. You must cast the return value of this method to the specific instance of the response that corresponds to the Request parameter.</returns>
        /// <param name="request">Type: <see cref="T:Microsoft.Xrm.Sdk.OrganizationRequest"></see>. An instance of a request class that defines the action to be performed.</param>
        public OrganizationResponse Execute(OrganizationRequest request)
        {
            return this.ExecuteCore(request);
        }

        /// <summary>Creates a link between records.</summary>
        /// <param name="relatedEntities">Type: <see cref="T:Microsoft.Xrm.Sdk.EntityReferenceCollection"></see>. A collection of entity references (references to records) to be associated.</param>
        /// <param name="relationship">Type: <see cref="T:Microsoft.Xrm.Sdk.Relationship"></see>. The name of the relationship to be used to create the link.</param>
        /// <param name="entityName">Type: Returns_String. The logical name of the entity specified in the entityId parameter.</param>
        /// <param name="entityId">Type: Returns_Guid. The ID of the record to which the related records will be associated.</param>
        public void Associate(
          string entityName,
          Guid entityId,
          Relationship relationship,
          EntityReferenceCollection relatedEntities)
        {
            this.AssociateCore(entityName, entityId, relationship, relatedEntities);
        }

        /// <summary>Deletes a link between records. </summary>
        /// <param name="relatedEntities">Type: <see cref="T:Microsoft.Xrm.Sdk.EntityReferenceCollection"></see>. A collection of entity references (references to records) to be disassociated.</param>
        /// <param name="relationship">Type: <see cref="T:Microsoft.Xrm.Sdk.Relationship"></see>. The name of the relationship to be used to remove the link.</param>
        /// <param name="entityName">Type: Returns_String. The logical name of the entity specified in the entityId parameter.</param>
        /// <param name="entityId">Type: Returns_Guid. The ID of the record from which the related records will be disassociated.</param>
        public void Disassociate(
          string entityName,
          Guid entityId,
          Relationship relationship,
          EntityReferenceCollection relatedEntities)
        {
            this.DisassociateCore(entityName, entityId, relationship, relatedEntities);
        }

        /// <summary>Retrieves a collection of records.</summary>
        /// <returns>Type:  <see cref="T:Microsoft.Xrm.Sdk.EntityCollection"></see>.A collection of entity records.</returns>
        /// <param name="query">Type: <see cref="T:Microsoft.Xrm.Sdk.Query.QueryBase"></see>. A query that determines the set of records to retrieve.</param>
        public EntityCollection RetrieveMultiple(QueryBase query)
        {
            return this.RetrieveMultipleCore(query);
        }
    }
}
