using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Crm.Sdk.Messages.CreateInstanceRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class CreateInstanceResponse : OrganizationResponse
  {
    /// <summary>Gets whether the series can be expanded.</summary>
    /// <returns>Type: Returns_BooleanIndicates whether the series can be expanded. true if can be expanded, otherwise, false. </returns>
    public bool SeriesCanBeExpanded
    {
      get
      {
        return this.Results.Contains(nameof (SeriesCanBeExpanded)) && (bool) this.Results[nameof (SeriesCanBeExpanded)];
      }
    }
  }
}
