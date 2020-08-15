using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>deprecated Use the ProductAssociation entity. Contains the response from the <see cref="T:Microsoft.Crm.Sdk.Messages.RemoveProductFromKitRequest"></see>.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RemoveProductFromKitResponse : OrganizationResponse
  {
  }
}
