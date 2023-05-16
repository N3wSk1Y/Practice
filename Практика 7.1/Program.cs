// Фоновая 2
namespace practice71;

internal class Program
{
    private static int FindSecondMax(int N) // Вариант 17
    {
        int max1 = Int32.MinValue;
        int max2 = Int32.MinValue;

        Console.WriteLine($"Введите {N} чисел через Enter");
        for (int i = 0; i < N; i++)
        {
            int input = int.Parse(Console.ReadLine());
            if (input > max1)
            {
                max2 = max1;
                max1 = input;
            }
            else if (input > max2)
                if (input != max1)
                    max2 = input;
        }

        return max2;
    }

    public static void Main(string[] args)
    {
        int max2 = FindSecondMax(5);
        if (max2 == Int32.MinValue)
        {
            Console.WriteLine("Второго максимума нет");
        }
        else
        {
            Console.WriteLine($"Второй максимум: {max2}");
        }
    }
}
