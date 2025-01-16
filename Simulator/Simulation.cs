using System;
using System.Collections.Generic;
using System.Linq;
using Simulator.Maps;
using Simulator;

namespace Simulator
{
    public class Simulation
    {
        /// <summary>
        /// Simulation's map.
        /// </summary>
        public Map Map { get; }

        /// <summary>
        /// Creatures moving on the map.
        /// </summary>
        public List<IMappable> Mappables { get; }

        /// <summary>
        /// Starting positions of creatures.
        /// </summary>
        public List<Point> Positions { get; }

        /// <summary>
        /// Cyclic list of creatures moves. 
        /// Bad moves are ignored - use DirectionParser.
        /// First move is for first creature, second for second and so on.
        /// When all creatures make moves, 
        /// next move is again for first creature and so on.
        /// </summary>
        public string Moves { get; }

        /// <summary>
        /// Has all moves been done?
        /// </summary>
        public bool Finished { get; private set; } = false;

        private int _currentTurn = 0;
        private readonly List<Direction> _parsedMoves;

        /// <summary>
        /// Creature which will be moving current turn.
        /// </summary>
        public IMappable CurrentMappable => Mappables[_currentTurn % Mappables.Count];

        /// <summary>
        /// Lowercase name of direction which will be used in current turn.
        /// </summary>
        public string CurrentMoveName => _parsedMoves[_currentTurn % _parsedMoves.Count].ToString().ToLower();

        /// <summary>
        /// Simulation constructor.
        /// Throw errors:
        /// if creatures' list is empty,
        /// if number of creatures differs from 
        /// number of starting positions.
        /// </summary>
        //konstruktor sprawdza poprawność creatures, positions, moves; parsuje ruchy z moves na listę kierunków używając DirectorParser; przypisuję każdego stwora do mapy na ich pozycje startowe
        public Simulation(Map map, List<IMappable> mappables, List<Point> positions, string moves)
        {
            if (mappables == null || mappables.Count == 0 )
            {
                throw new ArgumentException("List of creatures cannot be empty");
            }
            if (positions == null || mappables.Count != positions.Count)
            {
                throw new ArgumentException("Number of creatures must be equal to number of starting positions");
            }

            Map = map ?? throw new ArgumentNullException(nameof(map));
            Mappables = mappables;
            Positions = positions;
            Moves = moves ?? throw new ArgumentNullException(nameof(moves));

            _parsedMoves = DirectionParser.Parse(moves).ToList();

            if (_parsedMoves.Count == 0)
            {
                throw new ArgumentException("Moves string does not contain valid directions");
            }

            for (int i = 0; i < mappables.Count; i++)
            {
                if (mappables[i] is Creature creature)
                {
                    creature.AssignMap(map, positions[i]);
                }
                else
                {
                    throw new InvalidOperationException("Only creatures are currently supported for simulation.");
                }
            }
        }

        /// <summary>
        /// Makes one move of current creature in current direction.
        /// Throw error if simulation is finished.
        /// </summary>
        /// 
        //turn aktualizuje pozycję bieżącego stwora w kierunku zdefiniowanym w moves, zwiększa licznmik tur _currentTurn, oznacza symulację jako zakończoną, gdy wszystkie ruchy w moves zostały wykonane
        public void Turn()
        {
            if (Finished)
            {
                throw new InvalidOperationException("Simulation is finished");
            }
            var direction = _parsedMoves[_currentTurn % _parsedMoves.Count];

            if (CurrentMappable is Creature creature && creature.Position != null)
            {
                creature.Go(direction);
            }

            _currentTurn++;

            if (_currentTurn >= _parsedMoves.Count)
            {
                Finished = true;
            }
        }
    }
}
