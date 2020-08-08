using System;
using System.Xml.Serialization;

namespace Microsoft.Crm.Sdk
{
    [XmlInclude(typeof(DynamicEntity))]
    [XmlType(Namespace = "http://schemas.microsoft.com/crm/2006/WebServices")]
    [Serializable]
    public abstract class BusinessEntity
    {
    }
}