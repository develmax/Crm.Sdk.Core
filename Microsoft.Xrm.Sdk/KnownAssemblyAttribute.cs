using System;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace Microsoft.Xrm.Sdk
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface)]
    internal sealed class KnownAssemblyAttribute : Attribute, IContractBehavior
    {
        private KnownTypesResolver resolver;

        public KnownAssemblyAttribute()
        {
            this.resolver = new KnownTypesResolver();
        }

        public void AddBindingParameters(
          ContractDescription contractDescription,
          ServiceEndpoint endpoint,
          BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyClientBehavior(
          ContractDescription contractDescription,
          ServiceEndpoint endpoint,
          ClientRuntime clientRuntime)
        {
            this.CreateMyDataContractSerializerOperationBehaviors(contractDescription);
        }

        public void ApplyDispatchBehavior(
          ContractDescription contractDescription,
          ServiceEndpoint endpoint,
          DispatchRuntime dispatchRuntime)
        {
            this.CreateMyDataContractSerializerOperationBehaviors(contractDescription);
        }

        public void Validate(ContractDescription contractDescription, ServiceEndpoint endpoint)
        {
        }

        private void CreateMyDataContractSerializerOperationBehaviors(
          ContractDescription contractDescription)
        {
            foreach (OperationDescription operation in (Collection<OperationDescription>)contractDescription.Operations)
                this.CreateMyDataContractSerializerOperationBehavior(operation);
        }

        private void CreateMyDataContractSerializerOperationBehavior(OperationDescription operation)
        {
            DataContractSerializerOperationBehavior operationBehavior = operation.Behaviors.Find<DataContractSerializerOperationBehavior>();
            if (operationBehavior == null)
                return;
            operationBehavior.DataContractResolver = (DataContractResolver)this.resolver;
        }
    }
}
