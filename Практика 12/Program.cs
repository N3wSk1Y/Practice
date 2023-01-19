using System;
namespace practice12;

internal class Program
{
    private static int[] GenerateIntRange(int a, int b)
    {
        int[] array = new int[b - a + 1];
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = i + a;
        }

        return array;
    }

    private static void PrintArray(int[] array)
    {
        foreach (int xm in array)
        {
            Console.WriteLine(xm);
        }
    }

    private static void ArrayFilter(int[] array, out int amount, out int min)
    {
        amount = 0;
        min = array[0];
        foreach (var xm in array)
        {
            if (xm % 9 == 0 && xm % 7 != 0 && xm % 15 != 0 && xm % 17 != 0 && xm % 19 != 0)
            {
                amount++;
                min = xm < min ? xm : min;
            }
        }
    }

    public static void Main()
    {
        Console.Write("Введите первое число для генерации промежутка: ");
        int a = Convert.ToInt32(Console.ReadLine());
        Console.Write("Введите второе число для генерации промежутка: ");
        int b = Convert.ToInt32(Console.ReadLine());
        int[] array = GenerateIntRange(a, b);
        
        int amount, min;
        ArrayFilter(array, out amount, out min);
        Console.WriteLine($"Длина отсортированного массива: {amount}\nМинимальное число: {min}");
    }
}