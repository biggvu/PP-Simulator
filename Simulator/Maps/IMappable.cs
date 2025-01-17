using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator.Maps
{
    public interface IMappable
    {
        Point? Position { get; }
        void AssignMap(Map map, Point position);
        char Symbol { get; }
        void Move(Direction direction);
    }
}
