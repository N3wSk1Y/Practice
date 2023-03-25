namespace practice14;

public enum Axis
{
    X = 0,
    Y = 1,
    Z = 2
}

public class Point3D
{
    private double x;
    private double y;
    private double z;

    public Point3D()
    {
        this.X = 0;
        this.Y = 0;
        this.Z = 0;
    }
    
    public Point3D(double x, double y, double z)
    {
        this.X = x;
        this.Y = y;
        this.Z = z;
    }
    
    public Point3D (decimal xy) {
        this.X = Convert.ToInt32(xy);
        xy = xy % 1;
        
        while (xy % 1 != 0)
            xy *= 10;
        
        this.Y = Convert.ToInt32(xy);
        this.Z = 0;
    }
    
    public double RadiusVector {
        get { return Math.Sqrt(this.X * this.X + this.Y * this.Y + this.Z * this.Z); }
    }

    public double X {
        get { return this.x; } 
        set 
        {
            if (value >= 0) 
                this.x = value;
        }
    }

    public double Y {
        get { return this.y; } 
        set 
        {
            if (value < 100 && value >= 0)
                this.y = value;
            else
                this.y = 100;
        }
    }

    public double Z {
        get { return this.z; } 
        set 
        {
            if (value <= this.x + this.y)
                this.z = value;
            else
                Console.WriteLine($"Число не соответствует условиям.");
        }
    }

    public bool CrossArea {
        get { return (y <= x) && (y >= 2) && (x <= 10); }
    }

    public void PrintCoordinates()
    {
        Console.WriteLine($"X: {this.X}, Y: {this.Y}, Z: {this.Z}");
    }

    public Point3D CombinePoints(Point3D point2)
    {
        return new Point3D(
            this.X + point2.X,
            this.Y + point2.Y,
            this.Z + point2.Z
        );
    }
    
    public Point3D CombinePoints(Point3D point2, double step)
    {
        return new Point3D(
            this.X + point2.X + step,
            this.Y + point2.Y + step,
            this.Z + point2.Z + step
        );
    }
    
    public void AddPoints (Point3D point) {
        point.X += this.X;
        point.Y += this.Y;
        point.Z += this.Z;
    }

    public void AddPoints (double step) {
        this.X += step;
        this.Y += step;
        this.Z += step;
    }

}