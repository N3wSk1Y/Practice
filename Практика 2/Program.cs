using System;

namespace practice2;

public static class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Введите значения параметров a, b, c через запятую");
        string[] parameters = Console.ReadLine().Replace(" ", "").Split(',');
        double a = double.Parse(parameters[0]);
        double b = double.Parse(parameters[1]);
        double c = double.Parse(parameters[2]);
        double result = 1.2 - (34 / a + b) + c;
        Console.WriteLine($"{result:N3}");
        Console.ReadKey();
    }
}
