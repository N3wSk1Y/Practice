using System;

namespace practice8;

internal class Program
{
    private static int Remainder(int a, int b)
    {
        return a % b;
    }

    private static int Task1(int a) // Вариант 3
    {
        int counter = 0;
        a = Math.Abs(a);
        while (a > 0)
        {
            int number = a % 10;
            a /= 10;
            if (number < 8 && number % 3 != 0 && number % 4 != 0)
            {
                counter++;
            }
        }
        return counter;
    }

    private static int Task2(int a)
    {
        a = Math.Abs(a);
        int previousNumber = a % 10;
        int sum = 0;
        while (a > 0)
        {
            a /= 10;
            int number = a % 10;
            if ((number + previousNumber) % 2 == 0)
                sum += number + previousNumber;

            previousNumber = number;
        }
        return sum;
    }

    private static bool IsHappyNumber(int a)
    {
        a = Math.Abs(a);
        if (a < 10)
            return false;
        int counter = 0,
            sum1 = 0,
            sum2 = 0,
            aa = a;
        while (a > 0)
        {
            a /= 10;
            counter++;
        }

        for (int i = 0; i < counter; i++)
        {
            if (i < counter / 2 && counter % 2 == 1)
                sum1 += aa % 10;
            else if (i == counter / 2 && counter % 2 == 1)
            {
                sum1 += aa % 10;
                sum2 += aa % 10;
            }
            else
                sum2 += aa % 10;
            aa /= 10;
        }

        return sum1 == sum2;
    }

    private static void PerfectNumbers(int n)
    {
        for (int m = 1; m < n; m++)
        {
            int sum = 1;
            for (int i = 2; i <= Math.Sqrt(m); i++)
            {
                if (m % i == 0)
                    sum += i + m / i;
            }
            if (sum == m)
                Console.WriteLine(m);
        }
    }

    private static int Task5(int a)
    {
        int result = 0,
            number;
        bool positive = true;
        while (a > 0)
        {
            number = a % 10;
            a /= 10;
            if (positive)
                result += number;
            else
                result -= number;
            positive = !positive;
        }

        return result;
    }

    private static bool IsDegree(float N, float m)
    {
        while (N >= 1)
        {
            N /= m;
            if (N == 1)
                return true;
        }

        return false;
    }

    private static int Reminder(float n, float m)
    {
        float division = n / m;
        string zeroReminder = (division - (int)division).ToString();
        int result = int.Parse(zeroReminder.Substring(2));
        return result;
    }

    public static void Main(string[] args)
    {
        // Console.WriteLine($"Остаток от деления: {Remainder(17, 5)}");
        // int t1 = Task1(123123465);
        // if (t1 > 0)
        //     Console.WriteLine($"Чисел, подходящих под условия: {t1}");
        // else
        //     Console.WriteLine("NO");
        // Console.WriteLine(Task2(1587662));
        // Console.WriteLine(IsHappyNumber(4571862));
        // PerfectNumbers(20);
        // Console.WriteLine(Task5(4587315));
        // Console.WriteLine(IsDegree(8, 2));
        // Console.WriteLine(Reminder(10f, 3f));
    }
}
