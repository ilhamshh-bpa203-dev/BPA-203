using _14_StatiClassExtensionMethodsExceptions.Utilities;
using _14_StatiClassExtensionMethodsExceptions.Utilities.Exceptions;
using System.Threading.Channels;

namespace _14_StatiClassExtensionMethodsExceptions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LoginSytem login = new("admin", "student", "teacher", "admin123", "student123", "teacher123");
            //login.Login("admin", "admin123");


            LoginSytem log = new();
            while (true)
            {
                try
                {
                    Console.WriteLine("Enter Username:");
                    string username = Console.ReadLine();
                    Console.WriteLine("Enter Password:");
                    string password = Console.ReadLine();


                    if (login.Login(username, password))
                    {
                        break;
                    }
                }
                catch (InvalidUsernameException ex) { Console.WriteLine($"ERROR {ex.Message}"); }
                catch (InvalidProgramException ex) { Console.WriteLine($"ERROR {ex.Message}"); }
                catch (UserNotFoundException ex) { Console.WriteLine($"ERROR {ex.Message},Movcud userler 'admin,student.teacher'"); }
                catch (IncorrectPasswordException ex) { Console.WriteLine($"WARNING {ex.Message} "); }
                catch (AccountLockedException ex) { Console.WriteLine($"CRITICAL {ex.Message}, Contact Admin"); }
                catch (Exception ex) { Console.WriteLine($"UNEXPECTED ERROR,  {ex.Message}"); }
            }
        }
    }
}

