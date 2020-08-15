using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk
{
  /// <summary>Contains a collection of <see cref="T:Microsoft.Xrm.Sdk.Entity"></see> image objects.</summary>
  [CollectionDataContract(Name = "EntityImageCollection", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class EntityImageCollection : DataCollection<string, Entity>
  {
  }
}
