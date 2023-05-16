using System;

namespace practice1;

public static class Program
{
    public static void Main(string[] args)
    {
        string name;
        double f;
        double r = 64.100;
        float p1 = 0.78932597F;
        float pr = 100000000000f;
        double f1 = 3.20000;
        decimal dec = 18500.5m;
        int s1 = 4;
        int p = 16;
        string s = "AMD";

        Console.WriteLine("Введите ваше имя");
        name = Console.ReadLine();
        Console.WriteLine("Введите дробное число");
        f = double.Parse(Console.ReadLine(), System.Globalization.CultureInfo.InvariantCulture);

        Console.WriteLine($"\nПривет, {name}");
        Console.WriteLine("*********************************");
        Console.WriteLine("*\tЯ твой компьютер!\t*");
        Console.WriteLine("*********************************");
        Console.WriteLine("У меня следующие характеристики:\n");
        Console.WriteLine($"Процессор\t\t{s} с разрядностью {f1:F2}GHz");
        Console.WriteLine($"Моя память\t\t{p}Gb (доступно {p1:P0})");
        Console.WriteLine($"Жесткий диск\t\t{s1}Tb");
        Console.WriteLine($"Тип системы\t\t{r:F0}-разрядная OC\n");
        Console.WriteLine($"Моя производительность\t{pr:E0} оп/сек");
        Console.WriteLine($"Индекс произв-ти\t{f:F0}");
        Console.WriteLine($"Моя стоимость\t\t{dec:F2} р");
        Console.ReadKey();
    }
}
