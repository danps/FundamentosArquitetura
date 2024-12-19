using ConsoleApp_EF_01.Models;
using FundamentosEF.Core;
using FundamentosEF.Data;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp_EF_01.Areas.EnsureCreated
{
    public class MyEf
    {
        public static void Created()
        {
            using var db = new ApplicationContext();
            db.Database.EnsureCreated();
        }

        public static void DropDb()
        {
            using var db = new ApplicationContext();
            db.Database.EnsureDeleted();
        }
        public static void ListAll()
        {
            using var db = new ApplicationContext();
            var departaments = db.Departaments.AsNoTracking().ToArray();
            Helpers.Departaments.Write(departaments);
            db.SaveChanges();
        }
         

        public static void ClearDb()
        {
            using var db = new ApplicationContext();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            db.Departaments.AddRange(GenerateFaker.OnlyDepartments(4));

            db.SaveChanges();
            var departaments = db.Departaments.AsNoTracking().ToArray();

            Helpers.Departaments.Write(departaments);
        }


        public static NavigationModel Menu()
        {
            var id = (int)Options.EnsureCreatedAndDeleted;
            var menu = new NavigationModel(id, "EnsureCreatedAndDeleted", () => NavigationService.SaveOption(id));
            menu.Add(new NavigationModel(1, "Ensure Created", MyEf.Created));
            menu.Add(new NavigationModel(2, "Ensure Deleted", MyEf.DropDb));
            menu.Add(new NavigationModel(3, "List All", MyEf.ListAll));
            menu.Add(new NavigationModel(4, "Clear Db", MyEf.ClearDb));
            menu.Add(new NavigationModel(0, "Back", () => NavigationService.Back()));
            return menu;
        }
    }
}