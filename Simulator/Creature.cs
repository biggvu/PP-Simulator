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
        public string Name { get; set; }
        public int Level { get; set; }

        public string Info
        {
            get 
            {
                return $"{Name} [{Level}]";
            }
        }

        public Creature (string name, int level = 1)
        {
            Name = name;
            Level = level;
        }

        public Creature()
        {

        }

        public void sayHi()
        {
            Console.WriteLine($"Hi, I'm {Name}, my level is {Level}.");
        }
    }
}
