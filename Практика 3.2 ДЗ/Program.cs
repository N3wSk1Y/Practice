using System;
namespace practice3;

public static class Program
{
    private static void Task1()
    {
        int range = int.Parse(Console.ReadLine());
        if (range >= 30)
        {
            Console.WriteLine("Перелет!");
        }
        else if (range >= 28)
        {
            Console.WriteLine("Попал!");
        }
        else if (range >= 0)
        {
            Console.WriteLine("Недолет!");
        }

        Console.ReadKey();
    }

    private static void Task2()
    {
        string input = Console.ReadLine();
        // if (!int.TryParse(input, out var number))
        // {
        //     Console.WriteLine("Нет"); 
        //     Console.ReadKey(); return;
        // }
        int sybmol = int.Parse(input);
        // string result = 9 - sybmol >= 0 ? "Да" : "Нет";
        string result = sybmol >= 0 ? 10 > sybmol ? "Yes" : "No" : "No";
        Console.WriteLine(result);
        Console.ReadKey();
    }
    
    private static void Task3()
    {
        string[] parameters = Console.ReadLine().Replace(" ", "").Split(',');
        double a = double.Parse(parameters[0]);
        double b = double.Parse(parameters[1]);
        double c = double.Parse(parameters[2]);
        double D = Math.Pow(b, 2) - 4 * a * c;;

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

    private static void Task4()
    {
        string[] parameters = Console.ReadLine().Replace(" ", "").Split(',');
        int a = int.Parse(parameters[0]);
        int b = int.Parse(parameters[1]);
        int c = int.Parse(parameters[2]);
        string r = (a - b) * (a - c) * (b - c) == 0 ? "Yes" : "No";
        Console.WriteLine(r);
        Console.ReadKey();
    }
    private static void Task5()
    {
        char sybmol = char.Parse(Console.ReadLine().ToLower());
        // string vowels = "aeiou";
        // string result = vowels.IndexOf(sybmol.ToString()) >= 0 ? "Гласная" : "Согласная";
        // Console.WriteLine(result);

        switch (sybmol)
        {
            case 'a': Console.WriteLine("Гласная"); break;
            case 'e': Console.WriteLine("Гласная"); break;
            case 'i': Console.WriteLine("Гласная"); break;
            case 'o': Console.WriteLine("Гласная"); break;
            case 'u': Console.WriteLine("Гласная"); break;
            default: Console.WriteLine("Согласная"); break;
        }
    }
}