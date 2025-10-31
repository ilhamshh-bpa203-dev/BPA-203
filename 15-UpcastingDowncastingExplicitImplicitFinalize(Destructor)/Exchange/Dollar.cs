using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15_UpcastingDowncastingExplicitImplicitFinalize_Destructor_.Exchange
{
    internal class Dollar
    {
        public decimal USD {  get; set; }

        public Dollar(decimal usd)
        { 
            USD = usd; 
        }

        public static explicit operator Dollar(Manat manat)
        {
            return new Dollar(manat.AZN / 1.7m);
        }
    }
}
