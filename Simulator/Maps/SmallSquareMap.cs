using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps
{
    public class SmallSquareMap : SmallMap
    {
        public SmallSquareMap(int size) : base(size, size) { }

        //zwraca nowy punkt przesunięty o jedno pole w podanym kierunku
        public override Point Next(Point p, Direction d)
        {
            var nextPoint = p.Next(d);
            int newX = (nextPoint.X + SizeX) % SizeX;
            int newY = (nextPoint.Y + SizeY) % SizeY;
            return new Point(newX, newY);
        }

        //zwraca nowy punkt przesunięty o jedno pole po skosie w kierunku odchylonym o 45°, zgodnie z ruchem wskazówek zegara, w stosunku do podanego kierunku
        public override Point NextDiagonal(Point p, Direction d)
        {
            var nextPoint = p.NextDiagonal(d);
            int newX = (nextPoint.X + SizeX) % SizeX;
            int newY = (nextPoint.Y + SizeY) % SizeY;
            return new Point(newX, newY);
        }
    }
}
