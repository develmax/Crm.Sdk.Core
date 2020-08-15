using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to set or restore the data encryption key.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
  public sealed class SetDataEncryptionKeyRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the value of the data encryption key.</summary>
    /// <returns>Type: Returns_String.</returns>
    public string EncryptionKey
    {
      get
      {
        return this.Parameters.Contains(nameof (EncryptionKey)) ? (string) this.Parameters[nameof (EncryptionKey)] : (string) null;
      }
      set
      {
        this.Parameters[nameof (EncryptionKey)] = (object) value;
      }
    }

    /// <summary>Gets or sets the operation to perform with the data encryption key.</summary>
    /// <returns>Type: Returns_Booleantrue indicates to set (change) the data encryption key; otherwise, false indicates to restore the data encryption key.</returns>
    public bool ChangeEncryptionKey
    {
      get
      {
        return this.Parameters.Contains(nameof (ChangeEncryptionKey)) && (bool) this.Parameters[nameof (ChangeEncryptionKey)];
      }
      set
      {
        this.Parameters[nameof (ChangeEncryptionKey)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the <see cref="T:Microsoft.Xrm.Sdk.Messages.SetDataEncryptionKeyRequest"></see> class.</summary>
    public SetDataEncryptionKeyRequest()
    {
      this.RequestName = "SetDataEncryptionKey";
      this.EncryptionKey = (string) null;
      this.ChangeEncryptionKey = false;
    }
  }
}
