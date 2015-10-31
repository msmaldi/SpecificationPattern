namespace Msmaldi.SpecificationPattern.Test
{
  using Entities;
  using Specifications;
  using System;
  using Xunit;

  public class SpecificationTest
  {    
    [Fact]
    public void SpecsTest()
    {
      Assert.True(ehMulherSpec.IsSatisfiedBy(paula));
      Assert.False(ehMulherSpec.IsSatisfiedBy(matheus));
      Assert.True(ehSolteiroSpec.IsSatisfiedBy(paula));
      Assert.False(ehSolteiroSpec.IsSatisfiedBy(pedro));
    }

    [Fact]
    public void AndSpecsTest()
    {
      var ehMulherSolteira = ehMulherSpec & ehSolteiroSpec;
      Assert.True(ehMulherSolteira.IsSatisfiedBy(paula));
      Assert.False(ehMulherSolteira.IsSatisfiedBy(matheus));
      Assert.False(ehMulherSolteira.IsSatisfiedBy(silvia));
    }

    [Fact]
    public void OrSpecsTest()
    {
      var ehViuvoOuSolteiro = ehViuvoSpec | ehSolteiroSpec;
      Assert.True(ehViuvoOuSolteiro.IsSatisfiedBy(angela));
      Assert.True(ehViuvoOuSolteiro.IsSatisfiedBy(matheus));
      Assert.False(ehViuvoOuSolteiro.IsSatisfiedBy(pedro));
    }

    [Fact]
    public void XorSpecsTest()
    {
      var ehOuMulherOuSolteiro = ehMulherSpec ^ ehSolteiroSpec;
      Assert.True(ehOuMulherOuSolteiro.IsSatisfiedBy(silvia));
      Assert.True(ehOuMulherOuSolteiro.IsSatisfiedBy(matheus));
      Assert.False(ehOuMulherOuSolteiro.IsSatisfiedBy(paula));
    }

    [Fact]
    public void NotSpecsTest()
    {
      var naoEhSolteiro = !ehSolteiroSpec;
      Assert.True(naoEhSolteiro.IsSatisfiedBy(pedro));
      Assert.False(naoEhSolteiro.IsSatisfiedBy(paula));
    }


    private EhMulherSpec ehMulherSpec = new EhMulherSpec();
    private EhSolteiroSpec ehSolteiroSpec = new EhSolteiroSpec();
    private EhViuvoSpec ehViuvoSpec = new EhViuvoSpec();

    private Pessoa matheus = new Pessoa
    {
      Name = "MATHEUS",
      Sexo = Sexo.Masculino,
      EstadoCivil = EstadoCivil.Solteiro,
      DataNascimento = new DateTime(day: 10, month: 10, year: 1991)
    };
    private Pessoa pedro = new Pessoa
    {
      Name = "PEDRO",
      Sexo = Sexo.Masculino,
      EstadoCivil = EstadoCivil.Casado,
      DataNascimento = new DateTime(day: 11, month: 09, year: 1962)
    };
    private Pessoa silvia = new Pessoa
    {
      Name = "SILVIA",
      Sexo = Sexo.Feminino,
      EstadoCivil = EstadoCivil.Casado,
      DataNascimento = new DateTime(day: 8, month: 12, year: 1969)
    };
    private Pessoa paula = new Pessoa
    {
      Name = "PAULA",
      Sexo = Sexo.Feminino,
      EstadoCivil = EstadoCivil.Solteiro,
      DataNascimento = new DateTime(day: 10, month: 10, year: 1991)
    };
    private Pessoa angela = new Pessoa
    {
      Name = "ANGELA",
      Sexo = Sexo.Feminino,
      EstadoCivil = EstadoCivil.Viuvo,
      DataNascimento = new DateTime(day: 10, month: 10, year: 1960)
    };
  }
}
