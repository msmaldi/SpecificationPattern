namespace SpecificationPattern.ConsoleApp.Data
{
  using Entities;
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Threading.Tasks;

  public static class SampleData
  {
    public static async Task InitializePessoaDatabaseAsync()
    {
      using (var db = new PessoaDbContext())
      {
        db.Database.EnsureDeleted();
        db.Database.EnsureCreated();

        db.AddRange(GetPessoas());
        await db.SaveChangesAsync();
      }
    }

    private static Pessoa[] GetPessoas()
    {
      return new Pessoa[]
      {
        new Pessoa { Name = "MATHEUS SOARES MALDI", Sexo = Sexo.Masculino, EstadoCivil = EstadoCivil.Solteiro,
                     DataNascimento = new DateTime(day: 10, month: 10, year: 1991) },
        new Pessoa { Name = "PEDRO MALDI NETO", Sexo = Sexo.Masculino, EstadoCivil = EstadoCivil.Casado,
                     DataNascimento = new DateTime(day: 11, month: 09, year: 1962) },
        new Pessoa { Name = "JOAO VICTOR SOARES MALDI", Sexo = Sexo.Masculino, EstadoCivil = EstadoCivil.Casado,
                     DataNascimento = new DateTime(day: 14, month: 06, year: 1987) },
        new Pessoa { Name = "SILVIA HELENA APARECIDA SOARES MALDI", Sexo = Sexo.Feminino, EstadoCivil = EstadoCivil.Casado,
                     DataNascimento = new DateTime(day: 8, month: 12, year: 1969) },
        new Pessoa { Name = "ANALU CAMARGO DE CASTRO", Sexo = Sexo.Feminino, EstadoCivil = EstadoCivil.Casado,
                     DataNascimento = new DateTime(day: 10, month: 10, year: 1991) },
        new Pessoa { Name = "PAULA CRISTINA COUTO", Sexo = Sexo.Feminino, EstadoCivil = EstadoCivil.Solteiro,
                     DataNascimento = new DateTime(day: 10, month: 10, year: 1991) }
      };
    }
  }
}
