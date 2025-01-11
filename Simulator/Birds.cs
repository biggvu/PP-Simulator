using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
    public class Birds : Animals
    {
        //własność logiczna CanFly()
        public bool CanFly { get; set; } = true;

        //nadpisanie metidy Info
        public override string Info
        {
            get
            {
                string flyStatus = CanFly ? "fly+" : "fly-";
                return $"{Description} ({flyStatus}) <{Size}>";
            }
        }

        //konstruktor bezparametrowy
        public Birds() : base()
        {

        }

        //konstruktor z parametrami opcjonalnymi
        public Birds(string description, uint size = 3, bool canFly = true) : base()
        {
            Description = description;
            Size = size;
            CanFly = canFly;
        }
    }
}
