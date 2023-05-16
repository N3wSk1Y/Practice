using System;

namespace arrays1;

internal class Program
{
    private static int[] InputIntArray(int arrayLength)
    {
        int[] array = new int[arrayLength];
        for (int i = 0; i < arrayLength; i++)
        {
            Console.WriteLine($"Введите {i + 1} элемент массива");
            array[i] = Convert.ToInt32(Console.ReadLine());
        }

        return array;
    }

    private static void PrintArray(int[] array)
    {
        foreach (int xm in array)
        {
            Console.Write(xm);
        }
    }

    public static void Main()
    {
        Console.WriteLine("Введите длину массива");
        int n = Convert.ToInt32(Console.ReadLine());
        int[] array = InputIntArray(n);

        Console.WriteLine("\nВывод элементов массива:");
        PrintArray(array);
    }
}
