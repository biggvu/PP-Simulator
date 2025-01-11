using Simulator.Maps;

namespace Simulator;
public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Starting Simulator!\n");

        Lab5b();

    }

    static void Lab5b()
    {
        try
        {
            var map = new Maps.SmallSquareMap(10);
            Console.WriteLine($"Map has been created, size = {map.Size}");
        }
        catch (ArgumentOutOfRangeException e)
        {
            Console.WriteLine($"Error: {e.Message}");
        }

        try
        {
            var invalidMap = new SmallSquareMap(21);
        }
        catch (ArgumentOutOfRangeException e)
        {
            Console.WriteLine($"Error: {e.Message}");
        }

        var map10x10 = new SmallSquareMap(10);
        var pointInside = new Point(5, 5);
        var pointOutside = new Point(10, 10); 
   
        Console.WriteLine($"Point {pointInside} exists on the map: {map10x10.Exist(pointInside)}");
        Console.WriteLine($"Point {pointOutside} exists on the map: {map10x10.Exist(pointOutside)}");

        var point = new Point(9, 9);
        var nextPoint = map10x10.Next(point, Direction.Right);
        Console.WriteLine($"Moving {point} Right: {nextPoint} (should be {point}, as it cannot go outside)");

        var pointIn = new Point(9, 9);
        var nextInPoint = map10x10.Next(pointIn, Direction.Left);
        Console.WriteLine($"Moving {pointIn} Left: {nextInPoint} (should be {new Point(8, 9)})");

        var edgePoint = new Point(9, 9);
        var nextEdgePoint = map10x10.NextDiagonal(edgePoint, Direction.Right);
        Console.WriteLine($"Moving {edgePoint} Right Diagonal: {nextEdgePoint} (should be {new Point(9, 9)})");
    }
}