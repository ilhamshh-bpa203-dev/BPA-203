using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Object__Class__Constructor__Inheritance__this_vs_base_keywords.school
{
    internal class Person
    {
        public string firstName;
        public string lastName;
        public int age;
        public string email;
        public string ID;

        public Person(string firstName, string lastName, int age, string email, string ID)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
            this.email = email;
            this.ID = ID;
        }

        public void GetFullName()
        {
            Console.WriteLine($"{firstName} {lastName}");
        }
        public void ShowBasicInfo()
        {
            Console.WriteLine($"Age: {age} ,Email: {email},ID: {ID}");
        }

    }
}
