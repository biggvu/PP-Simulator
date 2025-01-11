using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
    public class Orc : Creature
    {

        private int _rage = 1;
        private int _huntCounter = 0; //licznik wywołań metody Hunt()

        public int Rage
        {
            get { return _rage; }

            init
            {
                //ustalenie wartości w zakresie 0-10
                if (value < 0)
                {
                    _rage = 0;
                }
                else if (value > 10)
                {
                    _rage = 10;
                }
                else
                {
                    _rage = value;
                }
            }
        }

        //metoda pomocnicza do zmiany szału
        private void ModifyRage(int delta)
        {
            _rage = Math.Clamp(_rage + delta, 0, 10);
        }

        //właściwość Power
        public override int Power => 7*Level + 3*Rage;

        //konstruktor bezparametrowy
        public Orc() : base()
        {

        }

        //konstruktor z parametrami opcjonalnymi
        public Orc(string name, int level = 1, int rage = 1) : base(name, level)
        {
            Rage = rage;
        }

        //implementacja metody abstrakcyjnejj SayHi()
        public override void SayHi()
        {
            Console.WriteLine($"Hi, I'm {Name}, my level is {Level}, my rage is {Rage}.");
        }

        public void Hunt()
        {
            //co drugie polowanie zwiększa szał
            _huntCounter++;
            Console.WriteLine($"{Name} is hunting.");

            if (_huntCounter % 2 == 0)
            {
                //Rage++;
                ModifyRage(1);
                Console.WriteLine($"{Name} rage increased to {Rage}");
            }
        }
    }
}
