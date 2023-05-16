using System;

namespace practice3;

public static class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Введите значения параметров a, b, c через запятую");
        string[] parameters = Console.ReadLine().Replace(" ", "").Split(',');
        double a = double.Parse(parameters[0]);
        double b = double.Parse(parameters[1]);
        double c = double.Parse(parameters[2]);
        double result =
            Math.Pow(2, a) * Math.Pow(a + b + c, (double)1 / 3)
            + (Math.Pow(c, a + b) / Math.Sin(a / b))
            - 0.2;
        Console.WriteLine(result);
        Console.ReadKey();
    }
}
