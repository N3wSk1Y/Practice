using System;

namespace phone33;

internal class Program
{
    private static int FindPoint(string s)
    {
        string localS,
            substring;
        bool isLocalS = true;
        for (int j = 1; j <= s.Length; j++)
        {
            isLocalS = true;
            if (s.Length % j != 0)
            {
                continue;
            }
            substring = s.Substring(0, j);
            for (int i = 1; i < s.Length / j; i++)
            {
                localS = s.Substring(i * j, j);
                if (localS != substring)
                {
                    isLocalS = false;
                    break;
                }
            }

            if (isLocalS)
            {
                return j;
            }
        }
        return 0;
    }

    public static void Main()
    {
        while (true)
        {
            Console.WriteLine("Введите строку");
            int r = FindPoint(Console.ReadLine());
            Console.WriteLine(r);
        }
    }
}
