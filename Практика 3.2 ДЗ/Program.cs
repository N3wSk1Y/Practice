using System;

namespace practice32;

public static class Program
{
    private static string Task1()
    {
        int range = int.Parse(Console.ReadLine());
        if (range >= 30)
        {
            return "Перелет!";
        }
        else if (range >= 28)
        {
            return "Попал!";
        }
        else
        {
            return "Недолет!";
        }
    }

    private static string Task2()
    {
        string input = Console.ReadLine();
        int number = int.Parse(input);
        string result = (number + 10) / 10 == 1 ? "Yes" : "No";
        return result;
    }

    private static void Task3()
    {
        string[] parameters = Console.ReadLine().Replace(" ", "").Split(',');
        double a = double.Parse(parameters[0]);
        double b = double.Parse(parameters[1]);
        double c = double.Parse(parameters[2]);
        double D = Math.Pow(b, 2) - 4 * a * c;

        Console.Write($"Уравнение с коэффициентами {a}, {b}, {c} ");
        if (D >= 0)
        {
            double x1 = (-b + Math.Sqrt(D)) / (2 * a);
            double x2 = (-b - Math.Sqrt(D)) / (2 * a);
            if (x1 == x2)
            {
                Console.Write($"имеет один корень: {x1}");
            }
            else
            {
                Console.Write($"имеет два корня: {x1} и {x2}");
            }
        }
        else
        {
            Console.Write("не имеет действительных корней.");
        }

        Console.ReadKey();
    }

    private static string Task4()
    {
        string[] parameters = Console.ReadLine().Replace(" ", "").Split(',');
        int a = int.Parse(parameters[0]);
        int b = int.Parse(parameters[1]);
        int c = int.Parse(parameters[2]);
        string r = (a - b) * (a - c) * (b - c) == 0 ? "Yes" : "No";
        return r;
    }

    private static string Task5()
    {
        char sybmol = char.Parse(Console.ReadLine().ToLower());
        // string vowels = "aeiou";
        // string result = vowels.IndexOf(sybmol.ToString()) >= 0 ? "Гласная" : "Согласная";
        // Console.WriteLine(result);

        switch (sybmol)
        {
            case 'a':
                return "Гласная";
            case 'e':
                return "Гласная";
            case 'i':
                return "Гласная";
            case 'o':
                return "Гласная";
            case 'u':
                return "Гласная";
            default:
                return "Согласная";
        }
    }
}
