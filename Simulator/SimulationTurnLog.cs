using System.Collections.Generic;
using Simulator;
using Simulator.Maps;

namespace Simulator
{
    public class SimulationTurnLog
    {
        public string Mappable { get; }
        public string Move { get; }
        public Dictionary<Point, char> Symbols { get; }
        public IMappable? ActiveMappable { get; }
        public bool IsInitial { get; }

        public SimulationTurnLog(string mappable, string move, Dictionary<Point, char> symbols, IMappable? activeMappable, Point? previousPosition, Point? currentPosition, bool isInitial = false)
        {
            Mappable = mappable;
            Move = move;
            Symbols = symbols;
            ActiveMappable = activeMappable;
            IsInitial = isInitial;
        }

        /// <summary>
        /// Generate detailed information about the move and position of the object.
        /// </summary>
        public string InfoText
        {
            get
            {
                if (IsInitial)
                    return "Pozycje startowe";

                if (ActiveMappable == null)
                    return "Brak ruchu w tej turze.";

                var currentPos = ActiveMappable.Position;
                return $"{Mappable} ⇒ {Move}";
            }
        }
    }
}
