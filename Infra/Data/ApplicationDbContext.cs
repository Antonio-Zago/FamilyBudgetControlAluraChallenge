using FamilyBudgetControlAluraChallenge.Domain.DespesaDomain;
using FamilyBudgetControlAluraChallenge.Domain.ReceitaDomain;
using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;

namespace FamilyBudgetControlAluraChallenge.Infra.Data
{
    public class ApplicationDbContext : DbContext
    {

        public DbSet<Receita> Receitas { get; set; }

        public DbSet<Despesa> Despesas { get; set; }

        public DbSet<CategoriaDespesa> CategoriaDespesas { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Notification>();
         

        }

        protected override void ConfigureConventions(ModelConfigurationBuilder modelConfigurationBuilder)
        {

        }




    }
}
