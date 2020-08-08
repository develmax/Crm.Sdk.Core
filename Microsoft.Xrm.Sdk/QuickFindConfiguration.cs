namespace Microsoft.Xrm.Sdk
{
    /// <summary>internal</summary>
    public sealed class QuickFindConfiguration
    {
        /// <summary>internal</summary>
        /// <returns>Returns_String</returns>
        public string EntityName { get; set; }

        /// <summary>internal</summary>
        public QuickFindConfiguration()
        {
        }

        /// <summary>internal</summary>
        public QuickFindConfiguration(string entityName)
        {
            this.EntityName = entityName;
        }
    }
}