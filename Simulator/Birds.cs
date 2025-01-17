using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using Simulator.Maps;

namespace Simulator
{
    public class Birds : Animals
    {
        public MovementType Movement { get; }

        public override char Symbol => Movement switch
        {
            MovementType.Flying => 'B',
            MovementType.NonFlying => 'b',
            _ => base.Symbol
        };

        //własność logiczna CanFly()
        public bool CanFly => Movement == MovementType.Flying;

        //nadpisanie metody Info
        public override string Info
        {
            get
            {
                string flyStatus = CanFly ? "fly+" : "fly-";
                return $"{Description} ({flyStatus}) <{Size}>";
            }
        }

        public Birds(string description, MovementType movement, uint size = 1) : base(description, size)
        {
            if(movement != MovementType.Flying && movement != MovementType.NonFlying)
            {
                throw new ArgumentException("Birds can only be flying or non-flying");
            }

            Movement = movement;
        }

        public override void Move(Direction direction)
        {
            if  (Map == null || Position == null)
            {
                throw new InvalidOperationException("Bird is not assigned to a map");
            }

            var newPosition = Movement switch
            {
                MovementType.Flying => Map.Next(Map.Next(Position.Value, direction), direction),
                MovementType.NonFlying => Map.NextDiagonal(Position.Value, direction),
                _ => throw new InvalidOperationException("Unknown movement type")
            };

            if (Map is SmallMap smallMap)
            {
                smallMap.Move(this, Position.Value, newPosition);
            }

            Position = newPosition;
        }

        public override string ToString()
        {
            return $"BIRD: {Info}";
        }

        public enum MovementType
        {
            Flying,
            NonFlying
        }
    }
}
