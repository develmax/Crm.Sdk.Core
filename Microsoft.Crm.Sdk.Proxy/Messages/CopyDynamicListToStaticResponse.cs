using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Crm.Sdk.Messages.CopyDynamicListToStaticRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class CopyDynamicListToStaticResponse : OrganizationResponse
  {
    /// <summary>Gets the ID of the created static list.</summary>
    /// <returns>Type: Returns_GuidThe ID of the created static list that corresponds to the List.ListId attribute, which is the primary key for the List entity.</returns>
    public Guid StaticListId
    {
      get
      {
        return this.Results.Contains(nameof (StaticListId)) ? (Guid) this.Results[nameof (StaticListId)] : new Guid();
      }
    }
  }
}
