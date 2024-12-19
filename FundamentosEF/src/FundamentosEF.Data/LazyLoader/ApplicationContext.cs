using FundamentosEF.Domain.LazyLoader;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FundamentosEF.Data.LazyLoader
{
    public class ApplicationContext: DbContext
    {
        public DbSet<Department> Departments { get; set; }
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