namespace phone51;

public class Pyramid
{
    private double basement;
    private double height;

    public double Perimeter
    {
        get { return this.basement * 4; }
    }

    public double Volume
    {
        get { return (this.basement * this.basement * this.height) / 3; }
    }

    public Pyramid(double basement, double height)
    {
        this.basement = basement;
        this.height = height;
    }

    public Pyramid()
    {
        this.basement = 5;
        this.height = 7;
    }

    public void PrintProperties()
    {
        Console.WriteLine($"Высота: {this.height}, основание: {this.basement}");
    }
}