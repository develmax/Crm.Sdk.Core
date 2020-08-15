using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Security;

namespace Microsoft.Xrm.Sdk.Discovery
{
  internal static class SdkUtilities
  {
    [SecuritySafeCritical]
    internal static string SecureStringToString(SecureString value)
    {
      if (value == null)
        return (string) null;
      IntPtr num = IntPtr.Zero;
      try
      {
        num = Marshal.SecureStringToBSTR(value);
        return Marshal.PtrToStringUni(num);
      }
      finally
      {
        if (num != IntPtr.Zero)
          Marshal.ZeroFreeBSTR(num);
      }
    }

    [SuppressMessage("Microsoft.Usage", "CA9888:DisposeObjectsCorrectly", Justification = "Value is returned from method and cannot be disposed.")]
    internal static SecureString StringToSecureString(string value)
    {
      if (value == null)
        return (SecureString) null;
      SecureString secureString = new SecureString();
      foreach (char c in value)
        secureString.AppendChar(c);
      secureString.MakeReadOnly();
      return secureString;
    }
  }
}
