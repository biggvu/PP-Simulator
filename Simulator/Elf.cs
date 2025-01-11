using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
    public class Elf : Creature
    {

        private int _agility = 1;
        private bool isAgilityInitialized = false;
        private int _singCounter = 0; //licznik wywołań metody Sing()
        public int Agility
        {
            get { return _agility; }

            init
            {
                if (Validator.isAlreadyInitialized(isAgilityInitialized, nameof(Agility)))
                {
                    _agility = Validator.Limiter(value, 0, 10);
                    isAgilityInitialized = true;
                }
            }
        }

        //metoda pomocnicza do zmiany zwinności
        private void ModifyAgility(int delta)
        {
            _agility = Math.Clamp(_agility + delta, 0, 10);
        }

        //właściwość Power
        public override int Power => 8*Level + 2*Agility;

        //implementacja właściwości Info
        public override string Info => $"{Name} [{Level}][{Agility}]";

        //konstruktor bezparametrowy
        public Elf() : base()
        {

        }

        //konstruktor z parametrami opcjonalnymi
        public Elf(string name, int level = 1, int agility = 1) : base(name, level)
        {
            Agility = agility;
        }


        //implementacja metody abstrakcyjnejj SayHi()
        public override void SayHi()
        {
            Console.WriteLine($"Hi, I'm {Name}, my level is {Level}, my agility is {Agility}.");
        }

        public void Sing()
        {
            //co trzeci śpiew zwiększa zwinność
            _singCounter++;
            Console.WriteLine($"{Name} is singing.");

            if (_singCounter % 3 == 0)
            {
                //Agility++;
                ModifyAgility(1);
                Console.WriteLine($"{Name} agility increased to {Agility}");
            }

        }
    }
}
