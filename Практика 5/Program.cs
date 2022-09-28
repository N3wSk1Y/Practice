using System;
namespace practice5;

class Program
{
    static bool includedInArea(float x, float y) // Вариант 10
    {
        if (Math.Pow(x, 2) + Math.Pow(y, 2) < 16)
            if (y <= 4 - x)
                if (y <= 4 + x)
                    return true;
        return false;
    }

    static double UValue(float x, float y)
    {
        if (includedInArea(x, y))
            return Math.Abs(1 - x * y);
        else
            return Math.Pow(x, 2) - 5;
    }

    static void Main(string[] args)
    {
        Console.WriteLine(UValue(0, -4.5f));
    }
}