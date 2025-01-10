using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Simulator
{
    internal class Creature
    {
       
        private string _name = "Unknown"; //wartość domyślna "Unknown"
        private int _level = 1; //domyślna wartość początkowa "1"
        private bool isNameInitialized = false;
        private bool isLevelInitialized = false;

        public string Name
        {
            get {return _name;}

            set
            {
                //name można nadać tylko raz przy inicjacji, próba nadania kolejny raz zwraca wyjątek InvalidOperationException
                if (isNameInitialized == true)
                {
                    Console.WriteLine($"Name can only be set once. Current name: {_name}");
                    return;
                }

                //usuwanie nadmiarowych spacji na początku i na końcu
                string trimmedName = value.Trim();

                //minimalnie 3 znaki, brakujące są uzpełniane znakiem '#'
                if (trimmedName.Length < 3)
                {
                    trimmedName = trimmedName.PadRight(3, '#');
                }
                //maksymalnie 25 znaków, przycięcie tych za długich
                if (trimmedName.Length > 25)
                {
                    trimmedName = trimmedName.Substring(0, 25).Trim();
                }
                //sprawdzenie czy wciąż name ma przynajmniej 3 znaki
                if (trimmedName.Length < 3)
                {
                    trimmedName = trimmedName.PadRight(3, '#');
                }
                //ustawianie pierwszej litery na wielką
                if (char.IsLower(trimmedName[0]))
                {
                    trimmedName = char.ToUpper(trimmedName[0]) + trimmedName.Substring(1);
                }

                _name = trimmedName;
                isNameInitialized = true;

            }
        }
        public int Level
        {
            get {return _level;}

            set
            {
                //level można nadać tylko raz przy inicjacji, próba nadania kolejny raz zwraca wyjątek InvalidOperationException
                if (isLevelInitialized == true)
                {
                    Console.WriteLine($"Level can only be set once. Current level: {_level}");
                    return;
                }

                //ustawienie wartości z przedziału 1-10
                if (value < 1)
                {
                    value = 1;
                }
                if (value > 10)
                {
                    value = 10;
                }
                _level = value;
                isLevelInitialized = true;
            }
        }

        // konstruktor przyjmujący wartości początkowe dla Name i opcjonalnie dla Level (wartość domyślna 1), konstruktor ma inicjować pola poprzez ich settery
        public Creature (string name, int level = 1)
        {
            Name = name;
            Level = level;
        }

        //konstruktor bezparametrowy nic nie robiący
        public Creature()
        {

        }

        //właściwość do odczytu Info
        public string Info
        {
            get
            {
                return $"{Name} [{Level}]";
            }
        }

        //metoda SayHi()
        public void SayHi()
        {
            Console.WriteLine($"Hi, I'm {Name}, my level is {Level}.");
        }

        //metoda Upgrade(), która pozwoli na awansowanie stwora o jeden poziom, ale nie powyżej 10-go.
        public void Upgrade()
        {
            if (_level < 10)
            {
                _level++;
            }
        }
    }
}
