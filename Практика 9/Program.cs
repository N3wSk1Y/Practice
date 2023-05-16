using System;

namespace practice9;

internal class Program
{
    private static void Task1()
    {
        byte day = 2; // 00000010
        byte month = 4; // 00000100
        Console.WriteLine(day & month);
        Console.WriteLine(day | month);
        Console.WriteLine(day ^ month);
        Console.WriteLine(~day);
        Console.WriteLine(~month);
        Console.WriteLine(day >> 1);
        Console.WriteLine(month << 2);
    }

    private static int Task2(int X, int N)
    {
        int m = 1 << N;
        return (X & m) == 0 ? 0 : 1;
    }

    private static void Task3(int a)
    {
        int m;
        for (int i = 31; i >= 0; i--)
        {
            m = 1 << i;
            Console.Write((a & m) == 0 ? 0 : 1);
        }
    }

    public static void Main(string[] args)
    {
        int X = 5,
            N = 2,
            a = 7;
        Console.WriteLine(Task2(X, N));
        Task3(a);
    }
}
