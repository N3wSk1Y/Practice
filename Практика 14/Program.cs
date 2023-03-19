using System;

namespace practice14;

class Program
{
    public static void Main()
    {
        Point3D point1 = new Point3D(
            50,
            0,
            20
        );
        Point3D point2 = new Point3D();
        point2.MovePoint(Axis.X, 50);
        point2.MovePoint(Axis.Y, 15);

        double radiusVectorLength1 = point1.GetRadiusVectorLength();
        double radiusVectorLength2 = point2.GetRadiusVectorLength();
        
        Console.WriteLine($"Длина радиус-вектора 1й точки - {radiusVectorLength1}, 2й точки - {radiusVectorLength2}");
        point2.CombinePoints(point1).PrintCoordinates();
    }
}