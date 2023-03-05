using System;
using System.Text;

namespace lines;

class Program
{
    private static void PrintField(int[,] field)
    {
        const string circle = "⏺";
        const string empty = "▢";
        for (int i = 0; i < field.GetLength(0); i++)
        {
            for (int j = 0; j < field.GetLength(1); j++)
            {
                if (field[i, j] == 0)
                {
                    Console.Write(empty);
                }
                else
                {
                    PrintWithColor(circle, (ConsoleColor)field[i, j]);
                }
                Console.Write(" ");
            }
            Console.WriteLine();
        }
    }

    private static void PrintWithColor(string text, ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.Write(text);
        Console.ResetColor();
    }

    private static void AddBalls(int[,] field, int ballsAmount = 3)
    {
        var random = new Random();
        for (int i = 0; i < ballsAmount; i++)
        {
            int x = random.Next(0, field.GetLength(0));
            int y = random.Next(0, field.GetLength(1));
            if (field[x, y] == 0)
            {
                int color = random.Next(1, 8);
                field[x, y] = color;
            }
            else
            {
                i -= 1;
            }
        }
    }

    private static void MoveBall(int[,] field, int x1, int y1, int x2, int y2)
    {
        int columns = field.GetLength(0);
        int rows = field.GetLength(1);
    }

    private static void BeginIteraction(int ballsAmount, ref int score, int[,] field)
    {
        AddBalls(field, ballsAmount);
        PrintField(field);
        Console.WriteLine($"Ваш счет: {score}");
        Console.WriteLine("Для передвижения шара введите x1|y2 => x2|y2\nПример:0|0 => 1|1");
        Console.ReadLine();
    }
    
    public static void Main()
    {   
        const int fieldSize = 9;
        int[,] field = new int[fieldSize, fieldSize];
        int score = 0;
        
        Console.Write("Введите количество генерируемых шаров после каждого хода: ");
        int ballsAmount = Convert.ToInt32(Console.ReadLine());
        while (true)
            BeginIteraction(ballsAmount, ref score, field);
    }
}
