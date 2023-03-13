using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace phone43;

public class TimeTable
{
    public int ClassNumber;
    public int GroupNumber;
    private string DatabasePath;
    private Lesson[][] LocalDatabase;

    public TimeTable(string databasePath, int classNumber, int groupNumber)
    {
        this.ClassNumber = classNumber;
        this.GroupNumber = groupNumber;
        this.DatabasePath = databasePath;
        this.LocalDatabase = new Lesson[classNumber is >= 7 and <= 10 ? 6 : 5][];
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
            this.LocalDatabase = JsonConvert.DeserializeObject<Lesson[][]>(content);
        }
        finally
        {
            if (reader != null)
                reader.Close();
        }
    }

    public void SetDayTimetable(WeekDay weekDay, Lesson[] timeTable)
    {
        this.LocalDatabase[(int)weekDay - 1] = timeTable;
        SaveDatabase();
    }

    public void Show()
    {
        string[] WeekDays = {"Понедельник", "Вторник", "Среда", "Четверг", "Пятница", "Суббота", "Воскресенье"};
        try
        {
            LoadDatabase();

            for (int i = 0; i < this.LocalDatabase.Length; i++)
            {
                Console.WriteLine($"| {WeekDays[i]} |");
                for (int j = 0; j < this.LocalDatabase[i].Length; j++)
                {
                    Lesson lesson = this.LocalDatabase[i][j];
                    Console.WriteLine(
                        $"{lesson.Subject} ({lesson.StartTime.ToShortTimeString()} - {lesson.EndTime.ToShortTimeString()}) \nАудитория: {lesson.Classroom}");
                }

                Console.WriteLine();
            }
        }
        catch (Exception e) { }
    }
}