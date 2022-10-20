using System;
namespace practice71;

internal class Program
{
    private static int FindSecondMax(int N) // Вариант 17
    {
        Console.WriteLine("Введите максимальное число 1 по умолчанию.");
        int max1 = int.Parse(Console.ReadLine());
        Console.WriteLine("Введите максимальное число 2 по умолчанию.");
        int max2 = int.Parse(Console.ReadLine());

        if (max2 > max1)
        {
            int c = max1;
            max1 = max2;
            max2 = c;
        }
        
        for (int i = 0; i < N; i++)
        {
            int input = int.Parse(Console.ReadLine());
            if (input > max1)
            {
                max2 = max1;
                max1 = input;
            }
            else if (input > max2)
                max2 = input;
        }

        return max2;
    }
    
    public static void Main(string[] args)
    {
        Console.WriteLine($"Второй максимум: {FindSecondMax(5)}");
    }
}