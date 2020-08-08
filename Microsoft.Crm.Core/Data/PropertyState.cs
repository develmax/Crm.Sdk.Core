using System.Diagnostics.CodeAnalysis;

namespace Microsoft.Crm.Data
{
    [SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue", Justification = "BASELINE: BackLog, [tobinz]: Base line for new rules.", MessageId = "")]
    [SuppressMessage("Microsoft.Design", "CA1027:MarkEnumsWithFlags", Justification = "BASELINE: BackLog, [tobinz]: Base line for new rules.", MessageId = "")]
    public enum PropertyState
    {
        Uninitialized = 1,
        Unchanged = 2,
        New = 4,
        Modified = 8,
        Deleted = 16, // 0x00000010
    }
}