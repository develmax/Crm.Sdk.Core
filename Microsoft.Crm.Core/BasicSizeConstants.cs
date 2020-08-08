using System;
using System.Runtime.InteropServices;

namespace Microsoft.Crm
{
    public static class BasicSizeConstants
    {
        public static readonly long Word = (long)Marshal.SizeOf(typeof(IntPtr));
        public static readonly long Pointer = BasicSizeConstants.Word;
        public static readonly long Guid = (long)Marshal.SizeOf(typeof(System.Guid));
        public static readonly long BoxedValue = 3L * BasicSizeConstants.Pointer;
        public static readonly long ClassInstanceOverhead = 2L * BasicSizeConstants.Pointer;
        public static readonly long Object = 2L * BasicSizeConstants.Pointer;
    }
}