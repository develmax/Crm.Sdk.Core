using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xrm.Sdk.Query;

namespace Crm.Sdk.Core.Linq.Tests
{
	public static class EqualEx
	{
		public static void AreEqual(FilterExpression item0, FilterExpression item1)
		{
			Assert.AreEqual(item0.FilterOperator, item1.FilterOperator);

			Assert.AreEqual(item0.Conditions.Count, item1.Conditions.Count);
			Assert.AreEqual(item0.Filters.Count, item1.Filters.Count);

			foreach (var a in item0.Conditions)
			{
				bool flag = item1.Conditions.Any(b => Equals(a, b));

				if (flag == false)
				{
					Assert.Fail($"Conditions не совпадают. {a} не найдена");
				}
			}

			foreach (var a in item0.Filters)
			{
				bool flag = item1.Filters.Any(b => Equals(a, b));

				if (flag == false)
				{
					Assert.Fail($"Filters не совпадают. {a} не найдена");
				}
			}
		}

		public static void AreEqual(ConditionExpression item0, ConditionExpression item1)
		{
			Assert.AreEqual(item0.Operator, item1.Operator);
			Assert.AreEqual(item0.EntityName, item1.EntityName);
			Assert.AreEqual(item0.AttributeName, item1.AttributeName);
		}

		public static bool Equals(ConditionExpression item0, ConditionExpression item1)
		{
			if (item0.Operator != item1.Operator)
			{
				return false;
			}

			if (item0.EntityName != item1.EntityName)
			{
				return false;
			}

			if (item0.AttributeName != item1.AttributeName)
			{
				return false;
			}

			if (item0.Values.Count != item1.Values.Count)
			{
				return false;
			}

			return item0.Values.All(t => item1.Values.Contains(t));
		}

		public static bool Equals(FilterExpression item0, FilterExpression item1)
		{
			if (item0.FilterOperator != item1.FilterOperator)
			{
				return false;
			}

			if (item0.Conditions.Count != item1.Conditions.Count)
			{
				return false;
			}

			if (item0.Filters.Count != item1.Filters.Count)
			{
				return false;
			}

			foreach (var a in item0.Conditions)
			{
				bool flag = item1.Conditions.Any(b => Equals(a, b));

				if (flag == false)
				{
					return false;
				}
			}

			foreach (var a in item0.Filters)
			{
				bool flag = item1.Filters.Any(b => Equals(a, b));

				if (flag == false)
				{
					return false;
				}
			}

			return true;
		}
	}
}
