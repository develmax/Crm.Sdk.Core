
using System;
using System.Diagnostics.CodeAnalysis;
using System.Security;
using System.Security.Permissions;
using System.ServiceModel;

namespace Microsoft.Xrm.Sdk.Client
{
    /// <summary>Represents a communication channel to a pn_microsoftcrm service.</summary>
    [SecuritySafeCritical]
    [SecurityPermission(SecurityAction.Demand, Unrestricted = true)]
    public class ServiceChannel<TChannel> : IDisposable where TChannel : class
    {
        private readonly object _lockObject = new object();
        private TimeSpan _timeout = ServiceDefaults.DefaultTimeout;
        private bool _updateTimeout = true;
        private TChannel _channel;
        private bool _disposed;

        /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Xrm.Sdk.Client.ServiceChannel`1"></see> class using a channel factory. internal</summary>
        /// <param name="factory">Type: Returns_ChannelFactory_Generic. A channel factory.</param>
        public ServiceChannel(ChannelFactory<TChannel> factory)
        {
            ClientExceptionHelper.ThrowIfNull((object)factory, nameof(factory));
            this.Factory = factory;
        }

        /// <summary>Gets the WCF channel that is associated with the service channel.</summary>
        /// <returns>Type: Returns_IOutputChannel or Returns_IRequestChannel The WCF channel associated with the service channel.</returns>
        public TChannel Channel
        {
            get
            {
                if ((object)this._channel == null || this._disposed || !ServiceChannel<TChannel>.IsCommunicationObjectValid(this.CommunicationObject))
                {
                    ClientExceptionHelper.ThrowIfNull((object)this.Factory, "Factory");
                    this.ConfigureNewChannel();
                }
                lock (this._lockObject)
                {
                    if (this._updateTimeout)
                    {
                        ((object)this._channel as IContextChannel).OperationTimeout = this._timeout;
                        this._updateTimeout = false;
                    }
                }
                return this._channel;
            }
        }

        /// <summary>Gets the channel factory associated with the service channel.</summary>
        /// <returns>Type: Returns_ChannelFactory_GenericThe channel factory associated with the service channel.</returns>
        protected ChannelFactory<TChannel> Factory { get; private set; }

        /// <summary>Creates a new WCF channel. </summary>
        /// <returns>Type: Returns_IOutputChannel or Returns_IRequestChannelThe new WCF channel associated with the service channel.</returns>
        [SecuritySafeCritical]
        [SecurityPermission(SecurityAction.Demand, Unrestricted = true)]
        protected virtual TChannel CreateChannel()
        {
            return this.Factory.CreateChannel();
        }

        /// <summary>Gets the communication object that is associated with the service channel.</summary>
        /// <returns>Type: Returns_ICommunicationObjectThe communication object associated with the service channel.</returns>
        protected ICommunicationObject CommunicationObject
        {
            get
            {
                return (object)this._channel as ICommunicationObject;
            }
        }

        internal static bool IsCommunicationObjectValid(ICommunicationObject communicationObject)
        {
            if (communicationObject != null)
            {
                switch (communicationObject.State)
                {
                    case CommunicationState.Created:
                    case CommunicationState.Opening:
                    case CommunicationState.Opened:
                        return true;
                }
            }
            return false;
        }

        internal TimeSpan Timeout
        {
            get
            {
                return this._timeout;
            }
            set
            {
                this._timeout = value;
                this._updateTimeout = true;
            }
        }

        internal bool IsChannelInvalid
        {
            get
            {
                return this._disposed || this.Factory == null;
            }
        }

        private void ConfigureNewChannel()
        {
            this._channel = this.CreateChannel();
            this.CommunicationObject.Opened += new EventHandler(this.Channel_Opened);
            this.CommunicationObject.Faulted += new EventHandler(this.Channel_Faulted);
            this.CommunicationObject.Closed += new EventHandler(this.Channel_Closed);
        }

        private void RemoveChannelEvents()
        {
            if (this.CommunicationObject == null)
                return;
            this.CommunicationObject.Opened -= new EventHandler(this.Channel_Opened);
            this.CommunicationObject.Faulted -= new EventHandler(this.Channel_Faulted);
            this.CommunicationObject.Closed -= new EventHandler(this.Channel_Closed);
        }

        /// <summary>Causes a service channel to transition from the created state into the opened state.</summary>
        public void Open()
        {
            if (this.CommunicationObject == null)
                return;
            if (this.CommunicationObject.State != CommunicationState.Created)
                return;
            try
            {
                this.CommunicationObject.Open();
            }
            catch (Exception ex)
            {
                ChannelFaultedEventArgs args = new ChannelFaultedEventArgs("Exception when opening an SDK channel", ex);
                this.OnChannelFaulted(args);
                if (args.Cancel)
                    return;
                throw;
            }
        }

        /// <summary>Causes a service channel to transition immediately from its current state into the closing state.</summary>
        public void Abort()
        {
            if (this.CommunicationObject == null)
                return;
            this.CommunicationObject.Abort();
        }

        /// <summary>Causes a service channel to transition from its current state into the closed state.</summary>
        public void Close()
        {
            if (this.CommunicationObject == null)
                return;
            this.RemoveChannelEvents();
            this.CommunicationObject.Close(true);
        }

        private void Channel_Faulted(object sender, EventArgs e)
        {
            ICommunicationObject channel = (object)this._channel as ICommunicationObject;
            this._channel = default(TChannel);
            this.OnChannelFaulted(new ChannelFaultedEventArgs("The channel has entered a faulted state.", (Exception)null));
            if (channel == null)
                return;
            this.RemoveChannelEvents();
            channel.Close(true);
        }

        private void Channel_Closed(object sender, EventArgs e)
        {
            this.OnChannelClosed(new ChannelEventArgs("The channel has entered a closed state."));
        }

        private void Channel_Opened(object sender, EventArgs e)
        {
            this.OnChannelOpened(new ChannelEventArgs("The channel has entered an opened state."));
        }

        /// <summary>Inserts processing on a service channel after it transitions to the faulted state due to the invocation of a synchronous operation.</summary>
        /// <param name="args">Type: <see cref="T:Microsoft.Xrm.Sdk.Client.ChannelFaultedEventArgs"></see>. Channel faulted event arguments.</param>
        protected virtual void OnChannelFaulted(ChannelFaultedEventArgs args)
        {
            if (this.ChannelFaulted == null)
                return;
            this.ChannelFaulted((object)this, args);
        }

        /// <summary>Inserts processing on a service channel after it transitions to the closing state due to the invocation of a synchronous close operation.</summary>
        /// <param name="args">Type: <see cref="T:Microsoft.Xrm.Sdk.Client.ChannelEventArgs"></see>. Channel event arguments.</param>
        protected virtual void OnChannelClosed(ChannelEventArgs args)
        {
            if (this.ChannelClosed == null)
                return;
            this.ChannelClosed((object)this, args);
        }

        /// <summary>Inserts processing on a service channel after it transitions into the opening state which must complete within a specified interval of time.</summary>
        /// <param name="args">Type: <see cref="T:Microsoft.Xrm.Sdk.Client.ChannelEventArgs"></see>. Channel event arguments.</param>
        protected virtual void OnChannelOpened(ChannelEventArgs args)
        {
            if (this.ChannelOpened == null)
                return;
            this.ChannelOpened((object)this, args);
        }

        /// <summary>Occurs when a service channel transitions into the faulted state.</summary>
        public event EventHandler<ChannelFaultedEventArgs> ChannelFaulted;

        /// <summary>Occurs when a service channel transitions into the opened state.</summary>
        public event EventHandler<ChannelEventArgs> ChannelOpened;

        /// <summary>Occurs when a service channel transitions into the closed state.</summary>
        public event EventHandler<ChannelEventArgs> ChannelClosed;

        /// <summary>Disposes the service channel.</summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize((object)this);
        }

        /// <summary>Finalizes the service channel.</summary>
        ~ServiceChannel()
        {
            this.Dispose(false);
        }

        [SuppressMessage("Microsoft.Usage", "CA9888:DisposeObjectsCorrectly", Justification = "False Positive - disposableFactory")]
        private void Dispose(bool disposing)
        {
            if (this._disposed)
                return;
            if ((object)this._channel != null)
            {
                try
                {
                    this.Close();
                }
                finally
                {
                    this._channel = default(TChannel);
                }
            }
            this.Factory = (ChannelFactory<TChannel>)null;
            if (!disposing)
                return;
            this._disposed = true;
        }
    }
}
