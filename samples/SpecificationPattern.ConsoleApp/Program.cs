using Msmaldi.SpecificationPattern;
using SpecificationPattern.ConsoleApp.Data;
using SpecificationPattern.ConsoleApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SpecificationPattern.ConsoleApp
{
  public class Program
  {
    public void Main(string[] args)
    {
      var mulher = new ExpressionSpecification<Pessoa>(p => p.Sexo == Sexo.Feminino);
      var solteiro = new ExpressionSpecification<Pessoa>(p => p.EstadoCivil == EstadoCivil.Solteiro);
      var mulherSolteira = mulher & solteiro;

      var casado = new ExpressionSpecification<Pessoa>(p => p.EstadoCivil == EstadoCivil.Casado);
      var naoCasado = !casado;

      SampleData.InitializePessoaDatabaseAsync().Wait();

      using (var db = new PessoaDbContext())
      {
        Console.WriteLine("----- Mulher Solteiras -----");
        var mulherSolteiraQuery = db.Pessoas.Where(mulherSolteira);
        foreach (var p in mulherSolteiraQuery)
          Console.WriteLine(p);

        Console.WriteLine("----- Não Casado -----");
        var naoCasadoQuery = db.Pessoas.Where(naoCasado);
        foreach (var p in naoCasadoQuery)
          Console.WriteLine(p);
      }

      Console.WriteLine("Finished OK.");
      Console.ReadLine();
    }
  }
}
