using System;
using System.Runtime.Serialization;
using System.Security;

namespace Microsoft.Xrm.Sdk
{
  /// <summary>Represents an exception that occurred during plug-in execution.</summary>
  [Serializable]
  public sealed class InvalidPluginExecutionException : Exception, ISerializable
  {
    private OperationStatus _status;

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.InvalidPluginExecutionException"></see> class.</summary>
    public InvalidPluginExecutionException()
    {
      this._status = OperationStatus.Failed;
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.InvalidPluginExecutionException"></see> class with an operation status.</summary>
    /// <param name="status">Type: <see cref="T:Microsoft.Xrm.Sdk.OperationStatus"></see>. The status of the operation.</param>
    public InvalidPluginExecutionException(OperationStatus status)
      : this(status, string.Empty)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.InvalidPluginExecutionException"></see> class with an error message.</summary>
    /// <param name="message">Type: Returns_String. The error message that explains the reason for the exception.</param>
    public InvalidPluginExecutionException(string message)
      : base(message)
    {
      this._status = OperationStatus.Failed;
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.InvalidPluginExecutionException"></see> class with an operation status and an error message.</summary>
    /// <param name="message">Type: Returns_String. The error message that explains the reason for the exception.</param>
    /// <param name="status">Type: <see cref="T:Microsoft.Xrm.Sdk.OperationStatus"></see>. The status of the operation.</param>
    public InvalidPluginExecutionException(OperationStatus status, string message)
      : this(status, 0, message)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.InvalidPluginExecutionException"></see> class with a reference to the inner exception that is the cause of this exception.</summary>
    /// <param name="exception">Type: Returns_Exception. The inner exception that is the cause of this exception.</param>
    /// <param name="message">Type: Returns_String. The error message that explains the reason for the exception.</param>
    public InvalidPluginExecutionException(string message, Exception exception)
      : base(message, exception)
    {
      this._status = OperationStatus.Failed;
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.InvalidPluginExecutionException"></see> class with an operation status, an error code, and an error message.</summary>
    /// <param name="message">Type: Returns_String. The error message that explains the reason for the exception. </param>
    /// <param name="status">Type: <see cref="T:Microsoft.Xrm.Sdk.OperationStatus"></see>. The status of the operation.</param>
    /// <param name="errorCode">Type: Returns_Int32. The error code that identifies the specific error.</param>
    public InvalidPluginExecutionException(OperationStatus status, int errorCode, string message)
      : this(message)
    {
      this._status = status;
      if (errorCode == 0)
        return;
      this.HResult = errorCode;
    }

    private InvalidPluginExecutionException(SerializationInfo info, StreamingContext context)
      : base(info, context)
    {
      this._status = (OperationStatus) info.GetValue(nameof (Status), typeof (OperationStatus));
    }

    /// <summary>Gets the status of the plug-in exception.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.OperationStatus"></see>The status of the plug-in exception.</returns>
    public OperationStatus Status
    {
      get
      {
        return this._status;
      }
    }

    /// <summary>Gets the numeric code that identifies a specific error condition.</summary>
    /// <returns>Type: Returns_Int32The error code.</returns>
    public int ErrorCode
    {
      get
      {
        return this.HResult;
      }
    }

    /// <summary>Sets the SerializationInfohttp://msdn.microsoft.com/en-us/library/system.runtime.serialization.serializationinfo.aspx with information about the exception.</summary>
    /// <param name="context">Type: StreamingContexthttp://msdn.microsoft.com/en-us/library/system.runtime.serialization.streamingcontext.aspx. The contextual information about the source or destination.</param>
    /// <param name="info">Type:  SerializationInfohttp://msdn.microsoft.com/en-us/library/system.runtime.serialization.serializationinfo.aspx. The serialized object data about the exception being thrown.</param>
    [SecurityCritical]
    public override void GetObjectData(SerializationInfo info, StreamingContext context)
    {
      if (info == null)
        throw new ArgumentNullException(nameof (info));
      info.AddValue("Status", (object) this._status, typeof (OperationStatus));
      base.GetObjectData(info, context);
    }
  }
}
