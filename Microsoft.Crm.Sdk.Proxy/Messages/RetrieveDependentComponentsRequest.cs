using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  retrieves a list dependencies for solution components that directly depend on a solution component.  </summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RetrieveDependentComponentsRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the ID of the solution component that you want to check. Required.</summary>
    /// <returns>Type: Returns_GuidThe ID of the solution component that you want to check. This corresponds to the SolutionComponent.SolutionComponentId attribute, which is the primary key for the SolutionComponent entity.</returns>
    public Guid ObjectId
    {
      get
      {
        return this.Parameters.Contains(nameof (ObjectId)) ? (Guid) this.Parameters[nameof (ObjectId)] : new Guid();
      }
      set
      {
        this.Parameters[nameof (ObjectId)] = (object) value;
      }
    }

    /// <summary>Gets or sets the value that represents the solution component. Required.</summary>
    /// <returns>Type: Returns_Int32The value that represents the solution component. Required.</returns>
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

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Crm.Sdk.Messages.RetrieveDependentComponentsRequest"></see> class.</summary>
    public RetrieveDependentComponentsRequest()
    {
      this.RequestName = "RetrieveDependentComponents";
      this.ObjectId = new Guid();
      this.ComponentType = 0;
    }
  }
}
