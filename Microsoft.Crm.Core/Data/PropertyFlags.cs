using System;
using System.Diagnostics.CodeAnalysis;

namespace Microsoft.Crm.Data
{
    [SuppressMessage("Microsoft.Naming", "CA1711:IdentifiersShouldNotHaveIncorrectSuffix", Justification = "BASELINE: BackLog", MessageId = "")]
    [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue", Justification = "BASELINE: BackLog, [tobinz]: Base line for new rules.", MessageId = "")]
    [Flags]
    public enum PropertyFlags
    {
        CanBeModified = 1,
        CanBeRemoved = 2,
        Browsable = 4,
        All = Browsable | CanBeRemoved | CanBeModified, // 0x00000007
        Default = All, // 0x00000007
        Static = Browsable | CanBeModified, // 0x00000005
        ReadonlyStatic = Browsable, // 0x00000004
        Ignore = 0,
    }
}