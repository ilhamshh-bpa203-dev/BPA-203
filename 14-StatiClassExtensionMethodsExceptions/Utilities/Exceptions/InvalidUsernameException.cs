using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_StatiClassExtensionMethodsExceptions.Utilities.Exceptions
{
    internal class InvalidUsernameException : Exception
    {
        public static string Error = "Invalid Username";
        public InvalidUsernameException():base(Error) { }
        public InvalidUsernameException(string message):base(message) { }
    }
}
