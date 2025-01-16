using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps
{
    public abstract class SmallMap : Map
    {
        //słownik zawierający stwory na mapie, kluczem jest punkt
        private readonly Dictionary<Point, List<IMappable>> _mappables = new();

        protected SmallMap(int sizeX, int sizeY) : base(sizeX, sizeY)
        {
            if (sizeX > 20 || sizeY > 20)
            {
                throw new ArgumentOutOfRangeException("Size cannot exceed 20x20.");
            }
        }

        //dodaje stwora na mapie w podanym punkcie, zmienione na imappable
        public void Add(IMappable mappable, Point position)
        {
            if (!Exist(position))
            {
                throw new ArgumentOutOfRangeException(nameof(position), "Position is outside the map.");
            }

            if (!_mappables.ContainsKey(position))
            {
                _mappables[position] = new List<IMappable>();
            }

            _mappables[position].Add(mappable);
        }

        //usuwa stwora z mapy z podanego punktu
        public void Remove(IMappable mappable, Point position)
        {
            if (_mappables.ContainsKey(position))
            {
                _mappables[position].Remove(mappable);

                if (_mappables[position].Count == 0)
                {
                    _mappables.Remove(position);
                }
            }
        }


        //przenosi stwora z jednego punktu na drugi
        public void Move(IMappable mappable, Point from, Point to)
        {
            if (!Exist(to))
            {
                throw new ArgumentOutOfRangeException(nameof(to), "Target position is outside the map.");
            }

            Remove(mappable, from);
            Add(mappable, to);
        }

        //zwraca listę stworów znajdujących się na podanym punkcie
        public IEnumerable<IMappable> At(Point position)
        {
            return _mappables.ContainsKey(position) ? _mappables[position] : Enumerable.Empty<IMappable>();
        }

        //zwraca listę stworów znajdujących się na podanym punkcie
        public IEnumerable<IMappable> At(int x, int y)
        {
            return At(new Point(x, y));
        }

    }
}
