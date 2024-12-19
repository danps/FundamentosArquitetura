using FundamentosEF.Domain.LazyLoaderAction;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FundamentosEF.Data.LazyLoaderAction
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Departament> Departaments { get; set; }
        public DbSet<Employer> Employers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(Connections.DEFAULT_DB)
                .EnableSensitiveDataLogging()
                .LogTo(Console.WriteLine, LogLevel.Information);
        }
    }
}