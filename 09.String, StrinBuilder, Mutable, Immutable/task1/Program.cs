namespace task1
{
    internal class Program
    {
            static void Main(string[] args)
            {
                string str = "I am Backend DEVELOPER I LEARN C#";

                FindVowels(str);

            }

            public static void FindVowels(string str)
            {
                str = str.ToLower();
                string saitler = "e u i o a";
                for (int i = 0; i < str.Length; i++)
                {
                    #region daha imperativ yol
                    //if (str[i] == 'e')
                    //{
                    //    Console.WriteLine($"index {i} e");
                    //}
                    //else if (str[i] == 'u')
                    //{
                    //    Console.WriteLine($"index {i}: u");
                    //}
                    //else if (str[i] == 'i')
                    //{
                    //    Console.WriteLine($"index {i}: i");
                    //}
                    //else if (str[i] == 'o')
                    //{
                    //    Console.WriteLine($"index {i}: o");
                    //}
                    //else if (str[i] == 'a')
                    //{
                    //    Console.WriteLine($"index {i}: a");
                    //}
                    #endregion

                    #region daha deklarative yol
                    //if (saitler.Contains(str[i]))
                    //{
                    //    Console.WriteLine($"Index {i}: {str[i]}");
                    //}
                    #endregion

                }

            }

        
    }
}
