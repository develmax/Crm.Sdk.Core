using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
    /// <summary>Defines a collection of <see cref="T:Microsoft.Xrm.Sdk.LocalizedLabel"></see>.</summary>
    [CollectionDataContract(Name = "LocalizedLabelCollection", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
    public sealed class LocalizedLabelCollection : DataCollection<LocalizedLabel>
    {
        /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Xrm.Sdk.LocalizedLabelCollection"></see> class</summary>
        public LocalizedLabelCollection()
        {
        }

        /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Xrm.Sdk.LocalizedLabelCollection"></see> class</summary>
        /// <param name="list">Type: Returns_IList&lt;<see cref="T:Microsoft.Xrm.Sdk.LocalizedLabel"></see>&gt;. Sets a list of localized labels.</param>
        public LocalizedLabelCollection(IList<LocalizedLabel> list)
            : base(list)
        {
        }
    }
}