namespace task5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string str = "I am Backend DEVELOPER I LEARN C#";
            string[] words = str.Split(' ');



            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i];
                int uppers = 0;

                for (int j = 0; j < word.Length; j++)
                {
                    char ch = word[j];
                    if (char.IsLetter(ch))
                    {
                        
                        if (char.IsUpper(ch))
                        {
                            uppers++;
                        }
                    }
                }

                if (uppers>2)
                {
                    Console.WriteLine($"{word}, index {i}");
                }

            }
        }
    }
}
