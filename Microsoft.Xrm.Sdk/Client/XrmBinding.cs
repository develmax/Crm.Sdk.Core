using System;
using System.ServiceModel.Channels;
using System.Xml;

namespace Microsoft.Xrm.Sdk.Client
{
    /// <summary>internal</summary>
    public sealed class XrmBinding : CustomBinding
    {
        private TransportBindingElement _transportElement;
        //private MtomMessageEncodingBindingElement _mtomMessageEncodingElement;
        private TextMessageEncodingBindingElement _textMessageEncodingElement;

        internal XrmBinding(Binding binding)
          : base(binding)
        {
            if (binding == null)
                throw new ArgumentNullException(nameof(binding));
            this.Initialize();
        }

        public int MaxBufferSize
        {
            get
            {
                return this._transportElement is HttpTransportBindingElement transportElement ? transportElement.MaxBufferSize : -1;
            }
            set
            {
                if (this._transportElement is HttpTransportBindingElement transportElement)
                    transportElement.MaxBufferSize = value;
                /*if (this._mtomMessageEncodingElement == null)
                    return;
                this._mtomMessageEncodingElement.MaxBufferSize = value;*/
            }
        }

        public long MaxReceivedMessageSize
        {
            get
            {
                return this._transportElement != null ? this._transportElement.MaxReceivedMessageSize : -1L;
            }
            set
            {
                if (this._transportElement == null)
                    return;
                this._transportElement.MaxReceivedMessageSize = value;
            }
        }

        public XmlDictionaryReaderQuotas ReaderQuotas
        {
            get
            {
                if (this._textMessageEncodingElement != null)
                    return this._textMessageEncodingElement.ReaderQuotas;
                return /*this._mtomMessageEncodingElement != null ? this._mtomMessageEncodingElement.ReaderQuotas :*/ (XmlDictionaryReaderQuotas)null;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(value));
                /*if (this._mtomMessageEncodingElement != null)
                    value.CopyTo(this._mtomMessageEncodingElement.ReaderQuotas);*/
                if (this._textMessageEncodingElement == null)
                    return;
                value.CopyTo(this._textMessageEncodingElement.ReaderQuotas);
            }
        }

        public override string Scheme
        {
            get
            {
                return this._transportElement == null ? string.Empty : this._transportElement.Scheme;
            }
        }

        private void Initialize()
        {
            this._transportElement = this.Elements.Find<TransportBindingElement>();
            //this._mtomMessageEncodingElement = this.Elements.Find<MtomMessageEncodingBindingElement>();
            this._textMessageEncodingElement = this.Elements.Find<TextMessageEncodingBindingElement>();
        }
    }
}
