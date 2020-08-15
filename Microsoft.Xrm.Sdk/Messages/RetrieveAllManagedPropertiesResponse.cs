using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Xrm.Sdk.Messages.RetrieveAllManagedPropertiesRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class RetrieveAllManagedPropertiesResponse : OrganizationResponse
  {
    /// <summary>Gets an array of managed property definitions.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Metadata.ManagedPropertyMetadata"></see>[]An array of managed property definitions.</returns>
    public Microsoft.Xrm.Sdk.Metadata.ManagedPropertyMetadata[] ManagedPropertyMetadata
    {
      get
      {
        return this.Results.Contains(nameof (ManagedPropertyMetadata)) ? (Microsoft.Xrm.Sdk.Metadata.ManagedPropertyMetadata[]) this.Results[nameof (ManagedPropertyMetadata)] : (Microsoft.Xrm.Sdk.Metadata.ManagedPropertyMetadata[]) null;
      }
    }
  }
}
