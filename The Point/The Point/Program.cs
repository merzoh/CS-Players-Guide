Console.Title = "The Point";

Point point1 = new Point();
point1.X = 2;
point1.Y = 3;

Point point2 = new Point();
point2.X = -4;
point2.Y = 0;

Console.WriteLine($"({point1.X}, {point1.Y})");
Console.WriteLine($"({point2.X}, {point2.Y})");

//Classes
public class Point
{
    public int X { get; set; }
    public int Y { get; set; }
    public Point()
    {
        X = 0;
        Y = 0;

    }
}