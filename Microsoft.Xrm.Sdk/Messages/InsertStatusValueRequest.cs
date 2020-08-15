using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  insert a new option into a <see cref="T:Microsoft.Xrm.Sdk.Metadata.StatusAttributeMetadata"></see> attribute. </summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class InsertStatusValueRequest : OrganizationRequest
  {
    /// <summary>Reserved for future use. Optional.</summary>
    /// <returns>Type: Returns_StringReserved for future use. Optional.</returns>
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

    /// <summary>Gets or sets the logical name of the status attribute. Optional.</summary>
    /// <returns>Type: Returns_StringThe logical name of the status attribute. Optional.</returns>
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

    /// <summary>Gets or sets the logical name of the entity that contains the attribute. Optional.</summary>
    /// <returns>Type: Returns_StringThe logical name of the entity that contains the attribute. Optional.</returns>
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

    /// <summary>Gets or sets the value for the new status. Optional.</summary>
    /// <returns>Type: Returns_Nullable&lt;Returns_Int32&gt;the value for the new status. Optional.</returns>
    public int? Value
    {
      get
      {
        return this.Parameters.Contains(nameof (Value)) ? (int?) this.Parameters[nameof (Value)] : new int?();
      }
      set
      {
        this.Parameters[nameof (Value)] = (object) value;
      }
    }

    /// <summary>Gets or sets the label for the new status. Required.</summary>
    /// <returns>Type:  <see cref="T:Microsoft.Xrm.Sdk.Label"></see>The label for the new status. Required..</returns>
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

    /// <summary>Gets or sets a description for the option. Optional.</summary>
    /// <returns>Type:  <see cref="T:Microsoft.Xrm.Sdk.Label"></see>The description for the option. Optional.</returns>
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

    /// <summary>Gets or sets the state code for the new status. Required.</summary>
    /// <returns>Type: Returns_Int32The state code for the new status. Required.</returns>
    public int StateCode
    {
      get
      {
        return this.Parameters.Contains(nameof (StateCode)) ? (int) this.Parameters[nameof (StateCode)] : 0;
      }
      set
      {
        this.Parameters[nameof (StateCode)] = (object) value;
      }
    }

    /// <summary>Gets or sets the solution that this attribute should be added to. Optional.</summary>
    /// <returns>Type: Returns_StringThe solution that this attribute should be added to. Optional.</returns>
    public string SolutionUniqueName
    {
      get
      {
        return this.Parameters.Contains(nameof (SolutionUniqueName)) ? (string) this.Parameters[nameof (SolutionUniqueName)] : (string) null;
      }
      set
      {
        this.Parameters[nameof (SolutionUniqueName)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Xrm.Sdk.Messages.InsertStatusValueRequest"></see> class</summary>
    public InsertStatusValueRequest()
    {
      this.RequestName = "InsertStatusValue";
      this.Label = (Label) null;
      this.StateCode = 0;
    }
  }
}
