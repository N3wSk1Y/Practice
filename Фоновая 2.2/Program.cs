using System;
namespace phone22;

internal class Program
{
    private static void CommandsHandler(int command)
    {
        switch (command)
        {
            case 1: // Занести

                break;
            case 2: // Прочитать

                break;
            case 3: // Очистить

                break;
            default:
                AwaitCommand("Неверная команда.");
                break;
        }
    }
    private static void AwaitCommand(string data)
    {
        Console.WriteLine(data);
        Console.WriteLine("Введите команду:\n1 - занести\n2 - прочитать\n3 - очистить");
        while (true)
        {
            string input = Console.ReadLine();
            if (Int32.TryParse(input, out int command))
                CommandsHandler(command);
            else
                Console.WriteLine();
        }
    }
    public static void Main(string[] args)
    {
        long number = 0;
        AwaitCommand("Архиватор.");
    }
}