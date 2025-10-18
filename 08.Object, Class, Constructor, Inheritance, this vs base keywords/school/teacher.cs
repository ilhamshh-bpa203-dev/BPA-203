using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Object__Class__Constructor__Inheritance__this_vs_base_keywords.school
{
    internal class Teacher:Person
    {
        public string Department;
        public string MainSubject;
        public decimal BaseSalary;
        public int ExperienceYears; 

        //Teacher ctor
        public Teacher(string firstName,string lastName,int age,string email,string ID, string Department, string MainSubject, decimal BaseSalary, int ExperienceYears) :base(firstName, lastName, age, email, ID)
        {
            this.Department = Department;
            this.MainSubject = MainSubject;
            this.BaseSalary = BaseSalary;
            this.ExperienceYears = ExperienceYears;
        }
        
        //Methods for Teacher
        public void ShowTeacherInfor()
        {
            Console.WriteLine($"Ad: {firstName} ,Soyad: {lastName} ,Yas: {age} ,Email: {email} ,ID: {ID} , Department: {Department} ,Esas fenn: {MainSubject} ,Baza maas: {BaseSalary} ,Tecrube {ExperienceYears}");
        }
        public decimal CalculateSalary() 
        {
            return BaseSalary + 100*ExperienceYears;
        }
    }
}
