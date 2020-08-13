namespace Microsoft.Crm.Sdk
{
  /// <summary>Contains integer flags that are used for the List.MemberType attribute, used to indicate whether a list specifies accounts, contacts, or leads.</summary>
  public static class ListMemberType
  {
    /// <summary>A list of accounts. Value = 1.</summary>
    public const int Account = 1;
    /// <summary>A list of contacts. Value = 2.</summary>
    public const int Contact = 2;
    /// <summary>A list of leads. Value = 4.</summary>
    public const int Lead = 4;
  }
}
