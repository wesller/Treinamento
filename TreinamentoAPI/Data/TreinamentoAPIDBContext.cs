using Microsoft.EntityFrameworkCore;
using TreinamentoAPI.Data.Map;
using TreinamentoAPI.Models;

namespace TreinamentoAPI.Data
{
    public class TreinamentoAPIDBContext : DbContext
    {
        public TreinamentoAPIDBContext(DbContextOptions<TreinamentoAPIDBContext> options)
            : base(options)
        {
        }

        public DbSet<Exercicio> Exercicios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ExercicioMap());
            base.OnModelCreating(modelBuilder);
        }

     
    }
}
