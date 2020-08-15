namespace Microsoft.Xrm.Sdk
{
  /// <summary>Identifies the types of claims that are supported or may be supported in a future product release.</summary>
  public static class ClaimTypes
  {
    /// <summary>An organization claim. Value = http://schemas.microsoft.com/xrm/2011/Claims/Organization</summary>
    public static readonly string Organization = "http://schemas.microsoft.com/xrm/2011/Claims/Organization";
    /// <summary>A user claim. Value = http://schemas.microsoft.com/xrm/2011/Claims/User</summary>
    public static readonly string User = "http://schemas.microsoft.com/xrm/2011/Claims/User";
    /// <summary>An initiating user claim. Value = http://schemas.microsoft.com/xrm/2011/Claims/InitiatingUser</summary>
    public static readonly string InitiatingUser = "http://schemas.microsoft.com/xrm/2011/Claims/InitiatingUser";
    /// <summary>A plug-in assembly claim. Value = http://schemas.microsoft.com/xrm/2011/Claims/PluginAssembly</summary>
    public static readonly string PluginAssembly = "http://schemas.microsoft.com/xrm/2011/Claims/PluginAssembly";
    /// <summary>A plug-in publisher claim. Value = http://schemas.microsoft.com/xrm/2011/Claims/PluginPublisher</summary>
    public static readonly string PluginPublisher = "http://schemas.microsoft.com/xrm/2011/Claims/PluginPublisher";
    /// <summary>An entity logical name claim. Value = http://schemas.microsoft.com/xrm/2011/Claims/EntityLogicalName</summary>
    public static readonly string EntityLogicalName = "http://schemas.microsoft.com/xrm/2011/Claims/EntityLogicalName";
    /// <summary>A request name claim. Value = http://schemas.microsoft.com/xrm/2011/Claims/RequestName</summary>
    public static readonly string RequestName = "http://schemas.microsoft.com/xrm/2011/Claims/RequestName";
    /// <summary>A security token claim. Value = http://schemas.microsoft.com/xrm/2011/Claims/SecurityToken</summary>
    public static readonly string SecurityToken = "http://schemas.microsoft.com/xrm/2011/Claims/SecurityToken";
  }
}
