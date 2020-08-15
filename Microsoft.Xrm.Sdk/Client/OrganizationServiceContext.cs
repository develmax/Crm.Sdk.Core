using Microsoft.Xrm.Sdk.Linq;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Security;
using System.Security.Permissions;

namespace Microsoft.Xrm.Sdk.Client
{
  /// <summary>Represents the runtime context of the data service that is used to track pn_microsoftcrm entities and that sends and receives entities from the server.</summary>
  [SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling")]
  [SuppressMessage("Microsoft.Security", "CA9881:ClassesShouldBeSealed", Justification = "This class is used as base by crmsvcutil")]
  public class OrganizationServiceContext : IDisposable
  {
    private readonly IOrganizationService _service;
    private readonly Dictionary<Entity, EntityDescriptor> _descriptors;
    private readonly Dictionary<EntityReference, EntityDescriptor> _identityToDescriptor;
    private readonly Dictionary<LinkDescriptor, LinkDescriptor> _bindings;
    private readonly HashSet<Entity> _roots;
    private readonly bool _trackEntityChanges;

    /// <summary>Gets the query provider.</summary>
    /// <returns>Type:  Returns_IQueryProviderThe query provider.</returns>
    protected virtual IQueryProvider QueryProvider { get; private set; }

    /// <summary>Gets or sets the synchronization option for receiving entities from the Web service.</summary>
    /// <returns>Type:  <see cref="T:Microsoft.Xrm.Sdk.Client.MergeOption"></see>The synchronization option for receiving entities from the Web service.</returns>
    public MergeOption MergeOption { get; set; }

    /// <summary>Gets or sets the <see cref="T:Microsoft.Xrm.Sdk.Client.SaveChangesOptions"></see> values that are used by the <see cref="M:Microsoft.Xrm.Sdk.Client.OrganizationServiceContext.SaveChanges(Microsoft.Xrm.Sdk.Client.SaveChangesOptions)"></see> method.</summary>
    /// <returns>Type:  <see cref="T:Microsoft.Xrm.Sdk.Client.SaveChangesOptions"></see>The <see cref="T:Microsoft.Xrm.Sdk.Client.SaveChangesOptions"></see> values that are used by the <see cref="M:Microsoft.Xrm.Sdk.Client.OrganizationServiceContext.SaveChanges(Microsoft.Xrm.Sdk.Client.SaveChangesOptions)"></see> method.</returns>
    public SaveChangesOptions SaveChangesDefaultOptions { get; set; }

    /// <summary>Creates a new instance of the <see cref="T:Microsoft.Xrm.Sdk.Client.OrganizationServiceContext"></see> class.</summary>
    /// <param name="service">Type: <see cref="T:Microsoft.Xrm.Sdk.IOrganizationService"></see>. The service that provides access to organization data.</param>
    public OrganizationServiceContext(IOrganizationService service)
      : this(service, true)
    {
    }

    internal OrganizationServiceContext(IOrganizationService service, bool trackEntityChanges)
    {
      if (service == null)
        throw new ArgumentNullException(nameof (service));
      this._service = service;
      this._descriptors = new Dictionary<Entity, EntityDescriptor>((IEqualityComparer<Entity>) EqualityComparer<Entity>.Default);
      this._identityToDescriptor = new Dictionary<EntityReference, EntityDescriptor>((IEqualityComparer<EntityReference>) EqualityComparer<EntityReference>.Default);
      this._bindings = new Dictionary<LinkDescriptor, LinkDescriptor>(LinkDescriptor.EquivalenceComparer);
      this._roots = new HashSet<Entity>((IEqualityComparer<Entity>) EqualityComparer<Entity>.Default);
      this._trackEntityChanges = trackEntityChanges;
      this.QueryProvider = (IQueryProvider) new Microsoft.Xrm.Sdk.Linq.QueryProvider(this);
      this.MergeOption = MergeOption.AppendOnly;
    }

    /// <summary>Destructor for the <see cref="T:Microsoft.Xrm.Sdk.Client.OrganizationServiceContext"></see> class.</summary>
    ~OrganizationServiceContext()
    {
      this.Dispose(false);
    }

    /// <summary>Creates a Web service pn_LINQ query for the specified entity.</summary>
    /// <returns>Type:  Returns_IQueryable_Generic&lt;<see cref="T:Microsoft.Xrm.Sdk.Entity"></see>&gt;The query of the specified entity.</returns>
    public IQueryable<TEntity> CreateQuery<TEntity>() where TEntity : Entity
    {
      OrganizationServiceContext.CheckEntitySubclass(typeof (TEntity));
      return this.CreateQuery<TEntity>(this.QueryProvider, KnownProxyTypesProvider.GetInstance(true).GetNameForType(typeof (TEntity)));
    }

    /// <summary>Creates a web service pn_LINQ query for the specified entity.</summary>
    /// <returns>Type:  Returns_IQueryable_Generic&lt;<see cref="T:Microsoft.Xrm.Sdk.Entity"></see>&gt;.The query of the specified entity.</returns>
    /// <param name="entityLogicalName">Type: Returns_String. The logical name of the entity to be queried.</param>
    public IQueryable<Entity> CreateQuery(string entityLogicalName)
    {
      if (string.IsNullOrWhiteSpace(entityLogicalName))
        throw new ArgumentNullException(nameof (entityLogicalName));
      return this.CreateQuery<Entity>(this.QueryProvider, entityLogicalName);
    }

    /// <summary>Creates a web service pn_LINQ query for the specified entity.</summary>
    /// <returns>Type:  Returns_IQueryable_Generic&lt;<see cref="T:Microsoft.Xrm.Sdk.Entity"></see>&gt;The query of the specified entity type..</returns>
    /// <param name="provider">Type: Returns_IQueryProvider. The provider of the Web service.</param>
    /// <param name="entityLogicalName">Type: Returns_String. The logical name of the entity to be queried.</param>
    protected virtual IQueryable<TEntity> CreateQuery<TEntity>(
      IQueryProvider provider,
      string entityLogicalName)
    {
      return (IQueryable<TEntity>) new Microsoft.Xrm.Sdk.Linq.Query<TEntity>(provider, entityLogicalName);
    }

    /// <summary>Loads deferred content for a specified property from the Web service.</summary>
    /// <param name="entity">Type: <see cref="T:Microsoft.Xrm.Sdk.Entity"></see>. The entity that contains the property to load.</param>
    /// <param name="propertyName">Type: Returns_String. The name of the property of the specified entity to load.</param>
    public void LoadProperty(Entity entity, string propertyName)
    {
      if (entity == null)
        throw new ArgumentNullException(nameof (entity));
      if (string.IsNullOrWhiteSpace(propertyName))
        throw new ArgumentNullException(nameof (propertyName));
      Type type = entity.GetType();
      OrganizationServiceContext.CheckEntitySubclass(type);
      PropertyInfo property = type.GetProperty(propertyName);
      if (property == (PropertyInfo) null)
        throw new InvalidOperationException(string.Format((IFormatProvider) CultureInfo.InvariantCulture, "The property '{0}' does not exist on the entity '{1}'.", (object) propertyName, (object) entity));
      RelationshipSchemaNameAttribute defaultCustomAttribute1 = property.GetFirstOrDefaultCustomAttribute<RelationshipSchemaNameAttribute>();
      if (defaultCustomAttribute1 != null)
      {
        Relationship relationship = defaultCustomAttribute1.Relationship;
        this.LoadProperty(entity, relationship);
      }
      else
      {
        AttributeLogicalNameAttribute defaultCustomAttribute2 = property.GetFirstOrDefaultCustomAttribute<AttributeLogicalNameAttribute>();
        if (defaultCustomAttribute2 != null)
          this.LoadProperty(entity, defaultCustomAttribute2);
        else
          throw new InvalidOperationException(string.Format((IFormatProvider) CultureInfo.InvariantCulture, "The closed type '{0}' does not have a corresponding '{1}' settable property.", (object) type, (object) propertyName));
      }
    }

    /// <summary>Loads the related entity collection for the specified relationshp.</summary>
    /// <param name="entity">Type: <see cref="T:Microsoft.Xrm.Sdk.Entity"></see>. The entity with the relationship to be loaded.</param>
    /// <param name="relationship">Type: <see cref="T:Microsoft.Xrm.Sdk.Relationship"></see>. The name of the attribute or navigation property on the entity that represents the relationship to be retrieved.</param>
    public void LoadProperty(Entity entity, Relationship relationship)
    {
      if (entity == null)
        throw new ArgumentNullException(nameof (entity));
      if (relationship == null)
        throw new ArgumentNullException(nameof (relationship));
      EntityDescriptor entityDescriptor;
      bool isAttached = this._descriptors.TryGetValue(entity, out entityDescriptor);
      if (isAttached)
      {
        if (this.MergeOption == MergeOption.NoTracking)
          throw new InvalidOperationException(string.Format((IFormatProvider) CultureInfo.InvariantCulture, "The context can not load the related collection or reference for tracked entities while the 'MergeOption' is set to 'NoTracking'. Change the 'MergeOption' value or detach the '{0}' entity.", (object) entity.LogicalName));
        if (entityDescriptor.State == EntityStates.Added)
          throw new InvalidOperationException("The context can not load the related collection or reference for entities in the added state.");
      }
      else if (this.MergeOption != MergeOption.NoTracking)
        throw new InvalidOperationException(string.Format((IFormatProvider) CultureInfo.InvariantCulture, "The context can not load the related collection or reference for untracked entities while the 'MergeOption' is not set to 'NoTracking'. Change the 'MergeOption' to 'NoTracking' or attach the '{0}' entity.", (object) entity.LogicalName));
      EntityCollection relatedEntities = this.GetRelatedEntities(entity, relationship);
      if (relatedEntities == null)
        return;
      foreach (Entity entity1 in (Collection<Entity>) relatedEntities.Entities)
      {
        Entity target = this.MergeEntity(entity1);
        this.MergeRelationship(entity, relationship, target, isAttached);
      }
    }

    private void LoadProperty(Entity entity, AttributeLogicalNameAttribute attribute)
    {
      if (this.MergeOption != MergeOption.NoTracking && this.EnsureTracked(entity, nameof (entity)).State == EntityStates.Added)
        throw new InvalidOperationException("The context can not load the related collection or reference for entities in the added state.");
      string logicalName = attribute.LogicalName;
      RetrieveResponse retrieveResponse = (RetrieveResponse) this.Execute((OrganizationRequest) new RetrieveRequest()
      {
        Target = new EntityReference(entity.LogicalName, entity.Id),
        ColumnSet = new ColumnSet(new string[1]
        {
          logicalName
        })
      });
      if (retrieveResponse == null || retrieveResponse.Entity == null || !retrieveResponse.Entity.Attributes.Contains(logicalName))
        return;
      entity.Attributes[logicalName] = retrieveResponse.Entity.Attributes[logicalName];
    }

    /// <summary>Notifies the <see cref="T:Microsoft.Xrm.Sdk.Client.OrganizationServiceContext"></see> to start tracking the specified entity.</summary>
    /// <param name="entity">Type: <see cref="T:Microsoft.Xrm.Sdk.Entity"></see>. The entity to be tracked.</param>
    public void Attach(Entity entity)
    {
      if (entity == null)
        throw new ArgumentNullException(nameof (entity));
      this.ValidateAttach(entity, EntityStates.Unchanged);
      this.AttachEntityGraph(entity, EntityStates.Unchanged);
    }

    /// <summary>Removes the entity from the set of entities that the <see cref="T:Microsoft.Xrm.Sdk.Client.OrganizationServiceContext"></see> is tracking.</summary>
    /// <returns>Type:  Returns_Boolean. true if the specified entity was detached; otherwise false.</returns>
    /// <param name="entity">Type: <see cref="T:Microsoft.Xrm.Sdk.Entity"></see>. The entity to be removed from the set of entities that the <see cref="T:Microsoft.Xrm.Sdk.Client.OrganizationServiceContext"></see> is tracking.</param>
    public bool Detach(Entity entity)
    {
      if (entity == null)
        throw new ArgumentNullException(nameof (entity));
      return this.Detach(entity, true);
    }

    /// <summary>Removes the entity from the set of entities that the <see cref="T:Microsoft.Xrm.Sdk.Client.OrganizationServiceContext"></see> is tracking.</summary>
    /// <returns>Type:  Returns_Boolean. Returns true if the specified entity was detached; otherwise false.</returns>
    /// <param name="entity">Type: <see cref="T:Microsoft.Xrm.Sdk.Entity"></see>. The entity to be removed from the set of entities that the <see cref="T:Microsoft.Xrm.Sdk.Client.OrganizationServiceContext"></see> is tracking.</param>
    /// <param name="recursive">Type: Returns_Boolean. true to specify entities to be detached recursively, otherwise false.</param>
    public bool Detach(Entity entity, bool recursive)
    {
      if (entity == null)
        throw new ArgumentNullException(nameof (entity));
      EntityDescriptor existingEntity;
      if (!this._descriptors.TryGetValue(entity, out existingEntity))
        return false;
      if (!recursive)
      {
        this.DetachEntityTracking(existingEntity);
        foreach (Tuple<Entity, Relationship, Entity> traverseRelatedEntity in OrganizationServiceContext.TraverseRelatedEntities(entity))
        {
          LinkDescriptor existingLink;
          if (this._bindings.TryGetValue(new LinkDescriptor(traverseRelatedEntity.Item1, traverseRelatedEntity.Item2, traverseRelatedEntity.Item3), out existingLink))
            this.DetachLinkTracking(existingLink);
        }
        foreach (LinkDescriptor existingLink in this.GetTargetingLinks(entity).ToList<LinkDescriptor>())
          this.DetachLinkTrackingAndRemoveEntity(existingLink);
      }
      else
      {
        foreach (Entity target in this.DetachEntityGraph(entity))
        {
          foreach (LinkDescriptor existingLink in this.GetTargetingLinks(target).ToList<LinkDescriptor>())
            this.DetachLinkTrackingAndRemoveEntity(existingLink);
        }
      }
      return true;
    }

    /// <summary>Notifies the <see cref="T:Microsoft.Xrm.Sdk.Client.OrganizationServiceContext"></see> to start tracking the specified link that defines a relationship between entity objects.</summary>
    /// <param name="target">Type: <see cref="T:Microsoft.Xrm.Sdk.Entity"></see>. The target entity in the link that is bound to the source entity specified in this call. </param>
    /// <param name="relationship">Type: <see cref="T:Microsoft.Xrm.Sdk.Relationship"></see>. The name of the attribute or navigation property on the source object that represents the link between the source and target object.</param>
    /// <param name="source">Type: <see cref="T:Microsoft.Xrm.Sdk.Entity"></see>. The source entity in the new link.</param>
    public void AttachLink(Entity source, Relationship relationship, Entity target)
    {
      if (source == null)
        throw new ArgumentNullException(nameof (source));
      if (target == null)
        throw new ArgumentNullException(nameof (target));
      if (relationship == null)
        throw new ArgumentNullException(nameof (relationship));
      this.EnsureRelatable(source, relationship, target, EntityStates.Unchanged);
      LinkDescriptor linkDescriptor = new LinkDescriptor(source, relationship, target);
      if (this.IsAttached(linkDescriptor))
        throw new InvalidOperationException(string.Format((IFormatProvider) CultureInfo.InvariantCulture, "The context is already tracking the '{0}' relationship.", (object) relationship.SchemaName));
      this.AttachLinkTracking(linkDescriptor);
      OrganizationServiceContext.AddRelationshipIfNotContains(source, relationship, target);
    }

    /// <summary>Removes the specified link from the list of links being tracked by the <see cref="T:Microsoft.Xrm.Sdk.Client.OrganizationServiceContext"></see>.</summary>
    /// <returns>Type:  Returns_Boolean. true if the specified entity was detached; otherwise false.</returns>
    /// <param name="target">Type: <see cref="T:Microsoft.Xrm.Sdk.Entity"></see>. The target entity involved in the link that is bound to the source object.</param>
    /// <param name="relationship">Type: <see cref="T:Microsoft.Xrm.Sdk.Relationship"></see>. The name of the attribute or navigation property on the source entity that represents the source in the link between the source and the target.</param>
    /// <param name="source">Type: <see cref="T:Microsoft.Xrm.Sdk.Entity"></see>. The source entity participating in the link to be marked for deletion.</param>
    public bool DetachLink(Entity source, Relationship relationship, Entity target)
    {
      if (source == null)
        throw new ArgumentNullException(nameof (source));
      if (target == null)
        throw new ArgumentNullException(nameof (target));
      if (relationship == null)
        throw new ArgumentNullException(nameof (relationship));
      LinkDescriptor existingLink;
      if (!this._bindings.TryGetValue(new LinkDescriptor(source, relationship, target), out existingLink))
        return false;
      this.DetachLinkTrackingAndRemoveEntity(existingLink);
      return true;
    }

    /// <summary>Gets an enumerable collection of the entities attached to the <see cref="T:Microsoft.Xrm.Sdk.Client.OrganizationServiceContext"></see>.</summary>
    /// <returns>Type:  Returns_IEnumerable_Generic&lt;<see cref="T:Microsoft.Xrm.Sdk.Entity"></see>&gt;.</returns>
    [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = "Method is appropriate.")]
    public IEnumerable<Entity> GetAttachedEntities()
    {
      return this._descriptors.Values.Select<EntityDescriptor, Entity>((Func<EntityDescriptor, Entity>) (d => d.Entity));
    }

    /// <summary>Determines whether an entity is attached and therefore being tracked by the <see cref="T:Microsoft.Xrm.Sdk.Client.OrganizationServiceContext"></see>.</summary>
    /// <returns>Type:  Returns_Boolean. true if the specified entity is attached to the <see cref="T:Microsoft.Xrm.Sdk.Client.OrganizationServiceContext"></see>; otherwise, false.</returns>
    /// <param name="entity">Type: <see cref="T:Microsoft.Xrm.Sdk.Entity"></see>. The entity to be determined if it is attached.</param>
    public bool IsAttached(Entity entity)
    {
      if (entity == null)
        throw new ArgumentNullException(nameof (entity));
      return this._descriptors.ContainsKey(entity);
    }

    /// <summary>Determines whether an entity has been deleted.</summary>
    /// <returns>Type:  Returns_Boolean. true if the specified entity is deleted; otherwise, false.</returns>
    /// <param name="entity">Type: <see cref="T:Microsoft.Xrm.Sdk.Entity"></see>. The entity to be determined if it is deleted.</param>
    public bool IsDeleted(Entity entity)
    {
      if (entity == null)
        throw new ArgumentNullException(nameof (entity));
      EntityDescriptor entityDescriptor;
      return this._descriptors.TryGetValue(entity, out entityDescriptor) && entityDescriptor.State == EntityStates.Deleted;
    }

    /// <summary>Determines whether an entity relationship is attached and therefore being tracked by the <see cref="T:Microsoft.Xrm.Sdk.Client.OrganizationServiceContext"></see>.</summary>
    /// <returns>Type:  Returns_Boolean. true if the specified entity is attached to the <see cref="T:Microsoft.Xrm.Sdk.Client.OrganizationServiceContext"></see>; otherwise, false.</returns>
    /// <param name="target">Type: <see cref="T:Microsoft.Xrm.Sdk.Entity"></see>. The target entity in the link.</param>
    /// <param name="relationship">Type: <see cref="T:Microsoft.Xrm.Sdk.Relationship"></see>. The name of the attribute or navigation property on the source entity that represents the link between the source and target entity.</param>
    /// <param name="source">Type: <see cref="T:Microsoft.Xrm.Sdk.Entity"></see>. The source entity in the link.</param>
    public bool IsAttached(Entity source, Relationship relationship, Entity target)
    {
      if (source == null)
        throw new ArgumentNullException(nameof (source));
      if (target == null)
        throw new ArgumentNullException(nameof (target));
      if (relationship == null)
        throw new ArgumentNullException(nameof (relationship));
      return this.IsAttached(new LinkDescriptor(source, relationship, target));
    }

    private bool IsAttached(LinkDescriptor link)
    {
      return this._bindings.ContainsKey(link);
    }

    /// <summary>Determines whether a relationship has been deleted.</summary>
    /// <returns>Type:  Returns_Boolean. true if the specified entity is deleted; otherwise, false.</returns>
    /// <param name="target">Type: <see cref="T:Microsoft.Xrm.Sdk.Entity"></see>. The target entity in the link.</param>
    /// <param name="relationship">Type: <see cref="T:Microsoft.Xrm.Sdk.Relationship"></see>. The name of the attribute or navigation property on the source entity that represents the link between the source and target entity.</param>
    /// <param name="source">Type: <see cref="T:Microsoft.Xrm.Sdk.Entity"></see>. The source entity in the link.</param>
    public bool IsDeleted(Entity source, Relationship relationship, Entity target)
    {
      if (source == null)
        throw new ArgumentNullException(nameof (source));
      if (target == null)
        throw new ArgumentNullException(nameof (target));
      if (relationship == null)
        throw new ArgumentNullException(nameof (relationship));
      LinkDescriptor linkDescriptor;
      return this._bindings.TryGetValue(new LinkDescriptor(source, relationship, target), out linkDescriptor) && linkDescriptor.State == EntityStates.Deleted;
    }

    private void ValidateAttach(Entity graph, EntityStates state)
    {
      OrganizationServiceContext.TraverseEntityGraph(graph, (Action<Entity>) (entity =>
      {
        if (entity == graph)
        {
          if (this.IsAttached(entity))
            throw new InvalidOperationException(string.Format((IFormatProvider) CultureInfo.InvariantCulture, "The context is already tracking the '{0}' entity.", (object) entity.LogicalName));
        }
        else if (this.IsAttached(entity))
          return;
        if (state == EntityStates.Unchanged && entity.EntityState.HasValue)
        {
          EntityState? entityState = entity.EntityState;
          if ((entityState.GetValueOrDefault() != EntityState.Unchanged ? 0 : (entityState.HasValue ? 1 : 0)) == 0)
            throw new ArgumentException(string.Format((IFormatProvider) CultureInfo.InvariantCulture, "The '{0}' entity must be in the default (null) or unchanged state.", (object) entity.LogicalName));
        }
        if (state == EntityStates.Added && entity.EntityState.HasValue)
        {
          EntityState? entityState = entity.EntityState;
          if ((entityState.GetValueOrDefault() != EntityState.Created ? 0 : (entityState.HasValue ? 1 : 0)) == 0)
            throw new ArgumentException(string.Format((IFormatProvider) CultureInfo.InvariantCulture, "The '{0}' entity must be in the default (null) or created state.", (object) entity.LogicalName));
        }
        if (state != EntityStates.Added && entity.Id == Guid.Empty)
          throw new ArgumentException(string.Format((IFormatProvider) CultureInfo.InvariantCulture, "The '{0}' entity has an empty ID.", (object) entity.LogicalName));
        if (entity.Id != Guid.Empty && this._identityToDescriptor.TryGetValue(entity.ToEntityReference(), out EntityDescriptor _))
          throw new InvalidOperationException(string.Format((IFormatProvider) CultureInfo.InvariantCulture, "The context is already tracking a different '{0}' entity with the same identity.", (object) entity.LogicalName));
        if (entity.IsReadOnly)
          throw new InvalidOperationException(string.Format((IFormatProvider) CultureInfo.InvariantCulture, "The '{0}' entity is already attached to a context.", (object) entity.LogicalName));
      }), (Action<Entity, Relationship, Entity>) ((source, relationship, target) => {})).ToList<Entity>();
    }

    private void AttachEntityGraph(Entity graph, EntityStates state)
    {
      OrganizationServiceContext.TraverseEntityGraph(graph, (Action<Entity>) (entity => this.AttachEntityTracking(new EntityDescriptor(state, entity.ToEntityReference(), entity))), (Action<Entity, Relationship, Entity>) ((source, relationship, target) => this.AttachLinkTracking(state, source, relationship, target))).ToList<Entity>();
    }

    private void AttachEntityTracking(EntityDescriptor newEntity)
    {
      if (this.IsAttached(newEntity.Entity))
        return;
      if (newEntity.Identity.Id != Guid.Empty)
        this._identityToDescriptor.Add(newEntity.Identity, newEntity);
      this._descriptors.Add(newEntity.Entity, newEntity);
      if (this._trackEntityChanges)
        newEntity.Entity.IsReadOnly = true;
      Entity entity = newEntity.Entity;
      EntityState? nullable = OrganizationServiceContext.MapEntityState(newEntity.State);
      EntityState? entityState = nullable.HasValue ? new EntityState?(nullable.GetValueOrDefault()) : newEntity.Entity.EntityState;
      entity.SetEntityStateInternal(entityState);
      this.OnBeginEntityTracking(newEntity.Entity);
    }

    private static EntityState? MapEntityState(EntityStates state)
    {
      switch (state)
      {
        case EntityStates.Unchanged:
          return new EntityState?(EntityState.Unchanged);
        case EntityStates.Added:
          return new EntityState?(EntityState.Created);
        case EntityStates.Modified:
          return new EntityState?(EntityState.Changed);
        default:
          return new EntityState?();
      }
    }

    private void AttachLinkTracking(
      EntityStates state,
      Entity source,
      Relationship relationship,
      Entity target)
    {
      EntityState? entityState1 = source.EntityState;
      int num;
      if ((entityState1.GetValueOrDefault() != EntityState.Created ? 0 : (entityState1.HasValue ? 1 : 0)) == 0)
      {
        EntityState? entityState2 = target.EntityState;
        if ((entityState2.GetValueOrDefault() != EntityState.Created ? 0 : (entityState2.HasValue ? 1 : 0)) == 0)
        {
          num = (int) state;
          goto label_4;
        }
      }
      num = 4;
label_4:
      EntityStates state1 = (EntityStates) num;
      if (state1 == EntityStates.Added)
        this._roots.Add(source);
      this.AttachLinkTracking(new LinkDescriptor(state1, source, relationship, target));
    }

    private void AttachLinkTracking(LinkDescriptor newLink)
    {
      if (this.IsAttached(newLink.Source, newLink.Relationship, newLink.Target))
        return;
      this._bindings.Add(newLink, newLink);
      this.OnBeginLinkTracking(newLink.Source, newLink.Relationship, newLink.Target);
    }

    private IEnumerable<Entity> DetachEntityGraph(Entity graph)
    {
      return (IEnumerable<Entity>) this.TraverseEntityGraph(graph, new Action<EntityDescriptor>(this.DetachEntityTracking), new Action<LinkDescriptor>(this.DetachLinkTracking)).ToList<Entity>();
    }

    private void DetachEntityTracking(EntityDescriptor existingEntity)
    {
      if (this._trackEntityChanges)
        existingEntity.Entity.IsReadOnly = false;
      existingEntity.State = EntityStates.Detached;
      bool flag = this._descriptors.Remove(existingEntity.Entity);
      this._identityToDescriptor.Remove(existingEntity.Entity.ToEntityReference());
      this._roots.Remove(existingEntity.Entity);
      if (!flag)
        return;
      this.OnEndEntityTracking(existingEntity.Entity);
    }

    private void DetachLinkTracking(LinkDescriptor existingLink)
    {
      existingLink.State = EntityStates.Detached;
      if (!this._bindings.Remove(existingLink))
        return;
      this.OnEndLinkTracking(existingLink.Source, existingLink.Relationship, existingLink.Target);
    }

    private void DetachLinkTrackingAndRemoveEntity(LinkDescriptor existingLink)
    {
      this.DetachLinkTracking(existingLink);
      OrganizationServiceContext.RemoveRelationshipIfContains(existingLink);
    }

    /// <summary>Adds the specified link to the set of objects the <see cref="T:Microsoft.Xrm.Sdk.Client.OrganizationServiceContext"></see> is tracking.</summary>
    /// <param name="target">Type: <see cref="T:Microsoft.Xrm.Sdk.Entity"></see>. The entity related to the source entity by the new link.</param>
    /// <param name="relationship">Type: <see cref="T:Microsoft.Xrm.Sdk.Relationship"></see>. The navigation property or attribute on the source object that returns the related object.</param>
    /// <param name="source">Type: <see cref="T:Microsoft.Xrm.Sdk.Entity"></see>. The source entity for the new link.</param>
    public void AddLink(Entity source, Relationship relationship, Entity target)
    {
      if (source == null)
        throw new ArgumentNullException(nameof (source));
      if (target == null)
        throw new ArgumentNullException(nameof (target));
      if (relationship == null)
        throw new ArgumentNullException(nameof (relationship));
      this.EnsureRelatable(source, relationship, target, EntityStates.Added);
      LinkDescriptor linkDescriptor = new LinkDescriptor(EntityStates.Added, source, relationship, target);
      if (this.IsAttached(linkDescriptor))
        throw new InvalidOperationException(string.Format((IFormatProvider) CultureInfo.InvariantCulture, "The context is already tracking the '{0}' relationship.", (object) relationship.SchemaName));
      this.AttachLinkTracking(linkDescriptor);
      OrganizationServiceContext.AddRelationshipIfNotContains(source, relationship, target);
      this._roots.Add(source);
    }

    /// <summary>Changes the state of the link to deleted in the list of links being tracked by the <see cref="T:Microsoft.Xrm.Sdk.Client.OrganizationServiceContext"></see>.</summary>
    /// <param name="target">Type: <see cref="T:Microsoft.Xrm.Sdk.Entity"></see>. The target entity involved in the link that is bound to the source entity.</param>
    /// <param name="relationship">Type: <see cref="T:Microsoft.Xrm.Sdk.Relationship"></see>. The name of the attribute or navigation property on the source entity that is used to access the target entity.</param>
    /// <param name="source">Type: <see cref="T:Microsoft.Xrm.Sdk.Entity"></see>. The source entity in the link to be marked for deletion.</param>
    public void DeleteLink(Entity source, Relationship relationship, Entity target)
    {
      if (source == null)
        throw new ArgumentNullException(nameof (source));
      if (target == null)
        throw new ArgumentNullException(nameof (target));
      if (relationship == null)
        throw new ArgumentNullException(nameof (relationship));
      bool flag = this.EnsureRelatable(source, relationship, target, EntityStates.Deleted);
      LinkDescriptor linkDescriptor = new LinkDescriptor(source, relationship, target);
      LinkDescriptor existingLink;
      if (this._bindings.TryGetValue(linkDescriptor, out existingLink) && existingLink.State == EntityStates.Added)
      {
        this.DeleteLinkTrackingAndRemoveEntity(existingLink);
      }
      else
      {
        if (flag)
          throw new InvalidOperationException(string.Format((IFormatProvider) CultureInfo.InvariantCulture, "One or both of the ends of the '{0}' relationship is in the added state.", (object) relationship.SchemaName));
        if (existingLink == null)
        {
          this.AttachLinkTracking(linkDescriptor);
          existingLink = linkDescriptor;
        }
        if (existingLink.State == EntityStates.Deleted)
          return;
        existingLink.State = EntityStates.Deleted;
        OrganizationServiceContext.RemoveRelationshipIfContains(existingLink);
      }
    }

    /// <summary>Adds the specified entity to the set of entities that the <see cref="T:Microsoft.Xrm.Sdk.Client.OrganizationServiceContext"></see> is tracking.</summary>
    /// <param name="entity">Type: <see cref="T:Microsoft.Xrm.Sdk.Entity"></see>. The entity to be tracked by the <see cref="T:Microsoft.Xrm.Sdk.Client.OrganizationServiceContext"></see>.</param>
    public void AddObject(Entity entity)
    {
      if (entity == null)
        throw new ArgumentNullException(nameof (entity));
      this.ValidateAttach(entity, EntityStates.Added);
      this.AttachEntityGraph(entity, EntityStates.Added);
      this._roots.Add(entity);
    }

    /// <summary>Adds a related entity to the <see cref="T:Microsoft.Xrm.Sdk.Client.OrganizationServiceContext"></see> and creates the link that defines the relationship between the two entities in a single request.</summary>
    /// <param name="target">Type: <see cref="T:Microsoft.Xrm.Sdk.Entity"></see>. The related object that is being added.</param>
    /// <param name="relationship">Type: <see cref="T:Microsoft.Xrm.Sdk.Relationship"></see>. The name of the attribute or navigation property that returns the related object based on an association between the two entities.</param>
    /// <param name="source">Type: <see cref="T:Microsoft.Xrm.Sdk.Entity"></see>. The parent entity that is being tracked by the context.</param>
    public void AddRelatedObject(Entity source, Relationship relationship, Entity target)
    {
      if (source == null)
        throw new ArgumentNullException(nameof (source));
      if (target == null)
        throw new ArgumentNullException(nameof (target));
      if (relationship == null)
        throw new ArgumentNullException(nameof (relationship));
      if (this.EnsureTracked(source, nameof (source)).State == EntityStates.Deleted)
        throw new InvalidOperationException("AddRelatedObject method only works if the source entity is in a non-deleted state.");
      this.AddObject(target);
      this.AddLink(source, relationship, target);
    }

    /// <summary>Changes the state of the specified entity to be deleted in the <see cref="T:Microsoft.Xrm.Sdk.Client.OrganizationServiceContext"></see>.</summary>
    /// <param name="entity">Type: <see cref="T:Microsoft.Xrm.Sdk.Entity"></see>. The tracked entity to be changed to the deleted state.</param>
    public void DeleteObject(Entity entity)
    {
      if (entity == null)
        throw new ArgumentNullException(nameof (entity));
      this.DeleteObject(entity, false);
    }

    /// <summary>Changes the state of the specified entity to be deleted in the <see cref="T:Microsoft.Xrm.Sdk.Client.OrganizationServiceContext"></see>.</summary>
    /// <param name="entity">Type: <see cref="T:Microsoft.Xrm.Sdk.Entity"></see>. The tracked entity to be changed to the deleted state.</param>
    /// <param name="recursive">Type: Returns_Boolean. true to specify entities to be deleted recursively, otherwise false.</param>
    public void DeleteObject(Entity entity, bool recursive)
    {
      if (entity == null)
        throw new ArgumentNullException(nameof (entity));
      EntityDescriptor existingEntity = this.EnsureTracked(entity, nameof (entity));
      if (!recursive)
      {
        this.DeleteEntityTracking(existingEntity);
        foreach (Tuple<Entity, Relationship, Entity> traverseRelatedEntity in OrganizationServiceContext.TraverseRelatedEntities(entity))
        {
          LinkDescriptor linkDescriptor;
          if (this._bindings.TryGetValue(new LinkDescriptor(traverseRelatedEntity.Item1, traverseRelatedEntity.Item2, traverseRelatedEntity.Item3), out linkDescriptor))
            linkDescriptor.State = EntityStates.Deleted;
        }
        foreach (LinkDescriptor existingLink in this.GetTargetingLinks(entity).ToList<LinkDescriptor>())
          this.DeleteLinkTrackingAndRemoveEntity(existingLink);
      }
      else
      {
        foreach (Entity target in this.DeleteEntityGraph(entity))
        {
          foreach (LinkDescriptor existingLink in this.GetTargetingLinks(target).ToList<LinkDescriptor>())
            this.DeleteLinkTrackingAndRemoveEntity(existingLink);
        }
      }
    }

    private IEnumerable<Entity> DeleteEntityGraph(Entity entity)
    {
      return (IEnumerable<Entity>) this.TraverseEntityGraph(entity, new Action<EntityDescriptor>(this.DeleteEntityTracking), new Action<LinkDescriptor>(this.DeleteLinkTracking)).ToList<Entity>();
    }

    private void DeleteEntityTracking(EntityDescriptor existingEntity)
    {
      switch (existingEntity.State)
      {
        case EntityStates.Added:
          this.DetachEntityTracking(existingEntity);
          goto case EntityStates.Deleted;
        case EntityStates.Deleted:
          this._roots.Remove(existingEntity.Entity);
          break;
        default:
          existingEntity.State = EntityStates.Deleted;
          goto case EntityStates.Deleted;
      }
    }

    private void DeleteLinkTracking(LinkDescriptor existingLink)
    {
      switch (existingLink.State)
      {
        case EntityStates.Added:
          this.DetachLinkTracking(existingLink);
          break;
        case EntityStates.Deleted:
          break;
        default:
          existingLink.State = EntityStates.Deleted;
          break;
      }
    }

    private void DeleteLinkTrackingAndRemoveEntity(LinkDescriptor existingLink)
    {
      this.DeleteLinkTracking(existingLink);
      OrganizationServiceContext.RemoveRelationshipIfContains(existingLink);
    }

    /// <summary>Changes the state of the specified entity in the <see cref="T:Microsoft.Xrm.Sdk.Client.OrganizationServiceContext"></see> to Modified.</summary>
    /// <param name="entity">Type: <see cref="T:Microsoft.Xrm.Sdk.Entity"></see>. The tracked entity to be assigned to the Modified state.</param>
    public void UpdateObject(Entity entity)
    {
      if (entity == null)
        throw new ArgumentNullException(nameof (entity));
      this.UpdateObject(entity, false);
    }

    /// <summary>Changes the state of the specified entity in the <see cref="T:Microsoft.Xrm.Sdk.Client.OrganizationServiceContext"></see> to Modified.</summary>
    /// <param name="entity">Type: <see cref="T:Microsoft.Xrm.Sdk.Entity"></see>. The tracked entity to be assigned to the Modified state.</param>
    /// <param name="recursive">Type: Returns_Boolean. true if operation should be recursive; otherwise false.</param>
    public void UpdateObject(Entity entity, bool recursive)
    {
      if (entity == null)
        throw new ArgumentNullException(nameof (entity));
      EntityDescriptor existingEntity = this.EnsureTracked(entity, nameof (entity));
      if (!recursive)
      {
        this.InternalUpdate(existingEntity);
      }
      else
      {
        this.ValidateUpdate(entity);
        this.UpdateEntityGraph(entity);
      }
    }

    private void ValidateUpdate(Entity graph)
    {
      OrganizationServiceContext.TraverseEntityGraph(graph, (Action<Entity>) (entity =>
      {
        if (!this.IsAttached(entity))
          throw new InvalidOperationException(string.Format((IFormatProvider) CultureInfo.InvariantCulture, "The context is not currently tracking the '{0}' entity.", (object) entity.LogicalName));
      }), (Action<Entity, Relationship, Entity>) ((source, relationship, target) => {})).ToList<Entity>();
    }

    private void UpdateEntityGraph(Entity entity)
    {
      this.TraverseEntityGraph(entity, new Action<EntityDescriptor>(this.InternalUpdate), (Action<LinkDescriptor>) (link => {})).ToList<Entity>();
    }

    private void InternalUpdate(EntityDescriptor existingEntity)
    {
      if (existingEntity.State != EntityStates.Unchanged)
        return;
      existingEntity.State = EntityStates.Modified;
      existingEntity.Entity.SetEntityStateInternal(new EntityState?(EntityState.Changed));
      this._roots.Add(existingEntity.Entity);
    }

    /// <summary>Executes a message in the form of a request, and returns a response.</summary>
    /// <returns>Type:  <see cref="T:Microsoft.Xrm.Sdk.OrganizationResponse"></see>. The response returned from processing the organization request.</returns>
    /// <param name="request">Type: <see cref="T:Microsoft.Xrm.Sdk.OrganizationResponse"></see>. The request to be sent.</param>
    public OrganizationResponse Execute(OrganizationRequest request)
    {
      if (request == null)
        throw new ArgumentNullException(nameof (request));
      this.OnExecuting(request);
      OrganizationResponse response;
      try
      {
        response = this._service.Execute(request);
      }
      catch (Exception ex)
      {
        this.OnExecute(request, ex);
        throw;
      }
      this.OnExecute(request, response);
      return response;
    }

    /// <summary>Clears all tracking of entities by the <see cref="T:Microsoft.Xrm.Sdk.Client.OrganizationServiceContext"></see>.</summary>
    public void ClearChanges()
    {
      foreach (LinkDescriptor existingLink in this._bindings.Values.ToList<LinkDescriptor>())
        this.DetachLinkTracking(existingLink);
      foreach (EntityDescriptor existingEntity in this._descriptors.Values.ToList<EntityDescriptor>())
        this.DetachEntityTracking(existingEntity);
      this._bindings.Clear();
      this._descriptors.Clear();
      this._identityToDescriptor.Clear();
      this._roots.Clear();
    }

    /// <summary>Saves the changes that the <see cref="T:Microsoft.Xrm.Sdk.Client.OrganizationServiceContext"></see> is tracking to pn_microsoftcrm.</summary>
    /// <returns>Type:  <see cref="T:Microsoft.Xrm.Sdk.SaveChangesResultCollection"></see>A <see cref="T:Microsoft.Xrm.Sdk.SaveChangesResultCollection"></see> that contains status, headers, and errors that result from the call to <see cref="M:Microsoft.Xrm.Sdk.Client.OrganizationServiceContext.SaveChanges"></see>.</returns>
    [SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists", Justification = "Choosing performance over flexibility. Also changing result collection does not need to be tracked.")]
    public SaveChangesResultCollection SaveChanges()
    {
      return this.SaveChanges(this.SaveChangesDefaultOptions);
    }

    /// <summary>Saves the changes that the <see cref="T:Microsoft.Xrm.Sdk.Client.OrganizationServiceContext"></see> is tracking to pn_microsoftcrm.</summary>
    /// <returns>Type:  <see cref="T:Microsoft.Xrm.Sdk.SaveChangesResultCollection"></see>A <see cref="T:Microsoft.Xrm.Sdk.SaveChangesResultCollection"></see> that contains status, headers, and errors that result from the call to <see cref="M:Microsoft.Xrm.Sdk.Client.OrganizationServiceContext.SaveChanges"></see>.</returns>
    /// <param name="options">Type:  <see cref="T:Microsoft.Xrm.Sdk.Client.SaveChangesOptions"></see>. Indicates how changes are saved.</param>
    [SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists", Justification = "Choosing performance over flexibility. Also changing result collection does not need to be tracked.")]
    public SaveChangesResultCollection SaveChanges(
      SaveChangesOptions options)
    {
      this.OnSavingChanges(options);
      SaveChangesResultCollection results = new SaveChangesResultCollection(options);
      foreach (Tuple<DisassociateRequest, IEnumerable<LinkDescriptor>> tuple in this.GetDisassociateRequests().ToList<Tuple<DisassociateRequest, IEnumerable<LinkDescriptor>>>())
      {
        SaveChangesResult result = this.SaveChange((OrganizationRequest) tuple.Item1, (IList<SaveChangesResult>) results);
        if (!OrganizationServiceContext.CanContinue(options, result))
        {
          this.OnSaveChanges(results);
          throw new SaveChangesException(result.Error, results);
        }
        foreach (LinkDescriptor existingLink in tuple.Item2)
          this.DetachLinkTracking(existingLink);
      }
      foreach (EntityDescriptor existingEntity in this.GetDeletedEntities().ToList<EntityDescriptor>())
      {
        EntityReference entityReference = existingEntity.Entity.ToEntityReference();
        SaveChangesResult result = this.SaveChange((OrganizationRequest) new DeleteRequest()
        {
          Target = entityReference
        }, (IList<SaveChangesResult>) results);
        if (!OrganizationServiceContext.CanContinue(options, result))
        {
          this.OnSaveChanges(results);
          throw new SaveChangesException(result.Error, results);
        }
        this.DetachEntityTracking(existingEntity);
        foreach (LinkDescriptor existingLink in this.GetTargetingLinks(existingEntity.Entity).ToList<LinkDescriptor>())
          this.DetachLinkTracking(existingLink);
      }
      foreach (Entity entity in OrganizationServiceContext.FilterRoots((ICollection<Entity>) new HashSet<Entity>((IEnumerable<Entity>) this._roots)).ToList<Entity>())
      {
        foreach (SaveChangesResult changeRequest in this.GetChangeRequests(results, entity))
        {
          if (!OrganizationServiceContext.CanContinue(options, changeRequest))
          {
            this.OnSaveChanges(results);
            throw new SaveChangesException(changeRequest.Error, results);
          }
        }
      }
      this.DetachAllOnSave();
      this.OnSaveChanges(results);
      return results;
    }

    private static IEnumerable<Entity> FilterRoots(ICollection<Entity> roots)
    {
      HashSet<Entity> entitySet = new HashSet<Entity>();
      while (roots.Any<Entity>())
        OrganizationServiceContext.FilterRoots((ICollection<Entity>) entitySet, roots);
      return (IEnumerable<Entity>) entitySet;
    }

    private static void FilterRoots(ICollection<Entity> filtered, ICollection<Entity> unfiltered)
    {
      Entity root = unfiltered.First<Entity>();
      OrganizationServiceContext.TraverseEntityGraph(root, (Action<Entity>) (entity =>
      {
        if (entity == root)
          return;
        filtered.Remove(entity);
        unfiltered.Remove(entity);
      }), (Action<Entity, Relationship, Entity>) ((s, r, t) => {})).ToList<Entity>();
      unfiltered.Remove(root);
      filtered.Add(root);
    }

    private bool CanDeleteRelationship(LinkDescriptor link)
    {
      EntityDescriptor entityDescriptor1;
      EntityDescriptor entityDescriptor2;
      return link.State == EntityStates.Deleted && this._descriptors.TryGetValue(link.Source, out entityDescriptor1) && (entityDescriptor1.State != EntityStates.Deleted && this._descriptors.TryGetValue(link.Target, out entityDescriptor2)) && entityDescriptor2.State != EntityStates.Deleted;
    }

    private static bool CanContinue(SaveChangesOptions options, SaveChangesResult result)
    {
      return (options & SaveChangesOptions.ContinueOnError) == SaveChangesOptions.ContinueOnError || result.Error == null;
    }

    [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Need to show proper error message instead of throwing exception.")]
    private SaveChangesResult SaveChange(
      OrganizationRequest request,
      IList<SaveChangesResult> results)
    {
      SaveChangesResult saveChangesResult;
      try
      {
        OrganizationResponse response = this.Execute(request);
        saveChangesResult = new SaveChangesResult(request, response);
      }
      catch (Exception ex)
      {
        saveChangesResult = new SaveChangesResult(request, ex);
      }
      results.Add(saveChangesResult);
      return saveChangesResult;
    }

    [SuppressMessage("Microsoft.Usage", "CA9888:DisposeObjectsCorrectly", Justification = "Value is returned from method and cannot be disposed.")]
    private IEnumerable<Tuple<DisassociateRequest, IEnumerable<LinkDescriptor>>> GetDisassociateRequests()
    {
      var entityRelationshipGroupings = this._bindings.Values.Where<LinkDescriptor>(new Func<LinkDescriptor, bool>(this.CanDeleteRelationship)).GroupBy(b => new
      {
        Source = b.Source,
        Relationship = b.Relationship
      });
      foreach (var source1 in entityRelationshipGroupings)
      {
        EntityReference source = source1.Key.Source.ToEntityReference();
        Relationship relationship = source1.Key.Relationship;
        List<LinkDescriptor> links = source1.ToList<LinkDescriptor>();
        EntityReferenceCollection relatedEntities = new EntityReferenceCollection();
        relatedEntities.AddRange(links.Select<LinkDescriptor, EntityReference>((Func<LinkDescriptor, EntityReference>) (grouping => grouping.Target.ToEntityReference())));
        yield return new Tuple<DisassociateRequest, IEnumerable<LinkDescriptor>>(new DisassociateRequest()
        {
          Target = source,
          Relationship = relationship,
          RelatedEntities = relatedEntities
        }, (IEnumerable<LinkDescriptor>) links);
      }
    }

    private IEnumerable<EntityDescriptor> GetDeletedEntities()
    {
      return this._descriptors.Values.Where<EntityDescriptor>((Func<EntityDescriptor, bool>) (d => d.State == EntityStates.Deleted));
    }

    [SuppressMessage("Microsoft.Usage", "CA9888:DisposeObjectsCorrectly", Justification = "Value is returned from method and cannot be disposed.")]
    private IEnumerable<SaveChangesResult> GetChangeRequests(
      SaveChangesResultCollection results,
      Entity entity)
    {
      List<Entity> path = new List<Entity>()
      {
        entity
      };
      List<LinkDescriptor> localCircularLinks = new List<LinkDescriptor>();
      EntityState? entityState = entity.EntityState;
      IEnumerable<SaveChangesResult> requests = (entityState.GetValueOrDefault() != EntityState.Unchanged ? 0 : (entityState.HasValue ? 1 : 0)) != 0 ? this.GetChangeRequestsFromUnchangedTree(results, entity, (IEnumerable<Entity>) path, (IList<LinkDescriptor>) localCircularLinks) : this.GetChangeRequestsFromChangedTree(results, entity, (IEnumerable<Entity>) path, (IList<LinkDescriptor>) localCircularLinks);
      foreach (SaveChangesResult saveChangesResult in requests)
        yield return saveChangesResult;
      if (localCircularLinks.Any<LinkDescriptor>())
      {
        IEnumerable<SaveChangesResult> associateResults = this.ToAssociateResults((IEnumerable<LinkDescriptor>) localCircularLinks, (IList<SaveChangesResult>) results);
        foreach (SaveChangesResult saveChangesResult in associateResults)
          yield return saveChangesResult;
      }
    }

    [SuppressMessage("Microsoft.Usage", "CA9888:DisposeObjectsCorrectly", Justification = "Value is returned from method and cannot be disposed.")]
    private IEnumerable<SaveChangesResult> GetChangeRequestsFromChangedTree(
      SaveChangesResultCollection results,
      Entity entity,
      IEnumerable<Entity> path,
      IList<LinkDescriptor> circularLinks)
    {
      List<Entity> localPath = new List<Entity>()
      {
        entity
      };
      List<LinkDescriptor> localCircularLinks = new List<LinkDescriptor>();
      IEnumerable<SaveChangesResult> requests = this.GetChangeRequestsFromSubtree(results, entity, (IEnumerable<Entity>) localPath, (IList<LinkDescriptor>) localCircularLinks, path, circularLinks);
      foreach (SaveChangesResult saveChangesResult in requests)
        yield return saveChangesResult;
      SaveChangesResult createOrUpdateResult = this.GetSaveChangesResult(results, entity);
      yield return createOrUpdateResult;
      this.DetachOnSave(entity);
      if (localCircularLinks.Any<LinkDescriptor>())
      {
        IEnumerable<SaveChangesResult> associateResults = this.ToAssociateResults((IEnumerable<LinkDescriptor>) localCircularLinks, (IList<SaveChangesResult>) results);
        foreach (SaveChangesResult saveChangesResult in associateResults)
          yield return saveChangesResult;
      }
    }

    [SuppressMessage("Microsoft.Usage", "CA9888:DisposeObjectsCorrectly", Justification = "Value is returned from method and cannot be disposed.")]
    private IEnumerable<SaveChangesResult> GetChangeRequestsFromUnchangedTree(
      SaveChangesResultCollection results,
      Entity entity,
      IEnumerable<Entity> path,
      IList<LinkDescriptor> circularLinks)
    {
      List<LinkDescriptor> relatedLinks = new List<LinkDescriptor>();
      var relatedEntityGroups = entity.RelatedEntities.SelectMany((Func<KeyValuePair<Relationship, EntityCollection>, IEnumerable<Entity>>) (relationship => (IEnumerable<Entity>) relationship.Value.Entities), (relationship, target) => new
      {
        relationship = relationship,
        target = target
      }).GroupBy(_param0 => _param0.target, _param0 => new
      {
        Relationship = _param0.relationship,
        Target = _param0.target
      }).Select(grp => new
      {
        Target = grp.Key,
        Relationships = grp.Select(g => g.Relationship).ToList<KeyValuePair<Relationship, EntityCollection>>()
      }).ToList();
      foreach (var data in relatedEntityGroups)
      {
        Entity target = data.Target;
        List<LinkDescriptor> addedLinks = new List<LinkDescriptor>();
        foreach (KeyValuePair<Relationship, EntityCollection> relationship in data.Relationships)
        {
          LinkDescriptor linkDescriptor;
          if (this._bindings.TryGetValue(new LinkDescriptor(entity, relationship.Key, target), out linkDescriptor) && linkDescriptor.State == EntityStates.Added)
            addedLinks.Add(linkDescriptor);
        }
        bool visited = path.Contains<Entity>(target);
        if (!visited)
        {
          IEnumerable<Entity> targetPath = path.Concat<Entity>((IEnumerable<Entity>) new Entity[1]
          {
            target
          });
          EntityState? entityState = target.EntityState;
          IEnumerable<SaveChangesResult> requests = (entityState.GetValueOrDefault() != EntityState.Unchanged ? 0 : (entityState.HasValue ? 1 : 0)) != 0 ? this.GetChangeRequestsFromUnchangedTree(results, target, targetPath, circularLinks) : this.GetChangeRequestsFromChangedTree(results, target, targetPath, circularLinks);
          foreach (SaveChangesResult saveChangesResult in requests)
            yield return saveChangesResult;
          if (addedLinks.Any<LinkDescriptor>())
            relatedLinks.AddRange((IEnumerable<LinkDescriptor>) addedLinks);
        }
        else if (addedLinks.Any<LinkDescriptor>())
        {
          foreach (LinkDescriptor linkDescriptor in addedLinks)
          {
            circularLinks.Add(linkDescriptor);
            OrganizationServiceContext.SetNewId(linkDescriptor.Source);
            OrganizationServiceContext.SetNewId(linkDescriptor.Target);
          }
        }
      }
      if (relatedLinks.Any<LinkDescriptor>())
      {
        IEnumerable<SaveChangesResult> associateResults = this.ToAssociateResults((IEnumerable<LinkDescriptor>) relatedLinks, (IList<SaveChangesResult>) results);
        foreach (SaveChangesResult saveChangesResult in associateResults)
          yield return saveChangesResult;
        using (List<LinkDescriptor>.Enumerator enumerator = relatedLinks.GetEnumerator())
        {
          while (enumerator.MoveNext())
          {
            LinkDescriptor link = enumerator.Current;
            this.DetachLinkTrackingAndRemoveEntity(link);
            EntityDescriptor existingEntity;
            if (!this._bindings.Values.Any<LinkDescriptor>((Func<LinkDescriptor, bool>) (b => b.Target == link.Target)) && this._descriptors.TryGetValue(link.Target, out existingEntity))
              this.DetachEntityTracking(existingEntity);
          }
        }
      }
      this._roots.Remove(entity);
    }

    [SuppressMessage("Microsoft.Usage", "CA9888:DisposeObjectsCorrectly", Justification = "Value is returned from method and cannot be disposed.")]
    private IEnumerable<SaveChangesResult> GetChangeRequestsFromSubtree(
      SaveChangesResultCollection results,
      Entity entity,
      IEnumerable<Entity> localPath,
      IList<LinkDescriptor> localCircularLinks,
      IEnumerable<Entity> path,
      IList<LinkDescriptor> circularLinks)
    {
      var relatedEntityGroups = entity.RelatedEntities.SelectMany((Func<KeyValuePair<Relationship, EntityCollection>, IEnumerable<Entity>>) (relationship => (IEnumerable<Entity>) relationship.Value.Entities), (relationship, target) => new
      {
        relationship = relationship,
        target = target
      }).GroupBy(_param0 => _param0.target, _param0 => new
      {
        Relationship = _param0.relationship,
        Target = _param0.target
      }).Select(grp => new
      {
        Target = grp.Key,
        Relationships = grp.Select(g => g.Relationship).ToList<KeyValuePair<Relationship, EntityCollection>>()
      }).ToList();
      foreach (var data in relatedEntityGroups)
      {
        Entity target = data.Target;
        List<LinkDescriptor> addedLinks = new List<LinkDescriptor>();
        foreach (KeyValuePair<Relationship, EntityCollection> relationship in data.Relationships)
        {
          LinkDescriptor existingLink;
          if (this._bindings.TryGetValue(new LinkDescriptor(entity, relationship.Key, target), out existingLink))
          {
            if (existingLink.State == EntityStates.Added)
              addedLinks.Add(existingLink);
            else
              this.DetachLinkTrackingAndRemoveEntity(existingLink);
          }
        }
        bool localVisited = localPath.Contains<Entity>(target);
        bool visited = path.Contains<Entity>(target);
        if (!localVisited && !visited)
        {
          IEnumerable<Entity> localTargetPath = localPath.Concat<Entity>((IEnumerable<Entity>) new Entity[1]
          {
            target
          });
          IEnumerable<Entity> targetPath = path.Concat<Entity>((IEnumerable<Entity>) new Entity[1]
          {
            target
          });
          IEnumerable<SaveChangesResult> saveChangesResults;
          if (!addedLinks.Any<LinkDescriptor>())
          {
            EntityState? entityState = target.EntityState;
            saveChangesResults = (entityState.GetValueOrDefault() != EntityState.Unchanged ? 0 : (entityState.HasValue ? 1 : 0)) != 0 ? this.GetChangeRequestsFromUnchangedTree(results, target, targetPath, circularLinks) : this.GetChangeRequestsFromChangedTree(results, target, targetPath, circularLinks);
          }
          else
            saveChangesResults = this.GetChangeRequestsFromSubtree(results, target, localTargetPath, localCircularLinks, targetPath, circularLinks);
          IEnumerable<SaveChangesResult> requests = saveChangesResults;
          foreach (SaveChangesResult saveChangesResult in requests)
            yield return saveChangesResult;
        }
        else if (addedLinks.Any<LinkDescriptor>())
        {
          foreach (LinkDescriptor existingLink in addedLinks)
          {
            if (localVisited)
              localCircularLinks.Add(existingLink);
            else
              circularLinks.Add(existingLink);
            this.DetachLinkTrackingAndRemoveEntity(existingLink);
            OrganizationServiceContext.SetNewId(existingLink.Source);
            OrganizationServiceContext.SetNewId(existingLink.Target);
          }
        }
      }
    }

    private static OrganizationRequest GetRequest(Entity entity)
    {
      EntityState? entityState1 = entity.EntityState;
      if ((entityState1.GetValueOrDefault() != EntityState.Created ? 0 : (entityState1.HasValue ? 1 : 0)) != 0)
        return (OrganizationRequest) new CreateRequest()
        {
          Target = entity
        };
      EntityState? entityState2 = entity.EntityState;
      if ((entityState2.GetValueOrDefault() != EntityState.Changed ? 0 : (entityState2.HasValue ? 1 : 0)) != 0)
        return (OrganizationRequest) new UpdateRequest()
        {
          Target = entity
        };
      throw new InvalidOperationException(string.Format((IFormatProvider) CultureInfo.InvariantCulture, "The '{0}' entity must be in the created or changed state.", (object) entity.LogicalName));
    }

    private SaveChangesResult GetSaveChangesResult(
      SaveChangesResultCollection results,
      Entity entity)
    {
      OrganizationRequest request = OrganizationServiceContext.GetRequest(entity);
      if (request is CreateRequest createRequest)
        OrganizationServiceContext.TraverseEntityGraph(createRequest.Target, new Action<Entity>(OrganizationServiceContext.SetNewId), (Action<Entity, Relationship, Entity>) ((source, relationship, target) => {}), (IEnumerable<Entity>) new Entity[1]
        {
          createRequest.Target
        }).ToList<Entity>();
      SaveChangesResult saveChangesResult = this.SaveChange(request, (IList<SaveChangesResult>) results);
      if (saveChangesResult.Response is CreateResponse response && entity.Id == Guid.Empty)
        entity.Id = response.id;
      return saveChangesResult;
    }

    private void DetachOnSave(Entity entity)
    {
      foreach (Entity target in this.DetachEntityGraph(entity))
      {
        bool flag = true;
        foreach (LinkDescriptor existingLink in this.GetTargetingLinks(target).ToList<LinkDescriptor>())
        {
          if (existingLink.State == EntityStates.Added)
          {
            existingLink.Target.RelatedEntities.ClearInternal();
            if (!this.IsAttached(existingLink.Target))
            {
              this.AttachEntityGraph(existingLink.Target, EntityStates.Unchanged);
              existingLink.Target.SetEntityStateInternal(new EntityState?(EntityState.Unchanged));
              flag = false;
            }
          }
          else
            this.DetachLinkTrackingAndRemoveEntity(existingLink);
        }
        if (flag)
          target.SetEntityStateInternal(new EntityState?());
      }
    }

    private void DetachAllOnSave()
    {
      foreach (EntityDescriptor existingEntity in this._descriptors.Values.ToList<EntityDescriptor>())
        this.DetachEntityTracking(existingEntity);
      foreach (LinkDescriptor existingLink in this._bindings.Values.ToList<LinkDescriptor>())
        this.DetachLinkTracking(existingLink);
      this._roots.Clear();
    }

    private static EntityReferenceCollection ToEntityReferenceCollection(
      IEnumerable<LinkDescriptor> links)
    {
      EntityReferenceCollection referenceCollection = new EntityReferenceCollection();
      referenceCollection.AddRange(links.Select<LinkDescriptor, EntityReference>((Func<LinkDescriptor, EntityReference>) (b => b.Target.ToEntityReference())));
      return referenceCollection;
    }

    private static IEnumerable<AssociateRequest> ToAssociateRequests(
      IEnumerable<LinkDescriptor> links)
    {
      return links.GroupBy(link => new
      {
        Source = link.Source,
        Relationship = link.Relationship
      }).Select(grp => new AssociateRequest()
      {
        Target = grp.Key.Source.ToEntityReference(),
        Relationship = grp.Key.Relationship,
        RelatedEntities = OrganizationServiceContext.ToEntityReferenceCollection((IEnumerable<LinkDescriptor>) grp)
      });
    }

    private IEnumerable<SaveChangesResult> ToAssociateResults(
      IEnumerable<LinkDescriptor> links,
      IList<SaveChangesResult> results)
    {
      return OrganizationServiceContext.ToAssociateRequests(links).Select<AssociateRequest, SaveChangesResult>((Func<AssociateRequest, SaveChangesResult>) (associate => this.SaveChange((OrganizationRequest) associate, results)));
    }

    private static void SetNewId(Entity entity)
    {
      EntityState? entityState = entity.EntityState;
      if ((entityState.GetValueOrDefault() != EntityState.Created ? 0 : (entityState.HasValue ? 1 : 0)) == 0 || !(entity.Id == Guid.Empty))
        return;
      Guid sequentialGuid = OrganizationServiceContext.CreateSequentialGuid();
      entity.Id = sequentialGuid;
    }

    private static SequentialGuid SequentialGuid = new SequentialGuid();
    private static Guid CreateSequentialGuid()
    {
        SequentialGuid++;
        var value = SequentialGuid.CurrentGuid;
        return value;
    }

    /*[SecuritySafeCritical]
    private static Guid CreateSequentialGuid()
    {
      Guid empty = Guid.Empty;
      long sequential;
      try
      {
        new PermissionSet(PermissionState.Unrestricted).Assert();
        sequential = NativeMethods.UuidCreateSequential(ref empty);
      }
      finally
      {
        CodeAccessPermission.RevertAssert();
      }
      if (0L != sequential)
        return Guid.NewGuid();
      byte[] byteArray = empty.ToByteArray();
      byte num1 = byteArray[2];
      byteArray[2] = byteArray[1];
      byteArray[1] = num1;
      byte num2 = byteArray[3];
      byteArray[3] = byteArray[0];
      byteArray[0] = num2;
      byte num3 = byteArray[4];
      byteArray[4] = byteArray[5];
      byteArray[5] = num3;
      byte num4 = byteArray[6];
      byteArray[6] = byteArray[7];
      byteArray[7] = num4;
      return new Guid(byteArray);
    }*/

    internal Entity MergeEntity(Entity entity)
    {
      if (this.MergeOption == MergeOption.NoTracking || entity == null || entity.Id == Guid.Empty)
        return entity;
      EntityDescriptor entityDescriptor = new EntityDescriptor(EntityStates.Unchanged, entity.ToEntityReference(), entity);
      EntityDescriptor existingEntity;
      this._identityToDescriptor.TryGetValue(entityDescriptor.Identity, out existingEntity);
      if (existingEntity != null)
      {
        if (this.MergeOption == MergeOption.AppendOnly || this.MergeOption == MergeOption.PreserveChanges && existingEntity.State != EntityStates.Unchanged)
          return existingEntity.Entity;
        this.DetachEntityTracking(existingEntity);
      }
      this._descriptors[entityDescriptor.Entity] = entityDescriptor;
      this._identityToDescriptor[entityDescriptor.Identity] = entityDescriptor;
      entityDescriptor.Entity.SetEntityStateInternal(new EntityState?(EntityState.Unchanged));
      if (this._trackEntityChanges)
        entityDescriptor.Entity.IsReadOnly = true;
      this.OnBeginEntityTracking(entityDescriptor.Entity);
      return entityDescriptor.Entity;
    }

    private void MergeRelationship(
      Entity source,
      Relationship relationship,
      Entity target,
      bool isAttached)
    {
      if (source == null)
        throw new ArgumentNullException(nameof (source));
      if (target == null)
        throw new ArgumentNullException(nameof (target));
      if (relationship == null)
        throw new ArgumentNullException(nameof (relationship));
      if (isAttached)
      {
        LinkDescriptor key = new LinkDescriptor(source, relationship, target);
        if (this.MergeOption == MergeOption.NoTracking)
          return;
        LinkDescriptor linkDescriptor;
        this._bindings.TryGetValue(key, out linkDescriptor);
        if (linkDescriptor != null && (this.MergeOption == MergeOption.AppendOnly || this.MergeOption == MergeOption.PreserveChanges && linkDescriptor.State != EntityStates.Unchanged))
        {
          OrganizationServiceContext.AddRelationshipIfNotContains(source, relationship, linkDescriptor.Target);
          return;
        }
        this._bindings[key] = key;
        this.OnBeginLinkTracking(key.Source, key.Relationship, key.Target);
      }
      if (!source.RelatedEntities.Contains(relationship))
      {
        source.RelatedEntities.SetItemInternal(relationship, new EntityCollection((IList<Entity>) new Entity[1]
        {
          target
        })
        {
          EntityName = target.LogicalName
        });
      }
      else
      {
        EntityReference targetReference = target.ToEntityReference();
        DataCollection<Entity> entities = source.RelatedEntities[relationship].Entities;
        Entity entity = entities.SingleOrDefault<Entity>((Func<Entity, bool>) (e => object.Equals((object) e.ToEntityReference(), (object) targetReference)));
        if (entity != null)
          entities.Remove(entity);
        entities.Add(target);
      }
    }

    private static void AddRelationshipIfNotContains(
      Entity source,
      Relationship relationship,
      Entity target)
    {
      if (!source.RelatedEntities.Contains(relationship))
      {
        source.RelatedEntities.SetItemInternal(relationship, new EntityCollection((IList<Entity>) new Entity[1]
        {
          target
        })
        {
          EntityName = target.LogicalName
        });
      }
      else
      {
        if (source.RelatedEntities[relationship].Entities.Contains(target))
          return;
        source.RelatedEntities[relationship].Entities.Add(target);
      }
    }

    private static bool RemoveRelationshipIfContains(LinkDescriptor existingLink)
    {
      return OrganizationServiceContext.RemoveRelationshipIfContains(existingLink.Source, existingLink.Relationship, existingLink.Target);
    }

    private static bool RemoveRelationshipIfContains(
      Entity source,
      Relationship relationship,
      Entity target)
    {
      if (!source.RelatedEntities.Contains(relationship))
        return false;
      EntityCollection relatedEntity = source.RelatedEntities[relationship];
      bool flag = relatedEntity.Entities.Remove(target);
      if (relatedEntity.Entities.Count == 0)
        source.RelatedEntities.RemoveInternal(relationship);
      return flag;
    }

    private static void CheckEntitySubclass(Type entityType)
    {
      if (!entityType.IsSubclassOf(typeof (Entity)))
        throw new ArgumentException(string.Format((IFormatProvider) CultureInfo.InvariantCulture, "The specified type '{0}' must be a subclass of '{1}'.", (object) entityType, (object) typeof (Entity)));
      if (string.IsNullOrWhiteSpace(KnownProxyTypesProvider.GetInstance(true).GetNameForType(entityType)))
        throw new ArgumentException(string.Format((IFormatProvider) CultureInfo.InvariantCulture, "The specified type '{0}' is not a known entity type.", (object) entityType));
    }

    private EntityCollection GetRelatedEntities(
      Entity entity,
      Relationship relationship)
    {
      string relatedEntityName = this.GetRelatedEntityName(entity, relationship);
      RelationshipQueryCollection relationshipQueryCollection1 = new RelationshipQueryCollection();
      relationshipQueryCollection1.Add(relationship, (QueryBase) new QueryExpression(relatedEntityName)
      {
        ColumnSet = new ColumnSet(true)
      });
      RelationshipQueryCollection relationshipQueryCollection2 = relationshipQueryCollection1;
      EntityReference entityReference = new EntityReference(entity.LogicalName, entity.Id);
      RelatedEntityCollection relatedEntities = (this.Execute((OrganizationRequest) new RetrieveRequest()
      {
        Target = entityReference,
        ColumnSet = new ColumnSet(),
        RelatedEntitiesQuery = relationshipQueryCollection2
      }) as RetrieveResponse).Entity.RelatedEntities;
      return !relatedEntities.Contains(relationship) ? (EntityCollection) null : relatedEntities[relationship];
    }

    private string GetRelatedEntityName(Entity entity, Relationship relationship)
    {
      if (relationship.PrimaryEntityRole.HasValue)
        return entity.LogicalName;
      RetrieveRelationshipResponse relationshipResponse = this.Execute((OrganizationRequest) new RetrieveRelationshipRequest()
      {
        Name = relationship.SchemaName
      }) as RetrieveRelationshipResponse;
      if (relationshipResponse.RelationshipMetadata is OneToManyRelationshipMetadata relationshipMetadata1)
        return !(relationshipMetadata1.ReferencingEntity == entity.LogicalName) ? relationshipMetadata1.ReferencingEntity : relationshipMetadata1.ReferencedEntity;
      if (relationshipResponse.RelationshipMetadata is ManyToManyRelationshipMetadata relationshipMetadata2)
        return !(relationshipMetadata2.Entity1LogicalName == entity.LogicalName) ? relationshipMetadata2.Entity1LogicalName : relationshipMetadata2.Entity2LogicalName;
      throw new InvalidOperationException(string.Format((IFormatProvider) CultureInfo.InvariantCulture, "Unable to load the '{0}' relationship.", (object) relationship.SchemaName));
    }

    private static IEnumerable<Entity> TraverseEntityGraph(
      Entity entity,
      Action<Entity> onEntity,
      Action<Entity, Relationship, Entity> onLink)
    {
      return OrganizationServiceContext.TraverseEntityGraph(entity, onEntity, onLink, (IEnumerable<Entity>) new Entity[0]);
    }

    [SuppressMessage("Microsoft.Usage", "CA9888:DisposeObjectsCorrectly", Justification = "Value is returned from method and cannot be disposed.", Target = "local$0")]
    private static IEnumerable<Entity> TraverseEntityGraph(
      Entity entity,
      Action<Entity> onEntity,
      Action<Entity, Relationship, Entity> onLink,
      IEnumerable<Entity> path)
    {
      onEntity(entity);
      yield return entity;
      foreach (Tuple<Entity, Relationship, Entity> traverseRelatedEntity in OrganizationServiceContext.TraverseRelatedEntities(entity))
      {
        Entity source = traverseRelatedEntity.Item1;
        Relationship relationship = traverseRelatedEntity.Item2;
        Entity target = traverseRelatedEntity.Item3;
        onLink(source, relationship, target);
        bool visited = path.Contains<Entity>(target);
        if (!visited)
        {
          IEnumerable<Entity> childPath = path.Concat<Entity>((IEnumerable<Entity>) new Entity[1]
          {
            target
          });
          foreach (Entity entity1 in OrganizationServiceContext.TraverseEntityGraph(target, onEntity, onLink, childPath))
            yield return entity1;
        }
      }
    }

    private static IEnumerable<Tuple<Entity, Relationship, Entity>> TraverseRelatedEntities(
      Entity entity)
    {
      return entity.RelatedEntities.ToList<KeyValuePair<Relationship, EntityCollection>>().Select(relatedEntity => new
      {
        relatedEntity = relatedEntity,
        relationship = relatedEntity.Key
      }).Select(_param0 => new
      {
        __TransparentIdentifierab = _param0,
        entities = _param0.relatedEntity.Value.Entities.ToList<Entity>()
      }).SelectMany(_param0 => (IEnumerable<Entity>) _param0.entities, (_param1, target) => new Tuple<Entity, Relationship, Entity>(entity, _param1.__TransparentIdentifierab.relationship, target));
    }

    [SuppressMessage("Microsoft.Usage", "CA9888:DisposeObjectsCorrectly", Justification = "Value is returned from method and cannot be disposed.")]
    private IEnumerable<Entity> TraverseEntityGraph(
      Entity graph,
      Action<EntityDescriptor> onEntity,
      Action<LinkDescriptor> onLink)
    {
      return OrganizationServiceContext.TraverseEntityGraph(graph, (Action<Entity>) (entity =>
      {
        EntityDescriptor entityDescriptor;
        if (!this._descriptors.TryGetValue(entity, out entityDescriptor))
          return;
        onEntity(entityDescriptor);
      }), (Action<Entity, Relationship, Entity>) ((source, relationship, target) =>
      {
        LinkDescriptor linkDescriptor;
        if (!this._bindings.TryGetValue(new LinkDescriptor(source, relationship, target), out linkDescriptor))
          return;
        onLink(linkDescriptor);
      }));
    }

    private IEnumerable<LinkDescriptor> GetTargetingLinks(Entity target)
    {
      return this._bindings.Values.Where<LinkDescriptor>((Func<LinkDescriptor, bool>) (b => b.Target == target));
    }

    private EntityDescriptor EnsureTracked(Entity entity, string parameterName)
    {
      if (entity == null)
        throw new ArgumentNullException(parameterName);
      EntityDescriptor entityDescriptor;
      if (!this._descriptors.TryGetValue(entity, out entityDescriptor))
        throw new InvalidOperationException(string.Format((IFormatProvider) CultureInfo.InvariantCulture, "The context is not currently tracking the '{0}' entity.", (object) entity.LogicalName));
      return entityDescriptor;
    }

    private bool EnsureRelatable(
      Entity source,
      Relationship relationship,
      Entity target,
      EntityStates state)
    {
      if (relationship == null)
        throw new ArgumentNullException(nameof (relationship));
      if (target == null)
        throw new ArgumentNullException(nameof (target));
      EntityDescriptor entityDescriptor1 = this.EnsureTracked(source, nameof (source));
      if (object.ReferenceEquals((object) source, (object) target))
        throw new InvalidOperationException("The entity cannot link to itself.");
      if (source.Id != Guid.Empty && target.Id != Guid.Empty && (source.Id == target.Id && string.Equals(source.LogicalName, target.LogicalName, StringComparison.Ordinal)))
        throw new InvalidOperationException("The entity cannot link to itself.");
      EntityDescriptor entityDescriptor2 = (EntityDescriptor) null;
      if (target != null || state != EntityStates.Modified && state != EntityStates.Unchanged)
        entityDescriptor2 = this.EnsureTracked(target, nameof (target));
      if ((state == EntityStates.Added || state == EntityStates.Unchanged) && (entityDescriptor1.State == EntityStates.Deleted || entityDescriptor2 != null && entityDescriptor2.State == EntityStates.Deleted))
        throw new InvalidOperationException(string.Format((IFormatProvider) CultureInfo.InvariantCulture, "One or both of the ends of the '{0}' relationship is in the deleted state.", (object) relationship.SchemaName));
      if (state != EntityStates.Deleted && state != EntityStates.Unchanged || entityDescriptor1.State != EntityStates.Added && (entityDescriptor2 == null || entityDescriptor2.State != EntityStates.Added))
        return false;
      if (state != EntityStates.Deleted)
        throw new InvalidOperationException(string.Format((IFormatProvider) CultureInfo.InvariantCulture, "One or both of the ends of the '{0}' relationship is in the added state.", (object) relationship.SchemaName));
      return true;
    }

    /// <summary>Disposes of the service context.</summary>
    public void Dispose()
    {
      this.Dispose(true);
      GC.SuppressFinalize((object) this);
    }

    /// <summary>Disposes of the service context.</summary>
    /// <param name="disposing">Type: Returns_Boolean.</param>
    protected virtual void Dispose(bool disposing)
    {
      if (!disposing)
        return;
      this.ClearChanges();
    }

    /// <summary>Virtual (Overridable) method called before <see cref="M:Microsoft.Xrm.Sdk.IOrganizationService.Execute(Microsoft.Xrm.Sdk.OrganizationRequest)"></see> is called.</summary>
    /// <param name="request">Type: <see cref="T:Microsoft.Xrm.Sdk.OrganizationRequest"></see>. The request being processed.</param>
    protected virtual void OnExecuting(OrganizationRequest request)
    {
    }

    /// <summary>Virtual (Overridable) method called after <see cref="M:Microsoft.Xrm.Sdk.IOrganizationService.Execute(Microsoft.Xrm.Sdk.OrganizationRequest)"></see> is called and before a response is returned.</summary>
    /// <param name="response">Type: <see cref="T:Microsoft.Xrm.Sdk.OrganizationResponse"></see>. The response that is to be returned from processing the request.</param>
    /// <param name="request">Type: <see cref="T:Microsoft.Xrm.Sdk.OrganizationRequest"></see>. The request being processed.</param>
    protected virtual void OnExecute(OrganizationRequest request, OrganizationResponse response)
    {
    }

    /// <summary>Virtual (Overridable) method called after <see cref="M:Microsoft.Xrm.Sdk.IOrganizationService.Execute(Microsoft.Xrm.Sdk.OrganizationRequest)"></see> is called and before an exception is re-thrown.</summary>
    /// <param name="exception">Type: Returns_Exception. The exception thrown from processing the request.</param>
    /// <param name="request">Type: <see cref="T:Microsoft.Xrm.Sdk.OrganizationRequest"></see>. The request being processed.</param>
    protected virtual void OnExecute(OrganizationRequest request, Exception exception)
    {
    }

    /// <summary>Virtual (Overridable) method called before an attempt to save changes is performed.</summary>
    /// <param name="options">Type: <see cref="T:Microsoft.Xrm.Sdk.Client.SaveChangesOptions"></see>. Save changes options.</param>
    protected virtual void OnSavingChanges(SaveChangesOptions options)
    {
    }

    /// <summary>Virtual (Overridable) method called after an attempt to save data changes.</summary>
    /// <param name="results">Type: <see cref="T:Microsoft.Xrm.Sdk.SaveChangesResultCollection"></see>. The results of the save changes operation.</param>
    protected virtual void OnSaveChanges(SaveChangesResultCollection results)
    {
    }

    /// <summary>Virtual (Overridable) method called when entity tracking begins.</summary>
    /// <param name="entity">Type: <see cref="T:Microsoft.Xrm.Sdk.Entity"></see>. The entity to be tracked by the <see cref="T:Microsoft.Xrm.Sdk.Client.OrganizationServiceContext"></see>.</param>
    protected virtual void OnBeginEntityTracking(Entity entity)
    {
    }

    /// <summary>Virtual (Overridable) method called after entity tracking ends.</summary>
    /// <param name="entity">Type: <see cref="T:Microsoft.Xrm.Sdk.Entity"></see>. The entity to be tracked by the <see cref="T:Microsoft.Xrm.Sdk.Client.OrganizationServiceContext"></see>.</param>
    protected virtual void OnEndEntityTracking(Entity entity)
    {
    }

    /// <summary>Virtual (Overridable) method called when link tracking begins.</summary>
    /// <param name="target">Type: <see cref="T:Microsoft.Xrm.Sdk.Entity"></see>. The target entity in the link that is bound to the source entity specified in this call.</param>
    /// <param name="relationship">Type: <see cref="T:Microsoft.Xrm.Sdk.Relationship"></see>. The name of the attribute or navigation property on the source object that represents the link between the source and target object.</param>
    /// <param name="source">Type: <see cref="T:Microsoft.Xrm.Sdk.Relationship"></see>. The navigation property or attribute on the source object that returns the related object.</param>
    protected virtual void OnBeginLinkTracking(
      Entity source,
      Relationship relationship,
      Entity target)
    {
    }

    /// <summary>Virtual (Overridable) method called after link tracking ends.</summary>
    /// <param name="entity">Type: <see cref="T:Microsoft.Xrm.Sdk.Relationship"></see>. The navigation property or attribute on the source object that returns the related object.</param>
    /// <param name="relationship">Type: <see cref="T:Microsoft.Xrm.Sdk.Relationship"></see>. The name of the attribute or navigation property on the source object that represents the link between the source and target object.</param>
    /// <param name="target">Type: <see cref="T:Microsoft.Xrm.Sdk.Entity"></see>. The target entity in the link that is bound to the source entity specified in this call.</param>
    protected virtual void OnEndLinkTracking(
      Entity entity,
      Relationship relationship,
      Entity target)
    {
    }

    private static class Strings
    {
      public const string PropertyDoesNotExist = "The property '{0}' does not exist on the entity '{1}'.";
      public const string NoSettableProperty = "The closed type '{0}' does not have a corresponding '{1}' settable property.";
      public const string RequiresCreatedOrChangedState = "The '{0}' entity must be in the created or changed state.";
      public const string RequiresUnchangedState = "The '{0}' entity must be in the default (null) or unchanged state.";
      public const string RequiresCreatedState = "The '{0}' entity must be in the default (null) or created state.";
      public const string AlreadyTrackingEntity = "The context is already tracking the '{0}' entity.";
      public const string AlreadyTrackingRelationship = "The context is already tracking the '{0}' relationship.";
      public const string EmptyId = "The '{0}' entity has an empty ID.";
      public const string AlreadyTrackingIdentity = "The context is already tracking a different '{0}' entity with the same identity.";
      public const string EntityAlreadyAttached = "The '{0}' entity is already attached to a context.";
      public const string NotSubclass = "The specified type '{0}' must be a subclass of '{1}'.";
      public const string NotKnownEntityType = "The specified type '{0}' is not a known entity type.";
      public const string NotTrackingEntity = "The context is not currently tracking the '{0}' entity.";
      public const string RelationshipEndIsDeleted = "One or both of the ends of the '{0}' relationship is in the deleted state.";
      public const string RelationshipEndIsAdded = "One or both of the ends of the '{0}' relationship is in the added state.";
      public const string CannotLoadAddedEntity = "The context can not load the related collection or reference for entities in the added state.";
      public const string CannotLoadAttachedEntity = "The context can not load the related collection or reference for tracked entities while the 'MergeOption' is set to 'NoTracking'. Change the 'MergeOption' value or detach the '{0}' entity.";
      public const string CannotLoadDetachedEntity = "The context can not load the related collection or reference for untracked entities while the 'MergeOption' is not set to 'NoTracking'. Change the 'MergeOption' to 'NoTracking' or attach the '{0}' entity.";
      public const string SourceEqualsTarget = "The entity cannot link to itself.";
    }
  }
}
