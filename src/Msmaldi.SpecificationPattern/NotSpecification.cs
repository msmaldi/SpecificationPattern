namespace Msmaldi.SpecificationPattern
{
  using System;

  public class NotSpecification<T> : Specification<T>
  {
    Specification<T> specification;

    public NotSpecification(Specification<T> specification)
    {
      if (specification == null)
        throw new ArgumentNullException();
      this.specification = specification;
    }

    public override bool IsSatisfiedBy(T arg)
    {
      return !this.specification.IsSatisfiedBy(arg);
    }
  }
}