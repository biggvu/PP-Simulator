using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps
{
    public class SmallSquareMap : Map
    {
        public int Size { get; }

        public SmallSquareMap(int size)
        {

            //sprawdzenie czy rozmiar mapy jest z przedziału 5-20
            if (size < 5 || size > 20)
            {
                //dla nieakceptowanych rozmiarów dostajemy poniższy wyjątek
                throw new ArgumentOutOfRangeException("Size must be between 5 and 20");
            }
            Size = size;
        }

        //sprawdzenie czy punkt istnieje na mapie
        public override bool Exist(Point p)
        {
            return p.X >= 0 && p.X < Size && p.Y >= 0 && p.Y < Size;
        }

        //zwraca nowy punkt przesunięty o jedno pole w podanym kierunku
        public override Point Next(Point p, Direction d)
        {
            var nextPoint = p.Next(d);
            int newX = (nextPoint.X + Size) % Size;
            int newY = (nextPoint.Y + Size) % Size;
            return new Point(newX, newY);
        }

        //zwraca nowy punkt przesunięty o jedno pole po skosie w kierunku odchylonym o 45°, zgodnie z ruchem wskazówek zegara, w stosunku do podanego kierunku
        public override Point NextDiagonal(Point p, Direction d)
        {
            var nextPoint = p.NextDiagonal(d);
            int newX = (nextPoint.X + Size) % Size;
            int newY = (nextPoint.Y + Size) % Size;
            return new Point(newX, newY);
        }
    }
}
