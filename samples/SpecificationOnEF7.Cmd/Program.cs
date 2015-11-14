using Msmaldi.SpecificationPattern;
using SpecificationOnEF7.Cmd.Data;
using SpecificationOnEF7.Cmd.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpecificationOnEF7.Cmd
{
  public class Program
  {
    public void Main(string[] args)
    {
      var ehSolteiro = new ExpressionSpecification<Pessoa>(p => p.EstadoCivil == EstadoCivil.Solteiro);
      var ehHomem = new ExpressionSpecification<Pessoa>(p => p.Sexo == Sexo.Masculino);
      var ehHomemSolteiro = ehSolteiro & ehHomem;
      var ouHomemOuSolteiro = ehHomem ^ ehSolteiro;

      var log = new Microsoft.Framework.Logging.LoggerFactory();
      log.MinimumLevel = Microsoft.Framework.Logging.LogLevel.Verbose;

      using (var db = new PessoaDbContext())
      {
        db.Pessoas.Where(ouHomemOuSolteiro)
          .Select(x => x).ToList().ForEach(x => Console.WriteLine(x));

      }


      Console.WriteLine("Finished OK.");
      Console.ReadLine();
    }
  }
}
