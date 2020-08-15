using Microsoft.Xrm.Sdk.Metadata;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Xrm.Sdk.Messages.RetrieveManagedPropertyRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class RetrieveManagedPropertyResponse : OrganizationResponse
  {
    /// <summary>Gets the definition of the managed property.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Metadata.ManagedPropertyMetadata"></see>The definition of the managed property.</returns>
    public ManagedPropertyMetadata ManagedPropertyMetadata
    {
      get
      {
        return this.Results.Contains(nameof (ManagedPropertyMetadata)) ? (ManagedPropertyMetadata) this.Results[nameof (ManagedPropertyMetadata)] : (ManagedPropertyMetadata) null;
      }
    }
  }
}
