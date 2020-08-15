using System.Collections.Generic;

namespace Microsoft.Xrm.Sdk
{
  internal sealed class LinkDescriptor : Descriptor
  {
    internal static readonly IEqualityComparer<LinkDescriptor> EquivalenceComparer = (IEqualityComparer<LinkDescriptor>) new LinkDescriptor.LinkDescriptorComparer();

    public Entity Source { get; private set; }

    public Relationship Relationship { get; private set; }

    public Entity Target { get; private set; }

    public LinkDescriptor(Entity source, Relationship relationship, Entity target)
      : this(EntityStates.Unchanged, source, relationship, target)
    {
    }

    public LinkDescriptor(
      EntityStates state,
      Entity source,
      Relationship relationship,
      Entity target)
      : base(state)
    {
      this.Source = source;
      this.Relationship = relationship;
      this.Target = target;
    }

    private class LinkDescriptorComparer : IEqualityComparer<LinkDescriptor>
    {
      public bool Equals(LinkDescriptor x, LinkDescriptor y)
      {
        if (x == null && y == null)
          return true;
        return x != null && y != null && (object.Equals((object) x.Source, (object) y.Source) && object.Equals((object) x.Relationship, (object) y.Relationship)) && object.Equals((object) x.Target, (object) y.Target);
      }

      public int GetHashCode(LinkDescriptor obj)
      {
        return obj == null ? 0 : obj.Source.GetHashCode() ^ (obj.Target != null ? obj.Target.GetHashCode() : 0) ^ (obj.Relationship != null ? obj.Relationship.GetHashCode() : 0);
      }
    }
  }
}
