using _14_StatiClassExtensionMethodsExceptions.Utilities.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace _14_StatiClassExtensionMethodsExceptions.Utilities
{
    internal class LoginSytem
    {
        private string[] Users = ["admin", "student", "teacher", "admin123", "student123", "teacher123"];
        private const int MaxAttempts = 3;
        User user = new();

        public LoginSytem() { }

        public LoginSytem(string user1, string user2, string user3, string password1, string password2, string password3)
        {
            Users[0] = user1;
            Users[1] = user2;
            Users[2] = user3;
            Users[3] = password1;
            Users[4] = password2;
            Users[5] = password3;
        }
        public void ValidateUsername(string username)
        {
            try
            {
                if (!string.IsNullOrEmpty(username) && username.Length >= 3)
                {
                    //Console.WriteLine($"'{username}' added");
                }
                else
                {
                    throw new InvalidUsernameException("Username is Wrong");
                }
            }
            catch (InvalidUsernameException ex)
            {

                Console.WriteLine(ex.Message);
            }

        }
        public void ValidatePassword(string password)
        {
            try
            {
                if (!string.IsNullOrEmpty(password) && password.Length > 6)
                {
                    //Console.WriteLine("password added");

                }
                else
                {
                    throw new InvalidPasswordException();

                }
            }
            catch (InvalidPasswordException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public void FindUser(string username)
        {
            username = username.ToLower();

            string[] newUsers = new string[3];
            for (int i = 0; i < 3; i++)
            {
                newUsers[i] = Users[i].ToLower();
            }
            try
            {
                foreach (string user in newUsers)
                {
                    if (username == user)
                    {
                        Console.WriteLine($"Username: {username}");
                        break;
                    }                   
                }
            }
            catch (UserNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
               

            }
        }

        public bool Login(string username, string password)
        {
            ValidateUsername(username);
            ValidatePassword(password);
            FindUser(username);

            if (user.IsLocked)
            {
                throw new AccountLockedException();
            }
            else
            {


                if (username == Users[0] || username == Users[1] || username == Users[2])
                {

                }
                else if (username != Users[0] || username != Users[1] || username != Users[2])
                {
                    throw new UserNotFoundException();
                    //throw new Exception("Name not found");

                }
                if (password == Users[3] || password == Users[4] || password == Users[5])
                {
                    user.FailedAttempts = 0;
                    Console.WriteLine($"Login successful!,WELCOME {username}");
                }
                else
                {

                    int attemps = MaxAttempts - user.FailedAttempts;
                    user.FailedAttempts++;
                    if (attemps > 0) { throw new IncorrectPasswordException(attemps); }
                    else
                    {
                        user.IsLocked = true;
                        throw new AccountLockedException();
                    }
                }
            }
            return false;
        }
    }
}

