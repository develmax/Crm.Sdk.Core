using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  create an exception for the recurring appointment instance.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class CreateExceptionRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the target appointment for the exception.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Entity"></see>The target appointment for the exception. This must be an entity reference for an appointment entity.</returns>
    public Entity Target
    {
      get
      {
        return this.Parameters.Contains(nameof (Target)) ? (Entity) this.Parameters[nameof (Target)] : (Entity) null;
      }
      set
      {
        this.Parameters[nameof (Target)] = (object) value;
      }
    }

    /// <summary>Gets or sets the original start date of the recurring appointment.</summary>
    /// <returns>Type:  Returns_DateTimeThe original start date of the recurring appointment.</returns>
    public DateTime OriginalStartDate
    {
      get
      {
        return this.Parameters.Contains(nameof (OriginalStartDate)) ? (DateTime) this.Parameters[nameof (OriginalStartDate)] : new DateTime();
      }
      set
      {
        this.Parameters[nameof (OriginalStartDate)] = (object) value;
      }
    }

    /// <summary>Gets or sets whether the appointment instance is deleted. </summary>
    /// <returns>Type:  Returns_BooleanIndicates if the appointment instance is deleted. true, if deleted, otherwise, false.</returns>
    public bool IsDeleted
    {
      get
      {
        return this.Parameters.Contains(nameof (IsDeleted)) && (bool) this.Parameters[nameof (IsDeleted)];
      }
      set
      {
        this.Parameters[nameof (IsDeleted)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Crm.Sdk.Messages.CreateExceptionRequest"></see> class.</summary>
    public CreateExceptionRequest()
    {
      this.RequestName = "CreateException";
      this.Target = (Entity) null;
      this.OriginalStartDate = new DateTime();
      this.IsDeleted = false;
    }
  }
}
