namespace Microsoft.Crm.Sdk
{
  /// <summary>Contains integer values that are used for the BusinessUnit.InheritanceMask attribute.</summary>
  public static class BusinessUnitInheritanceMask
  {
    /// <summary>The business does not inherit from its parent business. Value = 0.</summary>
    public const int InheritNone = 0;
    /// <summary>All child business units inherit process templates from this business. Value = 1.</summary>
    public const int InheritProcessTemplate = 1;
    /// <summary>The business inherits email templates from its parent business. Value = 2.</summary>
    public const int InheritEmailTemplate = 2;
    /// <summary>All child business units inherit referral sources from this business. Value = 4.</summary>
    public const int InheritReferralSource = 4;
    /// <summary>The business inherits competitors from its parent business. Value = 8.</summary>
    public const int InheritCompetitor = 8;
    /// <summary>The business inherits sale processes from its parent business. Value = 0x10.</summary>
    public const int InheritSalesProcess = 16;
    /// <summary>The business inherits process templates from its parent business. Value = 0x20.</summary>
    public const int MustInheritProcessTemplate = 32;
    /// <summary>All child business units inherit email templates from this business. Value = 0x40.</summary>
    public const int MustInheritEmailTemplate = 64;
    /// <summary>All child business units inherit referral sources from this business. Value = 0x80.</summary>
    public const int MustInheritReferralSource = 128;
    /// <summary>The business inherits competitors from its parent business. Value = 0x100.</summary>
    public const int MustInheritCompetitor = 256;
    /// <summary>The business inherits sale processes from its parent business. Value = 0x200.</summary>
    public const int MustInheritSalesProcess = 512;
    /// <summary>The business inherits all inheritance values. Value = 0x3ff.</summary>
    public const int InheritAll = 1023;
  }
}
