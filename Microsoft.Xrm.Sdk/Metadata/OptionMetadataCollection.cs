using System.Collections.Generic;

namespace Microsoft.Xrm.Sdk.Metadata
{
    /// <summary>Contains the options in for the <see cref="T:Microsoft.Xrm.Sdk.Metadata.OptionSetMetadata"></see>.<see cref="P:Microsoft.Xrm.Sdk.Metadata.OptionSetMetadata.Options"></see> class.</summary>
    public sealed class OptionMetadataCollection : DataCollection<OptionMetadata>
    {
        /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Xrm.Sdk.Metadata.OptionMetadataCollection"></see> class</summary>
        public OptionMetadataCollection()
        {
        }

        /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Xrm.Sdk.Metadata.OptionMetadataCollection"></see> class</summary>
        /// <param name="list">Type: Returns_IList&lt;<see cref="T:Microsoft.Xrm.Sdk.Metadata.OptionMetadata"></see>&gt;. Sets the options for the collection.</param>
        public OptionMetadataCollection(IList<OptionMetadata> list)
            : base(list)
        {
        }
    }
}