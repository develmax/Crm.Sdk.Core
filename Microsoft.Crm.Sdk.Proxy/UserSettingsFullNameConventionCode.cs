namespace Microsoft.Crm.Sdk
{
  /// <summary>Contains integer values that are used for the UserSettings.FullNameConventionCode attribute.</summary>
  public static class UserSettingsFullNameConventionCode
  {
    /// <summary>Show the last name and then the first name. Value = 0.</summary>
    public const int LastFirst = 0;
    /// <summary>Show the first and last name. Value = 1.</summary>
    public const int FirstLast = 1;
    /// <summary>Show the last name first, then the first name and the middle initial. Value = 2.</summary>
    public const int LastFirstMiddleInitial = 2;
    /// <summary>Show the first name, middle initial and last name. Value = 3.</summary>
    public const int FirstMiddleInitialLast = 3;
    /// <summary>Show the last name first, then the first name and the middle name. Value = 4.</summary>
    public const int LastFirstMiddle = 4;
    /// <summary>Show the first, middle and last names. Value = 5.</summary>
    public const int FirstMiddleLast = 5;
    /// <summary>Show the last name and then the first name, with a space separating the names. Value = 6.</summary>
    public const int LastSpaceFirst = 6;
    /// <summary>Show the last name and then the first name, with no space separating the names. Value = 7.</summary>
    public const int LastNoSpaceFirst = 7;
  }
}
