using System;
namespace meeting;

public static class Program
{
    private const string Name = "My Name";

    public static void Main(string[] args)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write($"Hello");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write($" {Name}");
        Console.ReadKey();
    }
}

