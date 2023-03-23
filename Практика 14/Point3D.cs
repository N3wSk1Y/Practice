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

    public double RadiusVector {
        get { return this.x * this.x + this.y * this.y + this.z * this.z; }
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

    
    public Point3D()
    {
        this.x = 0;
        this.y = 0;
        this.z = 0;
    }
    
    public Point3D(double x, double y, double z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }
    
    public Point3D (decimal xy) {
        this.x = Convert.ToInt32(xy);
        xy = xy % 1;
        
        while (xy % 1 != 0)
            xy *= 10;
        
        this.y = Convert.ToInt32(xy);
        this.z = 0;
    }


    public void PrintCoordinates()
    {
        Console.WriteLine($"X: {this.x}, Y: {this.y}, Z: {this.z}");
    }

    public Point3D CombinePoints(Point3D point2)
    {
        return new Point3D(
            this.x + point2.x,
            this.y + point2.y,
            this.z + point2.z
        );
    }
    
    public void AddToPoint (Point3D point) {
        point.X += this.X;
        point.Y += this.Y;
        point.Z += this.Z;
    }

    public void AddToPoint (int step) {
        this.X += step;
        this.Y += step;
        this.Z += step;
    }

}