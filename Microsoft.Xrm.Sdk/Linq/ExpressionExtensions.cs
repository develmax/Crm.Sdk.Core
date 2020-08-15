using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;

namespace Microsoft.Xrm.Sdk.Linq
{
  internal static class ExpressionExtensions
  {
    public static void ForSubtreePreorder(
      this Expression exp,
      ExpressionExtensions.ExpressionAction action)
    {
      exp.ForSubtreePreorder((Expression) null, action);
    }

    public static void ForSubtreePreorder(
      this Expression exp,
      Expression parent,
      ExpressionExtensions.ExpressionAction action)
    {
      action(exp, parent);
      foreach (Expression child in exp.GetChildren())
        child.ForSubtreePreorder(exp, action);
    }

    [SuppressMessage("Microsoft.Usage", "CA9888:DisposeObjectsCorrectly", Justification = "Value is returned from method and cannot be disposed.", Target = "local$0")]
    public static IEnumerable<Expression> GetChildren(this Expression exp)
    {
      switch (exp)
      {
        case UnaryExpression _:
          yield return ((UnaryExpression) exp).Operand;
          break;
        case BinaryExpression _:
          yield return ((BinaryExpression) exp).Left;
          yield return ((BinaryExpression) exp).Right;
          yield return (Expression) ((BinaryExpression) exp).Conversion;
          break;
        case TypeBinaryExpression _:
          yield return ((TypeBinaryExpression) exp).Expression;
          break;
        case ConditionalExpression _:
          yield return ((ConditionalExpression) exp).Test;
          yield return ((ConditionalExpression) exp).IfTrue;
          yield return ((ConditionalExpression) exp).IfFalse;
          break;
        case MemberExpression _:
          yield return ((MemberExpression) exp).Expression;
          break;
        case MethodCallExpression _:
          yield return ((MethodCallExpression) exp).Object;
          foreach (Expression expression in ((MethodCallExpression) exp).Arguments)
            yield return expression;
          break;
        case LambdaExpression _:
          yield return ((LambdaExpression) exp).Body;
          foreach (ParameterExpression parameter in ((LambdaExpression) exp).Parameters)
            yield return (Expression) parameter;
          break;
        case NewExpression _:
          foreach (Expression expression in ((NewExpression) exp).Arguments)
            yield return expression;
          break;
        case NewArrayExpression _:
          foreach (Expression expression in ((NewArrayExpression) exp).Expressions)
            yield return expression;
          break;
        case InvocationExpression _:
          yield return ((InvocationExpression) exp).Expression;
          foreach (Expression expression in ((InvocationExpression) exp).Arguments)
            yield return expression;
          break;
        case MemberInitExpression _:
          yield return (Expression) ((MemberInitExpression) exp).NewExpression;
          foreach (Expression child in ExpressionExtensions.GetChildren((IEnumerable<MemberBinding>) ((MemberInitExpression) exp).Bindings))
            yield return child;
          break;
        case ListInitExpression _:
          yield return (Expression) ((ListInitExpression) exp).NewExpression;
          foreach (Expression child in ExpressionExtensions.GetChildren((IEnumerable<ElementInit>) ((ListInitExpression) exp).Initializers))
            yield return child;
          break;
      }
    }

    private static IEnumerable<Expression> GetChildren(
      IEnumerable<MemberBinding> bindings)
    {
      return bindings.SelectMany<MemberBinding, Expression>(new Func<MemberBinding, IEnumerable<Expression>>(ExpressionExtensions.GetChildren));
    }

    [SuppressMessage("Microsoft.Usage", "CA9888:DisposeObjectsCorrectly", Justification = "Value is returned from method and cannot be disposed.", Target = "local$0")]
    private static IEnumerable<Expression> GetChildren(MemberBinding binding)
    {
      switch (binding.BindingType)
      {
        case MemberBindingType.Assignment:
          yield return ((MemberAssignment) binding).Expression;
          break;
        case MemberBindingType.MemberBinding:
          foreach (Expression child in ExpressionExtensions.GetChildren((IEnumerable<MemberBinding>) ((MemberMemberBinding) binding).Bindings))
            yield return child;
          break;
        case MemberBindingType.ListBinding:
          using (IEnumerator<Expression> enumerator = ExpressionExtensions.GetChildren((IEnumerable<ElementInit>) ((MemberListBinding) binding).Initializers).GetEnumerator())
          {
            while (enumerator.MoveNext())
            {
              Expression child = enumerator.Current;
              yield return child;
            }
            break;
          }
      }
    }

    private static IEnumerable<Expression> GetChildren(
      IEnumerable<ElementInit> initializers)
    {
      return initializers.SelectMany<ElementInit, Expression>((Func<ElementInit, IEnumerable<Expression>>) (initializer => (IEnumerable<Expression>) initializer.Arguments));
    }

    [SuppressMessage("Microsoft.Usage", "CA9888:DisposeObjectsCorrectly", Justification = "Value is returned from method and cannot be disposed.", Target = "local$0")]
    public static IEnumerable<Expression> GetSubtreePreorder(
      this Expression exp)
    {
      yield return exp;
      foreach (Expression expression in exp.GetChildren().SelectMany<Expression, Expression>((Func<Expression, IEnumerable<Expression>>) (child => child.GetSubtreePreorder())))
        yield return expression;
    }

    public static Expression FindPreorder(
      this Expression exp,
      Predicate<Expression> match)
    {
      return exp.GetSubtreePreorder().FirstOrDefault<Expression>((Func<Expression, bool>) (child => match(child)));
    }

    [SuppressMessage("Microsoft.Usage", "CA9888:DisposeObjectsCorrectly", Justification = "Value is returned from method and cannot be disposed.", Target = "local$0")]
    public static IEnumerable<MethodCallExpression> GetMethodsPreorder(
      this Expression exp)
    {
      if (exp is MethodCallExpression mce)
      {
        yield return mce;
        foreach (MethodCallExpression methodCallExpression in mce.Arguments[0].GetMethodsPreorder())
          yield return methodCallExpression;
      }
    }

    [SuppressMessage("Microsoft.Usage", "CA9888:DisposeObjectsCorrectly", Justification = "Value is returned from method and cannot be disposed.", Target = "local$0")]
    public static IEnumerable<MethodCallExpression> GetMethodsPostorder(
      this Expression exp)
    {
      if (exp is MethodCallExpression mce)
      {
        foreach (MethodCallExpression methodCallExpression in mce.Arguments[0].GetMethodsPostorder())
          yield return methodCallExpression;
        yield return mce;
      }
    }

    public delegate void ExpressionAction(Expression exp, Expression parent);
  }
}
