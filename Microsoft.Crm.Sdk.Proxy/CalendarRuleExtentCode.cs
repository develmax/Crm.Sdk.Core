namespace Microsoft.Crm.Sdk
{
  /// <summary>Contains integer flags that are used for the CalendarRule.ExtentCode attribute.</summary>
  public static class CalendarRuleExtentCode
  {
    /// <summary>No shadowing of calendar rules. All rules are displayed even if they are shadowed or preceded by other rules. Value = 0.</summary>
    public const int Transparent = 0;
    /// <summary>The recurrence duration determines the shadowing of that rule. Use this value to indicate working hours and a full day 24-hour shadow. Value = 1.</summary>
    public const int SubtractRecurrenceIntervals = 1;
    /// <summary>Only the rule duration is shadowed. Use this value to indicate time off. For example, 4 hours of time off allow working hours to appear before and after. Value = 2.</summary>
    public const int SubtractResults = 2;
  }
}
