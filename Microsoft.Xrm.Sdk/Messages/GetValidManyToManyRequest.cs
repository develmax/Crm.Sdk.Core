// Decompiled with JetBrains decompiler
// Type: Microsoft.Xrm.Sdk.Messages.GetValidManyToManyRequest
// Assembly: Microsoft.Xrm.Sdk, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: 917F618E-83AC-4359-819B-E0D742B6B85B
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Xrm.Sdk.dll

using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  retrieve a list of all the entities that can participate in a Many-to-Many entity relationship. </summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class GetValidManyToManyRequest : OrganizationRequest
  {
    /// <summary>Initializes a new instance of the  GetValidManyToManyRequest class</summary>
    public GetValidManyToManyRequest()
    {
      this.RequestName = "GetValidManyToMany";
    }
  }
}
