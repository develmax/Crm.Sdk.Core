using System;

namespace Microsoft.Xrm.Sdk.Client
{
    /// <summary>Contains the primary and alternate endpoints of an organization.</summary>
    public sealed class ServiceUrls
    {
        /// <summary>Gets or sets the primary endpoint of an organization.</summary>
        /// <returns>Type:  Returns_URIThe primary endpoint of an organization.</returns>
        public Uri PrimaryEndpoint { get; set; }

        /// <summary>Gets or sets the alternate endpoint of an organization.</summary>
        /// <returns>Type: Returns_URI The alternate endpoint of an organization.</returns>
        public Uri AlternateEndpoint { get; set; }

        /// <summary>Gets a value that indicates if the primary endpoint was generated from the alternate endpoint.</summary>
        /// <returns>Type: Returns_Booleantrue if the the primary endpoint was generated from the alternate endpoint; otherwise, false.</returns>
        public bool GeneratedFromAlternate { get; internal set; }
    }
}