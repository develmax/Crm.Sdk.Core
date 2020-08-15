using Microsoft.Xrm.Sdk.Metadata;
using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  create a new attribute, and optionally, to add it to a specified unmanaged solution.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class CreateAttributeRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the definition of the attribute type that you want to create. Required.</summary>
    /// <returns>Type:  <see cref="T:Microsoft.Xrm.Sdk.Metadata.AttributeMetadata"></see>The definition of the attribute type that you want to create. Required.</returns>
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

    /// <summary>Gets or sets the name of the entity for which you want to create an attribute. Required.</summary>
    /// <returns>Type: Returns_String
    /// The name of the entity for which you want to create an attribute. Required.</returns>
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

    /// <summary>Gets or sets the name of the unmanaged solution to which you want to add this attribute. Optional.</summary>
    /// <returns>Type: Returns_String
    /// The name of the unmanaged solution to which you want to add this attribute. Optional.</returns>
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

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Xrm.Sdk.Messages.CreateAttributeRequest"></see> class.</summary>
    public CreateAttributeRequest()
    {
      this.RequestName = "CreateAttribute";
      this.Attribute = (AttributeMetadata) null;
      this.EntityName = (string) null;
    }
  }
}
