using System;
namespace practice6;

internal class Program
{
    private static double Min(double a, double b)
    {
        if (a <= b)
            return a;
        else
            return b;
    }
    private static double Max(double a, double b)
    {
        if (a >= b)
            return a;
        else
            return b;
    }
    private static double Task(double a, double b) // 15 вариант
    {
        return Min(Max(a + 5, Min(2 - b, Min(Math.Pow(a, 2) + 1, a / b))), Min(Min(a, Min(b - 5, Math.Pow(a, 1/3f))), 0) + 3 * Max(a, 3 / a - 5));
    }
    public static void Main(string[] args)
    {
        Task(1, 2);
    }
}