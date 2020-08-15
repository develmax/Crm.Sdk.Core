using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml;

namespace Microsoft.Xrm.Sdk
{
    /// <summary>Resolves known organization message request and response types for the SDK contracts.</summary>
    public sealed class KnownTypesResolver : DataContractResolver
    {
        /// <summary>Enables users to map a xsi:type name to any type.</summary>
        /// <returns>Type: Returns_Type
        /// The type the xsi:type name and namespace is mapped to.</returns>
        /// <param name="typeNamespace">Returns_String. The xsi:type namespace to map.</param>
        /// <param name="typeName">Returns_String. The xsi:type name to map.</param>
        /// <param name="declaredType">Returns_Type. The type declared in the data contract.</param>
        /// <param name="knownTypeResolver">System.Runtime.Serialization.DataContractResolverhttp://msdn.microsoft.com/en-us/library/system.runtime.serialization.datacontractresolver.aspx. The known type resolver.</param>
        public override Type ResolveName(
          string typeName,
          string typeNamespace,
          Type declaredType,
          DataContractResolver knownTypeResolver)
        {
            Type type = knownTypeResolver.ResolveName(typeName, typeNamespace, declaredType, (DataContractResolver)null);
            if (type == (Type)null)
            {
                string key = KnownTypesProvider.QualifiedName(typeName, typeNamespace);
                Dictionary<string, Type> requestResponseTypes = KnownTypesProvider.KnownOrganizationRequestResponseTypes;
                if (requestResponseTypes.ContainsKey(key))
                    return requestResponseTypes[key];
                KnownTypesProvider.KnownCustomValueTypes?.TryGetValue(typeName, out type);
            }
            return type;
        }

        /// <summary>Maps any type to a new xsi:type representation.</summary>
        /// <returns> Type: Returns_Booleantrue if mapping succeeded; otherwise, false.</returns>
        /// <param name="typeNamespace">System.Xml.XmlDictionaryStringhttp://msdn.microsoft.com/en-us/library/system.xml.xmldictionarystring.aspx. The xsi:type namespace.</param>
        /// <param name="knownTypeResolver">System.Runtime.Serialization.DataContractResolverhttp://msdn.microsoft.com/en-us/library/system.runtime.serialization.datacontractresolver.aspx. The known type resolver.</param>
        /// <param name="type">Returns_Type. The type to map.</param>
        /// <param name="declaredType">Returns_Type. The type declared in the data contract.</param>
        /// <param name="typeName">System.Xml.XmlDictionaryStringhttp://msdn.microsoft.com/en-us/library/system.xml.xmldictionarystring.aspx. The xsi:type name.</param>
        public override bool TryResolveType(
          Type type,
          Type declaredType,
          DataContractResolver knownTypeResolver,
          out XmlDictionaryString typeName,
          out XmlDictionaryString typeNamespace)
        {
            typeName = (XmlDictionaryString)null;
            typeNamespace = (XmlDictionaryString)null;
            if (!knownTypeResolver.TryResolveType(type, declaredType, (DataContractResolver)null, out typeName, out typeNamespace))
            {
                typeName = new XmlDictionaryString(XmlDictionary.Empty, type.Name, 0);
                Type type1 = type;
                if (type.IsArray)
                {
                    Type elementType = type.GetElementType();
                    if (elementType.IsArray)
                        elementType = type1.GetElementType();
                    Type type2 = elementType;
                    if ((object)type2 == null)
                        type2 = type;
                    type1 = type2;
                }
                string empty = string.Empty;
                object[] customAttributes = type1.GetCustomAttributes(typeof(DataContractAttribute), false);
                if (customAttributes != null)
                {
                    object[] objArray = customAttributes;
                    int index = 0;
                    if (index < objArray.Length)
                    {
                        DataContractAttribute contractAttribute = (DataContractAttribute)objArray[index];
                        if (!string.IsNullOrEmpty(contractAttribute.Namespace))
                        {
                            string str = contractAttribute.Namespace;
                            typeNamespace = new XmlDictionaryString(XmlDictionary.Empty, str, 0);
                        }
                    }
                }
                if (typeNamespace == null)
                    typeNamespace = new XmlDictionaryString(XmlDictionary.Empty, type.Namespace, 0);
            }
            return true;
        }
    }
}
