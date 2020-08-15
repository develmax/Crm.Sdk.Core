using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  find a parent resource group (scheduling group) for the specified resource groups (scheduling groups).</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class FindParentResourceGroupRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the ID of the parent resource group.</summary>
    /// <returns>Type: Returns_GuidThe ID of the parent resource group. This corresponds to the ResourceGroup.ResourceGroupId attribute, which is the primary key for the ResourceGroup entity.</returns>
    public Guid ParentId
    {
      get
      {
        return this.Parameters.Contains(nameof (ParentId)) ? (Guid) this.Parameters[nameof (ParentId)] : new Guid();
      }
      set
      {
        this.Parameters[nameof (ParentId)] = (object) value;
      }
    }

    /// <summary>Gets or sets an array of IDs of the children resource groups.</summary>
    /// <returns>Type: Returns_Guid[]The array of IDs of the children resource groups.</returns>
    public Guid[] ChildrenIds
    {
      get
      {
        return this.Parameters.Contains(nameof (ChildrenIds)) ? (Guid[]) this.Parameters[nameof (ChildrenIds)] : (Guid[]) null;
      }
      set
      {
        this.Parameters[nameof (ChildrenIds)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.FindParentResourceGroupRequest"></see> class.</summary>
    public FindParentResourceGroupRequest()
    {
      this.RequestName = "FindParentResourceGroup";
      this.ParentId = new Guid();
      this.ChildrenIds = (Guid[]) null;
    }
  }
}
