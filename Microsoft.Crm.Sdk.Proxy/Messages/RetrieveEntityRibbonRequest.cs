using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  retrieve ribbon definitions for an entity.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RetrieveEntityRibbonRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the logical name of an entity in order to retrieve a ribbon definition. Required.</summary>
    /// <returns>Type: Returns_StringThe logical name of an entity in order to retrieve a ribbon definition. Required.</returns>
    public string EntityName
    {
      get
      {
        return this.Parameters.Contains(nameof (EntityName)) ? (string) this.Parameters[nameof (EntityName)] : (string) null;
      }
      set
      {
        this.Parameters[nameof (EntityName)] = (object) value;
      }
    }

    /// <summary>Gets or sets a filter to retrieve a specific set of ribbon definitions for an entity. Required.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Crm.Sdk.Messages.RibbonLocationFilters"></see>A filter to retrieve a specific set of ribbon definitions for an entity. Required.</returns>
    public RibbonLocationFilters RibbonLocationFilter
    {
      get
      {
        return this.Parameters.Contains(nameof (RibbonLocationFilter)) ? (RibbonLocationFilters) this.Parameters[nameof (RibbonLocationFilter)] : (RibbonLocationFilters) 0;
      }
      set
      {
        this.Parameters[nameof (RibbonLocationFilter)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Crm.Sdk.Messages.RetrieveEntityRibbonRequest"></see> class.</summary>
    public RetrieveEntityRibbonRequest()
    {
      this.RequestName = "RetrieveEntityRibbon";
      this.EntityName = (string) null;
      this.RibbonLocationFilter = (RibbonLocationFilters) 0;
    }
  }
}
