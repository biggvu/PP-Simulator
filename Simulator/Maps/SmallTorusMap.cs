using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps
{
    public class SmallTorusMap : Map
    {
        //właściwość do odczytu Size, przechowująca rozmiar torusa
        public int Size { get; }

        //konstruktor, już zaimplementowany
        public SmallTorusMap(int size)
        {
            if (size < 5 || size > 20)
            {
                throw new ArgumentOutOfRangeException("Size must be between 5 and 20");
            }
            Size = size;
        }

        public override bool Exist(Point p)
        {
            return p.X >= 0 && p.X < Size && p.Y >= 0 && p.Y < Size;
        }

        public override Point Next(Point p, Direction d)
        {
            var nextPoint = p.Next(d);
            int newX = (nextPoint.X + Size) % Size;
            int newY = (nextPoint.Y + Size) % Size;
            return new Point(newX, newY);
        }

        public override Point NextDiagonal(Point p, Direction d)
        {
            var nextPoint = p.NextDiagonal(d);
            int newX = (nextPoint.X + Size) % Size;
            int newY = (nextPoint.Y + Size) % Size;
            return new Point(newX, newY);
        }
    }
}
