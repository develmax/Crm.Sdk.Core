using System.ComponentModel;
using System.Xml.Serialization;

namespace Microsoft.Crm.Sdk
{
    [XmlType(Namespace = "http://schemas.microsoft.com/crm/2006/CoreTypes")]
    [TypeConverter(typeof(PrivilegeDepthConverter))]
    public enum PrivilegeDepth
    {
        Basic,
        Local,
        Deep,
        Global,
    }
}