using System;
using System.ServiceModel;

namespace Microsoft.Xrm.Sdk.Client
{
    internal abstract class ServiceContextInitializer<TService> : IDisposable where TService : class
    {
        private OperationContextScope _operationScope;

        protected ServiceContextInitializer(Microsoft.Xrm.Sdk.Client.ServiceProxy<TService> proxy)
        {
            ClientExceptionHelper.ThrowIfNull((object)proxy, nameof(proxy));
            this.ServiceProxy = proxy;
            this.Initialize(proxy);
        }

        public Microsoft.Xrm.Sdk.Client.ServiceProxy<TService> ServiceProxy { get; private set; }

        protected void Initialize(Microsoft.Xrm.Sdk.Client.ServiceProxy<TService> proxy)
        {
            this._operationScope = new OperationContextScope((IContextChannel)(object)proxy.ServiceChannel.Channel);
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize((object)this);
        }

        ~ServiceContextInitializer()
        {
            this.Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing || this._operationScope == null)
                return;
            this._operationScope.Dispose();
        }
    }
}