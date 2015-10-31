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
      var tVar = Expression.Parameter(typeof(T), "tVar");
      var exprAnd = Expression.AndAlso(Expression.Invoke(expression, tVar),
        Expression.Invoke(specification.expression, tVar));
      return new ExpressionSpecification<T>(Expression.Lambda<Func<T, bool>>(exprAnd, tVar));
    }

    private ExpressionSpecification<T> Or(ExpressionSpecification<T> specification)
    {
      var tVar = Expression.Parameter(typeof(T), "tVar");
      var exprOr = Expression.OrElse(Expression.Invoke(expression, tVar),
        Expression.Invoke(specification.expression, tVar));
      return new ExpressionSpecification<T>(Expression.Lambda<Func<T, bool>>(exprOr, tVar));
    }

    private ExpressionSpecification<T> Xor(ExpressionSpecification<T> specification)
    {
      var tVar = Expression.Parameter(typeof(T), "tVar");
      var exprXor = Expression.ExclusiveOr(Expression.Invoke(expression, tVar),
        Expression.Invoke(specification.expression, tVar));
      return new ExpressionSpecification<T>(Expression.Lambda<Func<T, bool>>(exprXor, tVar));
    }

    private ExpressionSpecification<T> Not()
    {
      var tVar = Expression.Parameter(typeof(T), "tVar");
      var exprNot = Expression.Not(Expression.Invoke(expression, tVar));
      return new ExpressionSpecification<T>(Expression.Lambda<Func<T, bool>>(exprNot, tVar));
    }
  }
}
