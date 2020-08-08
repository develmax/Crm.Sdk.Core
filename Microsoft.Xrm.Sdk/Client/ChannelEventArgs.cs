using System;

namespace Microsoft.Xrm.Sdk.Client
{
    /// <summary>Contains arguments for a WCF channel event.</summary>
    public sealed class ChannelEventArgs : EventArgs
    {
        /// <summary>Initializes a new instance of the  ChannelEventArgs class using a message.</summary>
        /// <param name="message">Type: Returns_String. The message describing the event.</param>
        public ChannelEventArgs(string message)
        {
            this.Message = message;
        }

        /// <summary>Gets the message describing the event.</summary>
        /// <returns>Type: Returns_StringThe message describing the event.</returns>
        public string Message { get; private set; }
    }
}