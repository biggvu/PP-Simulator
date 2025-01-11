using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
    public readonly struct Point
    {
        public readonly int X, Y;
        public Point(int x, int y) => (X, Y) = (x, y);
        public override string ToString() => $"({X}, {Y})";

        //Next() zwraca nowy punkt przesunięty o jedno pole w podanym kierunku
        public Point Next(Direction direction)
        {
            return direction switch
            {
                Direction.Up => new Point(X, Y + 1),
                Direction.Right => new Point(X + 1, Y),
                Direction.Down => new Point(X, Y - 1),
                Direction.Left => new Point(X - 1, Y),
                _ => this
            };
        }

        //zwraca nowy punkt przesunięty o jedno pole po skosie w kierunku odchylonym o 45°, zgodnie z ruchem wskazówek zegara, w stosunku do podanego kierunku
        public Point NextDiagonal(Direction direction)
        {
            return direction switch
            {
                Direction.Up => new Point(X + 1, Y + 1), //prawy górny
                Direction.Right => new Point(X + 1, Y - 1), //prawy dolny  
                Direction.Down => new Point(X - 1, Y - 1), //lewy dolny
                Direction.Left => new Point(X - 1, Y + 1), //lewy górny
                _ => this
            };
        }
    }
}
