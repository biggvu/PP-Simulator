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
        private bool isRageInitialized = false;
        private int _huntCounter = 0; //licznik wywołań metody Hunt()

        public int Rage
        {
            get { return _rage; }

            init
            {
                if (Validator.isAlreadyInitialized(isRageInitialized, nameof(Rage)))
                {
                    _rage = Validator.Limiter(value, 0, 10);
                    isRageInitialized = true;
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

        //implementacja właściwości Info
        public override string Info => $"{Name} [{Level}][{Rage}]";

        public override char Symbol => 'O';

        //konstruktor bezparametrowy
        public Orc() : base()
        {

        }

        //konstruktor z parametrami opcjonalnymi
        public Orc(string name, int level = 1, int rage = 1) : base(name, level)
        {
            Rage = rage;
        }

        //implementacja metody abstrakcyjnej SayHi(), zmieniona później na Greeting()
        public override string Greeting()
        {
            return $"Hi, I'm {Name}, my level is {Level}, my rage is {Rage}.";
        }

        public void Hunt()
        {
            //co drugie polowanie zwiększa szał
            _huntCounter++;

            if (_huntCounter % 2 == 0)
            {
                ModifyRage(1);
            }
        }
    }
}
