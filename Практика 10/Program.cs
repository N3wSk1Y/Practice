using System;
namespace practice10;

internal class Program
{
    private static int F(int n)
    {
        if (n < 2)
        {
            return 1;
        }
        else if (n % 3 == 0)
        {
            return F(n / 3) - 1;
        } 
        else
        {
            return F(n - 1) + 7;
        }
    }

    private static int F_35(int a, int b)
    {
        int counter = 0;
        for (int i = a; i <= b; i++)
        {
            if (F(i) == 35)
                counter++;
        }

        return counter;
    }
    
    public static void Main(string[] args)
    {
        Console.WriteLine(F_35(1, 100000));
    }
}