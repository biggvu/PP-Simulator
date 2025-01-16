using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Simulator.Maps;

namespace Simulator
{
    public abstract class Creature : IMappable
    {

        private string _name = "Unknown"; //wartość domyślna "Unknown"
        private int _level = 1; //domyślna wartość początkowa "1"
        private bool isNameInitialized = false;
        private bool isLevelInitialized = false;

        public string Name
        {
            get { return _name; }

            //setter z użyciem validatora
            set 
            {
                if (Validator.isAlreadyInitialized(isNameInitialized, nameof(Name)))
                {
                    //zamiana na pierwszą wielką literę
                    var formattedValue = Validator.Shortener(value, 3, 25, '#');
                    _name = char.ToUpper(formattedValue[0]) + formattedValue.Substring(1);
                    isNameInitialized = true;
                }
            }

        }


        public int Level
        {
            get { return _level; }

            //setter z użyciem validatora
            set
            {
                if (Validator.isAlreadyInitialized(isLevelInitialized, nameof(Level)))
                {
                    _level = Validator.Limiter(value, 1, 10);
                    isLevelInitialized = true;
                }
            }
        }
        // konstruktor przyjmujący wartości początkowe dla Name i opcjonalnie dla Level (wartość domyślna 1), konstruktor ma inicjować pola poprzez ich settery
        public Creature(string name, int level = 1)
        {
            Name = name;
            Level = level;
        }

        //pole Position, które przechowuje pozycję stwora na planszy
        public Point? Position { get; private set; }
        //pole Map, które przechowuje referencję do obiektu klasy Map
        public Map? Map { get; private set; }

        //konstruktor bezparametrowy nic nie robiący
        public Creature() { }

        //właściwość do odczytu Info, zmieniona na abstrakcyjną
        public abstract string Info { get; }


        //metoda SayHi() zmieniona na Greeting()
        public abstract string Greeting();

        //metoda Upgrade(), która pozwoli na awansowanie stwora o jeden poziom, ale nie powyżej 10-go.
        public void Upgrade()
        {
            if (_level < 10)
            {
                _level++;
            }
        }

        //metod do przypisania stworowi mapy i pozycji na niej
        public void AssignMap(Map map, Point position)
        {
            if (map == null)
                throw new ArgumentNullException(nameof(map));
            if (!map.Exist(position))
                throw new ArgumentOutOfRangeException(nameof(position), "Position is outside the map.");

            //usuwa stwora z poprzedniej mapy, jeśli na takowej istnieje
            if (Map is SmallMap oldSmallMap && Position != null)
            {
                oldSmallMap.Remove(this, Position.Value);
            }

            Map = map;
            Position = position;

            if (Map is SmallMap smallMap)
            {
                smallMap.Add(this, position);
            }
        }


        //metoda Go() przyjmuje parametr typu Direction i wypisuje w linii informację o ruchu, zmieniona na string Go()
        public string Go(Direction direction)
        {
            if (Position == null || Map == null)
            {
                return $"{Name} is not assigned to the map.";
            }
            Point newPosition = Map.Next(Position.Value, direction);

            if (Map is SmallMap smallMap && Position != null)
            {
                smallMap.Move(this, Position.Value, newPosition);
            }

            Position = newPosition;

            return $"{Name} moved to {Position}.";
        }

        //abstrakcyjna klasa Power()
        public abstract int Power { get; }

        //nadpisanie metody ToString()
        public override string ToString()
        {
            return $"{GetType().Name.ToUpper()}: {Info}";
        }
    }
}
