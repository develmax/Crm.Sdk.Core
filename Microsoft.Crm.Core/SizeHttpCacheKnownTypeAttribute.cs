using System;

namespace Microsoft.Crm
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface, AllowMultiple = false, Inherited = true)]
    public sealed class SizeHttpCacheKnownTypeAttribute : Attribute
    {
        private bool _skipThisType;

        public bool SkipThisType
        {
            get
            {
                return this._skipThisType;
            }
            set
            {
                this._skipThisType = value;
            }
        }
    }
}