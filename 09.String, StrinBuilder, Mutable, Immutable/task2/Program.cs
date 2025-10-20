using System.Globalization;

namespace task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str = "I am Backend DEVELOPER I LEARN C#";

            string space = " ";
            int lastIndex = 0;
            int count = 0;
            for (int i = lastIndex; i < str.Length; i++) 
            {
                if (space.Contains(str[i]))
                {
                    lastIndex=i;
                    count++;
                }
            }
            Console.WriteLine(count);
        }
    }
}
