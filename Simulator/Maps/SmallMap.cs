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
        private readonly Dictionary<Point, List<Creature>> _creatures = new();

        protected SmallMap(int sizeX, int sizeY) : base(sizeX, sizeY)
        {
            if (sizeX > 20 || sizeY > 20)
            {
                throw new ArgumentOutOfRangeException("Size cannot exceed 20x20.");
            }
        }

        //dodaje stwora na mapie w podanym punkcie
        public void Add(Creature creature, Point position)
        {
            if (!Exist(position))
            {
                throw new ArgumentOutOfRangeException("Position is out of map");
            }
            if (!_creatures.ContainsKey(position))
            {
                _creatures[position] = new List<Creature>();
            }
            _creatures[position].Add(creature);
        }

        //usuwa stwora z mapy z podanego punktu
        public void Remove(Creature creature, Point point)
        {
            if (_creatures.ContainsKey(point))
            {
                _creatures[point].Remove(creature);
            }
            if (_creatures[point].Count == 0)
            {
                _creatures.Remove(point);
            }
        }

        //przenosi stwora z jednego punktu na drugi
        public void Move(Creature creature, Point from, Point to)
        {
            Remove(creature, from);
            Add(creature, to);
        }

        //zwraca listę stworów znajdujących się na podanym punkcie
        public IEnumerable<Creature> At(Point point)
        {
            return _creatures.ContainsKey(point) ? _creatures[point] : new List<Creature>();
        }

        //zwraca listę stworów znajdujących się na podanym punkcie
        public IEnumerable<Creature> At(int x, int y)
        {
            return At(new Point(x, y));
        }

    }
}
