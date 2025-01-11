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
        private bool isDescriptionInitialized = false;

        public string Description
        {
            get { return _description; }

            set
            {
                if (Validator.isAlreadyInitialized(isDescriptionInitialized, nameof(Description)))
                {
                    //zamiana na pierwszą wielką literę
                    var formattedValue = Validator.Shortener(value, 3, 25, '#');
                    _description = char.ToUpper(formattedValue[0]) + formattedValue.Substring(1);
                    isDescriptionInitialized = true;
                }
            }
        }

        public uint Size { get; set; } = 3;

        //właściwość Info zmieniona na klasę wirtualną
        public virtual string Info => $"{Description} <{Size}>";

        //nadpisanie ToString()
        public override string ToString()
        {
            return $"{GetType().Name.ToUpper()}: {Info}";
        }
    }
}