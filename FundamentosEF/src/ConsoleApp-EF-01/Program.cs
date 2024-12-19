using ConsoleApp_EF_01.Models;
using FundamentosEF.Core;

public partial class Program
{

    private static void Main(string[] args)
    {
        NavigationService.Reset();

        while (!NavigationService.ExitFlag)
        {
            ResetColor();

            NavigationService.Display();

            var option = GetKeyPress();

            NavigationService.GoTo(option);
        }
        Console.WriteLine("Bye!");
    }

    private static void ResetColor()
    {
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.White;
    }

    public static string? GetKeyPress()
    {
        Console.WriteLine("------------------------");
        Console.WriteLine("Enter a number and press Enter");
        return Console.ReadLine();
    }
}