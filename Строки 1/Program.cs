using System.IO;

namespace stringpractice1;

internal class Program
{
    private static int Task1(string path)
    {
        int maxNumber = 0,
            localMax = 0;
        var fs = new StreamReader(path);
        string s = fs.ReadLine();
        char[] symbols = s.ToCharArray();
        char prepreviousSymbol = 'A',
            previousSymbol = 'A';
        for (int i = 0; i < symbols.Length; i++)
        {
            if (prepreviousSymbol != symbols[i] && prepreviousSymbol != 'Z' && symbols[i] != 'Z')
            {
                localMax++;
            }
            else
            {
                if (maxNumber < localMax)
                    maxNumber = localMax;
                localMax = 0;
            }
            prepreviousSymbol = previousSymbol;
            previousSymbol = symbols[i];
        }

        return maxNumber;
    }

    private static int Task2(string path)
    {
        int maxNumber = 0,
            localMax = 0;
        var fs = new StreamReader(path);
        string s = fs.ReadLine();
        char[] symbols = s.ToCharArray();
        char prepreviousSymbol = 'A',
            previousSymbol = 'A';
        for (int i = 0; i < symbols.Length; i++)
        {
            if (prepreviousSymbol != symbols[i] && prepreviousSymbol != 'Z' && symbols[i] != 'Z')
            {
                localMax++;
            }
            else
            {
                if (maxNumber < localMax)
                    maxNumber = localMax;
                localMax = 0;
            }
            prepreviousSymbol = previousSymbol;
            previousSymbol = symbols[i];
        }

        return maxNumber;
    }

    public static void Main()
    {
        // Вариант 2
        string path1 = "Task-1.txt";
        int res1 = Task1(path1);
        Console.WriteLine(res1);
    }
}
