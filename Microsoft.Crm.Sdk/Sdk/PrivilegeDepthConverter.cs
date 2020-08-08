namespace Microsoft.Crm.Sdk
{
    internal class PrivilegeDepthConverter : EnumConverter
    {
        public PrivilegeDepthConverter()
            : base(typeof(PrivilegeDepth))
        {
        }
    }
}