using System;
using System.Collections.Generic;
using Simulator;
using Simulator.Maps;

namespace Simulator
{
    public class SimulationHistory
    {
        private Simulation _simulation { get; }
        public int SizeX { get; }
        public int SizeY { get; }
        public List<SimulationTurnLog> TurnLogs { get; } = new();

        public SimulationHistory(Simulation simulation)
        {
            _simulation = simulation ?? throw new ArgumentNullException(nameof(simulation));
            SizeX = _simulation.Map.SizeX;
            SizeY = _simulation.Map.SizeY;

            Run();
        }

        private void Run()
        {
            LogCurrentState(null, true, null, null);

            while (!_simulation.Finished)
            {
                var currentMappable = _simulation.CurrentMappable;
                var previousPosition = currentMappable?.Position;

                _simulation.Turn();

                var currentPosition = currentMappable?.Position;
                LogCurrentState(currentMappable, false, previousPosition, currentPosition);
            }
        }

        private void LogCurrentState(IMappable? activeMappable, bool isInitial, Point? previousPosition, Point? currentPosition)
        {
            var symbols = new Dictionary<Point, char>();
            var collisionPoints = new Dictionary<Point, int>(); // Licznik obiektów na każdej pozycji

            // Iteracja po wszystkich obiektach na mapie
            foreach (var mappable in _simulation.Mappables)
            {
                if (mappable.Position != null)
                {
                    var position = mappable.Position.Value;

                    // Aktualizuj licznik dla tej pozycji
                    if (collisionPoints.ContainsKey(position))
                    {
                        collisionPoints[position]++;
                    }
                    else
                    {
                        collisionPoints[position] = 1;
                    }
                }
            }

            // Ustawianie symboli na mapie
            foreach (var mappable in _simulation.Mappables)
            {
                if (mappable.Position != null)
                {
                    var position = mappable.Position.Value;

                    // Jeśli jest kolizja, ustaw 'X'
                    if (collisionPoints[position] > 1)
                    {
                        symbols[position] = 'X';
                    }
                    else
                    {
                        // Jeśli brak kolizji, ustaw symbol obiektu
                        symbols[position] = mappable.Symbol;
                    }
                }
            }

            var move = isInitial
                ? "Start"
                : activeMappable != null
                    ? $"{previousPosition} → {currentPosition} ({GetDirection(previousPosition, currentPosition)})"
                    : "None";

            var log = new SimulationTurnLog(
                mappable: activeMappable?.ToString() ?? "None",
                move: move,
                symbols: symbols,
                activeMappable: activeMappable,
                previousPosition: previousPosition,
                currentPosition: currentPosition,
                isInitial: isInitial
            );

            TurnLogs.Add(log);
        }

        private string GetDirection(Point? previous, Point? current)
        {
            if (previous == null || current == null) return "None";

            var deltaX = current.Value.X - previous.Value.X;
            var deltaY = current.Value.Y - previous.Value.Y;

            return (deltaX, deltaY) switch
            {
                (0, > 0) => "UP",
                (0, < 0) => "DOWN",
                ( > 0, 0) => "RIGHT",
                ( < 0, 0) => "LEFT",
                ( > 0, > 0) => "UP-RIGHT",
                ( > 0, < 0) => "DOWN-RIGHT",
                ( < 0, > 0) => "UP-LEFT",
                ( < 0, < 0) => "DOWN-LEFT",
                _ => "NONE"
            };
        }

    }
}
