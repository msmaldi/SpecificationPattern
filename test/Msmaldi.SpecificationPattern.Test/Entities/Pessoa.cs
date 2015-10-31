namespace Msmaldi.SpecificationPattern.Test.Entities
{
  using System;

  public class Pessoa
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime DataNascimento { get; set; }
    public Sexo Sexo { get; set; }
    public EstadoCivil EstadoCivil { get; set; }

    public override string ToString()
    {
      return $"Nome: {Name}, Sexo: {Sexo}, Estado Civil: {EstadoCivil}";
    }
  }
}
