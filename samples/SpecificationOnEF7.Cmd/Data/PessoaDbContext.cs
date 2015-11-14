namespace SpecificationOnEF7.Cmd.Data
{
  using Entities;
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Threading.Tasks;
  using Microsoft.Data.Entity;

  public class PessoaDbContext : DbContext
  {
    public DbSet<Pessoa> Pessoas { get; set; }

    public PessoaDbContext()
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      base.OnConfiguring(optionsBuilder);
      optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PessoaDbEF7;Integrated Security=True;");
    }
  }
}
