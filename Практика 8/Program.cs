using System;
namespace practice8;

internal class Program
{
    private static int Remainder(int a, int b)
    {
        return a % b;
    }

    private static int Task1(int a) // Вариант 3
    {
        int counter = 0;
        a = Math.Abs(a);
        while (a > 0)
        {
            int number = a % 10;
            a /= 10;
            if (number < 8 && number % 3 != 0 && number % 4 != 0)
            {
                counter++;
            }
        }
        return counter;
    }
    
    private static int Task2(int a)
    {
        a = Math.Abs(a);
        int previousNumber = a % 10;
        int sum = 0;
        while (a > 0)
        {
            a /= 10;
            int number = a % 10;
            if ((number + previousNumber) % 2 == 0)
                sum += number + previousNumber;

            previousNumber = number;
        }
        return sum;
    }

    public static void Main(string[] args)
    {
        Console.WriteLine($"Остаток от деления: {Remainder(17, 5)}");
        int t1 = Task1(123123465);
        if (t1 > 0)
            Console.WriteLine($"Чисел, подходящих под условия: {t1}");
        else
            Console.WriteLine("NO");
        Console.WriteLine(Task2(1587662));
    }
}