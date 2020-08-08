namespace Microsoft.Xrm.Sdk.Client
{
    /// <summary>Contains a policy configuration that identifies a Secure Token Service (STS).</summary>
    public abstract class PolicyConfiguration
    {
        internal PolicyConfiguration(AuthenticationPolicy xrmPolicy)
        {
            this.XrmPolicy = xrmPolicy;
            this.Initialize();
        }

        private void Initialize()
        {
            this.SecureTokenServiceIdentifier = PolicyHelper.GetPolicyValue(this.XrmPolicy, "SecureTokenServiceIdentifier", string.Empty);
        }

        internal AuthenticationPolicy XrmPolicy { get; private set; }

        /// <summary>Gets an identifier of a Secure Token Service (STS) provider.</summary>
        /// <returns>Type:  Returns_StringThe identifier of a Secure Token Service (STS) provider.</returns>
        public string SecureTokenServiceIdentifier { get; private set; }
    }
}