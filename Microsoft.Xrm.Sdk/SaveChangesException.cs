using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security;

namespace Microsoft.Xrm.Sdk
{
  /// <summary>Represents an exception that occurred when saving changes to the <see cref="T:Microsoft.Xrm.Sdk.Client.OrganizationServiceContext"></see>.</summary>
  [Serializable]
  public sealed class SaveChangesException : Exception
  {
    private new const string _message = "An error occured while processing this request.";

    /// <summary>Gets the results from a <see cref="M:Microsoft.Xrm.Sdk.Client.OrganizationServiceContext.SaveChanges"></see> method call.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.SaveChangesResultCollection"></see>The collection of results.</returns>
    public SaveChangesResultCollection Results { get; private set; }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.SaveChangesException"></see> class.</summary>
    public SaveChangesException()
    {
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.SaveChangesException"></see> class with an error message.</summary>
    /// <param name="message">Type: Returns_String. The error message that explains the reason for the exception.</param>
    public SaveChangesException(string message)
      : base(message)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.SaveChangesException"></see> class with and error message and an inner exception.</summary>
    /// <param name="exception">Type: Returns_Exception. The inner exception that is the cause of this exception.</param>
    /// <param name="message">Type: Returns_String. The error message that explains the reason for the exception.</param>
    public SaveChangesException(string message, Exception exception)
      : base(message, exception)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.SaveChangesException"></see> class using <see cref="M:Microsoft.Xrm.Sdk.Client.OrganizationServiceContext.SaveChanges"></see> method call results.</summary>
    /// <param name="results">Type: <see cref="T:Microsoft.Xrm.Sdk.SaveChangesResultCollection"></see>. The results returned from a <see cref="M:Microsoft.Xrm.Sdk.Client.OrganizationServiceContext.SaveChanges"></see> call.</param>
    public SaveChangesException(SaveChangesResultCollection results)
      : this("An error occured while processing this request.", results)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.SaveChangesException"></see> class using an error message and <see cref="M:Microsoft.Xrm.Sdk.Client.OrganizationServiceContext.SaveChanges"></see> method call results.</summary>
    /// <param name="message">Type: Returns_String. The error message that explains the reason for the exception.</param>
    /// <param name="results">Type: <see cref="T:Microsoft.Xrm.Sdk.SaveChangesResultCollection"></see>. The results returned from a <see cref="M:Microsoft.Xrm.Sdk.Client.OrganizationServiceContext.SaveChanges"></see> call.</param>
    public SaveChangesException(string message, SaveChangesResultCollection results)
      : this(message, SaveChangesException.GetException((IEnumerable<SaveChangesResult>) results), results)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.SaveChangesException"></see> class using an inner exception and <see cref="M:Microsoft.Xrm.Sdk.Client.OrganizationServiceContext.SaveChanges"></see> method call results.</summary>
    /// <param name="innerException">Type: Returns_Exception. The inner exception that is the cause of this exception.</param>
    /// <param name="results">Type: <see cref="T:Microsoft.Xrm.Sdk.SaveChangesResultCollection"></see>. The results returned from a <see cref="M:Microsoft.Xrm.Sdk.Client.OrganizationServiceContext.SaveChanges"></see> call.</param>
    public SaveChangesException(Exception innerException, SaveChangesResultCollection results)
      : this("An error occured while processing this request.", innerException, results)
    {
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.SaveChangesException"></see> class with and error message, an inner exception, and <see cref="M:Microsoft.Xrm.Sdk.Client.OrganizationServiceContext.SaveChanges"></see> method call results.</summary>
    /// <param name="innerException">Type: Returns_Exception. The inner exception that is the cause of this exception.</param>
    /// <param name="message">Type: Returns_String. The error message that explains the reason for the exception.</param>
    /// <param name="results">Type: <see cref="T:Microsoft.Xrm.Sdk.SaveChangesResultCollection"></see>. The results returned from a <see cref="M:Microsoft.Xrm.Sdk.Client.OrganizationServiceContext.SaveChanges"></see> call.</param>
    public SaveChangesException(
      string message,
      Exception innerException,
      SaveChangesResultCollection results)
      : base(message, innerException)
    {
      this.Results = results;
    }

    private SaveChangesException(SerializationInfo info, StreamingContext context)
      : base(info, context)
    {
    }

    /// <summary>Sets the SerializationInfohttp://msdn.microsoft.com/en-us/library/system.runtime.serialization.serializationinfo.aspx with information about the exception.</summary>
    /// <param name="context">Type: StreamingContexthttp://msdn.microsoft.com/en-us/library/system.runtime.serialization.streamingcontext.aspx. The contextual information about the source or destination.</param>
    /// <param name="info">Type: SerializationInfohttp://msdn.microsoft.com/en-us/library/system.runtime.serialization.serializationinfo.aspx. The serialized object data about the exception being thrown.</param>
    [SecurityCritical]
    public override void GetObjectData(SerializationInfo info, StreamingContext context)
    {
      base.GetObjectData(info, context);
    }

    private static Exception GetException(IEnumerable<SaveChangesResult> results)
    {
      return results.Where<SaveChangesResult>((Func<SaveChangesResult, bool>) (r => r.Error != null)).Select<SaveChangesResult, Exception>((Func<SaveChangesResult, Exception>) (r => r.Error)).FirstOrDefault<Exception>();
    }
  }
}
