using System;
namespace phone31;

internal class Program
{
    private static bool IsPrimeNumber(int a)
    {
        for (int i = 2; i < a; i++)
        {
            if (a % i == 0)
                return false;
        }

        return true;
    }

    private static bool IsFullSquare(int a)
    {
        double t = Math.Sqrt(a);
        if (!(t * 10 % 10 > 0d))
            return true;
        else
            return false;
    }

    private static bool IsDividedBy7(int a)
    {
        if (a.ToString().Length == 3)
        {
            int a3 = a % 10;
            int n = a / 10;
            if ((n - (2 * a3)) % 7 == 0)
                return true;
        }

        return false;
    }

    private static void ReplaceWithNearestPrimeNumber(ref int a)
    {
        while (!IsPrimeNumber(a))
            a++;
    }

    private static void ReplaceWithFullSquares(ref int a)
    {
        int r = a;
        for (int i = 1; i <= a; i++)
        {
            int n = int.Parse(Console.ReadLine());
            if (!IsFullSquare(n))
                r--;
        }
        a = r;
    }

    private static void ReplaceWithNumbersMultipesOf7(ref int a)
    {
        for (int i = 0; i <= a; i++)
        {
            int n = int.Parse(Console.ReadLine());
            if (!IsDividedBy7(n))
                a--;
        }
    }
        
    public static void Main(string[] args)
    {
        int t1, t2, t3;
        Console.WriteLine("Введите число для поиска ближайшего простого");
        t1 = int.Parse(Console.ReadLine());
        ReplaceWithNearestPrimeNumber(ref t1);
        Console.WriteLine($"Ближайшее простое число: {t1}");
        
        Console.WriteLine("Введите количество чисел в последовательности для поиска полных квадратов");
        t2 = int.Parse(Console.ReadLine());
        ReplaceWithFullSquares(ref t2);
        Console.WriteLine($"В последовательности {t2} полных квадратов");
        
        Console.WriteLine("Введите количество чисел в последовательности для поиска трехзначных кратных семи");
        t3 = int.Parse(Console.ReadLine());
        ReplaceWithNumbersMultipesOf7(ref t3);
        Console.WriteLine($"В последовательности {t3} трезначных чисел кратных семи");
    }
}