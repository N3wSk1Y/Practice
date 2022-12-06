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
                
                break;
            case "/read": // Прочитать

                break;
            case "/clear": // Очистить

                break;
            default:
                Console.WriteLine("\nНеверная команда.");
                AwaitCommand();
                break;
        }
        Console.WriteLine(BitsRepresentation(ref number));
    }
    private static void ReadSector(long number, int sector)
    {
        int m = 15 << sector;
    }
    private static void AwaitCommand()
    {
        Console.WriteLine("Введите команду:\n/write [число (1-15)] - занести\n/read [ячейка (1-16)] - прочитать\n/clear [ячейка (1-16)] - очистить");
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
    private static string BitsRepresentation(ref long number)
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
        // Console.WriteLine(BitsRepresentation(ref number));
    }
}