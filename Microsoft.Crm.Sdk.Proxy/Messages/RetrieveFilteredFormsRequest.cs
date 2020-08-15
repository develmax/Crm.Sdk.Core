using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to retrieve the entity forms that are available for a specified user. </summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RetrieveFilteredFormsRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the logical name for the entity. Required.</summary>
    /// <returns>Type: Returns_StringThe logical name for the entity. Required.</returns>
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

    /// <summary>Gets or sets the type of form. Required.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.OptionSetValue"></see>The type of form. Required.</returns>
    public OptionSetValue FormType
    {
      get
      {
        return this.Parameters.Contains(nameof (FormType)) ? (OptionSetValue) this.Parameters[nameof (FormType)] : (OptionSetValue) null;
      }
      set
      {
        this.Parameters[nameof (FormType)] = (object) value;
      }
    }

    /// <summary>Gets or sets the ID of the user. Required.</summary>
    /// <returns>Type: Returns_GuidThe ID of the user. This corresponds to the SystemUser.SystemUserId attribute, which is the primary key for the SystemUser entity.</returns>
    public Guid SystemUserId
    {
      get
      {
        return this.Parameters.Contains(nameof (SystemUserId)) ? (Guid) this.Parameters[nameof (SystemUserId)] : new Guid();
      }
      set
      {
        this.Parameters[nameof (SystemUserId)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.RetrieveFilteredFormsRequest"></see> class.</summary>
    public RetrieveFilteredFormsRequest()
    {
      this.RequestName = "RetrieveFilteredForms";
      this.EntityLogicalName = (string) null;
      this.FormType = (OptionSetValue) null;
      this.SystemUserId = new Guid();
    }
  }
}
