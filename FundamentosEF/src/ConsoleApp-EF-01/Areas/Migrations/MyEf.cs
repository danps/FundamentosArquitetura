using ConsoleApp_EF_01.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp_EF_01.Areas.Migrations
{
    public class MyEf
    {
        public static void GetPendingMigrations()
        {
            using var db = new FundamentosEF.Data.ApplicationContextMigrations();
            var pendingMigrations = db.Database.GetPendingMigrations();
            Console.WriteLine($"Total: {pendingMigrations.Count()}");
            foreach (var migration in pendingMigrations)
            {
                Console.WriteLine($"Migration: {migration}");
            }
        }

        public static void GenerateCreateScript()
        {
            using var db = new FundamentosEF.Data.ApplicationContextMigrations();
            var script = db.Database.GenerateCreateScript();

            Console.WriteLine(script);
        }

        public static void GetAppliedMigrations()
        {
            using var db = new FundamentosEF.Data.ApplicationContextMigrations();
            var appliedMigrations = db.Database.GetAppliedMigrations();
            Console.WriteLine($"Total: {appliedMigrations.Count()}");
            foreach (var migration in appliedMigrations)
            {
                Console.WriteLine($"Migration: {migration}");
            }
        }

        public static void GetMigrations()
        {
            using var db = new FundamentosEF.Data.ApplicationContextMigrations();

            var migrations = db.Database.GetMigrations();

            Console.WriteLine($"Total: {migrations.Count()}");

            foreach (var migration in migrations)
            {
                Console.WriteLine($"Migration: {migration}");
            }
        }

        public static void Migrate()
        {
            using var db = new FundamentosEF.Data.ApplicationContextMigrations();

            db.Database.Migrate();
        }

        public static void ClearDb()
        {
            using var db = new FundamentosEF.Data.ApplicationContextMigrations();
            db.Database.EnsureDeleted();
        }

        public static NavigationModel Menu()
        {
            var id = (int)Options.PendingMigrations;
            var menu = new NavigationModel(id, "Migrations", () => NavigationService.SaveOption(id));
            menu.Add(new NavigationModel(1, "Pending Migrations", MyEf.GetPendingMigrations));
            menu.Add(new NavigationModel(2, "Applied Migrations", MyEf.GetAppliedMigrations));
            menu.Add(new NavigationModel(3, "All Migrations", MyEf.GetMigrations));
            menu.Add(new NavigationModel(4, "Generate Script", MyEf.GenerateCreateScript));
            menu.Add(new NavigationModel(5, "Migrate", MyEf.Migrate));
            menu.Add(new NavigationModel(6, "Clear Db", MyEf.ClearDb));
            menu.Add(new NavigationModel(0, "Back", () => NavigationService.Back()));
            return menu;
        }
    }
}