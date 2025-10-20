namespace task4
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
                int letters = 0;
                int uppers = 0;

                for (int j = 0; j < word.Length; j++)
                {
                    char ch = word[j];
                    if (char.IsLetter(ch))
                    {
                        letters++;
                        if (char.IsUpper(ch))
                        {
                            uppers++;
                        }
                    }
                }

                if (letters > 0 && letters == uppers)
                {
                    Console.WriteLine($"{word}, index {i}");
                }

              
            }

        }
    }
}
