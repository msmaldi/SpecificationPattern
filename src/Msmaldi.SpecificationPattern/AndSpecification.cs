namespace Msmaldi.SpecificationPattern
{
  using System;

  public class AndSpecification<T> : Specification<T>
  {
    Specification<T> leftSpecification;
    Specification<T> rightSpecification;

    public AndSpecification(Specification<T> left, Specification<T> right)
    {
      if (left == null || right == null)
        throw new ArgumentNullException();

      this.leftSpecification = left;
      this.rightSpecification = right;
    }

    public override bool IsSatisfiedBy(T o)
    {
      return this.leftSpecification.IsSatisfiedBy(o)
          && this.rightSpecification.IsSatisfiedBy(o);
    }
  }
}