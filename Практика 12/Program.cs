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

    private static void Task1(int[] array, out int amount, out int min)
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

    private static void Task2(int[] array, out int amount, out int min)
    {
        amount = 0;
        min = array[0];
        foreach (var xm in array)
        {
            string binaryCase = Convert.ToString(xm, 2);
            string quinaryCase = Convert.ToString(xm, 5);
            if (binaryCase.EndsWith("01") && quinaryCase.EndsWith("3"))
            {
                amount++;
                min = xm < min ? xm : min;
            }
        }
    }
    
    private static void Task3(int[] array, out int amount, out int max)
    {
        amount = 0;
        max = array[0];
        foreach (var xm in array)
        {
            string number = xm.ToString();
            int dozens = number[2];
            int hundrets = number[1];
            if (dozens >= 3 && dozens <= 7 && hundrets != 1 && hundrets != 9)
            {
                amount++;
                max = xm > max ? xm : max;
            }
        }
    }
    
    private static void Task4(int[] array, out int amount, out int max)
    {
        amount = 0;
        max = array[0];
        foreach (var xm in array)
        {
            string number = xm.ToString();
            if (xm % 7 == 0 && number.Contains("0") && number.Contains("2") && number.Contains("5"))
            {
                amount++;
                max = xm > max ? xm : max;
            }
        }
    }
    
    private static void Task5(int[] array, out int amount, out int average)
    {
        amount = 0;
        int sum = 0;
        foreach (var xm in array)
        {
            int dividersAmount = GetDividersAmount(xm);
            if (dividersAmount > 35)
            {
                amount++;
                sum += xm;
            }
        }

        average = sum / amount;
    }

    private static int GetDividersAmount(int a)
    {
        int result = 0;
        for (int i = 2; i < a; i++)
        {
            if (a % i == 0)
            {
                result++;
            }
        }

        return result;
    }
    
    public static void Main()
    {
        Console.Write("Введите первое число для генерации промежутка: ");
        int a = Convert.ToInt32(Console.ReadLine());
        Console.Write("Введите второе число для генерации промежутка: ");
        int b = Convert.ToInt32(Console.ReadLine());
        int[] array = GenerateIntRange(a, b);
        
        Console.Write("Введите номер задачи: ");
        int taskNumber = Convert.ToInt32(Console.ReadLine());
        switch (taskNumber)
        {
            case 1:
            {
                int amount, min;
                Task1(array, out amount, out min);
                Console.WriteLine($"Длина отсортированного массива: {amount}\nМинимальное число: {min}");
                break;  
            }

            case 2:
            {
                int amount, min;
                Task2(array, out amount, out min);
                Console.WriteLine($"Длина отсортированного массива: {amount}\nМинимальное число: {min}");
                break;
            }
            
            case 3:
            {
                int amount, max;
                Task3(array, out amount, out max);
                Console.WriteLine($"Длина отсортированного массива: {amount}\nМаксимальное число: {max}");
                break;
            }
            
            case 4:
            {
                int amount, min;
                Task4(array, out amount, out min);
                Console.WriteLine($"Длина отсортированного массива: {amount}\nМинимальное число: {min}");
                break;
            }
            
            case 5:
            {
                int amount, average;
                Task5(array, out amount, out average);
                Console.WriteLine($"Длина отсортированного массива: {amount}\nСреднее арифметическое: {average}");
                break;
            }
                
        }
        Main();
    }
}