using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  set the order for an option set. </summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class OrderOptionRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the name of the global option set you want to edit options for. Optional.</summary>
    /// <returns>Type: Returns_StringThe name of the global option set you want to edit options for. Optional.</returns>
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

    /// <summary>Gets or sets the logical name of the <see cref="T:Microsoft.Xrm.Sdk.Metadata.PicklistAttributeMetadata"></see> attribute. Optional.</summary>
    /// <returns>Type: Returns_StringThe logical name of the <see cref="T:Microsoft.Xrm.Sdk.Metadata.PicklistAttributeMetadata"></see> attribute. Optional.</returns>
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

    /// <summary>Gets or sets the array of option values in the wanted order. Required.</summary>
    /// <returns>Type: Returns_Int32The array of option values in the wanted order. Required.</returns>
    public int[] Values
    {
      get
      {
        return this.Parameters.Contains(nameof (Values)) ? (int[]) this.Parameters[nameof (Values)] : (int[]) null;
      }
      set
      {
        this.Parameters[nameof (Values)] = (object) value;
      }
    }

    /// <summary>Gets or sets the name of the solution you want to add the solution component to. Optional.</summary>
    /// <returns>Type: Returns_StringThe name of the solution you want to add the solution component to. Optional.</returns>
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

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Xrm.Sdk.Messages.OrderOptionRequest"></see> class</summary>
    public OrderOptionRequest()
    {
      this.RequestName = "OrderOption";
      this.Values = (int[]) null;
    }
  }
}
