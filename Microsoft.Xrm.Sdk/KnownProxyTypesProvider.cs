using Microsoft.Xrm.Sdk.Client;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Security;

namespace Microsoft.Xrm.Sdk
{
    internal abstract class KnownProxyTypesProvider
    {
        private static AppDomainBasedKnownProxyTypesProvider _appDomainBasedInstance = (AppDomainBasedKnownProxyTypesProvider)null;
        private static AssemblyBasedKnownProxyTypesProvider _assemblyBasedInstance = (AssemblyBasedKnownProxyTypesProvider)null;
        private static object _lockObject = new object();
        protected static Dictionary<Type, string> _typeAttributes = new Dictionary<Type, string>();
        protected List<Assembly> _strongTypeAssemblies;

        [SuppressMessage("Microsoft.Performance", "CA1810:InitializeReferenceTypeStaticFieldsInline")]
        static KnownProxyTypesProvider()
        {
            KnownProxyTypesProvider._typeAttributes.Add(typeof(EntityLogicalNameAttribute), "LogicalName");
            KnownProxyTypesProvider._typeAttributes.Add(typeof(ResponseProxyAttribute), "Name");
        }

        [SecuritySafeCritical]
        protected KnownProxyTypesProvider()
        {
            this._strongTypeAssemblies = new List<Assembly>();
        }

        protected abstract void AddTypeMapping(Assembly assembly, Type type, string proxyName);

        public abstract Type GetTypeForName(string name, Assembly proxyTypesAssembly);

        public abstract string GetNameForType(Type type);

        protected abstract void OnBeginLoadTypes(Assembly targetAssembly);

        protected abstract void OnEndLoadTypes();

        protected abstract void OnErrorLoadTypes();

        internal static KnownProxyTypesProvider GetInstance(
          bool supportIndividualAssemblies)
        {
            if (supportIndividualAssemblies)
            {
                if (KnownProxyTypesProvider._assemblyBasedInstance == null)
                {
                    lock (KnownProxyTypesProvider._lockObject)
                    {
                        if (KnownProxyTypesProvider._assemblyBasedInstance == null)
                            KnownProxyTypesProvider._assemblyBasedInstance = new AssemblyBasedKnownProxyTypesProvider();
                    }
                }
                return (KnownProxyTypesProvider)KnownProxyTypesProvider._assemblyBasedInstance;
            }
            if (KnownProxyTypesProvider._appDomainBasedInstance == null)
            {
                lock (KnownProxyTypesProvider._lockObject)
                {
                    if (KnownProxyTypesProvider._appDomainBasedInstance == null)
                        KnownProxyTypesProvider._appDomainBasedInstance = new AppDomainBasedKnownProxyTypesProvider();
                }
            }
            return (KnownProxyTypesProvider)KnownProxyTypesProvider._appDomainBasedInstance;
        }

        protected static object ThisLock
        {
            get
            {
                return KnownProxyTypesProvider._lockObject;
            }
        }

        public void RegisterAssembly(string assemblyName)
        {
            this.RegisterAssembly(Assembly.Load(assemblyName));
        }

        public void RegisterAssembly(Assembly assembly)
        {
            if (this._strongTypeAssemblies.Contains(assembly))
                return;
            lock (KnownProxyTypesProvider._lockObject)
            {
                if (this._strongTypeAssemblies.Contains(assembly))
                    return;
                this._strongTypeAssemblies.Add(assembly);
                this.LoadKnownTypes(assembly);
            }
        }

        private void LoadKnownTypes(Assembly assembly)
        {
            object[] customAttributes1 = assembly.GetCustomAttributes(typeof(ProxyTypesAssemblyAttribute), false);
            if (customAttributes1 == null || customAttributes1.Length == 0)
                return;
            this.OnBeginLoadTypes(assembly);
            try
            {
                foreach (Type exportedType in assembly.GetExportedTypes())
                {
                    foreach (KeyValuePair<Type, string> typeAttribute in KnownProxyTypesProvider._typeAttributes)
                    {
                        object[] customAttributes2 = exportedType.GetCustomAttributes(typeAttribute.Key, false);
                        if (customAttributes2 != null && customAttributes2.Length > 0 && customAttributes2[0].GetType().GetProperty(typeAttribute.Value) != (PropertyInfo)null)
                        {
                            string proxyName = (string)customAttributes2[0].GetType().GetProperty(typeAttribute.Value).GetValue(customAttributes2[0], (object[])null);
                            this.AddTypeMapping(assembly, exportedType, proxyName);
                        }
                    }
                }
                this.OnEndLoadTypes();
            }
            catch
            {
                this.OnErrorLoadTypes();
                throw;
            }
        }

        protected void InitializeLoadedAssemblies()
        {
            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
                this.RegisterAssembly(assembly);
        }
    }
}