using Microsoft.EntityFrameworkCore;
using Stone.Api.Contracheque.Domain.Entities;

namespace Stone.Api.Contracheque.Repository.Context
{
    public class FuncionarioContext : DbContext
    {
        public FuncionarioContext(DbContextOptions<FuncionarioContext> options)
            : base(options) { }

        public DbSet<Funcionario> Funcionarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FuncionarioContext).Assembly);
        }
    }
}
