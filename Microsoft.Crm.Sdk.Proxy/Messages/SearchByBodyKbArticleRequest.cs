using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  search for knowledge base articles that contain the specified body text.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class SearchByBodyKbArticleRequest : OrganizationRequest
  {
    /// <summary>Gets or sets the text contained in the body of the article. Required.</summary>
    /// <returns>Type: Returns_StringThe text contained in the body of the article.</returns>
    public string SearchText
    {
      get
      {
        return this.Parameters.Contains(nameof (SearchText)) ? (string) this.Parameters[nameof (SearchText)] : (string) null;
      }
      set
      {
        this.Parameters[nameof (SearchText)] = (object) value;
      }
    }

    /// <summary>Gets or sets the ID of the knowledge base article subject. Required.</summary>
    /// <returns>Type: Returns_GuidThe ID of the knowledge base article subject. This corresponds to the Subject.SubjectId attribute, which is the primary key for the Subject entity.</returns>
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

    /// <summary>Gets or sets a value that indicates whether to use inflectional stem matching when searching for knowledge base articles with a specified body text. Required.</summary>
    /// <returns>Type: Returns_BooleanIndicates whether to use inflectional stem matching when searching for knowledge base articles with a specified body text. true, to use inflectional stem matching, otherwise, false.</returns>
    public bool UseInflection
    {
      get
      {
        return this.Parameters.Contains(nameof (UseInflection)) && (bool) this.Parameters[nameof (UseInflection)];
      }
      set
      {
        this.Parameters[nameof (UseInflection)] = (object) value;
      }
    }

    /// <summary>Gets or sets the query criteria to find knowledge base articles with specified body text. Required. </summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Query.QueryBase"></see>The query criteria to find knowledge base articles with specified body text.</returns>
    public QueryBase QueryExpression
    {
      get
      {
        return this.Parameters.Contains(nameof (QueryExpression)) ? (QueryBase) this.Parameters[nameof (QueryExpression)] : (QueryBase) null;
      }
      set
      {
        this.Parameters[nameof (QueryExpression)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Crm.Sdk.Messages.SearchByBodyKbArticleRequest"></see> class.</summary>
    public SearchByBodyKbArticleRequest()
    {
      this.RequestName = "SearchByBodyKbArticle";
      this.SearchText = (string) null;
      this.SubjectId = new Guid();
      this.UseInflection = false;
      this.QueryExpression = (QueryBase) null;
    }
  }
}
