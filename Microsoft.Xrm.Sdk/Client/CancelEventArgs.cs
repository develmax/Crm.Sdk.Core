using System;

namespace Microsoft.Xrm.Sdk.Client
{
    /// <summary>Contains arguments for a cancel event.</summary>
    public abstract class CancelEventArgs : EventArgs
    {
        /// <summary>Gets or sets whether the event is cancelled. </summary>
        /// <returns>Type: Returns_Booleantrue if the event is cancelled, otherwise false.</returns>
        public bool Cancel { get; internal set; }
    }
}