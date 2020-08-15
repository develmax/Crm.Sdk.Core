using System;

namespace Microsoft.Xrm.Sdk
{
  [Flags]
  internal enum EntityStates
  {
    Detached = 1,
    Unchanged = 2,
    Added = 4,
    Deleted = 8,
    Modified = 16, // 0x00000010
  }
}
