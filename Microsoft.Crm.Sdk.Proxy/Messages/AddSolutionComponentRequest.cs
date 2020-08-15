using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to add a solution component to an unmanaged solution.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class AddSolutionComponentRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the ID of the solution component. Required.</summary>
    /// <returns>Type: Returns_Guid
    /// The ID of the solution component.</returns>
    public Guid ComponentId
    {
      get
      {
        return this.Parameters.Contains(nameof (ComponentId)) ? (Guid) this.Parameters[nameof (ComponentId)] : new Guid();
      }
      set
      {
        this.Parameters[nameof (ComponentId)] = (object) value;
      }
    }

    /// <summary>Gets or sets the value that represents the solution component that you are adding. Required.</summary>
    /// <returns>Type: Returns_Int32
    /// The integer value of the componenttype enumeration.</returns>
    public int ComponentType
    {
      get
      {
        return this.Parameters.Contains(nameof (ComponentType)) ? (int) this.Parameters[nameof (ComponentType)] : 0;
      }
      set
      {
        this.Parameters[nameof (ComponentType)] = (object) value;
      }
    }

    /// <summary>Gets or sets the unique name of the solution you are adding the solution component to. Required. </summary>
    /// <returns>Type: Returns_String
    /// The unique name of the solution you are adding the solution component to.</returns>
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

    /// <summary>Gets or sets a value that indicates whether other solution components that are required by the solution component that you are adding should also be added to the unmanaged solution. Required.</summary>
    /// <returns>Type: Returns_Booleantrue if the components that are required by the solution component you are adding should also be added to the unmanaged solution; otherwise, false.</returns>
    public bool AddRequiredComponents
    {
      get
      {
        return this.Parameters.Contains(nameof (AddRequiredComponents)) && (bool) this.Parameters[nameof (AddRequiredComponents)];
      }
      set
      {
        this.Parameters[nameof (AddRequiredComponents)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.AddSolutionComponentRequest"></see> class.</summary>
    public AddSolutionComponentRequest()
    {
      this.RequestName = "AddSolutionComponent";
      this.ComponentId = new Guid();
      this.ComponentType = 0;
      this.SolutionUniqueName = (string) null;
      this.AddRequiredComponents = false;
    }
  }
}
