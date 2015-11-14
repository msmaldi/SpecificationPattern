namespace Msmaldi.SpecificationPattern
{
  using System;
  using System.Linq.Expressions;

  public abstract class Specification<T>
  {
    public abstract bool IsSatisfiedBy(T arg);

    public static Specification<T> operator &(Specification<T> left, Specification<T> right) =>
      new AndSpecification<T>(left, right);

    public static Specification<T> operator |(Specification<T> left, Specification<T> right) =>
      new OrSpecification<T>(left, right);

    public static Specification<T> operator ^(Specification<T> left, Specification<T> right) =>
      new XorSpecification<T>(left, right);

    public static Specification<T> operator !(Specification<T> specification) =>
      new NotSpecification<T>(specification);

    public static implicit operator Expression<Func<T, bool>>(Specification<T> specification)
    {
      return (t) => specification.IsSatisfiedBy(t);
    }
  }
}
