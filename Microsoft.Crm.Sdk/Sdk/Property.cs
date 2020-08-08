using System;
using System.Xml.Serialization;

namespace Microsoft.Crm.Sdk
{
    [XmlInclude(typeof(CrmMoneyProperty))]
    [XmlInclude(typeof(CrmBooleanProperty))]
    [XmlInclude(typeof(CrmDateTimeProperty))]
    [XmlInclude(typeof(CrmDecimalProperty))]
    [XmlInclude(typeof(CrmFloatProperty))]
    [XmlInclude(typeof(StateProperty))]
    [XmlInclude(typeof(CrmNumberProperty))]
    [XmlInclude(typeof(CustomerProperty))]
    [XmlInclude(typeof(DynamicEntityArrayProperty))]
    [XmlInclude(typeof(EntityNameReferenceProperty))]
    [XmlInclude(typeof(KeyProperty))]
    [XmlInclude(typeof(LookupProperty))]
    [XmlInclude(typeof(OwnerProperty))]
    [XmlInclude(typeof(PicklistProperty))]
    [XmlType(Namespace = "http://schemas.microsoft.com/crm/2006/WebServices")]
    [XmlInclude(typeof(StatusProperty))]
    [XmlInclude(typeof(StringProperty))]
    [XmlInclude(typeof(UniqueIdentifierProperty))]
    [Serializable]
    public abstract class Property
    {
        private string nameField;

        [XmlAttribute]
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        internal abstract object GetValue();

        internal abstract void SetValue(object value);
    }
}