using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Access_Modifires__Encupsulation__Namespace
{
    internal class CarHP
    {
        private int _horsePower;

        public int HorsePower
        {
            get
            {
                return _horsePower;
            }

            set
            {
                if (value < 100)
                {
                    Console.WriteLine("Please set correct power");
                    return;
                }

                _horsePower = value;
            }
        }
    }
}
