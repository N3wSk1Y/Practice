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

    public static void Main(string[] args)
    {
        int t1, t2, t3;
        Console.WriteLine(F(5));
    }
}