using ConsoleApp_EF_01.Models;
using FundamentosEF.Core;
using FundamentosEF.Data;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp_EF_01.Areas.SqlInjection
{
    public class MyEf
    {
        public static void UpdateSafety()
        {
            var description = "Department 01";
            using var db = new ApplicationContext();
            db.Database.ExecuteSqlRaw("update departaments set description='UpdateSafety' where description={0}", description);
            var departaments = db.Departaments.AsNoTracking().ToArray();
            Helpers.Departaments.Write(departaments);
            db.SaveChanges();
        }

        public static void UpdateInjection()
        {
            using var db = new ApplicationContext();
            var description = "Teste ' or 1='1";
            db.Database.ExecuteSqlRaw($"update departaments set description='UpdateInjection' where description='{description}'");
            var departaments = db.Departaments.AsNoTracking().ToArray();
            Helpers.Departaments.Write(departaments);
            db.SaveChanges();
        }

        public static NavigationModel Menu()
        {
            var id = (int)Options.SqlInjection;
            var menu = new NavigationModel(id, "SQL Injection", () => NavigationService.SaveOption(id));
            menu.Add(new NavigationModel(1, "Clear DB", Areas.EnsureCreated.MyEf.ClearDb));
            menu.Add(new NavigationModel(2, "ListAll", Areas.EnsureCreated.MyEf.ListAll));
            menu.Add(new NavigationModel(3, "UpdateSafety **parameters**", MyEf.UpdateSafety));
            menu.Add(new NavigationModel(4, "ExecuteSqlInterpolated **UpdateAll**", MyEf.UpdateInjection));
            menu.Add(new NavigationModel(0, "Back", () => NavigationService.Back()));
            return menu;
        }
    }
}