using System;

namespace task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str = "I am Backend DEVELOPER I LEARN C#";

            
            string str1 = "";
            string maxstr = "";
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] != ' ')
                {
                    str1 += str[i];
                }
                else
                {
                    if (str1.Length > maxstr.Length)
                    {
                        maxstr = str1;
                        
                    }
                    str1 = "";
                }
                if (str1.Length > maxstr.Length)
                {
                    maxstr = str1;
                }

            }
            Console.WriteLine(maxstr);
        }
    }
}
