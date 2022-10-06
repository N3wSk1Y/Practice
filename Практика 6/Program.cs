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
    private static double Min(double a, double b, double c)
    {
        double min = a;
        if (min > b) min = b;
        if (min > c) min = c;
        return min;
    }
    private static double Max(double a, double b)
    {
        if (a >= b)
            return a;
        else
            return b;
    }
    private static double Max(double a, double b, double c)
    {
        double max = a;
        if (max < b) max = b;
        if (max < c) max = c;
        return max;
    }
    private static double Task(double a, double b) // 15 вариант
    {
        return Min(Max(a + 5, Min(2 - b, Math.Pow(a, 2)+1, a/b)), Min(a, b - 5, Math.Pow(a, 1/3f)), 0) + 3 * Max(a, 3 / a - 5);
    }
    public static void Main(string[] args)
    {
        double r = Task(1, 2);
        Console.WriteLine(r);
    }
}