namespace phone52;

internal class Program
{
    public static void Main()
    {
        int month,
            weekDay,
            temp;
        ConsoleKeyInfo keyInput;
        MatrixWeather weather = new MatrixWeather();
        Console.WriteLine("Ввести расписание погоды вручную? [Y/N]: ");

        keyInput = Console.ReadKey();
        Console.Clear();
        switch (keyInput.Key)
        {
            case ConsoleKey.Y:
                try
                {
                    Console.Write("Введите месяц: ");
                    month = Convert.ToInt16(Console.ReadLine());
                    Console.Clear();

                    Console.Write("Введите день начала недели: ");
                    weekDay = Convert.ToInt16(Console.ReadLine());
                    Console.Clear();

                    weather = MatrixWeather.Create((Month)month, weekDay);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
                break;
            case ConsoleKey.N:
                Console.WriteLine("Bye-bye!");
                break;
        }
        weather.PrintTable();
        Console.WriteLine(
            @"
1 - Изменить день недели, с которого начинается месяц
2 - Узнать день недели, с которого начался месяц
3 - Изменить месяц
4 - Узнать количество дней с температурой в ноль градусов
5 - Узнать максимальный скачок температуры за месяц
6 - Узнать максимальный скачок температуры за месяц, с числом, в которое произошёл скачок
"
        );
        keyInput = Console.ReadKey();
        Console.WriteLine();
        while (keyInput.Key != ConsoleKey.F9)
        {
            switch (keyInput.Key)
            {
                case ConsoleKey.D1:
                    Console.Write("Введите номер дня: ");
                    try
                    {
                        weather.Day = int.Parse(Console.ReadLine());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        weather.Day = 5;
                    }
                    weather.PrintTable();
                    keyInput = Console.ReadKey();
                    break;
                case ConsoleKey.D2:
                    Console.WriteLine(
                        $"Dень недели, с которого начался месяц - {(Week)weather.Day}"
                    );
                    keyInput = Console.ReadKey();
                    break;
                case ConsoleKey.D3:
                    Console.WriteLine("Введите интересующий вас месяц:");
                    try
                    {
                        weather.Month = (Month)int.Parse(Console.ReadLine());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        weather.Month = (Month)10;
                    }
                    weather.PrintTable();
                    keyInput = Console.ReadKey();
                    break;
                case ConsoleKey.D4:
                    Console.WriteLine(
                        $"Kоличество дней с температурой в ноль градусов - ${weather.GoodDays}"
                    );
                    keyInput = Console.ReadKey();
                    break;
                case ConsoleKey.D5:
                    Console.WriteLine(
                        $"Mаксимальный скачок температуры за месяц - {weather.HighestRise()}"
                    );
                    keyInput = Console.ReadKey();
                    break;
                case ConsoleKey.D6:
                    Console.WriteLine(
                        $"Mаксимальный скачок температуры за месяц - {weather.HighestRise(out temp)}, он был {temp}-го"
                    );
                    keyInput = Console.ReadKey();
                    break;
            }
        }
    }
}
