using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to set localized labels for a limited set of entity attributes.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class SetLocLabelsRequest : OrganizationRequest
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

    /// <summary>Gets or sets the name of the attribute. Required.</summary>
    /// <returns>Type: Returns_StringThe name of the attribute. Required.</returns>
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

    /// <summary>Gets or sets the label. Required.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.LocalizedLabel"></see>The label.</returns>
    public LocalizedLabel[] Labels
    {
      get
      {
        return this.Parameters.Contains(nameof (Labels)) ? (LocalizedLabel[]) this.Parameters[nameof (Labels)] : (LocalizedLabel[]) null;
      }
      set
      {
        this.Parameters[nameof (Labels)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.SetLocLabelsRequest"></see> class</summary>
    public SetLocLabelsRequest()
    {
      this.RequestName = "SetLocLabels";
      this.EntityMoniker = (EntityReference) null;
      this.AttributeName = (string) null;
      this.Labels = (LocalizedLabel[]) null;
    }
  }
}
