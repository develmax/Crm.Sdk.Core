using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
    /// <summary>internal</summary>
    [DataContract(Name = "QuickFindResult", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
    public sealed class QuickFindResult : IExtensibleDataObject
    {
        private int errorCode;
        private EntityCollection data;
        private DataCollection<string> queryColumnSet;
        private ExtensionDataObject _extensionDataObject;

        /// <summary>internal</summary>
        public QuickFindResult()
        {
        }

        /// <summary>internal</summary>
        public QuickFindResult(int error, EntityCollection entities)
        {
            this.errorCode = error;
            this.data = entities;
            this.queryColumnSet = (DataCollection<string>)null;
        }

        /// <summary>internal</summary>
        public QuickFindResult(
          int error,
          EntityCollection entities,
          DataCollection<string> queryColumns)
        {
            this.errorCode = error;
            this.data = entities;
            this.queryColumnSet = queryColumns;
        }

        /// <summary>internal</summary>
        /// <returns>Returns_Int32</returns>
        [DataMember]
        public int ErrorCode
        {
            get
            {
                return this.errorCode;
            }
            set
            {
                this.errorCode = value;
            }
        }

        /// <summary>internal</summary>
        /// <returns>Returns <see cref="T:Microsoft.Xrm.Sdk.EntityCollection"></see>.</returns>
        [DataMember]
        public EntityCollection Data
        {
            get
            {
                return this.data;
            }
            set
            {
                this.data = value;
            }
        }

        /// <summary>internal</summary>
        /// <returns>Returns <see cref="T:Microsoft.Xrm.Sdk.DataCollection`1"></see>.</returns>
        [DataMember]
        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly", Justification = "Collection properties should be read only")]
        public DataCollection<string> QueryColumnSet
        {
            get
            {
                return this.queryColumnSet;
            }
            set
            {
                this.queryColumnSet = value;
            }
        }

        /// <summary>internal</summary>
        /// <returns>Returns_ExtensionDataObject</returns>
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