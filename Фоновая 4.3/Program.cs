namespace phone43;

static class Program
{
    public static void FillTimetable(ref TimeTable timeTable, WeekDay weekDay)
    {
        string[] WeekDays = {"Понедельник", "Вторник", "Среда", "Четверг", "Пятница", "Суббота", "Воскресенье"};
        Console.Write($"Введите количество уроков в {WeekDays[(int)(weekDay - 1)].ToLower()} у класса {timeTable.ClassNumber}.{timeTable.GroupNumber} : ");
        int lessonsAmount = Convert.ToInt32(Console.ReadLine());
        
        Lesson[] lessons = new Lesson[lessonsAmount];
        for (int i = 0; i < lessonsAmount; i++)
        {
            Console.WriteLine($"\nВведите информацию об {i + 1} уроке в расписании.");
            lessons[i] = new Lesson();
            
            Console.Write("Введите название предмета: ");
            lessons[i].Subject = Console.ReadLine();
            
            Console.Write("Введите имя преподавателя: ");
            lessons[i].Teacher = Console.ReadLine();
            
            Console.Write("Введите номер аудитории: ");
            lessons[i].Classroom = Convert.ToInt32(Console.ReadLine());

            Console.Write("Введите время начала урока: ");
            lessons[i].StartTime = Convert.ToDateTime(Console.ReadLine());

            lessons[i].ClassNumber = timeTable.ClassNumber;
            lessons[i].GroupNumber = timeTable.GroupNumber;
            lessons[i].EndTime = lessons[i].StartTime.AddMinutes(45);
            lessons[i].OrderNumber = i + 1;
            lessons[i].WeekDay = weekDay;
        }
        timeTable.SetDayTimetable(weekDay, lessons);
    }
    public static void Main()
    {
        const string DatabasePath = "C:\\Users\\Dmitry\\RiderProjects\\Practice\\Фоновая 4.3\\timetable.json";
        
        Console.Write("Введите номер класса [1-11]: ");
        int classNumber = Convert.ToInt32(Console.ReadLine());
        
        Console.Write("Введите номер группы [1-6]: ");
        int groupNumber = Convert.ToInt32(Console.ReadLine());
        
        TimeTable table93 = new TimeTable(DatabasePath, classNumber, groupNumber);
        FillTimetable(ref table93, WeekDay.Monday);
        
        table93.Show();
    }
}