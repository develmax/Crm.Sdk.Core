// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Sdk.Messages.CreateExceptionRequest
// Assembly: Microsoft.Crm.Sdk.Proxy, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F3ED665D-73A2-4475-A0DE-3A25E42323B8
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Crm.Sdk.Proxy.dll

using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  create an exception for the recurring appointment instance.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class CreateExceptionRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the target appointment for the exception.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Entity"></see>The target appointment for the exception. This must be an entity reference for an appointment entity.</returns>
    public Entity Target
    {
      get
      {
        return this.Parameters.Contains(nameof (Target)) ? (Entity) this.Parameters[nameof (Target)] : (Entity) null;
      }
      set
      {
        this.Parameters[nameof (Target)] = (object) value;
      }
    }

    /// <summary>Gets or sets the original start date of the recurring appointment.</summary>
    /// <returns>Type:  Returns_DateTimeThe original start date of the recurring appointment.</returns>
    public DateTime OriginalStartDate
    {
      get
      {
        return this.Parameters.Contains(nameof (OriginalStartDate)) ? (DateTime) this.Parameters[nameof (OriginalStartDate)] : new DateTime();
      }
      set
      {
        this.Parameters[nameof (OriginalStartDate)] = (object) value;
      }
    }

    /// <summary>Gets or sets whether the appointment instance is deleted. </summary>
    /// <returns>Type:  Returns_BooleanIndicates if the appointment instance is deleted. true, if deleted, otherwise, false.</returns>
    public bool IsDeleted
    {
      get
      {
        return this.Parameters.Contains(nameof (IsDeleted)) && (bool) this.Parameters[nameof (IsDeleted)];
      }
      set
      {
        this.Parameters[nameof (IsDeleted)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Crm.Sdk.Messages.CreateExceptionRequest"></see> class.</summary>
    public CreateExceptionRequest()
    {
      this.RequestName = "CreateException";
      this.Target = (Entity) null;
      this.OriginalStartDate = new DateTime();
      this.IsDeleted = false;
    }
  }
}
