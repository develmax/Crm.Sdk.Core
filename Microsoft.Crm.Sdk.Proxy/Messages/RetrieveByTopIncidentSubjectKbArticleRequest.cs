using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  retrieve the top-ten articles about a specified subject from the knowledge base of articles for your organization.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RetrieveByTopIncidentSubjectKbArticleRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the ID of the subject. Required.</summary>
    /// <returns>Type: Returns_GuidThe ID of the subject. This corresponds to the Subject. SubjectId attribute, which is the primary key for the Subject entity.</returns>
    public Guid SubjectId
    {
      get
      {
        return this.Parameters.Contains(nameof (SubjectId)) ? (Guid) this.Parameters[nameof (SubjectId)] : new Guid();
      }
      set
      {
        this.Parameters[nameof (SubjectId)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Crm.Sdk.Messages.RetrieveByTopIncidentSubjectKbArticleRequest"></see> class.</summary>
    public RetrieveByTopIncidentSubjectKbArticleRequest()
    {
      this.RequestName = "RetrieveByTopIncidentSubjectKbArticle";
      this.SubjectId = new Guid();
    }
  }
}
