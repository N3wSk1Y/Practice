using System;
namespace practice4;

public static class Program
{
    private static int Task1(int speed, int hours)
    {
        if (speed > 0)
            return speed * hours % 109;
        else
            return 109 - Math.Abs(speed * hours % 109);
    }
    
    private static string Task2(int n)
    {
        n %= 1440;
        
        int hours = n / 60;
        int minutes = n % 60;
        return $"{hours:D2}:{minutes:D2}";
    }
    
    private static string Task3(int n)
    {
        n %= 86400;
        
        int hours = n / 3600;
        int minutes = (n - hours * 3600) / 60;
        int seconds = n % 60;
        return $"{hours:D2}:{minutes:D2}:{seconds:D2}";
    }
    
    private static int Task4(int h1, int m1, int s1, int h2, int m2, int s2)
    {
        int seconds1 = h1 * 3600 + m1 * 60 + s1;
        int seconds2 = h2 * 3600 + m2 * 60 + s2;
        return seconds2 - seconds1;
    }
}