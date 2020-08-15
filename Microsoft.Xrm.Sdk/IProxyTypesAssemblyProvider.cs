using System.Reflection;

namespace Microsoft.Xrm.Sdk
{
  /// <summary>Provides the early-bound entity types assembly that was created using the CrmSvcUtil utility.</summary>
  public interface IProxyTypesAssemblyProvider
  {
    /// <summary>Gets or sets the assembly that contains the early-bound entity types.</summary>
    /// <returns>Type: Returns_AssemblyThe assembly.</returns>
    Assembly ProxyTypesAssembly { get; set; }
  }
}
