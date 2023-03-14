using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace phone43;

public struct ClassTable
{
    [Range(1, 11, ErrorMessage = "Школьный класс может быть в диапазоне от 1 до 11")]
    public int ClassNumber;
    
    [Range(1, 6, ErrorMessage = "Номер группы может быть в диапазоне от 1 до 6")]
    public int GroupNumber;
    public Lesson[] Lessons;
}

public struct TimeTableWindow
{
    public string Teacher;
    public int ClassRoom;
}

public class TimeTable
{
    private string DatabasePath;
    private ClassTable[] LocalDatabase;
    private string[] Teachers;
    private int[] ClassRooms;

    public TimeTable(string databasePath, int classesAmount, string[] teachers, int[] classRooms)
    {
        this.DatabasePath = databasePath;
        this.LocalDatabase = new ClassTable[classesAmount];
        this.Teachers = teachers;
        this.ClassRooms = classRooms;
    }

    private void SaveDatabase()
    {
        TextWriter writer = null;
        try
        {
            string content = JsonConvert.SerializeObject(this.LocalDatabase);
            writer = new StreamWriter(this.DatabasePath, false);
            writer.Write(content);
        }
        finally
        {
            if (writer != null)
                writer.Close();
        }
    }

    private void LoadDatabase()
    {
        TextReader reader = null;
        try
        {
            reader = new StreamReader(this.DatabasePath);
            string content = reader.ReadToEnd();
            this.LocalDatabase = JsonConvert.DeserializeObject<ClassTable[]>(content);
        }
        finally
        {
            if (reader != null)
                reader.Close();
        }
    }

    public void FillTimeTable()
    {
        for (int i = 0; i < this.LocalDatabase.Length; i++)
        {
            Console.WriteLine($"\nЗаполнение данных класса ({i + 1}/{this.LocalDatabase.Length}).");
            this.LocalDatabase[i] = new ClassTable();
            
            Console.Write("Введите номер класса [1-11]: ");
            this.LocalDatabase[i].ClassNumber = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите номер группы [1-6]: ");
            this.LocalDatabase[i].GroupNumber = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите количество уроков у группы в этот день: ");
            this.LocalDatabase[i].Lessons = new Lesson[Convert.ToInt32(Console.ReadLine())];

            for (int j = 0; j < this.LocalDatabase[i].Lessons.Length; j++)
            {
                string classAndGroupTag = $"{this.LocalDatabase[i].ClassNumber}.{this.LocalDatabase[i].GroupNumber}";
                Console.WriteLine($"Есть-ли у группы {classAndGroupTag} {j + 1}-й урок [Y|N]:");
                ConsoleKeyInfo button;
                do
                {
                    button = Console.ReadKey(true);
                    if (button.Key == ConsoleKey.Y)
                    {
                        Lesson lesson = new Lesson();
                        Console.Write("\nВведите название предмета: ");
                        lesson.Subject = Console.ReadLine();
                        
                        Console.Write("Введите имя преподавателя: ");
                        lesson.Teacher = Console.ReadLine();
                        
                        Console.Write("Введите номер аудитории: ");
                        lesson.Classroom = Convert.ToInt32(Console.ReadLine());
                        
                        Console.Write("Введите время начала урока: ");
                        lesson.StartTime = Convert.ToDateTime(Console.ReadLine());
                        
                        lesson.EndTime = lesson.StartTime.AddMinutes(45);
                        lesson.OrderNumber = i + 1;
                        this.LocalDatabase[i].Lessons[j] = lesson;
                        break;
                    }

                    if (button.Key == ConsoleKey.N)
                        break;
                        
                } while (true);
            }
        }
        SaveDatabase();
    }

    // public TimeTableWindow[] FillWindow(int classNumber, int groupNumber, int orderNumber)
    // {
    //     List<string> allowedTeachers = this.Teachers.ToList();
    //     List<int> allowedClassrooms = this.ClassRooms.ToList();
    //     for (int i = 0; i < this.LocalDatabase.Length; i++)
    //     {
    //         if (this.LocalDatabase[i].ClassNumber == classNumber && this.LocalDatabase[i].GroupNumber == groupNumber)
    //         {
    //             Lesson lesson = this.LocalDatabase[i].Lessons[orderNumber - 1];
    //             for (int j = 0; j < this.LocalDatabase.Length; j++)
    //             {
    //                 for (int k = 0; k < this.LocalDatabase[j].Lessons.Length; k++)
    //                 {
    //                     Lesson localLesson = this.LocalDatabase[i].Lessons[k];
    //                     if (localLesson.OrderNumber == lesson.OrderNumber)
    //                     {
    //                         
    //                     }
    //                 }
    //             }
    //             break;
    //         }
    //     }
    // }

    public void Show()
    {
        try
        {
            LoadDatabase();

            for (int i = 0; i < this.LocalDatabase.Length; i++)
            {
                Console.WriteLine($"| Класс {this.LocalDatabase[i].ClassNumber}.{this.LocalDatabase[i].GroupNumber} |");
                for (int j = 0; j < this.LocalDatabase[i].Lessons.Length; j++)
                {
                    if (this.LocalDatabase[i].Lessons[j].Teacher != null)
                    {
                        Lesson lesson = this.LocalDatabase[i].Lessons[j];
                        Console.WriteLine(
                        $"{j + 1}) {lesson.Subject} ({lesson.StartTime.ToShortTimeString()} - {lesson.EndTime.ToShortTimeString()}) | {lesson.Classroom}");
                    } else 
                        Console.WriteLine($"{j + 1}) ОКНО В РАСПИСПИСАНИИ");
                }
                Console.WriteLine();
            }
        }
        catch (Exception e) { }
    }
}