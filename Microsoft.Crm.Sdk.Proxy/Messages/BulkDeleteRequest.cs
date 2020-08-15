using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to submit a bulk delete job that deletes selected records in bulk. This job runs asynchronously in the background without blocking other activities.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class BulkDeleteRequest : OrganizationRequest
  {
    /// <summary>Gets or sets an array of queries for a bulk delete job. Required.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Query.QueryExpression"></see>The array of queries for a bulk delete job.</returns>
    public QueryExpression[] QuerySet
    {
      get
      {
        return this.Parameters.Contains(nameof (QuerySet)) ? (QueryExpression[]) this.Parameters[nameof (QuerySet)] : (QueryExpression[]) null;
      }
      set
      {
        this.Parameters[nameof (QuerySet)] = (object) value;
      }
    }

    /// <summary>Gets or sets the name of an asynchronous bulk delete job. Required.</summary>
    /// <returns>Type: Returns_StringThe name of the asynchronous bulk delete job.</returns>
    public string JobName
    {
      get
      {
        return this.Parameters.Contains(nameof (JobName)) ? (string) this.Parameters[nameof (JobName)] : (string) null;
      }
      set
      {
        this.Parameters[nameof (JobName)] = (object) value;
      }
    }

    /// <summary>Gets or sets a value that indicates whether an email notification is sent after the bulk delete job has finished running. Required.</summary>
    /// <returns> Type: Returns_Booleantrue if an email notification should be sent after the bulk deletion is finished or has failed; otherwise, false.</returns>
    public bool SendEmailNotification
    {
      get
      {
        return this.Parameters.Contains(nameof (SendEmailNotification)) && (bool) this.Parameters[nameof (SendEmailNotification)];
      }
      set
      {
        this.Parameters[nameof (SendEmailNotification)] = (object) value;
      }
    }

    /// <summary>Gets or sets an array of IDs for the system users (users) who are listed in the To box of an email notification. Required.</summary>
    /// <returns>Type: Returns_Guid[] The array of IDs for the system users (users) who are listed in the To box of an email notification.</returns>
    public Guid[] ToRecipients
    {
      get
      {
        return this.Parameters.Contains(nameof (ToRecipients)) ? (Guid[]) this.Parameters[nameof (ToRecipients)] : (Guid[]) null;
      }
      set
      {
        this.Parameters[nameof (ToRecipients)] = (object) value;
      }
    }

    /// <summary>Gets or sets an array of IDs for the system users (users) who are listed in the Cc box of the email notification. Required.</summary>
    /// <returns>Type: Returns_Guid[] The array of IDs for the system users (users) who are listed in the Cc box of the email notification. </returns>
    public Guid[] CCRecipients
    {
      get
      {
        return this.Parameters.Contains(nameof (CCRecipients)) ? (Guid[]) this.Parameters[nameof (CCRecipients)] : (Guid[]) null;
      }
      set
      {
        this.Parameters[nameof (CCRecipients)] = (object) value;
      }
    }

    /// <summary>Gets or sets the recurrence pattern for the bulk delete job. Optional.</summary>
    /// <returns>Type: Returns_StringThe recurrence pattern for the bulk delete job.</returns>
    public string RecurrencePattern
    {
      get
      {
        return this.Parameters.Contains(nameof (RecurrencePattern)) ? (string) this.Parameters[nameof (RecurrencePattern)] : (string) null;
      }
      set
      {
        this.Parameters[nameof (RecurrencePattern)] = (object) value;
      }
    }

    /// <summary>Gets or sets the start date and time to run a bulk delete job. Optional.</summary>
    /// <returns>Type: Returns_DateTimeThe start date and time to run a bulk delete job.</returns>
    public DateTime StartDateTime
    {
      get
      {
        return this.Parameters.Contains(nameof (StartDateTime)) ? (DateTime) this.Parameters[nameof (StartDateTime)] : new DateTime();
      }
      set
      {
        this.Parameters[nameof (StartDateTime)] = (object) value;
      }
    }

    /// <summary>Gets or sets the ID of the data import job. Optional.</summary>
    /// <returns>Type: Returns_Nullable&lt;Returns_Guid&gt; The ID of the data import job that corresponds to the ImportrId property, which is the primary key for the Import entity.</returns>
    public Guid? SourceImportId
    {
      get
      {
        return this.Parameters.Contains(nameof (SourceImportId)) ? (Guid?) this.Parameters[nameof (SourceImportId)] : new Guid?();
      }
      set
      {
        this.Parameters[nameof (SourceImportId)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.BulkDeleteRequest"></see> class.</summary>
    public BulkDeleteRequest()
    {
      this.RequestName = "BulkDelete";
      this.QuerySet = (QueryExpression[]) null;
      this.JobName = (string) null;
      this.SendEmailNotification = false;
      this.ToRecipients = (Guid[]) null;
      this.CCRecipients = (Guid[]) null;
      this.RecurrencePattern = (string) null;
      this.StartDateTime = new DateTime();
    }
  }
}
