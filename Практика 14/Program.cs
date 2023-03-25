using System;

namespace practice14;

class Program
{
    public static void Main()
    {
        Console.WriteLine("Создать точку со значениями по умолчанию - R\nУказать значения вручную - E\nУказать decimal в качестве x, y - T");
        ConsoleKeyInfo button;
        Point3D point;
        do
        {
            button = Console.ReadKey(true);
            if (button.Key == ConsoleKey.E)
            {
                double x, y, z;
                Console.WriteLine("Введите координату X для точки");
                x = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Введите координату Y для точки");
                y = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Введите координату Z для точки");
                z = Convert.ToDouble(Console.ReadLine());
                point = new Point3D(x, y, z);
                break;
            }
            if (button.Key == ConsoleKey.R)
            {
                point = new Point3D();
                break;
            }
            if (button.Key == ConsoleKey.T)
            {
                Console.WriteLine("Введите число с фиксированной точкой: ");
                point = new Point3D(Convert.ToDecimal(Console.ReadLine()));
                break;
            }
        } while (true);
        Point3D point1 = new Point3D(
            50,
            0,
            20
        );
        // point.X += 50;
        // point.Y += 15;

        double radiusVectorLength1 = point1.RadiusVector;
        double radiusVectorLength2 = point.RadiusVector;
        
        // point.AddPoints(5);
        Console.WriteLine($"Длина радиус-вектора 1й точки - {radiusVectorLength1}, 2й точки - {radiusVectorLength2}");
        point.PrintCoordinates();
    }
}