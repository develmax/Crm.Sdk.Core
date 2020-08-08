using System.Diagnostics.CodeAnalysis;
using System.ServiceModel.Channels;

namespace Microsoft.Xrm.Sdk.Client
{
    internal abstract class XrmPolicy : BindingElement
    {
        private readonly PolicyDictionary _policyElements = new PolicyDictionary();

        internal PolicyDictionary PolicyElements
        {
            get
            {
                return this._policyElements;
            }
        }

        public override BindingElement Clone()
        {
            return (BindingElement)this;
        }

        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter", Justification = "Needed for interface definition.")]
        public override T GetProperty<T>(BindingContext context)
        {
            return context.GetInnerProperty<T>();
        }
    }
}