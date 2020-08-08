namespace Microsoft.Xrm.Sdk.Client
{
    internal static class PolicyHelper
    {
        internal static string GetPolicyValue(
            AuthenticationPolicy xrmPolicy,
            string elementName,
            string defaultValue)
        {
            string str;
            return xrmPolicy != null && xrmPolicy.PolicyElements.TryGetValue(elementName, out str) ? str : defaultValue;
        }
    }
}