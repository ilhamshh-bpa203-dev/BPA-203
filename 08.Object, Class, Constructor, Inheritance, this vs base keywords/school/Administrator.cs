using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Object__Class__Constructor__Inheritance__this_vs_base_keywords.school
{
    internal class Administrator:Person
    {
        public string position;
        public string department;
        public int accesLevel;

        public Administrator(string firstName, string lastName, int age, string email, string ID, string position, string department, int accesLevel) : base(firstName, lastName, age, email, ID)
        {
            this.position = position;
            this.department = department;
            this.accesLevel = accesLevel;
        }
        
        public void ShowAdminInfor()
        {
            Console.WriteLine($"Ad: {firstName} ,Soyad: {lastName} ,Yas: {age} ,Email: {email} ,ID: {ID} , Position: {position} ,Department: {department} ,Giris Seviyyesi: {accesLevel} ");
        }
        public void GrantAccess(Student student)
        {
            Console.WriteLine($"Dekan {firstName} {lastName} icaze verdi {student.firstName} {student.lastName}(a/ya)");
        }

    }
}
