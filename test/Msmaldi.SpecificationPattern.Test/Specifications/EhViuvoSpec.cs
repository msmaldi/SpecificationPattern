namespace Msmaldi.SpecificationPattern.Test.Specifications
{
  using Entities;

  public class EhViuvoSpec : Specification<Pessoa>
  {
    public override bool IsSatisfiedBy(Pessoa arg)
    {
      return arg.EstadoCivil == EstadoCivil.Viuvo;
    }
  }
}
