namespace Microsoft.Xrm.Sdk
{
  internal abstract class Descriptor
  {
    public EntityStates State { get; set; }

    protected Descriptor(EntityStates state)
    {
      this.State = state;
    }
  }
}
