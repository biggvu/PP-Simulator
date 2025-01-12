using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps
{
    public class SmallTorusMap : SmallMap
    {
        //konstruktor, już zaimplementowany
        public SmallTorusMap(int size) : base(size, size) { }

        public override Point Next(Point p, Direction d)
        {
            var nextPoint = p.Next(d);
            int newX = (nextPoint.X + SizeX) % SizeX;
            int newY = (nextPoint.Y + SizeY) % SizeY;
            return new Point(newX, newY);
        }

        public override Point NextDiagonal(Point p, Direction d)
        {
            var nextPoint = p.NextDiagonal(d);
            int newX = (nextPoint.X + SizeX) % SizeX;
            int newY = (nextPoint.Y + SizeY) % SizeY;
            return new Point(newX, newY);
        }
    }
}
