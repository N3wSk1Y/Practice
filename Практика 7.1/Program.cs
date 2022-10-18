using System;
namespace practice71;

internal class Program
{
    private static int FindSecondMax(int N) // Вариант 17
    {
        int max = int.Parse(Console.ReadLine());
        int max2 = int.Parse(Console.ReadLine());
        if (max <= max2)
        {
            for (int i = 0; i < N; i++)
            {
                int input = int.Parse(Console.ReadLine());
                if (input > max)
                {
                    max = input;
                    max2 = input;
                }
                else
                {
                    if (input < max && input > max2)
                        max2 = input;
                }
            }

            return max2;
        }
        else
        {
            throw new Exception("Max2 не может быть меньше Max");
        }
        
    }
    
    public static void Main(string[] args)
    {
        FindSecondMax(5);
    }
}