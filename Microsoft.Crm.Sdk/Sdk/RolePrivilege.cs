using System;
using System.Xml.Serialization;

namespace Microsoft.Crm.Sdk
{
    [XmlType(Namespace = "http://schemas.microsoft.com/crm/2006/CoreTypes")]
    [Serializable]
    public class RolePrivilege
    {
        private PrivilegeDepth _depth;
        private Guid _privilegeId;
        private Guid _businessUnitId;

        public PrivilegeDepth Depth
        {
            get
            {
                return this._depth;
            }
            set
            {
                this._depth = value;
            }
        }

        public Guid PrivilegeId
        {
            get
            {
                return this._privilegeId;
            }
            set
            {
                this._privilegeId = value;
            }
        }

        [XmlIgnore]
        public Guid BusinessUnitId
        {
            get
            {
                return this._businessUnitId;
            }
            set
            {
                this._businessUnitId = value;
            }
        }

        public RolePrivilege()
        {
        }

        public RolePrivilege(int depth, Guid privilegeId)
        {
            this.Depth = (PrivilegeDepth)depth;
            this.PrivilegeId = privilegeId;
            this.BusinessUnitId = Guid.Empty;
        }

        public RolePrivilege(int depth, Guid privilegeId, Guid businessId)
            : this((PrivilegeDepth)depth, privilegeId, businessId)
        {
        }

        public RolePrivilege(PrivilegeDepth depth, Guid privilegeId, Guid businessId)
        {
            this.Depth = depth;
            this.PrivilegeId = privilegeId;
            this.BusinessUnitId = businessId;
        }
    }
}