using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Internal;
using Microsoft.Framework.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Framework.DependencyInjection;
using Microsoft.Data.Entity.Infrastructure;
using SpecificationPattern.ConsoleApp.Entities;

namespace SpecificationPattern.ConsoleApp.Data
{
  public class PessoaDbContext : DbContext
  {
    public DbSet<Pessoa> Pessoas { get; set; }

    public PessoaDbContext()
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      base.OnConfiguring(optionsBuilder);
      optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PessoaDb;Integrated Security=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
    }
    
  }
}
