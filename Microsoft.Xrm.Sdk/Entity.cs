using Microsoft.Xrm.Sdk.Client;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
    /// <summary>Represents an instance of an entity (a record).</summary>
    [DataContract(Name = "Entity", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
    [SuppressMessage("Microsoft.Security", "CA9881:ClassesShouldBeSealed", Justification = "This class need to be instantiated by clients and be able to derive from it.")]
    public class Entity : IExtensibleDataObject
    {
        private string _logicalName;
        private Guid _id;
        private AttributeCollection _attributes;
        private Microsoft.Xrm.Sdk.EntityState? _entityState;
        private FormattedValueCollection _formattedValues;
        private RelatedEntityCollection _relatedEntities;
        internal bool _isReadOnly;
        private ExtensionDataObject _extensionDataObject;

        /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Xrm.Sdk.Entity"></see> class.</summary>
        public Entity()
          : this((string)null)
        {
        }

        /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Xrm.Sdk.Entity"></see> class setting the entity name.</summary>
        /// <param name="entityName">Type: Returns_String. The name of the entity.</param>
        public Entity(string entityName)
        {
            this._logicalName = entityName;
        }

        /// <summary>Gets or sets the logical name of the entity.</summary>
        /// <returns>Type: Returns_Stringthe logical name of the entity.</returns>
        [DataMember]
        public string LogicalName
        {
            get
            {
                return this._logicalName;
            }
            set
            {
                this.CheckIsReadOnly(nameof(LogicalName));
                this._logicalName = value;
            }
        }

        /// <summary>Gets or sets the ID of the record represented by this entity instance.</summary>
        /// <returns>Type: Returns_Guid
        /// The ID of the record (entity instance).</returns>
        [DataMember]
        public virtual Guid Id
        {
            get
            {
                return this._id;
            }
            set
            {
                if (this._id != Guid.Empty)
                    this.CheckIsReadOnly(nameof(Id));
                this._id = value;
            }
        }

        /// <summary>Gets or sets the collection of attributes for the entity.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.AttributeCollection"></see>
        /// The collection of attributes for the entity.</returns>
        [DataMember]
        public AttributeCollection Attributes
        {
            get
            {
                if (this._attributes == null)
                    this._attributes = new AttributeCollection();
                return this._attributes;
            }
            set
            {
                this._attributes = value;
            }
        }

        /// <summary>Gets or sets the state of the entity.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.EntityState"></see>.
        /// The state of the entity.</returns>
        [DataMember]
        public Microsoft.Xrm.Sdk.EntityState? EntityState
        {
            get
            {
                return this._entityState;
            }
            set
            {
                this.CheckIsReadOnly(nameof(EntityState));
                this._entityState = value;
            }
        }

        /// <summary>Gets of sets the collection of formatted values for the entity attributes.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.FormattedValueCollection"></see>
        /// The collection of formatted values for the entity attributes.</returns>
        [DataMember]
        public FormattedValueCollection FormattedValues
        {
            get
            {
                if (this._formattedValues == null)
                    this._formattedValues = new FormattedValueCollection();
                return this._formattedValues;
            }
            internal set
            {
                this._formattedValues = value;
            }
        }

        /// <summary>Gets or sets a collection of entity references (references to records).</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.RelatedEntityCollection"></see>
        /// a collection of entity references (references to records).</returns>
        [SuppressMessage("Microsoft.Naming", "CA1721:PropertyNamesShouldNotMatchGetMethods", Justification = "Member and conflicting method differences are obvious.")]
        [DataMember]
        public RelatedEntityCollection RelatedEntities
        {
            get
            {
                if (this._relatedEntities == null)
                {
                    this._relatedEntities = new RelatedEntityCollection();
                    this._relatedEntities.IsReadOnly = this.IsReadOnly;
                }
                return this._relatedEntities;
            }
            internal set
            {
                this.CheckIsReadOnly(nameof(RelatedEntities));
                this._relatedEntities = value;
            }
        }

        /// <summary>Provides an indexer for the attribute values.</summary>
        /// <returns>Type: Returns_ObjectThe attribute specified by the attributeName parameter.</returns>
        /// <param name="attributeName">Type: Returns_String. The logical name of the attribute.</param>
        public object this[string attributeName]
        {
            get
            {
                return this.Attributes[attributeName];
            }
            set
            {
                this.Attributes[attributeName] = value;
            }
        }

        /// <summary>Checks to see if there is a value present for the specified attribute.</summary>
        /// <returns>Type: Returns_Booleantrue if the <see cref="T:Microsoft.Xrm.Sdk.Entity"></see> contains an attribute with the specified name; otherwise, false.</returns>
        /// <param name="attributeName">Type: Returns_String. The logical name of the attribute.</param>
        public bool Contains(string attributeName)
        {
            return this.Attributes.Contains(attributeName);
        }

        /// <summary>Gets the entity as the specified type.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Entity"></see>The entity as the specified type.</returns>
        public T ToEntity<T>() where T : Entity
        {
            if (typeof(T) == typeof(Entity))
            {
                Entity target = new Entity();
                this.ShallowCopyTo(target);
                return target as T;
            }
            if (string.IsNullOrWhiteSpace(this._logicalName))
                throw new NotSupportedException("LogicalName must be set before calling ToEntity()");
            string str = (string)null;
            object[] customAttributes = typeof(T).GetCustomAttributes(typeof(EntityLogicalNameAttribute), true);
            if (customAttributes != null)
            {
                object[] objArray = customAttributes;
                int index = 0;
                if (index < objArray.Length)
                    str = ((EntityLogicalNameAttribute)objArray[index]).LogicalName;
            }
            if (string.IsNullOrWhiteSpace(str))
                throw new NotSupportedException("Cannot convert to type that is does not have EntityLogicalNameAttribute");
            if (this._logicalName != str)
                throw new NotSupportedException(string.Format((IFormatProvider)CultureInfo.InvariantCulture, "Cannot convert entity {0} to {1}", (object)this._logicalName, (object)str));
            T instance = (T)Activator.CreateInstance(typeof(T));
            this.ShallowCopyTo((Entity)instance);
            return instance;
        }

        /// <summary>Gets an entity reference for this entity instance.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.EntityReference"></see>The entity reference for the entity.</returns>
        public EntityReference ToEntityReference()
        {
            return new EntityReference(this.LogicalName, this.Id);
        }

        internal void ShallowCopyTo(Entity target)
        {
            if (target == null || target == this)
                return;
            target.Id = this.Id;
            target.SetLogicalNameInternal(this.LogicalName);
            target.SetEntityStateInternal(this.EntityState);
            target.SetRelatedEntitiesInternal(this.RelatedEntities);
            target.Attributes = this.Attributes;
            target.FormattedValues = this.FormattedValues;
            target.ExtensionData = this.ExtensionData;
        }

        /// <summary>Gets the value of the attribute.</summary>
        /// <returns>Type: Returns_Type
        /// The value of the attribute.</returns>
        /// <param name="attributeLogicalName">Type: Returns_String. The logical name of the attribute.</param>
        public virtual T GetAttributeValue<T>(string attributeLogicalName)
        {
            object attributeValue = this.GetAttributeValue(attributeLogicalName);
            return attributeValue == null ? default(T) : (T)attributeValue;
        }

        private object GetAttributeValue(string attributeLogicalName)
        {
            if (string.IsNullOrWhiteSpace(attributeLogicalName))
                throw new ArgumentNullException(nameof(attributeLogicalName));
            return !this.Contains(attributeLogicalName) ? (object)null : this[attributeLogicalName];
        }

        /// <summary>Sets the value of an attribute.</summary>
        /// <param name="value">Type: Returns_Object. The value to set.</param>
        /// <param name="attributeLogicalName">Type: Returns_String. The logical name of the attribute.</param>
        protected virtual void SetAttributeValue(string attributeLogicalName, object value)
        {
            if (string.IsNullOrWhiteSpace(attributeLogicalName))
                throw new ArgumentNullException(nameof(attributeLogicalName));
            this[attributeLogicalName] = value;
        }

        /// <summary>Gets the formatted value of the attribute.</summary>
        /// <returns>Type: Returns_String
        /// The formatted value of the attribute.</returns>
        /// <param name="attributeLogicalName">Type: Returns_String. The logical name of the attribute.</param>
        protected virtual string GetFormattedAttributeValue(string attributeLogicalName)
        {
            if (string.IsNullOrWhiteSpace(attributeLogicalName))
                throw new ArgumentNullException(nameof(attributeLogicalName));
            return !this.FormattedValues.Contains(attributeLogicalName) ? (string)null : this.FormattedValues[attributeLogicalName];
        }

        /// <summary>Gets the related entity instance for the specified relationship.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Entity"></see>The collection of related entity instances for the specified relationship.</returns>
        /// <param name="relationshipSchemaName">Type: Returns_String. The name of the relationship.</param>
        /// <param name="primaryEntityRole">Type: <see cref="T:Microsoft.Xrm.Sdk.EntityRole"></see>. The role of the primary entity in the relationship (referenced or referencing).</param>
        protected virtual TEntity GetRelatedEntity<TEntity>(
          string relationshipSchemaName,
          EntityRole? primaryEntityRole)
          where TEntity : Entity
        {
            if (string.IsNullOrWhiteSpace(relationshipSchemaName))
                throw new ArgumentNullException(nameof(relationshipSchemaName));
            Relationship key = new Relationship(relationshipSchemaName)
            {
                PrimaryEntityRole = primaryEntityRole
            };
            return !this.RelatedEntities.Contains(key) ? default(TEntity) : (TEntity)this.RelatedEntities[key].Entities.FirstOrDefault<Entity>();
        }

        /// <summary>Sets the related entity instance for the specified relationship.</summary>
        /// <param name="relationshipSchemaName">Type: Returns_String. The schema name of the relationship.</param>
        /// <param name="primaryEntityRole">Type: <see cref="T:Microsoft.Xrm.Sdk.EntityRole"></see>. The role of the primary entity in the relationship (referenced or referencing).</param>
        /// <param name="entity">Type: <see cref="T:Microsoft.Xrm.Sdk.Entity"></see>. The entity instance to set.</param>
        protected virtual void SetRelatedEntity<TEntity>(
          string relationshipSchemaName,
          EntityRole? primaryEntityRole,
          TEntity entity)
          where TEntity : Entity
        {
            if (string.IsNullOrWhiteSpace(relationshipSchemaName))
                throw new ArgumentNullException(nameof(relationshipSchemaName));
            if ((object)entity != null && string.IsNullOrWhiteSpace(entity.LogicalName))
                throw new ArgumentException("The entity is missing a value for the 'LogicalName' property.", nameof(entity));
            Relationship key = new Relationship(relationshipSchemaName)
            {
                PrimaryEntityRole = primaryEntityRole
            };
            EntityCollection entityCollection1;
            if ((object)entity == null)
                entityCollection1 = (EntityCollection)null;
            else
                entityCollection1 = new EntityCollection((IList<Entity>)new TEntity[1]
                                                                        {
                                                                            entity
                                                                        })
                {
                    EntityName = entity.LogicalName
                };
            EntityCollection entityCollection2 = entityCollection1;
            if (entityCollection2 != null)
                this.RelatedEntities[key] = entityCollection2;
            else
                this.RelatedEntities.Remove(key);
        }

        /// <summary>Gets the collection of related entity instances for the specified relationship.</summary>
        /// <returns>Type: Returns_IEnumerableThe collection of related entity instances for the specified relationship.</returns>
        /// <param name="relationshipSchemaName">Type: Returns_String. The schema name of the relationship.</param>
        /// <param name="primaryEntityRole">The role of the primary entity in the relationship (referenced or referencing).</param>
        protected virtual IEnumerable<TEntity> GetRelatedEntities<TEntity>(
          string relationshipSchemaName,
          EntityRole? primaryEntityRole)
          where TEntity : Entity
        {
            if (string.IsNullOrWhiteSpace(relationshipSchemaName))
                throw new ArgumentNullException(nameof(relationshipSchemaName));
            Relationship key = new Relationship(relationshipSchemaName)
            {
                PrimaryEntityRole = primaryEntityRole
            };
            return !this.RelatedEntities.Contains(key) ? (IEnumerable<TEntity>)null : this.RelatedEntities[key].Entities.Cast<TEntity>();
        }

        /// <summary>Sets the collection of related entity instances for the specified relationship.</summary>
        /// <param name="relationshipSchemaName">Type: Returns_String. The schema name of the relationship.</param>
        /// <param name="primaryEntityRole">Type: <see cref="T:Microsoft.Xrm.Sdk.EntityRole"></see>. The role of the primary entity in the relationship (referenced or referencing).</param>
        /// <param name="entities">Type: Returns_IEnumerable. The collection of entity instances to set.</param>
        protected virtual void SetRelatedEntities<TEntity>(
          string relationshipSchemaName,
          EntityRole? primaryEntityRole,
          IEnumerable<TEntity> entities)
          where TEntity : Entity
        {
            if (string.IsNullOrWhiteSpace(relationshipSchemaName))
                throw new ArgumentNullException(nameof(relationshipSchemaName));
            if (entities != null && entities.Any<TEntity>((Func<TEntity, bool>)(entity => string.IsNullOrWhiteSpace(entity.LogicalName))))
                throw new ArgumentException("An entity is missing a value for the 'LogicalName' property.", nameof(entities));
            Relationship key = new Relationship(relationshipSchemaName)
            {
                PrimaryEntityRole = primaryEntityRole
            };
            EntityCollection entityCollection1;
            if (entities == null)
                entityCollection1 = (EntityCollection)null;
            else
                entityCollection1 = new EntityCollection((IList<Entity>)new List<Entity>((IEnumerable<Entity>)entities))
                {
                    EntityName = entities.First<TEntity>().LogicalName
                };
            EntityCollection entityCollection2 = entityCollection1;
            if (entityCollection2 != null)
                this.RelatedEntities[key] = entityCollection2;
            else
                this.RelatedEntities.Remove(key);
        }

        internal bool IsReadOnly
        {
            get
            {
                return this._isReadOnly;
            }
            set
            {
                this._isReadOnly = value;
                this.RelatedEntities.IsReadOnly = value;
            }
        }

        internal void SetLogicalNameInternal(string logicalName)
        {
            this._logicalName = logicalName;
        }

        internal void SetEntityStateInternal(Microsoft.Xrm.Sdk.EntityState? entityState)
        {
            this._entityState = entityState;
        }

        internal void SetRelatedEntitiesInternal(RelatedEntityCollection relatedEntities)
        {
            this._relatedEntities = relatedEntities;
        }

        private void CheckIsReadOnly(string propertyName)
        {
            if (this.IsReadOnly)
                throw new InvalidOperationException(string.Format((IFormatProvider)CultureInfo.InvariantCulture, "The entity is read-only and the '{0}' property cannot be modified. Use the context to update the entity instead.", (object)propertyName));
        }

        /// <summary>ExtensionData</summary>
        /// <returns>Type: Returns_ExtensionDataObjectExtensionData</returns>
        public ExtensionDataObject ExtensionData
        {
            get
            {
                return this._extensionDataObject;
            }
            set
            {
                this._extensionDataObject = value;
            }
        }
    }
}