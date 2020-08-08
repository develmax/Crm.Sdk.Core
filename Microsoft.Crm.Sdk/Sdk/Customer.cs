using System;
using System.Xml.Serialization;

namespace Microsoft.Crm.Sdk
{
    [XmlType(Namespace = "http://schemas.microsoft.com/crm/2006/WebServices")]
    [Serializable]
    public class Customer : CrmReference
    {
        public Customer()
        {
        }

        public Customer(string type, Guid value)
        {
            this.type = type;
            this.Value = value;
        }

        public static Customer Null
        {
            get
            {
                Customer customer = new Customer();
                customer.IsNull = true;
                customer.IsNullSpecified = true;
                return customer;
            }
        }
    }
}