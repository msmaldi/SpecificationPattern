namespace Msmaldi.SpecificationPattern
{
  using System;

  public class OrSpecification<T> : Specification<T>
  {
    Specification<T> leftSpecification;
    Specification<T> rightSpecification;

    public OrSpecification(Specification<T> left, Specification<T> right)
    {
      if (left == null || right == null)
        throw new ArgumentNullException();

      this.leftSpecification = left;
      this.rightSpecification = right;
    }

    public override bool IsSatisfiedBy(T arg)
    {
      return this.leftSpecification.IsSatisfiedBy(arg)
          || this.rightSpecification.IsSatisfiedBy(arg);
    }
  }
}