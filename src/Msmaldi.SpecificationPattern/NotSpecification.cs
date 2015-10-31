namespace Msmaldi.SpecificationPattern
{
  using System;

  public class NotSpecification<T> : Specification<T>
  {
    private Specification<T> specification;

    public NotSpecification(Specification<T> specification)
    {
      if (specification == null)
        throw new ArgumentNullException();
      this.specification = specification;
    }

    public override bool IsSatisfiedBy(T arg)
    {
      return !specification.IsSatisfiedBy(arg);
    }
  }
}