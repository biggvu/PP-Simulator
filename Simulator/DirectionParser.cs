using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
    public static class DirectionParser
    {
        public static List<Direction> Parse(string input)
        {

            //jeśli input jest pusty zwracamy pustą tablicę
            if (string.IsNullOrWhiteSpace(input))
            {
                return new List<Direction>();
            }

            //lista, która przechowuje poprawne kierunki
            List<Direction> directions = new List<Direction>();

            //każdy znak przez który przechodzimy zmieniamy na wielką literę
            foreach (char c in input.ToUpper())
            {
                switch (c)
                {
                    //U - Up, R - Right, D - Down, L - Left
                    case 'U':
                        directions.Add(Direction.Up);
                        break;
                    case 'R':
                        directions.Add(Direction.Right);
                        break;
                    case 'D':
                        directions.Add(Direction.Down);
                        break;
                    case 'L':
                        directions.Add(Direction.Left);
                        break;
                    default:
                        //jeśli znak nie jest poprawny to jest ignorowany
                        break;
                }
            }
            //zwracamy wynik jako tablicę kierunków
            return directions;
        }
    }
}
