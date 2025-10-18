using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Object__Class__Constructor__Inheritance__this_vs_base_keywords.school
{
    internal class Student : Person
    {
        public string StudentNumber;
        public string Faculty;
        public double GPA;
        public int Year;


        public Student(string firstName, string lastName, int age, string email, string ID, string StudentNumber, string Faculty, double GPA, int Year) : base(firstName, lastName, age, email, ID)
        {
            this.StudentNumber = StudentNumber;
            this.Faculty = Faculty;
            this.GPA = GPA;
            this.Year = Year;
        }
        public void ShowStudentInfo()
        {
            Console.WriteLine($"Ad: {firstName} ,Soyad: {lastName} ,Yas: {age} ,Email: {email} ,ID: {ID} ,Telebe Nomresi: {StudentNumber} ,Fakulte: {Faculty} ,GPA: {GPA} ,Kurs: {Year}");
        }

        public int CalculateScholarship()
        {
            int elaci = 500;
            int zerbeci = 350;
            int sade = 200;
            if (GPA >= 90)
            {
                return elaci;
            }
            else if (GPA >= 80)
            {
                return zerbeci;
            }
            else if (GPA >= 70)
            {
                return sade;
            }
            else
            {
                return 0;
            }
        }


    }
}
