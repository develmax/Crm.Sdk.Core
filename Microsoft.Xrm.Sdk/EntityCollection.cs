using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
    /// <summary>Contains a collection of entity instances.</summary>
    [SuppressMessage("Microsoft.Naming", "CA1711:IdentifiersShouldNotHaveIncorrectSuffix", Justification = "Class wraps a collection")]
    [DataContract(Name = "EntityCollection", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
    public sealed class EntityCollection : IExtensibleDataObject
    {
        private string _entityName;
        private DataCollection<Entity> _entities;
        private bool _moreRecords;
        private string _pagingCookie;
        private string _minActiveRowVersion;
        private int _totalRecordCount;
        private bool _totalRecordCountLimitExceeded;
        private bool _isReadOnly;
        private ExtensionDataObject _extensionDataObject;

        /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Xrm.Sdk.EntityCollection"></see> class.</summary>
        public EntityCollection()
        {
        }

        /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Xrm.Sdk.EntityCollection"></see> class setting the list of entities.</summary>
        /// <param name="list">Type: Returns_IList&lt;<see cref="T:Microsoft.Xrm.Sdk.Entity"></see>&gt;. A list of entities.</param>
        public EntityCollection(IList<Entity> list)
        {
            this._entities = new DataCollection<Entity>(list);
        }

        /// <summary>Gets the collection of entities.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.DataCollection`1"></see>&lt;<see cref="T:Microsoft.Xrm.Sdk.Entity"></see>&gt;The collection of entities.</returns>
        [DataMember]
        public DataCollection<Entity> Entities
        {
            get
            {
                if (this._entities == null)
                    this._entities = new DataCollection<Entity>();
                return this._entities;
            }
      [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Called via reflection")] private set
            {
                this._entities = value;
            }
        }

        /// <summary>Gets or sets whether there are more records available.</summary>
        /// <returns>Type: Returns_Booleantrue if there are more records available; otherwise, false. This is used in conjunction with the <see cref="P:Microsoft.Xrm.Sdk.EntityCollection.PagingCookie"></see> when working with large record sets.</returns>
        [DataMember]
        public bool MoreRecords
        {
            get
            {
                return this._moreRecords;
            }
            set
            {
                this.CheckIsReadOnly();
                this._moreRecords = value;
            }
        }

        /// <summary>Gets or sets the current paging information.</summary>
        /// <returns>Type: Returns_String
        /// The current paging information. This is used in conjunction with <see cref="P:Microsoft.Xrm.Sdk.EntityCollection.MoreRecords"></see> when working with large record sets.</returns>
        [DataMember]
        public string PagingCookie
        {
            get
            {
                return this._pagingCookie;
            }
            set
            {
                this.CheckIsReadOnly();
                this._pagingCookie = value;
            }
        }

        /// <summary>Gets or sets the lowest active row version value.</summary>
        /// <returns>Type: Returns_StringThe lowest active row version value.</returns>
        [DataMember]
        public string MinActiveRowVersion
        {
            get
            {
                return this._minActiveRowVersion;
            }
            set
            {
                this.CheckIsReadOnly();
                this._minActiveRowVersion = value;
            }
        }

        /// <summary>Gets the total number of records in the collection.<see cref="P:Microsoft.Xrm.Sdk.Query.PagingInfo.ReturnTotalRecordCount"></see>  was true when the query was executed .</summary>
        /// <returns>Type: Returns_Int32The total number of records in the collection.</returns>
        [DataMember]
        public int TotalRecordCount
        {
            get
            {
                return this._totalRecordCount;
            }
            set
            {
                this.CheckIsReadOnly();
                this._totalRecordCount = value;
            }
        }

        /// <summary>Gets or sets whether the results of the query exceeds the total record count.</summary>
        /// <returns>Type: Returns_Booleantrue if the results of the query exceeds the total record count; otherwise, false..</returns>
        [DataMember]
        public bool TotalRecordCountLimitExceeded
        {
            get
            {
                return this._totalRecordCountLimitExceeded;
            }
            set
            {
                this.CheckIsReadOnly();
                this._totalRecordCountLimitExceeded = value;
            }
        }

        /// <summary>Gets or sets an item in the collection.</summary>
        /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Entity"></see>The item at the specified index.</returns>
        /// <param name="index">Type: Returns_Int32. The index of the item.</param>
        public Entity this[int index]
        {
            get
            {
                return this.Entities[index];
            }
            set
            {
                this.CheckIsReadOnly();
                this.Entities[index] = value;
            }
        }

        /// <summary>Gets or sets the logical name of the entity.</summary>
        /// <returns>Type: Returns_Stringthe logical name of the entity.</returns>
        [DataMember]
        public string EntityName
        {
            get
            {
                return this._entityName;
            }
            set
            {
                this.CheckIsReadOnly();
                this._entityName = value;
            }
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
            }
        }

        private void CheckIsReadOnly()
        {
            if (this.IsReadOnly)
                throw new InvalidOperationException("The collection is read-only.");
        }

        /// <summary>ExtensionData</summary>
        /// <returns>Type: Returns_ExtensionDataObjectThe extension data.</returns>
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