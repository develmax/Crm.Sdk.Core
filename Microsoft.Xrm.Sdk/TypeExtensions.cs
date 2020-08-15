using System;

namespace Microsoft.Xrm.Sdk
{
  internal static class TypeExtensions
  {
    public static string GetLogicalName(this Type type)
    {
      return KnownProxyTypesProvider.GetInstance(true).GetNameForType(type);
    }

    public static Type GetUnderlyingType(this Type type)
    {
      Type underlyingType = Nullable.GetUnderlyingType(type);
      return (object) underlyingType != null ? underlyingType : type;
    }

    public static bool IsA<T>(this Type type)
    {
      return type.IsA(typeof (T));
    }

    public static bool IsA(this Type type, Type referenceType)
    {
      return referenceType != (Type) null && referenceType.IsAssignableFrom(type);
    }
  }
}
