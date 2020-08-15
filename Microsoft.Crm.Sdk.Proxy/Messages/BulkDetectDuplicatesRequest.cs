using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to submit an asynchronous system job that detects and logs multiple duplicate records.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class BulkDetectDuplicatesRequest : OrganizationRequest
  {
    /// <summary>Gets or sets  the query criteria for detecting multiple duplicate records. Required.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Query.QueryExpression"></see>The query criteria for detecting multiple duplicate records.</returns>
    public QueryBase Query
    {
      get
      {
        return this.Parameters.Contains(nameof (Query)) ? (QueryBase) this.Parameters[nameof (Query)] : (QueryBase) null;
      }
      set
      {
        this.Parameters[nameof (Query)] = (object) value;
      }
    }

    /// <summary>Gets or sets the name of the asynchronous system job that detects and logs multiple duplicate records. Required.</summary>
    /// <returns>Type: Returns_StringThe name of the asynchronous system job that detects and logs multiple duplicate records. </returns>
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

    /// <summary>Gets or sets a value that indicates whether an email notification is sent after the asynchronous system job that detects multiple duplicate records finishes running. Required.</summary>
    /// <returns>Type: Returns_Booleantrue if an email notification should be sent after the job to detect multiple duplicate records is finished running or has failed; otherwise, false.</returns>
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

    /// <summary>Sets the ID of the template (email template) that is used for the email notification. </summary>
    /// <returns>Type: Returns_GuidThe ID of the template (email template) that is used for the email notification that corresponds to the TemplateId attribute, which is the primary key for the Template entity..</returns>
    public Guid TemplateId
    {
      get
      {
        return this.Parameters.Contains(nameof (TemplateId)) ? (Guid) this.Parameters[nameof (TemplateId)] : new Guid();
      }
      set
      {
        this.Parameters[nameof (TemplateId)] = (object) value;
      }
    }

    /// <summary>Gets or sets an array of IDs for the system users (users) who are listed in the To box of the email notification. </summary>
    /// <returns>Type: Returns_Guid[] The array of IDs for the system users (users) who are listed in the To box of the email notification. </returns>
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

    /// <summary>Gets or sets an array of IDs for the system users (users) who are listed in the Cc box of the email notification. </summary>
    /// <returns>Type: Returns_Guid[]The array of IDs for the system users (users) who are listed in the Cc box of the email notification.</returns>
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

    /// <summary>Gets or sets the recurrence pattern for the asynchronous system job that detects multiple duplicate records. Optional.</summary>
    /// <returns>Type: Returns_StringThe recurrence pattern for the asynchronous system job that detects multiple duplicate records.</returns>
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

    /// <summary>Gets or sets the start date and time of an asynchronous system job that detects and logs multiple duplicate records. Optional.</summary>
    /// <returns>Type: Returns_DateTimeThe start date and time of an asynchronous system job that detects and logs multiple duplicate record.</returns>
    public DateTime RecurrenceStartTime
    {
      get
      {
        return this.Parameters.Contains(nameof (RecurrenceStartTime)) ? (DateTime) this.Parameters[nameof (RecurrenceStartTime)] : new DateTime();
      }
      set
      {
        this.Parameters[nameof (RecurrenceStartTime)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Crm.Sdk.Messages.BulkDetectDuplicatesRequest"></see> class.</summary>
    public BulkDetectDuplicatesRequest()
    {
      this.RequestName = "BulkDetectDuplicates";
      this.Query = (QueryBase) null;
      this.JobName = (string) null;
      this.SendEmailNotification = false;
      this.TemplateId = new Guid();
      this.ToRecipients = (Guid[]) null;
      this.CCRecipients = (Guid[]) null;
      this.RecurrencePattern = (string) null;
      this.RecurrenceStartTime = new DateTime();
    }
  }
}
