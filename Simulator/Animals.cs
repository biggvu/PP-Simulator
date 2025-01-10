using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
    public class Animals
    {
        private string _description = "Default"; //wartość domyślna "Default", aby uniknąć ostrzeżenia kompilatora

        public string Description
        {
            get { return _description; }

            set
            {
                //usuwanie nadmiarowych spacji na początku i na końcu
                string trimmedDescription = value.Trim();

                if (string.IsNullOrWhiteSpace(trimmedDescription))
                {
                    trimmedDescription = "###";
                }
                //minimalnie 3 znaki, brakujące są uzpełniane znakiem '#'
                if (trimmedDescription.Length < 3)
                {
                    trimmedDescription = trimmedDescription.PadRight(3, '#');
                }
                //maksymalnie 15 znaków, przycięcie tych za długich
                if (trimmedDescription.Length > 15)
                {
                    trimmedDescription = trimmedDescription.Substring(0, 15).Trim();
                }
                //sprawdzenie czy wciąż name ma przynajmniej 3 znaki
                if (trimmedDescription.Length < 3)
                {
                    trimmedDescription = trimmedDescription.PadRight(3, '#');
                }
                //ustawianie pierwszej litery na wielką
                if (char.IsLower(trimmedDescription[0]))
                {
                    trimmedDescription = char.ToUpper(trimmedDescription[0]) + trimmedDescription.Substring(1);
                }

                _description = trimmedDescription;
            }
        }

        public uint Size { get; set; } = 3;

        //właściwość do odczytu Info zwracająca opis i liczebność w formie: Dogs <3>
        public string Info
        {
            get { return $"{Description} <{Size}>"; }
        }
    }
}