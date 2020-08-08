using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Metadata.Query;
using Microsoft.Xrm.Sdk.Organization;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Reflection;
using System.Runtime.Serialization;
using System.Security;

namespace Microsoft.Xrm.Sdk
{
    [SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling", Justification = "Class contains lists of types.")]
    internal static class KnownTypesProvider
    {
        private static object _lockObj = new object();
        private static List<Assembly> _knownAssemblies = (List<Assembly>)null;
        private static Dictionary<string, Type> _knownCustomValueTypes = (Dictionary<string, Type>)null;
        private static bool _regenerateknownCustomValueTypes = false;
        private static Dictionary<string, Type> _knownOrganizationRequestResponseTypes = (Dictionary<string, Type>)null;
        private static bool _regenerateknownOrganizationRequestResponseTypes = false;

        [SecuritySafeCritical]
        [SuppressMessage("Microsoft.Performance", "CA1810:InitializeReferenceTypeStaticFieldsInline")]
        static KnownTypesProvider()
        {
            AppDomain.CurrentDomain.AssemblyLoad += new AssemblyLoadEventHandler(KnownTypesProvider.CurrentDomain_AssemblyLoad);
        }

        private static void CurrentDomain_AssemblyLoad(object sender, AssemblyLoadEventArgs args)
        {
            KnownTypesProvider.RegisterAssembly(args.LoadedAssembly);
        }

        private static List<Assembly> KnownAssemblies
        {
            get
            {
                if (KnownTypesProvider._knownAssemblies == null)
                {
                    lock (KnownTypesProvider._lockObj)
                    {
                        if (KnownTypesProvider._knownAssemblies == null)
                        {
                            KnownTypesProvider._knownAssemblies = new List<Assembly>();
                            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
                                KnownTypesProvider.RegisterAssembly(assembly);
                        }
                    }
                }
                return KnownTypesProvider._knownAssemblies;
            }
        }

        private static void RegisterAssembly(Assembly assembly)
        {
            if (KnownTypesProvider.GetProxyTypesAttribute(assembly) == null || KnownTypesProvider.KnownAssemblies.Contains(assembly))
                return;
            lock (KnownTypesProvider._lockObj)
            {
                if (KnownTypesProvider._knownAssemblies.Contains(assembly))
                    return;
                KnownTypesProvider._knownAssemblies.Add(assembly);
                KnownTypesProvider._regenerateknownCustomValueTypes = true;
                KnownTypesProvider._regenerateknownOrganizationRequestResponseTypes = true;
            }
        }

        private static ProxyTypesAssemblyAttribute GetProxyTypesAttribute(
          Assembly assembly)
        {
            object[] customAttributes = assembly.GetCustomAttributes(typeof(ProxyTypesAssemblyAttribute), false);
            return customAttributes == null || customAttributes.Length == 0 ? (ProxyTypesAssemblyAttribute)null : customAttributes[0] as ProxyTypesAssemblyAttribute;
        }

        internal static Dictionary<string, Type> KnownCustomValueTypes
        {
            get
            {
                if (KnownTypesProvider._knownCustomValueTypes == null || KnownTypesProvider._regenerateknownCustomValueTypes)
                {
                    lock (KnownTypesProvider._lockObj)
                    {
                        if (KnownTypesProvider._knownCustomValueTypes != null)
                        {
                            if (!KnownTypesProvider._regenerateknownCustomValueTypes)
                                goto label_23;
                        }
                        List<Assembly> knownAssemblies = KnownTypesProvider.KnownAssemblies;
                        Dictionary<string, Type> dictionary = new Dictionary<string, Type>();
                        foreach (Assembly assembly in knownAssemblies)
                        {
                            if (!(assembly == Assembly.GetExecutingAssembly()))
                            {
                                ProxyTypesAssemblyAttribute proxyTypesAttribute = KnownTypesProvider.GetProxyTypesAttribute(assembly);
                                if (proxyTypesAttribute != null && proxyTypesAttribute.ContainsSharedContracts)
                                {
                                    foreach (Type exportedType in assembly.GetExportedTypes())
                                    {
                                        bool flag = false;
                                        object[] customAttributes1 = exportedType.GetCustomAttributes(typeof(DataContractAttribute), false);
                                        if (customAttributes1 != null && customAttributes1.Length > 0)
                                        {
                                            flag = true;
                                        }
                                        else
                                        {
                                            object[] customAttributes2 = exportedType.GetCustomAttributes(typeof(CollectionDataContractAttribute), false);
                                            if (customAttributes2 != null && customAttributes2.Length > 0)
                                                flag = true;
                                        }
                                        if (flag && !exportedType.IsSubclassOf(typeof(OrganizationRequest)) && (!exportedType.IsSubclassOf(typeof(OrganizationResponse)) && !dictionary.ContainsKey(exportedType.Name)))
                                        {
                                            dictionary.Add(exportedType.Name, exportedType);
                                            dictionary.Add(string.Format((IFormatProvider)CultureInfo.InvariantCulture, "ArrayOf{0}", (object)exportedType.Name), exportedType.MakeArrayType());
                                            dictionary.Add(string.Format((IFormatProvider)CultureInfo.InvariantCulture, "ArrayOfArrayOf{0}", (object)exportedType.Name), exportedType.MakeArrayType().MakeArrayType());
                                        }
                                    }
                                }
                            }
                        }
                        KnownTypesProvider._knownCustomValueTypes = dictionary;
                        KnownTypesProvider._regenerateknownCustomValueTypes = false;
                    }
                }
label_23:
                return KnownTypesProvider._knownCustomValueTypes;
            }
        }

        internal static Dictionary<string, Type> KnownOrganizationRequestResponseTypes
        {
            get
            {
                if (KnownTypesProvider._knownOrganizationRequestResponseTypes == null || KnownTypesProvider._regenerateknownOrganizationRequestResponseTypes)
                {
                    lock (KnownTypesProvider._lockObj)
                    {
                        if (KnownTypesProvider._knownOrganizationRequestResponseTypes != null)
                        {
                            if (!KnownTypesProvider._regenerateknownOrganizationRequestResponseTypes)
                                goto label_21;
                        }
                        List<Assembly> knownAssemblies = KnownTypesProvider.KnownAssemblies;
                        Dictionary<string, Type> dictionary = new Dictionary<string, Type>();
                        foreach (Assembly assembly in knownAssemblies)
                        {
                            foreach (Type exportedType in assembly.GetExportedTypes())
                            {
                                object[] customAttributes = exportedType.GetCustomAttributes(typeof(DataContractAttribute), false);
                                if (customAttributes != null && customAttributes.Length > 0 && (exportedType.IsSubclassOf(typeof(OrganizationRequest)) || exportedType.IsSubclassOf(typeof(OrganizationResponse))))
                                {
                                    foreach (DataContractAttribute contractAttribute in customAttributes)
                                    {
                                        string key = KnownTypesProvider.QualifiedName(contractAttribute.Name ?? exportedType.Name, contractAttribute.Namespace);
                                        if (!dictionary.ContainsKey(key))
                                            dictionary.Add(key, exportedType);
                                    }
                                }
                            }
                        }
                        KnownTypesProvider._knownOrganizationRequestResponseTypes = dictionary;
                        KnownTypesProvider._regenerateknownOrganizationRequestResponseTypes = false;
                    }
                }
label_21:
                return KnownTypesProvider._knownOrganizationRequestResponseTypes;
            }
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Called by runtime to get known types")]
        [SuppressMessage("Microsoft.Maintainability", "CA1506:AvoidExcessiveClassCoupling", Justification = "The extra coupling is temporary.")]
        public static IEnumerable<Type> RetrieveKnownValueTypes()
        {
            List<Type> knownTypes = new List<Type>();
            KnownTypesProvider.AddKnownAttributeTypes(knownTypes);
            knownTypes.Add(typeof(AliasedValue));
            knownTypes.Add(typeof(Dictionary<string, string>));
            knownTypes.Add(typeof(Entity));
            knownTypes.Add(typeof(Entity[]));
            knownTypes.Add(typeof(ColumnSet));
            knownTypes.Add(typeof(EntityReferenceCollection));
            knownTypes.Add(typeof(QueryBase));
            knownTypes.Add(typeof(QueryExpression));
            knownTypes.Add(typeof(QueryExpression[]));
            knownTypes.Add(typeof(LocalizedLabel[]));
            knownTypes.Add(typeof(PagingInfo));
            knownTypes.Add(typeof(Relationship));
            knownTypes.Add(typeof(AttributePrivilegeCollection));
            knownTypes.Add(typeof(RelationshipQueryCollection));
            knownTypes.Add(typeof(EntityMetadataCollection));
            knownTypes.Add(typeof(MetadataFilterExpression));
            knownTypes.Add(typeof(MetadataConditionExpression));
            knownTypes.Add(typeof(MetadataQueryBase));
            knownTypes.Add(typeof(DeletedMetadataFilters));
            knownTypes.Add(typeof(DeletedMetadataCollection));
            knownTypes.Add(typeof(ExecuteMultipleSettings));
            knownTypes.Add(typeof(OrganizationRequestCollection));
            knownTypes.Add(typeof(ExecuteMultipleResponseItemCollection));
            knownTypes.Add(typeof(QuickFindResultCollection));
            knownTypes.Add(typeof(QuickFindConfigurationCollection));
            knownTypes.Add(typeof(AttributeMappingCollection));
            knownTypes.Add(typeof(OrganizationDetail));
            foreach (Type type in KnownTypesProvider.KnownCustomValueTypes.Values)
                knownTypes.Add(type);
            return (IEnumerable<Type>)knownTypes;
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Called by runtime to get known types")]
        public static IEnumerable<Type> RetrieveKnownConditionValueTypes()
        {
            List<Type> knownTypes = new List<Type>();
            KnownTypesProvider.AddKnownAttributeTypes(knownTypes);
            return (IEnumerable<Type>)knownTypes;
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Called by other methods of this class")]
        internal static void AddKnownAttributeTypes(List<Type> knownTypes)
        {
            knownTypes.Add(typeof(bool));
            knownTypes.Add(typeof(bool[]));
            knownTypes.Add(typeof(int));
            knownTypes.Add(typeof(int[]));
            knownTypes.Add(typeof(string));
            knownTypes.Add(typeof(string[]));
            knownTypes.Add(typeof(string[][]));
            knownTypes.Add(typeof(double));
            knownTypes.Add(typeof(double[]));
            knownTypes.Add(typeof(Decimal));
            knownTypes.Add(typeof(Decimal[]));
            knownTypes.Add(typeof(Guid));
            knownTypes.Add(typeof(Guid[]));
            knownTypes.Add(typeof(DateTime));
            knownTypes.Add(typeof(DateTime[]));
            knownTypes.Add(typeof(Money));
            knownTypes.Add(typeof(Money[]));
            knownTypes.Add(typeof(EntityReference));
            knownTypes.Add(typeof(EntityReference[]));
            knownTypes.Add(typeof(OptionSetValue));
            knownTypes.Add(typeof(OptionSetValue[]));
            knownTypes.Add(typeof(EntityCollection));
            knownTypes.Add(typeof(Money));
            knownTypes.Add(typeof(Label));
            knownTypes.Add(typeof(LocalizedLabel));
            knownTypes.Add(typeof(LocalizedLabelCollection));
            knownTypes.Add(typeof(EntityMetadata[]));
            knownTypes.Add(typeof(EntityMetadata));
            knownTypes.Add(typeof(AttributeMetadata[]));
            knownTypes.Add(typeof(AttributeMetadata));
            knownTypes.Add(typeof(RelationshipMetadataBase[]));
            knownTypes.Add(typeof(RelationshipMetadataBase));
            knownTypes.Add(typeof(EntityFilters));
            knownTypes.Add(typeof(OptionSetMetadataBase));
            knownTypes.Add(typeof(OptionSetMetadataBase[]));
            knownTypes.Add(typeof(OptionSetMetadata));
            knownTypes.Add(typeof(BooleanOptionSetMetadata));
            knownTypes.Add(typeof(OptionSetType));
            knownTypes.Add(typeof(ManagedPropertyMetadata));
            knownTypes.Add(typeof(ManagedPropertyMetadata[]));
            knownTypes.Add(typeof(BooleanManagedProperty));
            knownTypes.Add(typeof(AttributeRequiredLevelManagedProperty));
            knownTypes.Add(typeof(EndpointAccessType));
        }

        public static List<Type> GetKnownMetadataEnumTypes()
        {
            return new List<Type>()
      {
        typeof (object[]),
        typeof (StringFormat),
        typeof (StringFormat[]),
        typeof (AttributeRequiredLevel),
        typeof (AttributeRequiredLevel[]),
        typeof (AttributeTypeCode),
        typeof (AttributeTypeCode[]),
        typeof (CascadeType),
        typeof (CascadeType[]),
        typeof (Microsoft.Xrm.Sdk.Metadata.DateTimeFormat),
        typeof (Microsoft.Xrm.Sdk.Metadata.DateTimeFormat[]),
        typeof (IntegerFormat),
        typeof (IntegerFormat[]),
        typeof (ManagedPropertyEvaluationPriority),
        typeof (ManagedPropertyEvaluationPriority[]),
        typeof (ManagedPropertyOperation),
        typeof (ManagedPropertyOperation[]),
        typeof (ManagedPropertyType),
        typeof (ManagedPropertyType[]),
        typeof (SecurityTypes),
        typeof (SecurityTypes[]),
        typeof (OwnershipTypes),
        typeof (OwnershipTypes[]),
        typeof (ImeMode),
        typeof (ImeMode[]),
        typeof (RelationshipType),
        typeof (RelationshipType[]),
        typeof (AttributeTypeDisplayName),
        typeof (AttributeTypeDisplayName[])
      };
        }

        internal static string QualifiedName(string typeName, string typeNamespace)
        {
            return string.Format((IFormatProvider)CultureInfo.InvariantCulture, "{0}/{1}", (object)typeNamespace, (object)typeName);
        }
    }
}