using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace _17_Directory_StreamReader_StreamWritter_Serialization_deserialization.Models
{
    internal class FileManager
    {
        public string FolderPath { get; set; }
        public string TextFilePath { get; set; }
        public string JsonFilePath { get; set; }

        public FileManager()
        {
            FolderPath = @"C:\Users\Ilham\Desktop\StudentData";
            TextFilePath = @"C:\Users\Ilham\Desktop\StudentData\Students.txt";
            JsonFilePath = @"C:\Users\Ilham\Desktop\BPA-203\17-Directory,StreamReader,StreamWritter,Serialization,deserialization\JSon\jsconfig1.json";
        }

        public void DirectoryCreate()
        {
            if (!Directory.Exists(FolderPath))
            {
                Directory.CreateDirectory(FolderPath);
                Console.WriteLine($"Qovluq yaradildi {FolderPath}");
            }

        }
        public void DirectoryDelete()
        {
            if (Directory.Exists(FolderPath))
            {
                Directory.Delete(FolderPath, true);
                Console.WriteLine($"Qovluq silindi {FolderPath}");
            }
        }
        public bool IsDirectoryExistis()
        {
            if (Directory.Exists(FolderPath)) { return true; }
            else { return false; }
        }

        public void StudentWriter(Student student)
        {
            using (StreamWriter sw = new StreamWriter(JsonFilePath, true))
            {
                sw.WriteLine(student.ToString());
                Console.WriteLine($"Telebe yazildi {student.Name}");
               
            }
        }
        public void AllStudentWriter(List<Student> students)
        {
            File.WriteAllText(JsonFilePath, "");

            int count = 0;
            foreach (var student in students)
            {
                count++;
                using (StreamWriter sw = new StreamWriter(JsonFilePath, true))
                {
                    sw.WriteLine(student.ToString());

                }
            }
            Console.WriteLine($"Ümumi [{count}] tələbə fayla yazıldı");
        }

        public List<Student> ReadStudentsFromFile(List<Student> students)
        {
            //List<Student> students = new List<Student>();

            if (File.Exists(JsonFilePath))
            {
                using (StreamReader sr = new StreamReader(JsonFilePath))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                      
                        string[] parts = line.Split(',');
                        if (parts.Length == 5)
                        {
                            int id = int.Parse(parts[0]);
                            string name = parts[1];
                            string surname = parts[2];
                            int age = int.Parse(parts[3]);
                            double grade = double.Parse(parts[4]);

                            students.Add(new Student(id, name, surname, age, grade));
                        }
                    }
                }
                Console.WriteLine($"Fayldan {students.Count} tələbə oxundu.");
            }
            else
            {
                Console.WriteLine("Fayl tapılmadı!");
            }

            return students;
        }

        public void Serialize(List<Student> students)
        {
            string result = JsonSerializer.Serialize(students);
            File.WriteAllText(JsonFilePath,result);
            Console.WriteLine($"Tələbələr JSON formatında yadda saxlanıldı \nfayl path: {JsonFilePath}");
        }
        public void Deserialize(List<Student> students) 
        {
            string resault;
            using(StreamReader sr = new StreamReader(JsonFilePath))
            {
                resault = sr.ReadToEnd();
            }
            List<Student> DesStudent= JsonSerializer.Deserialize<List<Student>>(resault);

            if (DesStudent != null)
            {
                int count = 0;
                foreach (var student in DesStudent)
                {
                    count++;
                    Console.WriteLine($"[{student.ID}] {student.Name} {student.Surname} - Yaş: {student.Age}, Qiymət: {student.Grade}");
                }
                Console.WriteLine($"JSON-dan [{count}] tələbə yükləndi");
            }
            else {
                Console.WriteLine("List bosdur");
            }


        }

    }


}
