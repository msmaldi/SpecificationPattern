namespace Msmaldi.SpecificationPattern.Test.Specifications
{
  using Entities;

  public class EhMulherSpec : Specification<Pessoa>
  {
    public override bool IsSatisfiedBy(Pessoa arg)
    {
      return arg.Sexo == Sexo.Feminino;
    }
  }
}
