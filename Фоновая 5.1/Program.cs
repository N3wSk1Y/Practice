namespace phone51;

public class Program
{
    public static void Main()
    {
        ConsoleKeyInfo button;
        Pyramid pyramid;
        do
        {
            Console.WriteLine("R - Пирамида по-умолчанию, E - Ввести данные вручную");
            button = Console.ReadKey(true);
            if (button.Key == ConsoleKey.E)
            {
                Console.Write("Введите основание трапеции: ");
                double basement = Convert.ToDouble(Console.ReadLine());
        
                Console.Write("Введите высоту трапеции: ");
                double height = Convert.ToDouble(Console.ReadLine());

                pyramid = new Pyramid(basement, height);
                break;
            }
            if (button.Key == ConsoleKey.R)
            {
                pyramid = new Pyramid();
                break;
            }
        } while (true);

        double perimeter = pyramid.Perimeter;
        double volume = pyramid.Volume;
        Console.WriteLine($"Периметр: {perimeter}, объем: {volume}");
    }
}