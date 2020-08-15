using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Crm.Sdk.Messages.GetQuantityDecimalRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class GetQuantityDecimalResponse : OrganizationResponse
  {
    /// <summary>Gets the quantity decimal value for a product.</summary>
    /// <returns>Type: Returns_Int32The quantity decimal value for a product.</returns>
    public int Quantity
    {
      get
      {
        return this.Results.Contains(nameof (Quantity)) ? (int) this.Results[nameof (Quantity)] : 0;
      }
    }
  }
}
