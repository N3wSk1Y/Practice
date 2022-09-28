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

    static void Main(string[] args)
    {
        Console.WriteLine(includedInArea(0, -4.5f));
    }
}