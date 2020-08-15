using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to retrieve localized labels for a limited set of entity attributes.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RetrieveLocLabelsRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the entity. Required.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.EntityReference"></see>The entity. Required.</returns>
    public EntityReference EntityMoniker
    {
      get
      {
        return this.Parameters.Contains(nameof (EntityMoniker)) ? (EntityReference) this.Parameters[nameof (EntityMoniker)] : (EntityReference) null;
      }
      set
      {
        this.Parameters[nameof (EntityMoniker)] = (object) value;
      }
    }

    /// <summary>Gets or sets the name of the attribute for which to retrieve the localized labels. Required.</summary>
    /// <returns>Type: Returns_StringThe name of the attribute for which to retrieve the localized labels. Required.</returns>
    public string AttributeName
    {
      get
      {
        return this.Parameters.Contains(nameof (AttributeName)) ? (string) this.Parameters[nameof (AttributeName)] : (string) null;
      }
      set
      {
        this.Parameters[nameof (AttributeName)] = (object) value;
      }
    }

    /// <summary>Gets or sets whether to include unpublished labels. Required.</summary>
    /// <returns>Type: Returns_Booleantrue if unpublished labels should be included; otherwise, false.</returns>
    public bool IncludeUnpublished
    {
      get
      {
        return this.Parameters.Contains(nameof (IncludeUnpublished)) && (bool) this.Parameters[nameof (IncludeUnpublished)];
      }
      set
      {
        this.Parameters[nameof (IncludeUnpublished)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.RetrieveLocLabelsRequest"></see> class.</summary>
    public RetrieveLocLabelsRequest()
    {
      this.RequestName = "RetrieveLocLabels";
      this.EntityMoniker = (EntityReference) null;
      this.AttributeName = (string) null;
      this.IncludeUnpublished = false;
    }
  }
}
