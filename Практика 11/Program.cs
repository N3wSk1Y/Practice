using System;

namespace practice11;

internal class Program // Вариант 5
{
    private static string Task1(string a, int n)
    {
        for (int i = (a.Length % n == 0) ? n : a.Length % n; i < a.Length; i += n)
        {
            a = a.Insert(i, ".");
            i++;
        }

        return a;
    }

    private static void Task2(ref string s, string subs)
    {
        while (s.Contains(subs))
        {
            s = s.Replace(subs, "");
        }
    }

    private static void Task3(ref string s)
    {
        if (s.Length % 2 == 0)
        {
            s = s.Remove(s.Length / 2 - 1, s.Length / 2);
        }
        else
        {
            s = s.Remove((s.Length - 1) / 2, (s.Length - 1) / 2);
        }
    }

    public static void Main()
    {
        string s1 = "12345678";
        Console.WriteLine(Task1(s1, 2));

        string s2 = "abc123abc121233";
        Task2(ref s2, "123");
        Console.WriteLine(s2);

        string s3 = "1234";
        Task3(ref s3);
        Console.WriteLine(s3);
    }
}
