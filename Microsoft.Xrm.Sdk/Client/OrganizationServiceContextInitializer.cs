using System;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace Microsoft.Xrm.Sdk.Client
{
    internal sealed class OrganizationServiceContextInitializer : ServiceContextInitializer<IOrganizationService>
    {
        public OrganizationServiceContextInitializer(OrganizationServiceProxy proxy)
          : base((ServiceProxy<IOrganizationService>)proxy)
        {
            this.Initialize();
        }

        private OrganizationServiceProxy OrganizationServiceProxy
        {
            get
            {
                return this.ServiceProxy as OrganizationServiceProxy;
            }
        }

        private void Initialize()
        {
            if (this.OrganizationServiceProxy == null)
                return;
            if (this.OrganizationServiceProxy.OfflinePlayback)
                OperationContext.Current.OutgoingMessageHeaders.Add(MessageHeader.CreateHeader("IsOfflinePlayback", "http://schemas.microsoft.com/xrm/2011/Contracts", (object)true));
            if (this.OrganizationServiceProxy.CallerId != Guid.Empty)
                OperationContext.Current.OutgoingMessageHeaders.Add(MessageHeader.CreateHeader("CallerId", "http://schemas.microsoft.com/xrm/2011/Contracts", (object)this.OrganizationServiceProxy.CallerId));
            if (this.OrganizationServiceProxy.LanguageCodeOverride != 0)
                OperationContext.Current.OutgoingMessageHeaders.Add(MessageHeader.CreateHeader("LanguageCodeOverride", "http://schemas.microsoft.com/xrm/2011/Contracts", (object)this.OrganizationServiceProxy.LanguageCodeOverride));
            if (this.OrganizationServiceProxy.SyncOperationType != null)
                OperationContext.Current.OutgoingMessageHeaders.Add(MessageHeader.CreateHeader("OutlookSyncOperationType", "http://schemas.microsoft.com/xrm/2011/Contracts", (object)this.OrganizationServiceProxy.SyncOperationType));
            if (!string.IsNullOrEmpty(this.OrganizationServiceProxy.ClientAppName))
                OperationContext.Current.OutgoingMessageHeaders.Add(MessageHeader.CreateHeader("ClientAppName", "http://schemas.microsoft.com/xrm/2011/Contracts", (object)this.OrganizationServiceProxy.ClientAppName));
            if (!string.IsNullOrEmpty(this.OrganizationServiceProxy.ClientAppVersion))
                OperationContext.Current.OutgoingMessageHeaders.Add(MessageHeader.CreateHeader("ClientAppVersion", "http://schemas.microsoft.com/xrm/2011/Contracts", (object)this.OrganizationServiceProxy.ClientAppVersion));
            if (!string.IsNullOrEmpty(this.OrganizationServiceProxy.SdkClientVersion))
            {
                OperationContext.Current.OutgoingMessageHeaders.Add(MessageHeader.CreateHeader("SdkClientVersion", "http://schemas.microsoft.com/xrm/2011/Contracts", (object)this.OrganizationServiceProxy.SdkClientVersion));
            }
            else
            {
                string assemblyFileVersion = this.OrganizationServiceProxy.GetXrmSdkAssemblyFileVersion();
                if (string.IsNullOrEmpty(assemblyFileVersion))
                    return;
                OperationContext.Current.OutgoingMessageHeaders.Add(MessageHeader.CreateHeader("SdkClientVersion", "http://schemas.microsoft.com/xrm/2011/Contracts", (object)assemblyFileVersion));
            }
        }
    }
}