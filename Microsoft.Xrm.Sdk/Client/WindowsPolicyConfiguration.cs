namespace Microsoft.Xrm.Sdk.Client
{
    /// <summary>Contains a policy configuration that identifies an Active Directory provider.</summary>
    public sealed class WindowsPolicyConfiguration : PolicyConfiguration
    {
        internal WindowsPolicyConfiguration(AuthenticationPolicy xrmPolicy)
            : base(xrmPolicy)
        {
        }
    }
}