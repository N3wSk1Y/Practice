namespace phone43;

static class Program
{
    public static void Main()
    {
        const string DatabasePath = "/Users/n3wsk1y/RiderProjects/Practice/Фоновая 4.3/timetable.json";

        Console.Write("Введите количество классов в расписании: ");
        int classesAmount = Convert.ToInt32(Console.ReadLine());

        TimeTable table = new TimeTable(
                DatabasePath,
                classesAmount, 
                new string[5] { "Соладтова", "Казицин", "А.Терехина", "Меринов", "Ляхова" },
                new int[4] { 666, 304, 200, 1 }
        );

        Console.WriteLine("Заполнить расписание заного - R\nПолучить данные из файла - F");
        ConsoleKeyInfo button;
        do
        {
            button = Console.ReadKey(true);
            if (button.Key == ConsoleKey.R)
            {
                table.FillTimeTable();
                table.Show();
                break;
            }

            if (button.Key == ConsoleKey.F)
            {
                table.Show();
                break;
            }
        } while (true);
    }
}