using ConsoleApp_EF_01.Models;
using FundamentosEF.Data;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp_EF_01.Areas.ExecuteSQL
{
    public class MyEf
    {
        public static void ExecuteNonQuery()
        {
            using var db = new ApplicationContext();

            using (var cmd = db.Database.GetDbConnection().CreateCommand())
            {
                cmd.CommandText = "update departaments set description='ExecuteNonQuery' where id=1";
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
            }
            Areas.EnsureCreated.MyEf.ListAll();
        }

        public static void ExecuteSqlRaw()
        {
            using var db = new ApplicationContext();
            var description = "ExecuteSqlRaw";
            db.Database.ExecuteSqlRaw("update departaments set description={0} where id=1", description);
            db.SaveChanges();
            Areas.EnsureCreated.MyEf.ListAll();
        }

        public static void ExecuteSqlInterpolated()
        {
            var description = "ExecuteSqlInterpolated";
            using var db = new ApplicationContext();
            db.Database.ExecuteSqlInterpolated($"update departaments set description={description} where id=1");
            db.SaveChanges();

            Areas.EnsureCreated.MyEf.ListAll();
        }

        public static NavigationModel Menu()
        {
            var id = (int)Options.ExecuteSQL;
            var menu = new NavigationModel(id, "Execute SQL", () => NavigationService.SaveOption(id));
            menu.Add(new NavigationModel(1, "Clear DB", Areas.EnsureCreated.MyEf.ClearDb));
            menu.Add(new NavigationModel(2, "ExecuteNonQuery", MyEf.ExecuteNonQuery));
            menu.Add(new NavigationModel(3, "ExecuteSqlRaw **(safe) **", MyEf.ExecuteSqlRaw));
            menu.Add(new NavigationModel(4, "ExecuteSqlInterpolated **string interpolated to parameters**", MyEf.ExecuteSqlInterpolated));
            menu.Add(new NavigationModel(0, "Back", () => NavigationService.Back()));
            return menu;
        }
    }
}