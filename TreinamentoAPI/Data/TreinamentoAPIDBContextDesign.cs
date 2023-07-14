using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace TreinamentoAPI.Data
{

    public class TreinamentoAPIDBContextDesign : IDesignTimeDbContextFactory<TreinamentoAPIDBContext>
    {
        public TreinamentoAPIDBContext CreateDbContext(string[] args)
        {
           var builder = new DbContextOptionsBuilder<TreinamentoAPIDBContext>();
           builder.UseNpgsql("Server=127.0.0.1;Port=5432;Database=TreinamentoDB;User Id=postgres;Password=123456;");
            return new TreinamentoAPIDBContext(builder.Options);
        }
    }
}
