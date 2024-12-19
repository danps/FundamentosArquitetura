namespace FundamentosEF.Data
{
    public class Connections
    {
        public const string DEFAULT_DB = "Data source=(localdb)\\mssqllocaldb; Initial Catalog=ConsoleApp_EF_01;Integrated Security=true;pooling=true;";
        public const string MULTIPLE_RESULTS = "Data source=(localdb)\\mssqllocaldb; Initial Catalog=ConsoleApp_EF_01;Integrated Security=true;pooling=true;MultipleActiveResultSets=true";
        public static string CITY_DB = "Data source=(localdb)\\mssqllocaldb; Initial Catalog=ConsoleApp_EF_01_CITY;Integrated Security=true;pooling=true";
    }
}