using _08.Object__Class__Constructor__Inheritance__this_vs_base_keywords.school;
using System.Security.Cryptography.X509Certificates;

namespace _08.Object__Class__Constructor__Inheritance__this_vs_base_keywords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Objects

            Student student = new Student("Ilham", "Huseynov", 19, "BDUstudent@bdu.edu", "TK-215689", "213455", "IT", 71.6, 3);
            Teacher teacher = new Teacher("Seid", "Nuraliyev", 36, "saidnuraliyev@gmail.com", "TC235", "IT", "Developer", 800, 5);
            Administrator admin = new Administrator("Abbas", "Agayev", 45, "abbasagg@bdu.edu", "AD1277", "Dekan", "TR", 3);

            //method calls

            //student.GetFullName();
            //student.ShowBasicInfo();
            //student.ShowStudentInfo();
            //student.CalculateScholarship();
            //teacher.ShowTeacherInfor();
            //teacher.CalculateSalary();
            //admin.ShowAdminInfor();
            //admin.GrantAccess(student);

            //SSenariler


            Student student1 = new Student("Rehim", "Memmedov", 19, "BDUstudent@bdu.edu", "TK-342562", "223615", "IT", 88.5, 3); 
            Student student2 = new Student("Xankisi", "Xankisiyev", 19, "BDUstudent@bdu.edu", "TK-23224", "213455", "IT", 92.0, 3);
            Student student3 = new Student("Teymur", "Abdurahmanov", 19, "BDUstudent@bdu.edu", "TK-344253", "313354", "IT", 68.5, 3);


            Teacher teacher1 = new Teacher("Aga", "Agayev", 36, "saidnuraliyev@gmail.com", "TC242", "IT", "Developer", 800, 15);
            Teacher teacher2 = new Teacher("Mehemmed", "Aliyev", 28, "saidnuraliyev@gmail.com", "TC356", "KT", "Developer", 800, 8);


            Administrator admin1 = new Administrator("Ceyhun", "Agayev", 47, "ceyhunagg@bdu.edu", "AD122", "Dekan", "TT", 2);
            
            student1.ShowStudentInfo();
            Console.WriteLine($"Sizin teqaudunuz: {student1.CalculateScholarship()}");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine(" ");
            student2.ShowStudentInfo();
            Console.WriteLine($"Sizin teqaudunuz: {student2.CalculateScholarship()}");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine(" ");
            student3.ShowStudentInfo();
            Console.WriteLine($"Sizin teqaudunuz: {student3.CalculateScholarship()}");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine(" ");
            teacher1.ShowTeacherInfor();
            Console.WriteLine($"{teacher1.firstName} {teacher1.lastName} muellim: {teacher1.CalculateSalary()}");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine(" ");
            teacher2.ShowTeacherInfor();
            Console.WriteLine($"{teacher2.firstName} {teacher1.lastName} muellim: {teacher2.CalculateSalary()}");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine(" ");
            admin1.ShowAdminInfor();
            admin1.GrantAccess(student3);
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine(" ");


            Console.WriteLine($"*Umumi teqaud xerci: {student1.CalculateScholarship() + student2.CalculateScholarship() + student3.CalculateScholarship()}");
            Console.WriteLine($"*Umumi maas xerci: {teacher1.CalculateSalary() + teacher2.CalculateSalary()} ");
        }
    }
}
