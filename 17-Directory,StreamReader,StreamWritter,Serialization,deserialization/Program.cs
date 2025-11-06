using _17_Directory_StreamReader_StreamWritter_Serialization_deserialization.Models;
using Newtonsoft.Json;

namespace _17_Directory_StreamReader_StreamWritter_Serialization_deserialization
{

    internal class Program
    {
        static void Main(string[] args)
        {
            Student student1 = new(1, "Ali", "Məmmədov", 20, 85.5);
            Student student2 = new(2, "Leyla", "Həsənova", 19, 92.0);
            Student student3 = new(3, "Vüqar", "Əliyev", 21, 78.5);
            Student student4 = new(3, "Nigar", "Əhmədova", 20, 88.0);
            Student student5 = new(4, "Rəşad", "Quliyev", 22, 95.5);

            List<Student> students = new List<Student>()
            {
                student1,student2,student3,student4,student5
            };


            //FileManager fileManager = new FileManager();

            ////bir telebeni fayla yaz
            ////fileManager.StudentWriter(student1);


            ////butun telebeleri fayla yaz



            //fileManager.ReadStudentsFromFile(students);


            //Program.cs 

            //1.
            student1.DisplayInfo();
            student2.DisplayInfo();
            student3.DisplayInfo();
            student4.DisplayInfo();
            student5.DisplayInfo();


            //2. Directory əməliyyatları:

            FileManager fileManager1 = new FileManager();

            if (fileManager1.IsDirectoryExistis())
            {
                fileManager1.DirectoryDelete();
            }
            else
            {
                fileManager1.DirectoryCreate();

                if (fileManager1.IsDirectoryExistis())
                {
                    File.Create(fileManager1.TextFilePath);
                    Console.WriteLine("Succesful.");
                }
                else { Console.WriteLine("Unsuccesful"); }
            }

            //3. StreamWriter - Tələbələri fayla yazın:
            //a)
            fileManager1.StudentWriter(student1);
            fileManager1.StudentWriter(student2);
            fileManager1.StudentWriter(student3);
            fileManager1.StudentWriter(student4);
            fileManager1.StudentWriter(student5);
            //b)

            fileManager1.AllStudentWriter(students);

            //4. StreamReader - Fayldan oxuma:

            fileManager1.ReadStudentsFromFile(students);

            //5. Serialization - JSON-a yazma:
            fileManager1.Serialize(students);

            //6. Serialization - JSON-a yazma:
            fileManager1.Deserialize(students);

            //7. Fayl əməliyyatları test:
            //a)

            if (File.Exists(fileManager1.TextFilePath))
            {


                Console.WriteLine("Faylın məzmunu:");
                Console.WriteLine(File.ReadAllText(fileManager1.TextFilePath));

                Console.WriteLine("CSV formatı:");
                Console.WriteLine("ID,Name,Surname,Age,Grade");
            }
            else
            {
                Console.WriteLine("Students.txt NOT Found");
            }
            //b)
            if (File.Exists(fileManager1.JsonFilePath))
            {


                Console.WriteLine("Faylın məzmunu:");
                Console.WriteLine(File.ReadAllText(fileManager1.JsonFilePath));

                Console.WriteLine("Formatı:");
                Console.WriteLine("ID,Name,Surname,Age,Grade");
            }
            else
            {
                Console.WriteLine("NOT Found");
            }

            //8. Statistika:

            //telebelerin sayi
            Console.WriteLine($"Umumi telebe sayi: {students.Count}");
            //ortaqiymet
            double avg = 0;
            foreach (var item in students)
            {
                avg += item.Grade;
            }
            Console.WriteLine(avg / students.Count);

            //enasagi qiymet
            double[] min = new double[students.Count];
            int num = 0;
            foreach (var item in students)
            {
                min[num] = item.Grade; num++;
            }
            Console.WriteLine(min.Min());

            //enyuksek
            double[] max = new double[students.Count];
            int num1 = 0;
            foreach (var item in students)
            {
                max[num1] = item.Grade; num1++;
            }
            Console.WriteLine(max.Max());

            int st = 0;
            foreach (var item in students)
            {
                if (item.Grade > 90)
                {
                    st++;
                }
            }
            Console.WriteLine(st);


            FileInfo info = new FileInfo(fileManager1.JsonFilePath);
            Console.WriteLine(info.Length);
        }
    }
}
