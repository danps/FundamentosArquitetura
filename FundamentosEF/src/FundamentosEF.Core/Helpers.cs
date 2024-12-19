using FundamentosEF.Domain;

namespace FundamentosEF.Core
{
    public class Helpers
    { 
            public class Departaments
            {
                public static void Write(IDepartament[] departaments)
                {
                    Console.WriteLine("----------------------------------");
                    Console.WriteLine("| Id  | Description                              |");
                    Console.WriteLine("| --- | ---------------------------------------- |");

                    foreach (var item in departaments)
                    {
                        Console.WriteLine($"| {item.Id,-4}| {PadRight40(item.Description)} |");
                    }
                }

                public static void Write(IDepartament item)
                {
                    Console.WriteLine("---------------------------------------");
                    Console.WriteLine($"Department: {item.Description}");

                    if (item.HasEmployers())
                    {
                        Console.WriteLine("----------------------------------");
                        Console.WriteLine("\t| ID             | Name                                     |");
                        Console.WriteLine("\t| -------------- | ---------------------------------------- |");

                        foreach (var emp in item.GetEmployers())
                        {
                            Console.WriteLine($"\t| {emp.Code} | {PadRight40(emp.Name)} |");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"\tNo employees found!");
                    }
                }
            }

            public class Employers
            {
                public static void Head()
                {
                    Console.WriteLine("----------------------------------");
                    Console.WriteLine("| Id  | Description                              | Employer                                 |");
                    Console.WriteLine("| --- | ---------------------------------------- | ---------------------------------------- |");
                }

                public static void Write(IDepartament[] departaments)
                {
                    Head();

                    foreach (var item in departaments)
                    {
                        var description = $"| {item.Id.ToString().PadRight(4)}| {PadRight40(item.Description)} |";

                        if (item.HasEmployers())
                        {
                            foreach (var emp in item.GetEmployers())
                            {
                                Console.WriteLine($"{description}{PadRight40(emp.Name)} |");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"{description}| Not found                                |");
                        }
                    }
                }
            } 
        private static string PadRight40(string item)
        {
            if (item.Length < 40)
                item = item.PadRight(40);
            return item;
        }

        public static void Exception(Exception e)
        {
            var cor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(e.ToString());
            Console.ForegroundColor = cor;
        }
    }
}