using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Simulator
{
    public abstract class Creature
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

        //konstruktor bezparametrowy nic nie robiący
        public Creature()
        {

        }

        //właściwość do odczytu Info, zmieniona na abstrakcyjną
        public abstract string Info { get; }


        //metoda SayHi()
        public abstract void SayHi();

        //metoda Upgrade(), która pozwoli na awansowanie stwora o jeden poziom, ale nie powyżej 10-go.
        public void Upgrade()
        {
            if (_level < 10)
            {
                _level++;
            }
        }

        //metoda Go() przyjmuje parametr typu Direction i wypisuje w linii informację o ruchu
        public void Go(Direction direction)
        {
            string directionName = direction.ToString().ToLower();
            Console.WriteLine($"{Name} goes {directionName}.");
        }

        //kolejna metoda Go() przyjmującą tablicę kierunków i wykonującą kolejno kilka ruchów przez wywołanie pierwszej metody Go()
        public void Go(Direction[] directions)
        {
            foreach (var direction in directions)
            {
                Go(direction);
            }
        }

        //kolejna metodę Go() przyjmującą jako argument string powodującą odpowiednie ruchy stwora
        public void Go(string directions)
        {
            Direction[] parsedDirections = DirectionParser.Parse(directions);
            Go(parsedDirections);
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
