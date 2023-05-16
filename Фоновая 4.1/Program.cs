using System;

namespace phone41;

class Program
{
    private static bool ArrayContains(int[] array, int value)
    {
        foreach (var xm in array)
        {
            if (xm == value)
                return true;
        }

        return false;
    }

    private static int IndexOf(int[] array, int value)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == value)
            {
                return i;
            }
        }

        return -1;
    }

    private static int LastIndexOf(int[] array, int value)
    {
        for (int i = array.Length - 1; i >= 0; i--)
        {
            if (array[i] == value)
            {
                return i;
            }
        }

        return -1;
    }

    private static void SwapArrayElements(int[] array, int firstIndex, int secondIndex)
    {
        int temp = array[secondIndex];
        array[secondIndex] = array[firstIndex];
        array[firstIndex] = temp;
    }

    private static int[] InputIntArray(int arrayLength)
    {
        int[] array = new int[arrayLength];
        for (int i = 0; i < arrayLength; i++)
        {
            Console.WriteLine($"Введите {i + 1} элемент массива");
            array[i] = Convert.ToInt32(Console.ReadLine());
        }

        return array;
    }

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

    private static int FindMax(int[] array)
    {
        int max = array[0];
        foreach (var xm in array)
            max = xm > max ? xm : max;

        return max;
    }

    private static int FindMin(int[] array)
    {
        int min = array[0];
        foreach (var xm in array)
            min = xm < min ? xm : min;

        return min;
    }

    private static int[] SliceByMaxAndMin(int[] array)
    {
        int indexOfMax = IndexOf(array, FindMax(array));
        int indexOfMin = LastIndexOf(array, FindMin(array));

        // return array.Where((value, index) => index >= Math.Min(indexOfMin, indexOfMax) && index <= Math.Max(indexOfMin, indexOfMax)).ToArray();
        for (int i = 0; i < array.Length; i++)
        {
            if (!(i >= Math.Min(indexOfMin, indexOfMax) && i <= Math.Max(indexOfMin, indexOfMax)))
            {
                array[i] = 0;
            }
        }

        return array;
    }

    private static int[] ArrayShiftLeft(int[] array, int k)
    {
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = i + k < array.Length ? array[i + k] : 0;
        }

        // return array.Where((value) => value != 0).ToArray();
        // for (int i = 0; i + 1 < array.Length; i++)
        // {
        //     if (array[i] == 0)
        //     {
        //         SwapArrayElements(ref array, i, i+1);
        //     }
        // }
        //
        // int firstZero = LastIndexOf(array, 0);
        // int[] result = new int[firstZero + 1];
        // for (int i = 0; i < result.Length; i++)
        // {
        //     result[i] = array[i];
        // }
        //
        // return result;
        return array;
    }

    private static void PrintArrayCrosses(int[] array1, int[] array2)
    {
        foreach (var xm in array2)
        {
            if (ArrayContains(array1, xm))
            {
                Console.Write(xm);
            }
        }
    }

    private static int[] RemoveDublicatesFromArray(int[] array)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            if (array[i] == array[i + 1])
            {
                array[i + 1] = 0;
            }
        }

        // return array.Where((value) => value != 0).ToArray();
        return array;
    }

    private static void SelectTask(int taskNumber)
    {
        Console.WriteLine($"Введите длину массива");
        int arrayLength = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine($"Последовательно введите значения массива");
        int[] array = InputIntArray(arrayLength);
        switch (taskNumber)
        {
            case 1:
            {
                int[] result = SliceByMaxAndMin(array);
                Console.WriteLine(
                    "Элементы между первым максимальным и последним минимальными элементами: "
                );
                PrintArray(result);
                break;
            }
            case 2:
            {
                Console.WriteLine("На сколько сдвинуть массив: ");
                int shift = Convert.ToInt32(Console.ReadLine());
                int[] result = ArrayShiftLeft(array, shift);
                Console.WriteLine("Элементы сдвинутого массива: ");
                PrintArray(result);
                break;
            }
            case 3:
            {
                Console.WriteLine("Введите длину второго массива: ");
                int arrayLength2 = Convert.ToInt32(Console.ReadLine());
                int[] array2 = InputIntArray(arrayLength2);
                Console.WriteLine("Пересечение массивов: ");
                PrintArrayCrosses(array, array2);
                break;
            }
            case 4:
            {
                int[] result = RemoveDublicatesFromArray(array);
                Console.WriteLine("Массив без повторяющихся элементов: ");
                PrintArray(result);
                break;
            }
        }
    }

    public static void Main()
    {
        while (true)
        {
            Console.WriteLine(
                "\n1 - Поиск элементов между первым максимальным и последним минимальными элементами\n"
                    + "2 - Циклический сдвиг массива\n"
                    + "3 - Пересечение массивов\n"
                    + "4 - Удаление идущих подряд элементов"
            );
            Console.Write("Введите номер функции: ");
            int taskNumber = Convert.ToInt32(Console.ReadLine());
            if (taskNumber is >= 1 and <= 4)
                SelectTask(taskNumber);
        }
    }
}
