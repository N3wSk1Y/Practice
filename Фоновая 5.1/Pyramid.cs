namespace phone51;

public class Pyramid
{
    private double basement;
    private double height;

    public double Height
    {
        get { return this.height; }
        set {
            if (value > 0)
            {
                this.height = value;
            }
            else
            {
                throw new Exception("Высота пирамиды должно быть больше 0.");
            }
        }
    }
    
    public double Basement
    {
        get { return this.basement; }
        set {
            if (value > 0)
            {
                this.basement = value;
            }
            else
            {
                throw new Exception("Основание пирамиды должно быть больше 0.");
            }
        }
    }
    
    public double Perimeter
    {
        get { return this.basement * 4; }
    }

    public double Volume
    {
        get { return (this.basement * this.basement * this.height) / 3; }
    }

    public bool GoldenRatio
    {
        get
        {
            return Math.Round(this.height) / Math.Round(this.basement) == 1.6 || Math.Round(this.basement) / Math.Round(this.height) == 1.6;
        }
    }

    private Pyramid(double basement, double height)
    {
        this.basement = basement;
        this.height = height;
    }

    public static Pyramid Create()
    {
        return new Pyramid(5, 7);
    }

    public static Pyramid Create(double basement, double height)
    {
        if (basement > 0 && height > 0)
        {
            return new Pyramid(basement, height);
        }
        else
        {
            throw new Exception("Некорректные параметры высоты и основания пирамиды.");
        }
    }

    public void PrintProperties()
    {
        Console.WriteLine($"Высота: {this.height}, основание: {this.basement}");
    }
}