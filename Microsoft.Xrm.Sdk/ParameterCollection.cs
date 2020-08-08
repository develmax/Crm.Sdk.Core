using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
    /// <summary>Provides a collection of parameters for a request.</summary>
    [CollectionDataContract(Name = "ParameterCollection", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
    [KnownType("GetKnownParameterTypes")]
    public sealed class ParameterCollection : DataCollection<string, object>
    {
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Justification = "Called by runtime to get known types")]
        private static IEnumerable<Type> GetKnownParameterTypes()
        {
            return KnownTypesProvider.RetrieveKnownValueTypes();
        }
    }
}