using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17_Directory_StreamReader_StreamWritter_Serialization_deserialization.Models
{
    internal class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public double Grade { get; set; }


        public Student(int ID,string Name, string Surname, int Age, double Grade)
        {
            this.ID = ID;
            this.Name = Name;
            this.Surname = Surname;
            this.Age = Age;
            this.Grade = Grade;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"[{ID}] {Name } {Surname} - Yaş: {Age}, Qiymət: {Grade}");
            
        }

        public override string ToString()
        {
            return $"[{ID}] {Name} {Surname} - Yaş: {Age}, Qiymət: {Grade}";

        }



    }
}
