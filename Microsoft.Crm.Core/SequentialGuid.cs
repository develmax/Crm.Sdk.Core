using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace Microsoft.Crm
{
    [SuppressMessage("Microsoft.Design", "CA1053:StaticHolderTypesShouldNotHaveConstructors", Justification = "BASELINE: BackLog, [tobinz]: Base line for new rules.", MessageId = "")]
    public class SequentialGuid
    {
        [SuppressMessage("Microsoft.Design", "CA1060:MovePInvokesToNativeMethodsClass", Justification = "BASELINE: BackLog, [tobinz]: Base line for new rules.", MessageId = "")]
        [DllImport("Rpcrt4", CallingConvention = CallingConvention.StdCall, SetLastError = true)]
        private static extern long UuidCreateSequential(ref Guid ptrGuid);

        public static Guid CreateGuid()
        {
            //if ((int)RegistryCache.GetValue("TurnOffSequentialGuid", (object)0) != 0)
            //    return Guid.NewGuid();
            Guid empty = Guid.Empty;
            if (0L != SequentialGuid.UuidCreateSequential(ref empty))
                return Guid.NewGuid();
            byte[] byteArray = empty.ToByteArray();
            byte num1 = byteArray[2];
            byteArray[2] = byteArray[1];
            byteArray[1] = num1;
            byte num2 = byteArray[3];
            byteArray[3] = byteArray[0];
            byteArray[0] = num2;
            byte num3 = byteArray[4];
            byteArray[4] = byteArray[5];
            byteArray[5] = num3;
            byte num4 = byteArray[6];
            byteArray[6] = byteArray[7];
            byteArray[7] = num4;
            return new Guid(byteArray);
        }
    }
}