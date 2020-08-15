namespace Microsoft.Xrm.Sdk
{
  internal sealed class EntityDescriptor : Descriptor
  {
    public EntityReference Identity { get; private set; }

    public Entity Entity { get; private set; }

    public EntityDescriptor(EntityStates state, EntityReference identity, Entity entity)
      : base(state)
    {
      this.Identity = identity;
      this.Entity = entity;
    }
  }
}
