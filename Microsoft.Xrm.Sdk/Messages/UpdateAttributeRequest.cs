using Microsoft.Xrm.Sdk.Metadata;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  update the definition of an attribute. </summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class UpdateAttributeRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the attribute metadata to be updated. Required.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Metadata.AttributeMetadata"></see>The attribute metadata to be updated. Required.</returns>
    public AttributeMetadata Attribute
    {
      get
      {
        return this.Parameters.Contains(nameof (Attribute)) ? (AttributeMetadata) this.Parameters[nameof (Attribute)] : (AttributeMetadata) null;
      }
      set
      {
        this.Parameters[nameof (Attribute)] = (object) value;
      }
    }

    /// <summary>Gets or sets the logical name of the entity to which the attribute belongs. Required.</summary>
    /// <returns>Type: Returns_StringThe logical name of the entity to which the attribute belongs. Required.</returns>
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

    /// <summary>Gets or sets whether the label metadata will be merged or overwritten. Required.</summary>
    /// <returns>Type: Returns_Booleantrue if the label metadata will be merged or overwritten; otherwise, false.</returns>
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

    /// <summary>Gets or sets the name of the solution to associate the entity with. Optional.</summary>
    /// <returns>Type: Returns_StringThe name of the solution to associate the entity with. Optional.</returns>
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

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Xrm.Sdk.Messages.UpdateAttributeRequest"></see> class</summary>
    public UpdateAttributeRequest()
    {
      this.RequestName = "UpdateAttribute";
      this.Attribute = (AttributeMetadata) null;
      this.EntityName = (string) null;
      this.MergeLabels = false;
    }
  }
}
