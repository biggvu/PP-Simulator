using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps
{
    public abstract class SmallMap : Map
    {
        protected SmallMap(int sizeX, int sizeY) : base(sizeX, sizeY)
        {
            if (sizeX > 20 || sizeY > 20)
            {
                throw new ArgumentOutOfRangeException("Value of both dimensions must be at most 20");
            }
        }
    }
}
