using System;
namespace phone32;

internal class Program
{
    private static int F(int n)
    {
        if (n > 10)
            return n * n + 5 * n + 4;
        else if (n % 2 == 0)
            return F(n + 1) + 3 * F(n + 4);
        else
            return 2 * F(n + 2) + F(n + 5);
    }

    private static int FindRoutesAmount(int a, int b)
    {
        if (a == b)
            return 1;
        else if (a > b || a == 17 || a == 23)
            return 0;
        else
            return FindRoutesAmount(a + 1, b) + FindRoutesAmount(a + 2, b);
    }
    
    private static int NumberDigitsSum(int n, int sum = 0)
    {
        if (n <= 0)
            return sum;
        else 
            return NumberDigitsSum(n / 10, sum + n % 10);
    }

    public static void Main(string[] args)
    {
        int t1, t2, t22, t3;
        Console.WriteLine("Введите число для поиска количества натуральный чисел, для которых сумма чисел значения F(n) = 27.");
        t1 = int.Parse(Console.ReadLine());
        Console.WriteLine($"Количество таких чисел: {F(t1)}");

        Console.WriteLine("Введите начальное и конечное число для поиска количества возможных програм исполнителя.");
        t2 = int.Parse(Console.ReadLine());
        t22 = int.Parse(Console.ReadLine());
        Console.WriteLine($"Таких програм существует: {FindRoutesAmount(t2, t22)}");
        
        Console.WriteLine("Введите число для поиска суммы цифр.");
        t3 = int.Parse(Console.ReadLine());
        Console.WriteLine($"Сумма цифр числа: {NumberDigitsSum(t3)}");
    }
}