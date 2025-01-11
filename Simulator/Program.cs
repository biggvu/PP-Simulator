namespace Simulator;
public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Starting Simulator!\n");

        Lab5a();

    }

    static void Lab5a()
    {
        try
        {
            var rect1 = new Rectangle(10, 5, 2, 15);
            Console.WriteLine(rect1);

        }

        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }
        try
        {
            var point1 = new Point(3, 3);
            var point2 = new Point(8, 7);
            var rect2 = new Rectangle(point1, point2);
            Console.WriteLine(rect2);
        }

        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }

        try
        {
            var rect3 = new Rectangle(3, 3, 3, 10);
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }

        var rect4 = new Rectangle(2, 3, 10, 15);
        Console.WriteLine(rect4);

        var pointInside = new Point(5, 10);
        var pointOutside = new Point(1, 2);

        Console.WriteLine($"Contains {pointInside}: {rect4.Contains(pointInside)}");
        Console.WriteLine($"Contains {pointOutside}: {rect4.Contains(pointOutside)}");
    }
}