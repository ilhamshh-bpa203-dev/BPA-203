using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_StatiClassExtensionMethodsExceptions.Utilities.Exceptions
{
    internal class IncorrectPasswordException : Exception
    {
        public static int AttemptLeft;
        public static string Error = "Invorrect password";
        public IncorrectPasswordException(int attemtsLeft) : base(Error)
        {
            AttemptLeft = attemtsLeft;

            Console.WriteLine($"Attempts left {AttemptLeft} ");
        }
    }
}
