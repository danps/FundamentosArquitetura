using ConsoleApp_EF_01.Models;
using FundamentosEF.Data.EnsureCreated;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace ConsoleApp_EF_01.Areas.GapEnsureCreated
{
    public class MyEf
    {
        public static void Problem()
        {
            using var db1 = new ApplicationContext();
            using var db2 = new ApplicationContextCities();

            db1.Database.EnsureCreated();
            db2.Database.EnsureCreated();
        }

        public static void Solve()
        {
            using var db1 = new ApplicationContext();
            using var db2 = new ApplicationContextCities();

            db1.Database.EnsureCreated();
            db2.Database.EnsureCreated();

            var databaseCreator = db2.GetService<IRelationalDatabaseCreator>();
            databaseCreator.CreateTables();
        }

        public static NavigationModel Menu()
        {
            var id = (int)Options.EnsureCreatedGap;
            var item = new NavigationModel(id, "Gap of Ensure Created", () => NavigationService.SaveOption(id));
            item.Add(new NavigationModel(1, "Problem **Not create tables of the second context**", Problem));
            item.Add(new NavigationModel(2, "Solution", Solve));
            item.Add(new NavigationModel(0, "Back", () => NavigationService.Back()));
            return item;
        }
    }
}