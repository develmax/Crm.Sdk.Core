using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data to return an existing social profile record if one exists, otherwise generates a new one and returns it.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class GenerateSocialProfileRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the SocialProfile to return or generate.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Entity"></see>The SocialProfile to return or generate.</returns>
    public Entity Entity
    {
      get
      {
        return this.Parameters.Contains(nameof (Entity)) ? (Entity) this.Parameters[nameof (Entity)] : (Entity) null;
      }
      set
      {
        this.Parameters[nameof (Entity)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.GenerateSocialProfileRequest"></see> class.</summary>
    public GenerateSocialProfileRequest()
    {
      this.RequestName = "GenerateSocialProfile";
      this.Entity = (Entity) null;
    }
  }
}
