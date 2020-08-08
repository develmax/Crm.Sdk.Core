using System;

namespace Microsoft.Xrm.Sdk.Client
{
    /// <summary>Contains arguments for a faulted WCF channel event.</summary>
    public sealed class ChannelFaultedEventArgs : CancelEventArgs
    {
        /// <summary>Initializes a new instance of the  ChannelFaultedEventArgs class using an exception.</summary>
        /// <param name="exception">Type: Returns_Exception. An exception or null.</param>
        public ChannelFaultedEventArgs(Exception exception)
            : this(string.Empty, exception)
        {
        }

        /// <summary>Initializes a new instance of the  ChannelFaultedEventArgs class using message and an exception.</summary>
        /// <param name="exception">Type: Returns_Exception. An exception or null.</param>
        /// <param name="message">Type: Returns_String. A message describing the event.</param>
        public ChannelFaultedEventArgs(string message, Exception exception)
        {
            this.Exception = exception;
            this.Message = message;
        }

        /// <summary>Gets the exception related to the event.</summary>
        /// <returns>Type: Returns_Exceptionthe exception related to the event.</returns>
        public Exception Exception { get; private set; }

        /// <summary>Gets the message describing the event.</summary>
        /// <returns>Type: Returns_StringThe message describing the event.</returns>
        public string Message { get; private set; }
    }
}