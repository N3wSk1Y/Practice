using System.Text;

namespace practice13
{
    internal class Program
    {
        public enum Season
        {
            зима,
            весна,
            лето,
            осень
        }

        public enum Month
        {
            Январь = 1,
            Февраль = 2,
            Март = 3,
            Апрель = 4,
            Май = 5,
            Июнь = 6,
            Июль = 7,
            Август = 8,
            Сентябрь = 9,
            Октябрь = 10,
            Ноябрь = 11,
            Декабрь = 12
        }        
        static void Main()
        {
            int[] daysInMonth = new int[] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            for (Month i = Month.Январь; i <= Month.Декабрь; i++)
                Console.WriteLine($"Месяц {i} cоответсвует числу {(int)i}");

            Console.Write("Введите номер месяца: "); 
            int monthNumber = int.Parse(Console.ReadLine());
            
            Console.Write("Введите номер дня: "); 
            int dayNumber = int.Parse(Console.ReadLine());
            
            Console.Write("Введите сколько отсчитать дней ");
            int addDays = int.Parse(Console.ReadLine());

            int finalDay = dayNumber + addDays;
            for (monthNumber--; finalDay > 0; monthNumber++)
                finalDay -= daysInMonth[monthNumber % 12];

            Season result = (Season)((monthNumber % 12) / 3);
            Console.WriteLine("Сейчас ");
            Console.WriteLine(result);
        }
    }
}