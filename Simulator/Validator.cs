using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
    public static class Validator
    {
        //zwraca wartość z zakresu [min-max]
        public static int Limiter(int value, int min, int max)
        {
            return Math.Clamp(value, min, max);
        }

        //skraca wartość do określonej długości, uzupełnia brakujące znaki placeholderem
        public static string Shortener(string value, int min, int max, char placeholder)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return new string(placeholder, min);
            }

            string trimmed = value.Trim();

            if (trimmed.Length < min)
            {
                return trimmed.PadRight(min, placeholder);
            }
            else if (trimmed.Length > max)
            {
                return trimmed.Substring(0, max);
            }
            else
            {
                return trimmed;
            }

        }

        public static bool isAlreadyInitialized(bool isInitialized, string property)
        {
            if (isInitialized)
            {
                Console.WriteLine($"Property {property} has already been initialized.");
                return false;
            }

            return true;
        }
    }
}
