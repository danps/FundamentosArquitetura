using FundamentosEF.Core;

namespace ConsoleApp_EF_01.Models
{
    public class NavigationService
    {
        public NavigationService()
        { }

        public static bool ExitFlag { get; private set; }
        private static List<int> PathNavigations { get; set; } = new List<int>();
        private static NavigationModel ActiveNavigation { get; set; }

        #region Menu Items

        private static readonly List<NavigationModel> _items = new List<NavigationModel>
            {
                Areas.EnsureCreated.MyEf.Menu(),
                Areas.GapEnsureCreated.MyEf.Menu(),
                Areas.HealthCheck.MyEf.Menu(),
                Areas.StateChange.MyEf.Menu(),
                Areas.ExecuteSQL.MyEf.Menu(),
                Areas.SqlInjection.MyEf.Menu(),
                Areas.Migrations.MyEf.Menu(),
                Areas.Loading.MyEf.Menu(),
                new NavigationModel(0, "Exit", Exit)
            };

        public static NavigationModel GetNavigationById(int id) => _items.FirstOrDefault(a => a.VisualId == id);

        public static NavigationModel GetAll()
        {
            var principal = new NavigationModel(0, "Mastering Entity Framework Core", Exit)
            {
                Itens = _items
            };
            return principal;
        }

        #endregion Menu Items

        #region Menu Display

        public static void Display()
        {
            SetNavigation();
            Console.WriteLine("------------------------\n");
            Console.WriteLine($"#{ActiveNavigation}");
            DisplayItems(ActiveNavigation?.Itens);
        }

        private static void DisplayItems(List<NavigationModel> items)
        {
            if (items == null) return;

            var originalColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (var item in items)
            {
                Console.WriteLine($"\t{item}");
            }
            Console.ForegroundColor = originalColor;
        }

        private static void SetNavigation()
        {
            ActiveNavigation = PathNavigations.Count == 0 ? GetAll() : GetNavigationById(PathNavigations.Last());
        }

        #endregion Menu Display

        #region Navigation

        public static void Exit() => ExitFlag = true;

        public static void SaveOption(int id)
        {
            PathNavigations.Add(id);
        }

        public static void Back()
        {
            if (PathNavigations.Any())
            {
                PathNavigations.RemoveAt(PathNavigations.Count - 1);
            }
        }

        public static void Reset()
        {
            PathNavigations = new List<int>();
        }

        public static void GoTo(string? option)
        {
            try
            {
                if (int.TryParse(option, out int id))
                {
                    var action = ActiveNavigation?.Itens.FirstOrDefault(a => a.VisualId == id)?.Action;
                    if (action != null)
                    {
                        var originalColor = Console.ForegroundColor;
                        Console.ForegroundColor = ConsoleColor.Yellow;

                        action();
                        Console.ForegroundColor = originalColor;
                    }
                }
                else
                {
                    Exit();
                }
            }
            catch (Exception e)
            {
                Helpers.Exception(e);
            }
        }

        #endregion Navigation
    }
}