using System;
namespace practice5;

class Program
{
    static void Main(string[] args)
    {
        float x = float.Parse(Console.ReadLine());
        float y = float.Parse(Console.ReadLine());
        if (y <= 2 - x)
            if (y >= 0)
                if (y >= x * x)
                    Console.Write("принадлежит");
                else
                    Console.Write(" не принадлежит");
        Console.ReadKey();
    }
}