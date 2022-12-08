using System;
namespace phone22;

internal class Program
{
    private static long number = 0;
    private static void HandleCommand(string command, int argument)
    {
        switch (command)
        {
            case "/write": // Занести
                if (argument is >= 1 and <= 15)
                {
                    WriteNumber(ref number, argument);
                }
                else
                    Console.WriteLine("Число должно быть в диапазоне от 1 до 15");
                break;
            case "/read": // Прочитать
                if (argument is >= 0 and <= 15)
                {
                    Console.WriteLine($"Число в ячейке {argument}: " + ReadSector(number, argument));
                }
                else
                    Console.WriteLine("Ячейка должна быть в диапазоне от 0 до 15");
    
                break;
            case "/clear": // Очистить
                if (argument is >= 0 and <= 15)
                {
                    ClearSector(ref number, argument);
                    Console.WriteLine($"Ячейка {argument} очищена.");
                }
                else
                    Console.WriteLine("Ячейка должна быть в диапазоне от 0 до 15");
                break;
            default:
                Console.WriteLine("\nНеверная команда.");
                break;
        }
        Console.WriteLine("\nСостояние памяти:\n" + RepresentToBase2(number) + "\n");
        AwaitCommand();
    }
    private static void WriteNumber(ref long mainNumber, int number)
    {
        mainNumber <<= 4;
        mainNumber |= number;
    }
    private static long ReadSector(long mainNumber, int sector)
    {
        long m = 0xF;
        long result = (mainNumber >> 4 * sector) & m;
        return result;
    }
    private static void ClearSector(ref long mainNumber, int sector)
    {
        long m, m1;
        if (sector > 0)
        {
            m1 = 15 << (sector - 1) * 4;
            m = (0xFFFFFFF0 << (sector * 4)) | m1;
        }
        else
        {
            m = 0xFFFFFFF0 << (sector * 4);
        }
        mainNumber &= m;
    }
    private static void AwaitCommand()
    {
        Console.WriteLine("Введите команду:\n/write [число (1-15)] - занести\n/read [ячейка (0-15)] - прочитать\n/clear [ячейка (0-15)] - очистить");
        string input = Console.ReadLine();
        string[] words = input.Split(' ');
        if (words.Length == 2)
        {
            if (Int32.TryParse(words[1], out int argument))
            {
                HandleCommand(words[0], argument);
            }
            return;
        }
        Console.WriteLine("\nНеверная команда.");
        AwaitCommand();
    }
    private static string RepresentToBase2(long number)
    {
        string binaryRepresentation = Convert.ToString(number, 2);
        string result = "";
        for (int i = 64; i > binaryRepresentation.Length; i--)
            result += "0";
        
        return result += binaryRepresentation;
    }
    public static void Main(string[] args)
    {
        AwaitCommand();
    }
}