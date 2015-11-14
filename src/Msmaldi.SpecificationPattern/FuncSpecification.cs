namespace Msmaldi.SpecificationPattern
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Threading.Tasks;

  public class FuncSpecification<T> : Specification<T>
  {
    private Func<T, bool> function;

    public FuncSpecification(Func<T, bool> function)
    {
      if (function == null)
        throw new ArgumentNullException();

      this.function = function;
    }

    public override bool IsSatisfiedBy(T arg)
    {
      return function(arg);
    }
  }
}
