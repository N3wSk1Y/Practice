using System;
namespace phone22;

class BitArrayHandler
{
    private long number = 0;
    private void HandleCommand(string command, int argument)
    {
        switch (command)
        {
            case "/write": // Занести
                if (argument is >= 1 and <= 15)
                {
                    if (ReadSector(number, 15) == 0)
                        WriteNumber(ref number, argument);
                    else
                        PrintWithColor("\n[!] Ячейка занята.", ConsoleColor.White,ConsoleColor.Red);
                    PrintSelectedSector(RepresentToBase2(number), 0);
                }
                else
                    PrintWithColor("\n[!] Число должно быть в диапазоне от 1 до 15.", ConsoleColor.White,ConsoleColor.Red);
                break;
            case "/read": // Прочитать
                if (argument is >= 0 and <= 15)
                {
                    PrintWithColor($"\nЧисло в ячейке {argument}: " + ReadSector(number, argument), ConsoleColor.White,ConsoleColor.Blue);
                    PrintSelectedSector(RepresentToBase2(number), argument);
                }
                else
                    PrintWithColor("\n[!] Ячейка должна быть в диапазоне от 0 до 15.", ConsoleColor.White,ConsoleColor.Red);
    
                break;
            case "/clear": // Очистить
                if (argument is >= 0 and <= 15)
                {
                    ClearSector(ref number, argument);
                    PrintWithColor($"\nЯчейка {argument} очищена.", ConsoleColor.White,ConsoleColor.Blue);
                    PrintSelectedSector(RepresentToBase2(number), argument);
                }
                else
                    PrintWithColor("\n[!] Ячейка должна быть в диапазоне от 0 до 15.", ConsoleColor.White,ConsoleColor.Red);
                break;
            default:
                PrintWithColor("[!] Неверная команда.", ConsoleColor.White,ConsoleColor.Red);
                break;
        }
        AwaitCommand();
    }
    
    private void WriteNumber(ref long mainNumber, int number)
    {
        mainNumber <<= 4;
        mainNumber |= number;
    }
    
    private long ReadSector(long mainNumber, int sector)
    {
        long m = 0xF;
        long result = (mainNumber >> 4 * sector) & m;
        return result;
    }
    
    private void ClearSector(ref long mainNumber, int sector)
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
    
    public void AwaitCommand()
    {
        Console.WriteLine("\nВведите команду:\n/write [число (1-15)] - занести\n/read [ячейка (0-15)] - прочитать\n/clear [ячейка (0-15)] - очистить");
        string input = Console.ReadLine();
        string[] words = input.Trim().Split(' ');
        if (words.Length == 2)
        {
            if (Int32.TryParse(words[1], out int argument))
            {
                HandleCommand(words[0], argument);
            }
            return;
        }

        PrintWithColor("\n\n[!] Неверная команда.", ConsoleColor.White,ConsoleColor.Red);
        AwaitCommand();
    }
    
    private string RepresentToBase2(long number)
    {
        string binaryRepresentation = Convert.ToString(number, 2);
        string result = "";
        for (int i = 64; i > binaryRepresentation.Length; i--)
            result += "0";
        
        return result += binaryRepresentation;
    }
    
    private void PrintSelectedSector(string number, int sector)
    {
        sector = 16 - sector;
        int lastIndex = sector * 4;
        int firstIndex = lastIndex - 4;
        Console.WriteLine("\nТекущее состояние памяти:");
        for (int i = 0; i <= 63; i++)
        {
            if (i >= firstIndex && i < lastIndex)
                PrintWithColor(number[i].ToString(), ConsoleColor.Green);
            else
                PrintWithColor(number[i].ToString(), ConsoleColor.Red);
        }

        Console.WriteLine();
    }

    private void PrintWithColor(string text, ConsoleColor textColor = ConsoleColor.White, ConsoleColor backColor = ConsoleColor.Black)
    {
        Console.ForegroundColor = textColor;
        Console.BackgroundColor = backColor;
        Console.Write(text);
        Console.ResetColor();
    }
}

internal class Program
{
    public static void Main(string[] args)
    {
        var handler = new BitArrayHandler();
        handler.AwaitCommand();
    }
}