// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Sdk.Messages.ConstraintRelation
// Assembly: Microsoft.Crm.Sdk.Proxy, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F3ED665D-73A2-4475-A0DE-3A25E42323B8
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Crm.Sdk.Proxy.dll

using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Specifies additional constraints to be applied when you select resources for appointments. </summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class ConstraintRelation : IExtensibleDataObject
  {
    private ExtensionDataObject _extensionDataObject;

    /// <summary>constructor_initializes<see cref="T:Microsoft.Crm.Sdk.Messages.ConstraintRelation"></see> class.</summary>
    public ConstraintRelation()
    {
    }

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Crm.Sdk.Messages.ConstraintRelation"></see> class that sets the object ID, constraint type, and constraints.</summary>
    /// <param name="constraints">Type: Returns_String. The set of constraints.</param>
    /// <param name="constraintType">Type: Returns_String. The constraint type. Must be "Resource Selection".</param>
    /// <param name="objectId">Type: Returns_Guid. The ID of the calendar rule.</param>
    public ConstraintRelation(Guid objectId, string constraintType, string constraints)
    {
      this.ObjectId = objectId;
      this.ConstraintType = constraintType;
      this.Constraints = constraints;
    }

    /// <summary>Gets or sets the ID of the calendar rule to which the constraint is applied.</summary>
    /// <returns>Type: Returns_Guid
    /// The ID of the calendar rule to which the constraint is applied. This corresponds to the CalendarRule.CalenderRuleID attribute, which is the primary key for the CalendarRule entity.</returns>
    [DataMember]
    public Guid ObjectId { get; set; }

    /// <summary>Gets or sets the type of constraints.</summary>
    /// <returns>Type: Returns_String
    /// The type of constraints, which must be "Resource Selection".</returns>
    [DataMember]
    public string ConstraintType { get; set; }

    /// <summary>Gets or sets the set of additional constraints.</summary>
    /// <returns>Type: Returns_String
    /// The set of additional constraints.</returns>
    [DataMember]
    public string Constraints { get; set; }

    /// <summary>ExtensionData</summary>
    /// <returns>Type: Returns_ExtensionDataObjectThe extension data.</returns>
    public ExtensionDataObject ExtensionData
    {
      get
      {
        return this._extensionDataObject;
      }
      set
      {
        this._extensionDataObject = value;
      }
    }
  }
}
