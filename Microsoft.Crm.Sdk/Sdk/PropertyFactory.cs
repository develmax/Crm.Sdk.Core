using System;
using System.Globalization;

namespace Microsoft.Crm.Sdk
{
    internal sealed class PropertyFactory
    {
        private static PropertyFactory _instance = new PropertyFactory();
        private const string StatePropertyName = "StateCode";

        public static PropertyFactory Instance
        {
            get
            {
                return PropertyFactory._instance;
            }
        }

        public Property CreateInstance(string propertyName, object value)
        {
            switch (propertyName)
            {
                case "":
                case null:
                    throw new ArgumentException("Property name must be non null.", nameof(propertyName));
                default:
                    if (value == null)
                        throw new ArgumentException("Property value must be non null.", nameof(value));
                    bool ignoreCase = true;
                    Property property;
                    if (string.Compare(propertyName, "StateCode", ignoreCase, CultureInfo.InvariantCulture) == 0)
                    {
                        property = (Property)new StateProperty();
                    }
                    else
                    {
                        switch (value)
                        {
                            case string _:
                                property = (Property)new StringProperty();
                                break;
                            case UniqueIdentifier _:
                                property = (Property)new UniqueIdentifierProperty();
                                break;
                            case Status _:
                                property = (Property)new StatusProperty();
                                break;
                            case Picklist _:
                                property = (Property)new PicklistProperty();
                                break;
                            case Owner _:
                                property = (Property)new OwnerProperty();
                                break;
                            case Lookup _:
                                property = (Property)new LookupProperty();
                                break;
                            case Key _:
                                property = (Property)new KeyProperty();
                                break;
                            case EntityNameReference _:
                                property = (Property)new EntityNameReferenceProperty();
                                break;
                            case DynamicEntity[] _:
                                property = (Property)new DynamicEntityArrayProperty();
                                break;
                            case Customer _:
                                property = (Property)new CustomerProperty();
                                break;
                            case CrmNumber _:
                                property = (Property)new CrmNumberProperty();
                                break;
                            case CrmMoney _:
                                property = (Property)new CrmMoneyProperty();
                                break;
                            case CrmFloat _:
                                property = (Property)new CrmFloatProperty();
                                break;
                            case CrmDecimal _:
                                property = (Property)new CrmDecimalProperty();
                                break;
                            case CrmDateTime _:
                                property = (Property)new CrmDateTimeProperty();
                                break;
                            case CrmBoolean _:
                                property = (Property)new CrmBooleanProperty();
                                break;
                            case long _:
                            case bool _:
                                property = (Property)new UnknownProperty();
                                value = (object)new UnknownValue(value);
                                break;
                            case UnknownValue _:
                                property = (Property)new UnknownProperty();
                                break;
                            default:
                                throw new ArgumentException(string.Format((IFormatProvider)CultureInfo.InvariantCulture, "Value of type '{0}' is not supported.", (object)value.GetType().Name), nameof(value));
                        }
                    }
                    property.Name = propertyName;
                    property.SetValue(value);
                    return property;
            }
        }

        private PropertyFactory()
        {
        }
    }
}
