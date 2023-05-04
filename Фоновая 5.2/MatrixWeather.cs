namespace phone52;

public class MatrixWeather
{
    private static int[,] mTemperature = new int[,] { { -12, 3 }, { -5, 14 }, { 10, 22 }, { -2, 13 } };
    private static readonly int noData = -1000;
    private static readonly int[] DaysInMonths = { 31, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30 };
    private static Random rnd = new Random();
    
    private Month month;
    private int day;
    private int[,] temperature;

    private int DaysInMonth
    {
        get { return MatrixWeather.DaysInMonths[(int)this.month]; }
    }
    
    public int Day
    {
        get { return this.day; }
        set
        {
            if (value >= 1 && value <= 7 && value != this.day)
            {
                int[] buff = new int[this.DaysInMonth];
                for (int i = this.day; i < this.day + this.DaysInMonth; i++)
                {
                    buff[i - this.day] = this.temperature[i / 7, i % 7];
                }                        

                this.day = value;
                int daysNum = this.day + this.DaysInMonth;
                this.temperature = new int[daysNum / 7 + (daysNum % 7 == 0 ? 0 : 1), 7];

                for (int i = 0; i < this.temperature.Length; i++)
                {
                    if (i < this.day || i >= this.DaysInMonth + this.day)
                    {
                        this.temperature[i / 7, i % 7] = MatrixWeather.noData;
                    }                            
                    else {this.temperature[i / 7, i % 7] = buff[i - this.day];}
                }
            }
        }
    }

    public int GoodDays
    {
        get
        {
            int temp = 0;
            for (int i = 0; i < this.DaysInMonth + day; i++)
            {
                if (this.temperature[i / 7, i % 7] == 0)
                {
                    temp += 1;
                }
            }

            return temp;
        }
    }

    public Month Month
    {
        get { return this.month; }
        set
        {
            this.month = value;
            Randomize(ref this.temperature, this.day, (int)value);
        }
    }

    public MatrixWeather()
    {
        this.month = MatrixWeather.GenerateRandomMonth();
        this.day = MatrixWeather.GenerateRandomWeekDay();
        this.temperature = new int[6, 7];
        MatrixWeather.Randomize(ref this.temperature, this.day, (int)this.month);
    }

    private MatrixWeather(Month month, int weekDay)
    {
        this.month = month;
        this.day = weekDay;
        this.temperature = new int[7, 7];
        MatrixWeather.Randomize(ref this.temperature, this.day, (int)this.month);
    }

    public void PrintTable()
    {
        Console.Write($"\n{this.month}\nMon\tTue\tWed\tThu\tFri\tSat\tSun");
        for (int i = 0; i < this.DaysInMonth + day; i++)
        {
            if (temperature[i / 7, i % 7] != MatrixWeather.noData)
            {
                Console.Write($"{i + 1 - day}: {temperature[i / 7, i % 7]}\t");
            }
            else
            {
                Console.Write("       \t");
            }

            if (i % 7 == 0)
            {
                Console.WriteLine();
            }
        }
        Console.WriteLine();
    }
    
    public int HighestRise()
    {
        int temp = -10001;
        for (int i = day+1; i < this.DaysInMonth + day; i++)
        {
            if (temperature[i/7,i%7] - temperature[(i-1) / 7,(i-1) % 7] > temp) { temp = temperature[i / 7, i % 7] - temperature[(i - 1) / 7, (i - 1) % 7]; }
        }
        return temp;
    }
    
    public int HighestRise(out int input)
    {
        input = -1;
        int temp = -10001;
        for (int i = day+1; i < this.DaysInMonth + day; i++)
        {
            if (temperature[i / 7, i % 7] - temperature[(i - 1) / 7, (i - 1) % 7] > temp) { temp = temperature[i / 7, i % 7] - temperature[(i - 1) / 7, (i - 1) % 7]; input = i - day; }
        }
        return temp;
    }
    
    public static MatrixWeather Create()
    {
        return new MatrixWeather();
    }

    public static MatrixWeather Create(Month month, int weekDay)
    {
        if (weekDay is >= 1 and <= 7)
        {
            return new MatrixWeather(month, weekDay);
        }
        else
        {
            throw new Exception("День недели указан некорректно. Необходимо число в диапазоне от 1 до 7.");
        }
    }
    
    public static void Randomize(ref int[,] temperature, int day, int month)
    {
        for (int i = 0; i < MatrixWeather.DaysInMonths[month] + day; i++)
        {
            if (i < day)
            {
                temperature[i / 7, i % 7] = MatrixWeather.noData;
            }
            else
            {
                temperature[i / 7, i % 7] = rnd.Next(MatrixWeather.mTemperature[month / 3, 0], MatrixWeather.mTemperature[month / 3, 1]);
            }
        }
    }
    
    private static Month GenerateRandomMonth()
    {
        Random random = new Random();
        return (Month)random.Next(1, 12);
    }

    private static int GenerateRandomWeekDay()
    {
        Random random = new Random();
        return random.Next(1, 7);
    }
}