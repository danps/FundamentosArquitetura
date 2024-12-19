using FundamentosEF.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FundamentosEF.Data
{
    public class ApplicationContextMultiple : DbContext
    {
        public DbSet<Departament> Departments { get; set; }
        public DbSet<Employer> Employers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(Connections.MULTIPLE_RESULTS)
                .EnableSensitiveDataLogging() 
                .LogTo(Console.WriteLine, LogLevel.Information);
        }
    }
}