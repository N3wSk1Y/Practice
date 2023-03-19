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

    public void MovePoint(Axis axis, double value)
    {
        switch (axis)
        {
            case Axis.X:
                this.x += value;
                break;
            case Axis.Y:
                this.y += value;
                break;
            case Axis.Z:
                this.z += value;
                break;
        }
    }

    public void PrintCoordinates()
    {
        Console.WriteLine($"X: {this.x}, Y: {this.y}, Z: {this.z}");
    }

    public double GetRadiusVectorLength()
    {
        return Math.Sqrt(x * x + y * y + z * z);
    }

    public Point3D CombinePoints(Point3D point2)
    {
        return new Point3D(
            this.x + point2.x,
            this.y + point2.y,
            this.z + point2.z
        );
    }
}