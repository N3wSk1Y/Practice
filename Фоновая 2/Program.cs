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

    private static string CyclicRightShift(uint x1, uint n)
    {
        string result = "";
        int t;
        int m ;
        for (int nn = (int)n ; nn >= 0; nn--)
        {
            t = (x1 & 1 << 1) == 0 ? 0 : 1;
            x1 >>= 1;
            if (t == 1)
            {
                x1 |= 2147483648;
            }
            n--;
        }

        for (int i = 31; i >= 0; i--)
        { 
            m = 1 << i;
            result += (x1 & m) == 0 ? 0 : 1;
        }

        return result;
    }
    
    public static void Main(string[] args)
    {
        uint n = 3, x1 = 413;
        int x2 = 5;

        int nullBitsAmount = FindNullBitsAmount(x1);
        Console.WriteLine($"Число {x1} имеет {nullBitsAmount} нулей двоичной системе.");
        
        string convertedNumber = ConvertToBits(x2);
        Console.WriteLine($"Число {x2} имеет представление {convertedNumber} в двоичной системе без ведущих нулей.");
        
        string shiftedNumber = CyclicRightShift(x1, n);
        Console.WriteLine($"Число {x1} при цикличном сдвиге вправо на {n} имеет представление {shiftedNumber} в двоичной системе.");
    }
}