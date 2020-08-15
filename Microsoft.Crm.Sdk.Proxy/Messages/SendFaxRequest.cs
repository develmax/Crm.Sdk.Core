using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to send a fax.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class SendFaxRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the ID of the fax to send.</summary>
    /// <returns>Type: Returns_GuidThe ID of the fax to send. This corresponds to the Fax.FaxId attribute, which is the primary key for the Fax entity.</returns>
    public Guid FaxId
    {
      get
      {
        return this.Parameters.Contains(nameof (FaxId)) ? (Guid) this.Parameters[nameof (FaxId)] : new Guid();
      }
      set
      {
        this.Parameters[nameof (FaxId)] = (object) value;
      }
    }

    /// <summary>Gets or sets whether to send the e-mail, or to just record it as sent.</summary>
    /// <returns>Type: Returns_BooleanIndicates whether to send the e-mail, or to just record it as sent. true, to send the e-mail, otherwise, false. </returns>
    public bool IssueSend
    {
      get
      {
        return this.Parameters.Contains(nameof (IssueSend)) && (bool) this.Parameters[nameof (IssueSend)];
      }
      set
      {
        this.Parameters[nameof (IssueSend)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the<see cref="T:Microsoft.Crm.Sdk.Messages.SendFaxRequest"></see> class.</summary>
    public SendFaxRequest()
    {
      this.RequestName = "SendFax";
      this.FaxId = new Guid();
      this.IssueSend = false;
    }
  }
}
