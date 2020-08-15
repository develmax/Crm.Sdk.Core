using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  delete an option value in a global or local option set.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class DeleteOptionValueRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the name of the option set that contains the value. Optional.</summary>
    /// <returns>Type: Returns_StringThe name of the option set that contains the value. Optional.</returns>
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

    /// <summary>Gets or sets the logical name of the attribute from which to delete the option value. Optional.</summary>
    /// <returns>Type: Returns_StringThe logical name of the attribute from which to delete the option value. Optional.</returns>
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

    /// <summary>Gets or sets the value of the option to delete. Required.</summary>
    /// <returns>Type: Returns_Int32The value of the option to delete. Required.</returns>
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

    /// <summary>Gets or sets the solution name associated with this option value. Optional.</summary>
    /// <returns>Type: Returns_StringThe solution name associated with this option value. Optional.</returns>
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

    /// <summary>constructor_initializes<see cref="T:Microsoft.Xrm.Sdk.Messages.DeleteOptionValueRequest"></see> class</summary>
    public DeleteOptionValueRequest()
    {
      this.RequestName = "DeleteOptionValue";
      this.Value = 0;
    }
  }
}
