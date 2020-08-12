// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Sdk.Messages.BookResponse
// Assembly: Microsoft.Crm.Sdk.Proxy, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F3ED665D-73A2-4475-A0DE-3A25E42323B8
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Crm.Sdk.Proxy.dll

using Microsoft.Xrm.Sdk;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the response from the <see cref="T:Microsoft.Crm.Sdk.Messages.BookRequest"></see> class.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class BookResponse : OrganizationResponse
  {
    /// <summary>Gets the appointment validation results.</summary>
    /// <returns>Type:<see cref="T:Microsoft.Crm.Sdk.Messages.ValidationResult"></see>The appointment validation results.</returns>
    public ValidationResult ValidationResult
    {
      get
      {
        return this.Results.Contains(nameof (ValidationResult)) ? (ValidationResult) this.Results[nameof (ValidationResult)] : (ValidationResult) null;
      }
    }

    /// <returns>Returns Returns_Object.</returns>
    public object Notifications
    {
      get
      {
        return this.Results.Contains(nameof (Notifications)) ? this.Results[nameof (Notifications)] : (object) null;
      }
    }
  }
}
