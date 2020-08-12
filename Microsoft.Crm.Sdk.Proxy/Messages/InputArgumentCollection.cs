// Decompiled with JetBrains decompiler
// Type: Microsoft.Crm.Sdk.Messages.InputArgumentCollection
// Assembly: Microsoft.Crm.Sdk.Proxy, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35
// MVID: F3ED665D-73A2-4475-A0DE-3A25E42323B8
// Assembly location: D:\Projects.Hg\prod_15\Sources\Bcs.Crm\packages\Microsoft.CrmSdk.CoreAssemblies.7.0.0.1\lib\net45\Microsoft.Crm.Sdk.Proxy.dll

using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class InputArgumentCollection : IExtensibleDataObject
  {
    private ExtensionDataObject _extensionDataObject;

    public InputArgumentCollection()
    {
      this.Arguments = new InputArgument();
    }

    /// <param name="value">Type: </param>
    /// <param name="key">Type: </param>
    public void Add(string key, object value)
    {
      this.Arguments.Add(key, value);
    }

    /// <returns>Type: <see cref="T:System.Int32"></see>.</returns>
    public int Count
    {
      get
      {
        return this.Arguments.Count;
      }
    }

    /// <returns>Type: <see cref="T:System.Runtime.Serialization.ExtensionDataObject"></see>.</returns>
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

    /// <returns>Type: <see cref="T:System.Object"></see>.</returns>
    /// <param name="key">Type: </param>
    public object this[string key]
    {
      get
      {
        return this.Arguments[key];
      }
      set
      {
        this.Arguments[key] = value;
      }
    }

    /// <returns>Type: <see cref="T:Microsoft.Crm.Sdk.Messages.InputArgument"></see>.</returns>
    [DataMember]
    public InputArgument Arguments { get; set; }
  }
}
