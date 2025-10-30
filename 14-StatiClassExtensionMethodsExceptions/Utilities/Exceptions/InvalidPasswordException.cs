using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_StatiClassExtensionMethodsExceptions.Utilities.Exceptions
{
    internal class InvalidPasswordException : Exception
    {
       public static string Error = "Invalid Password";
        public InvalidPasswordException():base(Error) { }
        public InvalidPasswordException(string message):base(message) { }

    }
}
