using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulator.Maps;

namespace Simulator
{
    public class Animals : IMappable
    {
        private string _description = "Default"; //wartość domyślna "Default", aby uniknąć ostrzeżenia kompilatora
        private bool isDescriptionInitialized = false;

        public string Description
        {
            get { return _description; }

            set
            {
                if (Validator.isAlreadyInitialized(isDescriptionInitialized, nameof(Description)))
                {
                    //zamiana na pierwszą wielką literę
                    var formattedValue = Validator.Shortener(value, 3, 25, '#');
                    _description = char.ToUpper(formattedValue[0]) + formattedValue.Substring(1);
                    isDescriptionInitialized = true;
                }
            }
        }

        public uint Size { get; set; } = 3;

        //określenie sposobu poruszania się
        //public MovementType Movement { get; }

        //pozycja zwierzęcia na mapie
        public Point? Position { get; protected set; }

        //przypisanie mapy i pozycji
        public Map? Map { get; private set; }

        //konstruktor
        public Animals(string description, uint size = 1)
        {
            if (size == 0)
                throw new ArgumentOutOfRangeException(nameof(size), "Size must be greater than 0.");

            Description = description;
            Size = size;
        }

        //konstruktor dla innych zwierząt
        //public Animals(string description, uint size) : this(description, MovementType.Other, size)
        //{
       // }

        //właściwość Info zmieniona na klasę wirtualną
        public virtual string Info => $"{Description} <{Size}>";

        //symbol zwierzęcia do przypisania na mapie
        public virtual char Symbol => 'A';

        //przypisanie mapy i pozycji
        public void AssignMap(Map map, Point position)
        {
            if (map == null)
                throw new ArgumentNullException(nameof(map));
            if (!map.Exist(position))
                throw new ArgumentOutOfRangeException(nameof(position), "Position is outside the map.");

            if (Map is SmallMap oldSmallMap && Position != null)
            {
                oldSmallMap.Remove(this, Position.Value);
            }

            Map = map;
            Position = position;

            if (map is SmallMap smallMap)
            {
                smallMap.Add(this, position);
            }
        }

        //poruszanie się zwierzęcia na mapie
        public virtual void Move(Direction direction)
        {
            if (Map == null || Position == null)
                throw new InvalidOperationException("Animal is not assigned to a map.");

            var newPosition = Map.Next(Position.Value, direction);

            if (Map is SmallMap smallMap)
            {
                smallMap.Move(this, Position.Value, newPosition);
            }

            Position = newPosition;
        }

        //nadpisanie ToString()
        public override string ToString()
        {
            return $"{GetType().Name.ToUpper()}: {Info}";
        }
    }
}