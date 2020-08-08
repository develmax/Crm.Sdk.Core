using System;

namespace Microsoft.Xrm.Sdk.Client
{
    /// <summary>Indicates the name of the message response, represented by the <see cref="T:Microsoft.Crm.Services.Utility.SdkMessageResponse"></see>  entity, to which the response corresponds.</summary>
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class ResponseProxyAttribute : Attribute
    {
        private string _name;

        /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Xrm.Sdk.Client.ResponseProxyAttribute"></see>  class.</summary>
        /// <param name="name">Type: Returns_String. Specifies the name of the message response.</param>
        public ResponseProxyAttribute(string name)
        {
            this._name = name;
        }

        /// <summary>Gets the name of the message response.</summary>
        /// <returns>Type: Returns_String The name of the message response.</returns>
        public string Name
        {
            get
            {
                return this._name;
            }
        }
    }
}