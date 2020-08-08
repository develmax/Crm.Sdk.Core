namespace Microsoft.Xrm.Sdk.Client
{
    /// <summary>Identifies the type of identity provider used for authentication.</summary>
    public enum AuthenticationProviderType
    {
        /// <summary>No identity provider. Value = 0.</summary>
        None,
        /// <summary>An Active Directory identity provider. Value = 1.</summary>
        ActiveDirectory/*,
        /// <summary>A federated claims identity provider. Value = 2.</summary>
        Federation,
        /// <summary>A pn_Windows_Live_ID identity provider. Value = 3.</summary>
        LiveId,
        /// <summary>An online (pn_Office_365) federated identity provider. Value = 4.</summary>
        OnlineFederation,*/
    }
}