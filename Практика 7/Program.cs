using System;

namespace practice7;

internal class Program
{
    private static void Task1()
    {
        for (int i = 2; i <= 9; i++)
        {
            Console.WriteLine();
            for (int y = 2; y <= 5; y++)
            {
                Console.Write($"{y} * {i} = {i * y}\t");
            }
        }

        Console.WriteLine();
        for (int i = 2; i <= 9; i++)
        {
            Console.WriteLine();
            for (int y = 6; y <= 9; y++)
            {
                Console.Write($"{y} * {i} = {i * y}\t");
            }
        }
    }

    public static void Main(string[] args)
    {
        Task1();
    }
}
