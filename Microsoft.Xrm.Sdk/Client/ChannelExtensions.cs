using System;
using System.Diagnostics.CodeAnalysis;
using System.ServiceModel;

namespace Microsoft.Xrm.Sdk.Client
{
    internal static class ChannelExtensions
    {
        public static void Abort(this ICommunicationObject communicationObject)
        {
            communicationObject?.Abort();
        }

        [SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Justification = "There is already a version that supplies the default parameter.  This is an extension method")]
        public static void Close(this ICommunicationObject communicationObject, bool throwOnException = true)
        {
            if (communicationObject == null)
                return;
            try
            {
                CommunicationState state = communicationObject.State;
                if (CommunicationState.Faulted == state)
                {
                    communicationObject.Abort();
                }
                else
                {
                    if (state == CommunicationState.Closing || state == CommunicationState.Closed)
                        return;
                    communicationObject.Close();
                }
            }
            catch (CommunicationException ex)
            {
                communicationObject.Abort();
            }
            catch (TimeoutException ex)
            {
                communicationObject.Abort();
            }
            catch (Exception ex)
            {
                communicationObject.Abort();
                if (!throwOnException)
                    return;
                throw;
            }
        }
    }
}