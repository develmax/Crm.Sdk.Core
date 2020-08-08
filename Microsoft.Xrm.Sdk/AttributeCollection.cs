using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
    /// <summary>Provides a collection of attributes for an entity.</summary>
    [CollectionDataContract(Name = "AttributeCollection", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
    [KnownType("GetKnownParameterTypes")]
    public sealed class AttributeCollection : DataCollection<string, object>
    {
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Called by runtime to get known types")]
        private static IEnumerable<Type> GetKnownParameterTypes()
        {
            return KnownTypesProvider.RetrieveKnownValueTypes();
        }
    }
}