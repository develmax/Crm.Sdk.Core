using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Microsoft.Xrm.Sdk.Linq
{
  internal static class LinkEntityExtensions
  {
    public static LinkEntity Find(this LinkEntity link, Predicate<LinkEntity> match)
    {
      return !match(link) ? link.LinkEntities.Select<LinkEntity, LinkEntity>((Func<LinkEntity, LinkEntity>) (child => child.Find(match))).FirstOrDefault<LinkEntity>((Func<LinkEntity, bool>) (result => result != null)) : link;
    }

    [SuppressMessage("Microsoft.Usage", "CA9888:DisposeObjectsCorrectly", Justification = "Value is returned from method and cannot be disposed.", Target = "local$0")]
    public static IEnumerable<LinkEntity> GetSubtree(this LinkEntity link)
    {
      yield return link;
      foreach (LinkEntity linkEntity in link.LinkEntities.SelectMany<LinkEntity, LinkEntity>(new Func<LinkEntity, IEnumerable<LinkEntity>>(LinkEntityExtensions.GetSubtree)))
        yield return linkEntity;
    }
  }
}
