using System.Runtime.Serialization;

namespace Microsoft.Xrm.Sdk.Query
{
    /// <summary>Describes the type of comparison for two values (or expressions) in a condition expression. </summary>
    [DataContract(Name = "ConditionOperator", Namespace = "http://schemas.microsoft.com/xrm/2011/Contracts")]
    public enum ConditionOperator
    {
        /// <summary>The values are compared for equality. Value = 0.</summary>
        [EnumMember] Equal,
        /// <summary>The two values are not equal. Value = 1.</summary>
        [EnumMember] NotEqual,
        /// <summary>The value is greater than the compared value. Value = 2.</summary>
        [EnumMember] GreaterThan,
        /// <summary>The value is less than the compared value. Value = 3.</summary>
        [EnumMember] LessThan,
        /// <summary>The value is greater than or equal to the compared value. Value = 4.</summary>
        [EnumMember] GreaterEqual,
        /// <summary>The value is less than or equal to the compared value. Value = 5.</summary>
        [EnumMember] LessEqual,
        /// <summary>The character string is matched to the specified pattern. Value = 6.</summary>
        [EnumMember] Like,
        /// <summary>The character string does not match the specified pattern. Value = 7.</summary>
        [EnumMember] NotLike,
        /// <summary>TheThe value exists in a list of values. Value = 8.</summary>
        [EnumMember] In,
        /// <summary>The given value is not matched to a value in a subquery or a list. Value = 9.</summary>
        [EnumMember] NotIn,
        /// <summary>The value is between two values. Value = 10.</summary>
        [EnumMember] Between,
        /// <summary>The value is not between two values. Value = 11.</summary>
        [EnumMember] NotBetween,
        /// <summary>The value is null. Value = 12.</summary>
        [EnumMember] Null,
        /// <summary>The value is not null. Value = 13.</summary>
        [EnumMember] NotNull,
        /// <summary>The value equals yesterday’s date. Value = 14.</summary>
        [EnumMember] Yesterday,
        /// <summary>The value equals today’s date. Value = 15.</summary>
        [EnumMember] Today,
        /// <summary>The value equals tomorrow’s date. Value = 16.</summary>
        [EnumMember] Tomorrow,
        /// <summary>The value is within the last seven days including today. Value = 17.</summary>
        [EnumMember] Last7Days,
        /// <summary>The value is within the next seven days. Value = 18.</summary>
        [EnumMember] Next7Days,
        /// <summary>The value is within the previous week including Sunday through Saturday. Value = 19.</summary>
        [EnumMember] LastWeek,
        /// <summary>The value is within the current week. Value = 20.</summary>
        [EnumMember] ThisWeek,
        /// <summary>The value is within the next week. Value = 21.</summary>
        [EnumMember] NextWeek,
        /// <summary>The value is within the last month including first day of the last month and last day of the last month. Value = 22.</summary>
        [EnumMember] LastMonth,
        /// <summary>The value is within the current month. Value = 23.</summary>
        [EnumMember] ThisMonth,
        /// <summary>The value is within the next month. Value = 24.</summary>
        [EnumMember] NextMonth,
        /// <summary>The value is on a specified date. Value = 25.</summary>
        [EnumMember] On,
        /// <summary>The value is on or before a specified date. Value = 26.</summary>
        [EnumMember] OnOrBefore,
        /// <summary>The value is on or after a specified date. Value = 27.</summary>
        [EnumMember] OnOrAfter,
        /// <summary>The value is within the previous year. Value = 28.</summary>
        [EnumMember] LastYear,
        /// <summary>The value is within the current year. Value = 29.</summary>
        [EnumMember] ThisYear,
        /// <summary>The value is within the next year. Value = 30.</summary>
        [EnumMember] NextYear,
        /// <summary>The value is within the last X hours. Value =31.</summary>
        [EnumMember] LastXHours,
        /// <summary>The value is within the next X (specified value) hours. Value = 32.</summary>
        [EnumMember] NextXHours,
        /// <summary>The value is within last X days. Value = 33.</summary>
        [EnumMember] LastXDays,
        /// <summary>The value is within the next X (specified value) days. Value = 34.</summary>
        [EnumMember] NextXDays,
        /// <summary>The value is within the last X (specified value) weeks. Value = 35.</summary>
        [EnumMember] LastXWeeks,
        /// <summary>The value is within the next X weeks. Value = 36.</summary>
        [EnumMember] NextXWeeks,
        /// <summary>The value is within the last X (specified value) months. Value = 37.</summary>
        [EnumMember] LastXMonths,
        /// <summary>The value is within the next X (specified value) months. Value = 38.</summary>
        [EnumMember] NextXMonths,
        /// <summary>The value is within the last X years. Value = 39.</summary>
        [EnumMember] LastXYears,
        /// <summary>The value is within the next X years. Value = 40.</summary>
        [EnumMember] NextXYears,
        /// <summary>The value is equal to the specified user ID. Value = 41.</summary>
        [EnumMember] EqualUserId,
        /// <summary>The value is not equal to the specified user ID. Value = 42.</summary>
        [EnumMember] NotEqualUserId,
        /// <summary>The value is equal to the specified business ID. Value = 43.</summary>
        [EnumMember] EqualBusinessId,
        /// <summary>The value is not equal to the specified business ID. Value = 44.</summary>
        [EnumMember] NotEqualBusinessId,
        /// <summary>internal</summary>
        [EnumMember] ChildOf,
        /// <summary>The value is found in the specified bit-mask value. Value = 46.</summary>
        [EnumMember] Mask,
        /// <summary>The value is not found in the specified bit-mask value. Value = 47.</summary>
        [EnumMember] NotMask,
        /// <summary>Internal Value = 48.</summary>
        [EnumMember] MasksSelect,
        /// <summary>The string contains another string. Value = 49.You must use the Contains operator for only those attributes that are enabled for full-text indexing. Otherwise, you will receive a generic SQL error message while retrieving data. In a pn_microsoftcrm default installation, only the attributes of the KBArticle (article) entity are enabled for full-text indexing.</summary>
        [EnumMember] Contains,
        /// <summary>The string does not contain another string. Value = 50.</summary>
        [EnumMember] DoesNotContain,
        /// <summary>The value is equal to the language for the user. Value = 51.</summary>
        [EnumMember] EqualUserLanguage,
        /// <summary>The value is not on the specified date. Value = 52.</summary>
        [EnumMember] NotOn,
        /// <summary>The value is older than the specified number of months. Value = 53.</summary>
        [EnumMember] OlderThanXMonths,
        /// <summary>The string occurs at the beginning of another string. Value = 54.</summary>
        [EnumMember] BeginsWith,
        /// <summary>The string does not begin with another string. Value = 55.</summary>
        [EnumMember] DoesNotBeginWith,
        /// <summary>The string ends with another string. Value = 56.</summary>
        [EnumMember] EndsWith,
        /// <summary>The string does not end with another string. Value = 57.</summary>
        [EnumMember] DoesNotEndWith,
        /// <summary>The value is within the current fiscal year . Value = 58.</summary>
        [EnumMember] ThisFiscalYear,
        /// <summary>The value is within the current fiscal period. Value = 59.</summary>
        [EnumMember] ThisFiscalPeriod,
        /// <summary>The value is within the next fiscal year. Value = 60.</summary>
        [EnumMember] NextFiscalYear,
        /// <summary>The value is within the next fiscal period. Value = 61.</summary>
        [EnumMember] NextFiscalPeriod,
        /// <summary>The value is within the last fiscal year. Value = 62.</summary>
        [EnumMember] LastFiscalYear,
        /// <summary>The value is within the last fiscal period. Value = 63.</summary>
        [EnumMember] LastFiscalPeriod,
        /// <summary>The value is within the last X (specified value) fiscal periods. Value = 0x40.</summary>
        [EnumMember] LastXFiscalYears,
        /// <summary>The value is within the last X (specified value) fiscal periods. Value = 65.</summary>
        [EnumMember] LastXFiscalPeriods,
        /// <summary>The value is within the next X (specified value) fiscal years. Value = 66.</summary>
        [EnumMember] NextXFiscalYears,
        /// <summary>The value is within the next X (specified value) fiscal period. Value = 67.</summary>
        [EnumMember] NextXFiscalPeriods,
        /// <summary>The value is within the specified year. Value = 68.</summary>
        [EnumMember] InFiscalYear,
        /// <summary>The value is within the specified fiscal period. Value = 69.</summary>
        [EnumMember] InFiscalPeriod,
        /// <summary>The value is within the specified fiscal period and year. Value = 70.</summary>
        [EnumMember] InFiscalPeriodAndYear,
        /// <summary>The value is within or before the specified fiscal period and year. Value = 71.</summary>
        [EnumMember] InOrBeforeFiscalPeriodAndYear,
        /// <summary>The value is within or after the specified fiscal period and year. Value = 72.</summary>
        [EnumMember] InOrAfterFiscalPeriodAndYear,
        /// <summary>The record is owned by teams that the user is a member of. Value = 73.</summary>
        [EnumMember] EqualUserTeams,
        /// <summary>The record is owned by a user or teams that the user is a member of. Value = 74.</summary>
        [EnumMember] EqualUserOrUserTeams,
        /// <summary>Returns all child records below the referenced record in the hierarchy. Value = 76.</summary>
        [EnumMember] Under,
        /// <summary>Returns all records not below the referenced record in the hierarchy. Value = 77.</summary>
        [EnumMember] NotUnder,
        /// <summary>Returns the referenced record and all child records below it in the hierarchy. Value = 79.</summary>
        [EnumMember] UnderOrEqual,
        /// <summary>Returns all records in referenced record's hierarchical ancestry line. Value = 75.</summary>
        [EnumMember] Above,
        /// <summary>Returns the referenced record and all records above it in the hierarchy. Value = 78.</summary>
        [EnumMember] AboveOrEqual,
        /// <summary>When hierarchical security models are used, Equals current user or their reporting hierarchy. Value = 80.</summary>
        [EnumMember] EqualUserOrUserHierarchy,
        /// <summary>When hierarchical security models are used, Equals current user and his teams or their reporting hierarchy and their teams. Value = 81.</summary>
        [EnumMember] EqualUserOrUserHierarchyAndTeams,
    }
}