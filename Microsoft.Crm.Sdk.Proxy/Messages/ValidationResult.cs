using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the result from the <see cref="T:Microsoft.Crm.Sdk.Messages.ValidateRequest"></see>, <see cref="T:Microsoft.Crm.Sdk.Messages.BookRequest"></see>, or <see cref="T:Microsoft.Crm.Sdk.Messages.RescheduleRequest"></see> messages.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class ValidationResult : IExtensibleDataObject
  {
    private ExtensionDataObject _extensionDataObject;

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Crm.Sdk.Messages.ValidationResult"></see> class.</summary>
    public ValidationResult()
    {
      this.ValidationSuccess = false;
      this.TraceInfo = (TraceInfo) null;
    }

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Crm.Sdk.Messages.ValidationResult"></see> class, setting the success, traceinfo and activityid properties.</summary>
    /// <param name="success">Type: Returns_Boolean. The value that indicates whether the appointment or service appointment was validated successfully.</param>
    /// <param name="activityId">Type: Returns_Guid. The ID of the validated activity.</param>
    /// <param name="traceInfo">Type: <see cref="T:Microsoft.Crm.Sdk.Messages.TraceInfo"></see>. The reasons for any scheduling failures.</param>
    public ValidationResult(bool success, TraceInfo traceInfo, Guid activityId)
    {
      this.ValidationSuccess = success;
      this.TraceInfo = traceInfo;
      this.ActivityId = activityId;
    }

    /// <summary>Gets or sets the value that indicates whether the appointment or service appointment was validated successfully.</summary>
    /// <returns>Type: Returns_Booleantrue if the appointment or service appointment was validated successfully; otherwise, false.</returns>
    [DataMember]
    public bool ValidationSuccess { get; set; }

    /// <summary>Gets or sets the reasons for any scheduling failures.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Crm.Sdk.Messages.TraceInfo"></see>The reasons for any scheduling failures.</returns>
    [DataMember]
    public TraceInfo TraceInfo { get; set; }

    /// <summary>Gets or sets the ID of the validated activity.</summary>
    /// <returns>Type: Returns_Guid
    /// The ID of the validated activity. This corresponds to the ActivityPointer.ActivityPointerId attribute, which is the primary key for the ActivityPointer entity.</returns>
    [DataMember]
    public Guid ActivityId { get; set; }

    /// <summary>ExtensionData</summary>
    /// <returns>Type: Returns_ExtensionDataObjectThe extension data.</returns>
    public ExtensionDataObject ExtensionData
    {
      get
      {
        return this._extensionDataObject;
      }
      set
      {
        this._extensionDataObject = value;
      }
    }
  }
}
