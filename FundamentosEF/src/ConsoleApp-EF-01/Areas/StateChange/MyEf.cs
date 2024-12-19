using ConsoleApp_EF_01.Models;
using FundamentosEF.Data;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp_EF_01.Areas.StateChange
{
    public class MyEf
    {
        private static int _count;

        public static void DbConnectionState(bool openDbConnection)
        {
            using var db = new ApplicationContext();
            var time = System.Diagnostics.Stopwatch.StartNew();

            var connection = db.Database.GetDbConnection();

            connection.StateChange += (_, __) => ++_count;

            if (openDbConnection)
            {
                connection.Open();
            }

            for (var i = 0; i < 200; i++)
            {
                db.Departaments.AsNoTracking().Any();
            }

            time.Stop();
            var message = $"Time: {time.Elapsed.ToString()}, {openDbConnection}, Counter: {_count}";

            Console.WriteLine(message);
        }

        private static void Managed() => DbConnectionState(true);

        private static void Unmanaged() => DbConnectionState(false);

        public static NavigationModel Menu()
        {
            var id = (int)Options.ManageConnectionState;
            var menu = new NavigationModel(id, "Manage Connection State", () => NavigationService.SaveOption(id));
            menu.Add(new NavigationModel(1, "Open Connection", MyEf.Managed));
            menu.Add(new NavigationModel(2, "Close Connection", MyEf.Unmanaged));
            menu.Add(new NavigationModel(0, "Back", () => NavigationService.Back()));
            return menu;
        }
    }
}