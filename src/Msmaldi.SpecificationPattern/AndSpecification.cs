namespace Msmaldi.SpecificationPattern
{
  using System;

  public class AndSpecification<T> : Specification<T>
  {
    private Specification<T> leftSpecification;
    private Specification<T> rightSpecification;

    public AndSpecification(Specification<T> left, Specification<T> right)
    {
      if (left == null || right == null)
        throw new ArgumentNullException();

      leftSpecification = left;
      rightSpecification = right;
    }

    public override bool IsSatisfiedBy(T o)
    {
      return leftSpecification.IsSatisfiedBy(o)
          && rightSpecification.IsSatisfiedBy(o);
    }
  }
}