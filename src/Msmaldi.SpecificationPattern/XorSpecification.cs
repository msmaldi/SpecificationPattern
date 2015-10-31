namespace Msmaldi.SpecificationPattern
{
  using System;

  public class XorSpecification<T> : Specification<T>
  {
    private Specification<T> leftSpecification;
    private Specification<T> rightSpecification;

    public XorSpecification(Specification<T> left, Specification<T> right)
    {
      if (left == null || right == null)
        throw new ArgumentNullException();

      leftSpecification = left;
      rightSpecification = right;
    }

    public override bool IsSatisfiedBy(T arg)
    {
      return leftSpecification.IsSatisfiedBy(arg)
           ^ rightSpecification.IsSatisfiedBy(arg);
    }
  }
}