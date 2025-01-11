using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
    public class Rectangle
    {
        //pola tylko do odczytu int: X1 i Y1 oznaczające współrzędne lewego dolnego narożnika oraz X2 i Y2 dla prawego górnego narożnika
        public readonly int X1, Y1, X2, Y2;

        public Rectangle(int x1, int y1, int x2, int y2)
        {

            //jeśli punkty są współliniowe należy rzucić wyjątek typu ArgumentException z odpowiednim komunikatem (nie chcemy chudych prostokątów)
            if (x1 == x2 || y1 == y2)
            {
                throw new ArgumentException("Invalid rectangle");
            }

            //jeśli współrzędne są w złej kolejności mają zostać zamienione
            X1 = Math.Min(x1, x2);
            Y1 = Math.Min(y1, y2);  
            X2 = Math.Max(x1, x2);  
            Y2 = Math.Max(y1, y2); 

        }

        //konstruktor Rectangle(Point p1, Point p2), który ma odpowiednio wywołać poprzednio zdefiniowany konstruktor,
        public Rectangle(Point p1, Point p2) : this(p1.X, p1.Y, p2.X, p2.Y) { }

        //metoda bool Contains(Point point) sprawdzającą czy prostokąt zawiera podany punkt
        public bool Contains(Point p)
        {
            return p.X >= X1 && p.X <= X2 && p.Y >= Y1 && p.Y <= Y2;
        }

        //nadpisana metoda ToString() zwracającą (X1, Y1):(X2, Y2).
        public override string ToString()
        {
            return $"({X1}, {Y1}):({X2}, {Y2})";
        }
    }
}
