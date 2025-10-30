using _14_StatiClassExtensionMethodsExceptions.Utilities.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14_StatiClassExtensionMethodsExceptions.Utilities
{
    internal class User
    {
        public string Username;
        public string Password;
        public bool IsLocked=false;
        public int FailedAttempts;

         public User() { }
        public User(string username,string password)
        {
            Username = username;
            Password = password;
            FailedAttempts++;

        }
        


    }

}
