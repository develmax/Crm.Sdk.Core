﻿using Microsoft.Xrm.Sdk.Query;

namespace Microsoft.Xrm.Sdk.Linq
{
  internal static class FilterExpressionExtensions
  {
    public static void ForSubtreePreorder(this FilterExpression exp, FilterExpressionExtensions.FilterAction action)
    {
      exp.ForSubtreePreorder(null, action);
    }

    public static void ForSubtreePreorder(this FilterExpression exp, FilterExpression parent, FilterExpressionExtensions.FilterAction action)
    {
      action(exp, parent);
      if (exp.Filters == null)
      {
	      return;
      }

      foreach (FilterExpression filter in exp.Filters)
      {
	      filter.ForSubtreePreorder(exp, action);
      }
    }

    public static void ForSubtreePreorder(this FilterExpression exp, FilterExpressionExtensions.FilterAction filterAction, FilterExpressionExtensions.ConditionAction conditionAction)
    {
      exp.ForSubtreePreorder(null, filterAction, conditionAction);
    }

    public static void ForSubtreePreorder(this FilterExpression exp, FilterExpression parent, FilterExpressionExtensions.FilterAction filterAction, FilterExpressionExtensions.ConditionAction conditionAction)
    {
      exp.ForSubtreePreorder(parent, (e, p) =>
      {
	      filterAction(e, p);
	      if (e.Conditions == null)
	      {
		      return;
	      }

	      foreach (ConditionExpression condition in e.Conditions)
	      {
		      conditionAction(condition, e);
	      }
      });
    }

    public static void ForSubtreePostorder(this FilterExpression exp, FilterExpressionExtensions.FilterAction action)
    {
      exp.ForSubtreePostorder(null, action);
    }

    public static void ForSubtreePostorder(this FilterExpression exp, FilterExpression parent, FilterExpressionExtensions.FilterAction action)
    {
      if (exp.Filters != null)
      {
        foreach (FilterExpression filter in exp.Filters)
        {
	        filter.ForSubtreePostorder(exp, action);
        }
      }
      action(exp, parent);
    }

    public static void ForSubtreePostorder(this FilterExpression exp, FilterExpressionExtensions.FilterAction filterAction, FilterExpressionExtensions.ConditionAction conditionAction)
    {
      exp.ForSubtreePostorder(null, filterAction, conditionAction);
    }

    public static void ForSubtreePostorder(this FilterExpression exp, FilterExpression parent, FilterExpressionExtensions.FilterAction filterAction, FilterExpressionExtensions.ConditionAction conditionAction)
    {
      exp.ForSubtreePostorder(parent, (e, p) =>
      {
	      if (e.Conditions != null)
	      {
		      foreach (ConditionExpression condition in e.Conditions)
		      {
			      conditionAction(condition, e);
		      }
	      }
	      filterAction(e, p);
      });
    }

    public delegate void FilterAction(FilterExpression exp, FilterExpression parent);

    public delegate void ConditionAction(ConditionExpression exp, FilterExpression parent);
  }
}
