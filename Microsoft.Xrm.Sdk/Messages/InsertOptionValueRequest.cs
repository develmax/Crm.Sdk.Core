using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  insert a new option value for a global or local option set. </summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class InsertOptionValueRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the name of the global option set. Optional.</summary>
    /// <returns>Type: Returns_StringThe name of the global option set. Optional.</returns>
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

    /// <summary>Gets or sets the name of the attribute when updating a local option set in a picklist attribute. Optional.</summary>
    /// <returns>Type: Returns_StringThe name of the attribute when updating a local option set in a picklist attribute. Optional.</returns>
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

    /// <summary>Gets or sets the logical name of the entity when updating the local option set in a picklist attribute. Optional.</summary>
    /// <returns>Type: Returns_StringThe logical name of the entity when updating the local option set in a picklist attribute. Optional.</returns>
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

    /// <summary>Gets or sets the value for the option. Optional.</summary>
    /// <returns>Type: Returns_Nullable&lt;Returns_Int32&gt;The value for the option. Optional.</returns>
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

    /// <summary>Gets or sets the label for the option. Required.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Label"></see>The label for the option. Required..</returns>
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
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Label"></see>A description for the option.</returns>
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

    /// <summary>Gets or sets the unique name of the unmanaged solution when updating a global option set. Optional.</summary>
    /// <returns>Type: Returns_StringThe unique name of the unmanaged solution when updating a global option set. Optional.</returns>
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

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Xrm.Sdk.Messages.InsertOptionValueRequest"></see> class</summary>
    public InsertOptionValueRequest()
    {
      this.RequestName = "InsertOptionValue";
      this.Label = (Label) null;
    }
  }
}
