using System;
namespace practice4;

public static class Program
{
    private static void Task1(int speed, int hours)
    {
        if (speed > 0)
            Console.WriteLine(speed * hours % 109);
        else
            Console.WriteLine(109 - Math.Abs(speed * hours % 109));
    }
    
    private static void Task2(int n)
    {
        if (n >= 1440)
            n %= 1440;
        
        int hours = n / 60;
        int minutes = n % 60;
        Console.WriteLine($"{hours:D2}:{minutes:D2}");
    }
    
    private static void Task3(int n)
    {
        if (n >= 86400)
            n %= 86400;
        
        int hours = n / 3600;
        int minutes = (n - hours * 3600) / 60;
        int seconds = n % 60;
        Console.WriteLine($"{hours:D2}:{minutes:D2}:{seconds:D2}");
    }
    
    private static void Task4(int h1, int m1, int s1, int h2, int m2, int s2)
    {
        int seconds1 = h1 * 3600 + m1 * 60 + s1;
        int seconds2 = h2 * 3600 + m2 * 60 + s2;
        Console.WriteLine(seconds2 - seconds1);
    }

    public static void Main()
    {
        
    }
}