using System;

namespace Microsoft.Xrm.Sdk
{
  /// <summary>Used by the code generation tool to create classes based on entities. </summary>
  [AttributeUsage(AttributeTargets.Property)]
  public sealed class AttributeLogicalNameAttribute : Attribute
  {
    /// <summary>Gets the logical name of an attribute.</summary>
    /// <returns>Type: Returns_String
    /// The logical name of an attribute.</returns>
    public string LogicalName { get; private set; }

    /// <summary>constructor_initializes<see cref="T:Microsoft.Xrm.Sdk.AttributeLogicalNameAttribute"></see> class</summary>
    /// <param name="logicalName">Type: Returns_String.
    /// The logical name of an attribute.</param>
    public AttributeLogicalNameAttribute(string logicalName)
    {
      if (string.IsNullOrWhiteSpace(logicalName))
        throw new ArgumentNullException(nameof (logicalName));
      this.LogicalName = logicalName;
    }
  }
}
