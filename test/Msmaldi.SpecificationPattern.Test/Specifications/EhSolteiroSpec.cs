namespace Msmaldi.SpecificationPattern.Test.Specifications
{
  using Entities;

  public class EhSolteiroSpec : Specification<Pessoa>
  {
    public override bool IsSatisfiedBy(Pessoa arg)
    {
      return arg.EstadoCivil == EstadoCivil.Solteiro;
    }
  }
}
