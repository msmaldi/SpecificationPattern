namespace Msmaldi.SpecificationPattern
{
  using System;
  using System.Linq.Expressions;

  public class ExpressionSpecification<T> : Specification<T>
  {
    private Expression<Func<T, bool>> expression;

    public ExpressionSpecification(Expression<Func<T, bool>> expression)
    {
      if (expression == null)
        throw new ArgumentNullException();

      this.expression = expression;
    }

    public override bool IsSatisfiedBy(T arg)
    {
      return this.expression.Compile()(arg);
    }

    public static ExpressionSpecification<T> operator &(ExpressionSpecification<T> left, ExpressionSpecification<T> right) =>
      left.And(right);

    public static ExpressionSpecification<T> operator |(ExpressionSpecification<T> left, ExpressionSpecification<T> right) =>
      left.Or(right);

    public static ExpressionSpecification<T> operator ^(ExpressionSpecification<T> left, ExpressionSpecification<T> right) =>
      left.Xor(right);

    public static ExpressionSpecification<T> operator !(ExpressionSpecification<T> specification) =>
      specification.Not();

    public static implicit operator Expression<Func<T, bool>>(ExpressionSpecification<T> specification) =>
      specification.expression;

    private ExpressionSpecification<T> And(ExpressionSpecification<T> specification)
    {
      var t = Expression.Parameter(typeof(T), "t");
      var exprAnd = Expression.AndAlso(Expression.Invoke(expression, t),
        Expression.Invoke(specification.expression, t));
      return new ExpressionSpecification<T>(Expression.Lambda<Func<T, bool>>(exprAnd, t));
    }

    private ExpressionSpecification<T> Or(ExpressionSpecification<T> specification)
    {
      var t = Expression.Parameter(typeof(T), "t");
      var exprOr = Expression.OrElse(Expression.Invoke(expression, t),
        Expression.Invoke(specification.expression, t));
      return new ExpressionSpecification<T>(Expression.Lambda<Func<T, bool>>(exprOr, t));
    }

    private ExpressionSpecification<T> Xor(ExpressionSpecification<T> specification)
    {
      // This implementation doesnt supported in query
      //var t = Expression.Parameter(typeof(T), "t");
      //var exprXor = Expression.ExclusiveOr(Expression.Invoke(expression, t),
      //  Expression.Invoke(specification.expression, t));
      //return new ExpressionSpecification<T>(Expression.Lambda<Func<T, bool>>(exprXor, t));

      //  A xor B = (not A and B) or (A and not B)
      var t = Expression.Parameter(typeof(T), "t");
      var exprNotA = Expression.Not(Expression.Invoke(expression, t));
      var exprNotB = Expression.Not(Expression.Invoke(specification.expression, t));
      var exprNotAandB = Expression.AndAlso(exprNotA, Expression.Invoke(specification.expression, t));
      var exprAandNotB = Expression.AndAlso(Expression.Invoke(expression, t), exprNotB);
      var exprAxorB = Expression.OrElse(exprNotAandB, exprAandNotB);
      return new ExpressionSpecification<T>(Expression.Lambda<Func<T, bool>>(exprAxorB, t));
    }

    private ExpressionSpecification<T> Not()
    {
      var t = Expression.Parameter(typeof(T), "t");
      var exprNot = Expression.Not(Expression.Invoke(expression, t));
      return new ExpressionSpecification<T>(Expression.Lambda<Func<T, bool>>(exprNot, t));
    }
  }
}
