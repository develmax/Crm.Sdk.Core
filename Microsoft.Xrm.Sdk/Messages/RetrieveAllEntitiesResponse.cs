using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Xrm.Sdk.Messages.RetrieveAllEntitiesRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class RetrieveAllEntitiesResponse : OrganizationResponse
  {
    /// <summary>Gets an array of <see cref="T:Microsoft.Xrm.Sdk.Metadata.EntityMetadata"></see> instances.</summary>
    /// <returns>Type:  <see cref="T:Microsoft.Xrm.Sdk.Metadata.EntityMetadata"></see>[]an array of <see cref="T:Microsoft.Xrm.Sdk.Metadata.EntityMetadata"></see> instances..</returns>
    public Microsoft.Xrm.Sdk.Metadata.EntityMetadata[] EntityMetadata
    {
      get
      {
        return this.Results.Contains(nameof (EntityMetadata)) ? (Microsoft.Xrm.Sdk.Metadata.EntityMetadata[]) this.Results[nameof (EntityMetadata)] : (Microsoft.Xrm.Sdk.Metadata.EntityMetadata[]) null;
      }
    }

    /// <summary>Gets a time stamp that represents the time when the data was retrieved.</summary>
    /// <returns>Type: Returns_StringA time stamp that represents the time when the data was retrieved.</returns>
    public string Timestamp
    {
      get
      {
        return this.Results.Contains(nameof (Timestamp)) ? (string) this.Results[nameof (Timestamp)] : (string) null;
      }
    }
  }
}
