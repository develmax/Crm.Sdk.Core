using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Xrm.Sdk.Messages.InsertOptionValueRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class InsertOptionValueResponse : OrganizationResponse
  {
    /// <summary>Gets the option value for the new option.</summary>
    /// <returns>Type: Returns_Int32The option value for the new option.</returns>
    public int NewOptionValue
    {
      get
      {
        return this.Results.Contains(nameof (NewOptionValue)) ? (int) this.Results[nameof (NewOptionValue)] : 0;
      }
    }
  }
}
