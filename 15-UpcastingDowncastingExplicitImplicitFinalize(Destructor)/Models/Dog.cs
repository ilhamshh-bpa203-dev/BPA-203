using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15_UpcastingDowncastingExplicitImplicitFinalize_Destructor_.Models
{
    internal class Dog :Animal
    {
        public string Name { get; set; }
        public string Breed { get; set; }

        public int Count { get; set; }

        public Dog(int count) 
        { 
            Count = count+1;  
        }

        ~Dog()
        {
            Console.WriteLine($"Destructor Destroyed Object:{Count}");
        }

    }
}
