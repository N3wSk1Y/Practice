using System;
namespace practice121;

class Program
{
    private static void PrintArray(int[] array)
    {
        foreach (int xm in array)
        {
            if (xm != 0)
            {
                Console.Write(xm);
            }
        }
    }
    
    private static int GetColumnsAmount(int[][] array)
    {
        int result = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if (result < array[i].Length)
            {
                result = array[i].Length;
            }
        }
        
        return result;
    }
    
    private static int GetRowsAmount(int[][] array)
    {
        int result = 0;
        int empties;
        for (int i = 0; i < array.Length; i++)
        {
            empties = 0;
            for (int j = 0; j < array[i].Length; j++)
            {
                if (array[i][j] == 0)
                {
                    empties++;
                }
                if (array[i].Length / 2 >= empties)
                {
                    result++;
                }
            }
        }
        
        return result;
    }

    
    private static int[][] InputJaggetArray(int length)
    {
        int[][] array = new int[length][];
        for (int i = 0; i < length; i++)
        {
            Console.WriteLine($"Введите длину {i+1}-й строки");
            int length2 = Convert.ToInt32(Console.ReadLine());
            int[] insideArray = new int[length2];
            for (int j = 0; j < length2; j++)
            {
                Console.WriteLine($"Введите {j+1} значение строки");
                insideArray[j] = Convert.ToInt32(Console.ReadLine());
            }

            array[i] = insideArray;
        }

        return array;
    }

    private static void PrintJaggetArray(int[][] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            for (int j = 0; j < array[i].Length; j++)
            {
                Console.Write(array[i][j]);
            }
            Console.WriteLine();
        }
    }

    private static int[] GetFirstEvens(int[][] array)
    {
        int columnsAmount = GetColumnsAmount(array);
        int[] result = new int[columnsAmount];
        for (int j = 0; j < columnsAmount; j++)
        {
            result[j] = -1;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].Length > j)
                {
                    if (array[i][j] % 2 == 0)
                    {
                        result[j] = array[i][j];
                        break;
                    }   
                }
            }
        }
        
        return result;
    }

    private static void CompactArray(ref int[][] array)
    {
        int rowsAmount = GetRowsAmount(array);
        int emptiesAmount;
        int currentIndex = 0;
        int[][] result = new int[rowsAmount][];
        for (int i = 0; i < array.Length; i++)
        {
            emptiesAmount = 0;
            for (int j = 0; j < array[i].Length; j++)
            {
                if (array[i][j] == 0)
                {
                    emptiesAmount++;
                }
            }
            if (array[i].Length / 2 >= emptiesAmount)
            {
                result[currentIndex] = array[i];
                currentIndex++;
            }
        }
        
        array = result;
    }
    
    private static void ShiftArray(ref int[][] array, int shiftStep)
    {
        int result = array[shiftStep][array[shiftStep].Length-1];
        for (int j = array[shiftStep].Length-1; j > 0; j--)
        {
            array[shiftStep][j] = array[shiftStep][j-1];
        }
        array[shiftStep][0] = result;
    }
    
    public static void Main()
    {
        Console.Write("Введите количество строк в массиве:");
        int arrayLength = Convert.ToInt32(Console.ReadLine());
        int[][] array = InputJaggetArray(arrayLength);

        int[] firstEvenNumbers = GetFirstEvens(array);
        PrintArray(firstEvenNumbers);

        CompactArray(ref array);
        PrintJaggetArray(array);

        Console.Write("Введите номер строки: ");
        int rowNumber = Convert.ToInt32(Console.ReadLine());
        for (int i = 0; i < array[rowNumber].Length; i++)
        {
            ShiftArray(ref array, rowNumber);
            PrintArray(array[rowNumber]);
            Console.WriteLine();
        }
        Main();
    }
}