using Microsoft.Xrm.Sdk;
using System;
using System.Runtime.Serialization;

namespace Microsoft.Crm.Sdk.Messages
{
  /// <summary>Contains the data that is needed to  retrieve pages of posts, including comments for each post, for all records that the calling user is following.</summary>
  [DataContract(Namespace = "http://schemas.microsoft.com/crm/2011/Contracts")]
  public sealed class RetrievePersonalWallRequest : OrganizationRequest
  {
    /// <summary>Gets or sets, for retrieval, a specific page of posts that is designated by its page number. Required.</summary>
    /// <returns>Type:  Returns_Int32The specific page of posts that is designated by its page number. The page number for the first page is 1. If you specify a value of 0, it is treated as a value of 1.</returns>
    public int PageNumber
    {
      get
      {
        return this.Parameters.Contains(nameof (PageNumber)) ? (int) this.Parameters[nameof (PageNumber)] : 0;
      }
      set
      {
        this.Parameters[nameof (PageNumber)] = (object) value;
      }
    }

    /// <summary>Gets or sets, for retrieval, the number of posts per page. Required.</summary>
    /// <returns>Type:  Returns_Int32The number of posts per page. The maximum number of retrieved posts, per page, is 100; the minimum number is 1.</returns>
    public int PageSize
    {
      get
      {
        return this.Parameters.Contains(nameof (PageSize)) ? (int) this.Parameters[nameof (PageSize)] : 0;
      }
      set
      {
        this.Parameters[nameof (PageSize)] = (object) value;
      }
    }

    /// <summary>Gets or sets, for retrieval, the number of comments per post. Required.</summary>
    /// <returns>Type: Returns_Int32The number of comments per post to retrieve. The maximum number of retrieved comments, per post, is 50; the minimum number is 0.</returns>
    public int CommentsPerPost
    {
      get
      {
        return this.Parameters.Contains(nameof (CommentsPerPost)) ? (int) this.Parameters[nameof (CommentsPerPost)] : 0;
      }
      set
      {
        this.Parameters[nameof (CommentsPerPost)] = (object) value;
      }
    }

    /// <summary>Gets or sets the start date and time of the posts that you want to retrieve. Optional.</summary>
    /// <returns>Type:  Returns_DateTimeThe start date and time of the posts that you want to retrieve. If specified, only the posts that were created on or after the specified date and time are retrieved.</returns>
    public DateTime StartDate
    {
      get
      {
        return this.Parameters.Contains(nameof (StartDate)) ? (DateTime) this.Parameters[nameof (StartDate)] : new DateTime();
      }
      set
      {
        this.Parameters[nameof (StartDate)] = (object) value;
      }
    }

    /// <summary>Gets or sets the end date and time of the posts that you want to retrieve. Optional.</summary>
    /// <returns>Type:  Returns_DateTimeThe end date and time of the posts that you want to retrieve. If specified, the posts that were created on or before the specified end date and time are retrieved.</returns>
    public DateTime EndDate
    {
      get
      {
        return this.Parameters.Contains(nameof (EndDate)) ? (DateTime) this.Parameters[nameof (EndDate)] : new DateTime();
      }
      set
      {
        this.Parameters[nameof (EndDate)] = (object) value;
      }
    }

    /// <summary>Reserved for future use.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.OptionSetValue"></see>.</returns>
    public OptionSetValue Type
    {
      get
      {
        return this.Parameters.Contains(nameof (Type)) ? (OptionSetValue) this.Parameters[nameof (Type)] : (OptionSetValue) null;
      }
      set
      {
        this.Parameters[nameof (Type)] = (object) value;
      }
    }

    /// <summary>Gets or sets a value that specifies the source of the post. Optional.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.OptionSetValue"></see>The value that specifies the source of the post.</returns>
    public OptionSetValue Source
    {
      get
      {
        return this.Parameters.Contains(nameof (Source)) ? (OptionSetValue) this.Parameters[nameof (Source)] : (OptionSetValue) null;
      }
      set
      {
        this.Parameters[nameof (Source)] = (object) value;
      }
    }

    /// <summary>Initializes a new instance of the  <see cref="T:Microsoft.Crm.Sdk.Messages.RetrievePersonalWallRequest"></see> class.</summary>
    public RetrievePersonalWallRequest()
    {
      this.RequestName = "RetrievePersonalWall";
      this.PageNumber = 0;
      this.PageSize = 0;
      this.CommentsPerPost = 0;
    }
  }
}
