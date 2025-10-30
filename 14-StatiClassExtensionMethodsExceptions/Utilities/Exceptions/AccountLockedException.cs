using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_StatiClassExtensionMethodsExceptions.Utilities.Exceptions
{
    internal class AccountLockedException : Exception
    {
        public static string Error = "Account Locked";
        public AccountLockedException() : base(Error) { }

    }
}
