using System;

namespace phone2;

internal class Program
{
    private static int FindNullBitsAmount(uint x)
    {
        int m;
        int amount = 0;
        for (int i = 31; i >= 0; i--)
        {
            m = 1 << i;
            if ((x & m) == 0)
                amount++;
        }

        return amount;
    }

    private static string ConvertToBits(int x)
    {
        int m;
        bool firstOne = false;
        string result = "";
        for (int i = 31; i >= 0; i--)
        {
            m = 1 << i;
            if ((x & m) != 0)
            {
                firstOne = true;
                result += "1";
            }
            else if (firstOne)
            {
                result += "0";
            }
        }

        return result;
    }

    private static int CyclicRightShift(int x1, int n)
    {
        return (x1 << n) | (x1 >> (0x20 - n));
    }

    public static void Main(string[] args)
    {
        uint n = 3,
            x1 = 5;
        int x2 = 5;
        Console.WriteLine("Введите числа n, x1, x2 через Enter.");
        n = Convert.ToUInt32(Console.ReadLine());
        x1 = Convert.ToUInt32(Console.ReadLine());
        x2 = Convert.ToInt32(Console.ReadLine());

        int nullBitsAmount = FindNullBitsAmount(x1);
        Console.WriteLine($"Число {x1} имеет {nullBitsAmount} нулей двоичной системе.");

        string convertedNumber = ConvertToBits(x2);
        Console.WriteLine(
            $"Число {x2} имеет представление {convertedNumber} в двоичной системе без ведущих нулей."
        );

        int shiftedNumber = CyclicRightShift((int)x1, (int)n);
        Console.WriteLine(
            $"Число {x1} при цикличном сдвиге вправо на {n} имеет представление {shiftedNumber} в двоичной системе."
        );
    }
}
