using System;

namespace Microsoft.Xrm.Sdk.Client
{
    /// <summary>Identifies the logical name of an entity.</summary>
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class EntityLogicalNameAttribute : Attribute
    {
        /// <summary>Gets the logical name of the entity.</summary>
        /// <returns>Type: Returns_String The logical name of the entity.</returns>
        public string LogicalName { get; private set; }

        /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Xrm.Sdk.Client.EntityLogicalNameAttribute"></see> class.</summary>
        /// <param name="logicalName">Type: Returns_String. The logical name of the entity</param>
        public EntityLogicalNameAttribute(string logicalName)
        {
            if (string.IsNullOrWhiteSpace(logicalName))
                throw new ArgumentNullException(nameof(logicalName));
            this.LogicalName = logicalName;
        }
    }
}