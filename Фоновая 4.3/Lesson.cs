namespace phone43;

public struct Lesson
{
    public Classroom Classroom;
    public Teacher Teacher;
    public Group Group;
    public Subject Subject;
    public DateTime DateStart;
    public DayOfWeek WeekDay;
    private int lessonTime;
    public int LessonOrderNumber;
}