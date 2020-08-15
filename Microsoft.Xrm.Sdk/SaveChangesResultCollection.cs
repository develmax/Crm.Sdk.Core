using Microsoft.Xrm.Sdk.Client;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Microsoft.Xrm.Sdk
{
  /// <summary>Provides a collection of results for a save changes operation.</summary>
  public sealed class SaveChangesResultCollection : Collection<SaveChangesResult>
  {
    /// <summary>Gets how the <see cref="M:Microsoft.Xrm.Sdk.Client.OrganizationServiceContext.SaveChanges(Microsoft.Xrm.Sdk.Client.SaveChangesOptions)"></see> method behaves when an error occurs.</summary>
    /// <returns>Type: <see cref="T:Microsoft.Xrm.Sdk.Client.SaveChangesOptions"></see>
    /// The option that describes the save changes behavior.</returns>
    public SaveChangesOptions Options { get; private set; }

    /// <summary>Gets whether there is an error.</summary>
    /// <returns>Type: Returns_Booleantrue if there is an error; otherwise, false.</returns>
    public bool HasError
    {
      get
      {
        return this.Any<SaveChangesResult>((Func<SaveChangesResult, bool>) (result => result.Error != null));
      }
    }

    internal SaveChangesResultCollection(SaveChangesOptions options)
    {
      this.Options = options;
    }
  }
}
