using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_StatiClassExtensionMethodsExceptions.Utilities.Exceptions
{
    internal class UserNotFoundException : Exception
    {
        public static string Error = "User Not Found";
        public UserNotFoundException():base(Error) { }
        public UserNotFoundException(string user) { }
    }
}
