using ConsoleApp_EF_01.Models;
using FundamentosEF.Data;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp_EF_01.Areas.HealthCheck
{
    public class MyEf
    {
        public static void CanConnect()
        {
            using var db = new ApplicationContext();
            var canConnect = db.Database.CanConnect();

            if (canConnect)
            {
                Console.WriteLine("Can connect");
            }
            else
            {
                Console.WriteLine("Cannot connect");
            }
        }

        public static void TableVerified()
        {
            try
            {
                using var db = new ApplicationContext();
                var connection = db.Database.GetDbConnection();
                connection.Open();
                db.Departaments.Any();
                Console.WriteLine("Can connect");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Cannot connect");
                Console.WriteLine(ex.Message);
            }
        }

        public static NavigationModel Menu()
        {
            var id = (int)Options.DatabaseHealthCheck;
            var item = new NavigationModel(id, "Database Health Check", () => NavigationService.SaveOption(3));
            item.Add(new NavigationModel(1, "Health Check **Simplified**", MyEf.CanConnect));
            item.Add(new NavigationModel(2, "TableVerified", MyEf.TableVerified));
            item.Add(new NavigationModel(0, "Back", () => NavigationService.Back()));
            return item;
        }
    }
}