using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15_UpcastingDowncastingExplicitImplicitFinalize_Destructor_.Exchange
{
    internal class Manat
    {
        public decimal AZN { get; set; }

        public Manat(decimal azn)
        { 
           AZN = azn; 
        }

        public static explicit operator Manat(Dollar dollar)
        {
            return new Manat(dollar.USD * 1.7m);
        }

        public static implicit operator Manat(decimal value)
        {
            return new Manat(value);
        }
    }
}
