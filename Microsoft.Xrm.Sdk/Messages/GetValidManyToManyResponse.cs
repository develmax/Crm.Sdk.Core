using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Xrm.Sdk.Messages.GetValidManyToManyRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class GetValidManyToManyResponse : OrganizationResponse
  {
    /// <summary>Gets an array of logical entity names that can have many-to-many entity relationships.</summary>
    /// <returns>Type: Returns_String[]An array of logical entity names that can have many-to-many entity relationships.</returns>
    public string[] EntityNames
    {
      get
      {
        return this.Results.Contains(nameof (EntityNames)) ? (string[]) this.Results[nameof (EntityNames)] : (string[]) null;
      }
    }
  }
}
