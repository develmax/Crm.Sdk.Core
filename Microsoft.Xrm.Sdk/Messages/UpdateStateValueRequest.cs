using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  update an option set value in for a <see cref="T:Microsoft.Xrm.Sdk.Metadata.StateAttributeMetadata"></see> attribute.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class UpdateStateValueRequest : OrganizationRequest
  {
    /// <summary>internal</summary>
    /// <returns>Type: Returns_Stringinternal</returns>
    public string OptionSetName
    {
      get
      {
        return this.Parameters.Contains(nameof (OptionSetName)) ? (string) this.Parameters[nameof (OptionSetName)] : (string) null;
      }
      set
      {
        this.Parameters[nameof (OptionSetName)] = (object) value;
      }
    }

    /// <summary>Gets or sets the logical name of the attribute. Optional.</summary>
    /// <returns>Type: Returns_StringThe logical name of the attribute. Optional.</returns>
    public string AttributeLogicalName
    {
      get
      {
        return this.Parameters.Contains(nameof (AttributeLogicalName)) ? (string) this.Parameters[nameof (AttributeLogicalName)] : (string) null;
      }
      set
      {
        this.Parameters[nameof (AttributeLogicalName)] = (object) value;
      }
    }

    /// <summary>Gets or sets the name of the entity that has this statecode attribute. Optional.</summary>
    /// <returns>Type: Returns_StringThe name of the entity that has this statecode attribute. Optional.</returns>
    public string EntityLogicalName
    {
      get
      {
        return this.Parameters.Contains(nameof (EntityLogicalName)) ? (string) this.Parameters[nameof (EntityLogicalName)] : (string) null;
      }
      set
      {
        this.Parameters[nameof (EntityLogicalName)] = (object) value;
      }
    }

    /// <summary>Gets or sets the statecode attribute options to update. Required.</summary>
    /// <returns>Type: Returns_Int32The statecode attribute options to update. Required.</returns>
    public int Value
    {
      get
      {
        return this.Parameters.Contains(nameof (Value)) ? (int) this.Parameters[nameof (Value)] : 0;
      }
      set
      {
        this.Parameters[nameof (Value)] = (object) value;
      }
    }

    /// <summary>Gets or sets the display label for this statecode option that is specified by the <see cref="P:Microsoft.Xrm.Sdk.Messages.UpdateStateValueRequest.Value"></see> property. Optional.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Label"></see>The display label for this statecode option that is specified by the <see cref="P:Microsoft.Xrm.Sdk.Messages.UpdateStateValueRequest.Value"></see> property. Optional.</returns>
    public Label Label
    {
      get
      {
        return this.Parameters.Contains(nameof (Label)) ? (Label) this.Parameters[nameof (Label)] : (Label) null;
      }
      set
      {
        this.Parameters[nameof (Label)] = (object) value;
      }
    }

    /// <summary>Gets or sets the description label for the statecode option that is specified in the <see cref="P:Microsoft.Xrm.Sdk.Messages.UpdateStateValueRequest.Value"></see> property. Optional.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Label"></see>the description label for the statecode option that is specified in the <see cref="P:Microsoft.Xrm.Sdk.Messages.UpdateStateValueRequest.Value"></see> property. Optional.</returns>
    public Label Description
    {
      get
      {
        return this.Parameters.Contains(nameof (Description)) ? (Label) this.Parameters[nameof (Description)] : (Label) null;
      }
      set
      {
        this.Parameters[nameof (Description)] = (object) value;
      }
    }

    /// <summary>Gets or sets whether to merge the current label with any existing labels that are already specified for this attribute. Required.</summary>
    /// <returns>Type:  Returns_Booleantrue if any newly defined labels should only overwrite existing labels when their language code matches; otherwise, false.</returns>
    public bool MergeLabels
    {
      get
      {
        return this.Parameters.Contains(nameof (MergeLabels)) && (bool) this.Parameters[nameof (MergeLabels)];
      }
      set
      {
        this.Parameters[nameof (MergeLabels)] = (object) value;
      }
    }

    /// <summary>Gets or sets the default value for the statuscode (status reason) attribute when this statecode value is set. Optional.</summary>
    /// <returns>Type: Returns_Nullable&lt;Returns_Int32&gt;The default value for the statuscode (status reason) attribute when this statecode value is set. Optional.</returns>
    public int? DefaultStatusCode
    {
      get
      {
        return this.Parameters.Contains(nameof (DefaultStatusCode)) ? (int?) this.Parameters[nameof (DefaultStatusCode)] : new int?();
      }
      set
      {
        this.Parameters[nameof (DefaultStatusCode)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Xrm.Sdk.Messages.UpdateStateValueRequest"></see> class.</summary>
    public UpdateStateValueRequest()
    {
      this.RequestName = "UpdateStateValue";
      this.Value = 0;
      this.MergeLabels = false;
    }
  }
}
