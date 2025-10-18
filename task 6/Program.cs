namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Cumleni daxil et:");
            string text = Console.ReadLine();
            Find(text);
            
        }
        public static void Find(string name)
        {
            string soz = "";
            string uzunsoz = "";
            for (int i = 0; i < name.Length; i++) 
            {
                if (name[i] != ' ')
                {
                    soz += name[i];
                }
                else
                {
                    if (soz.Length > uzunsoz.Length)
                    {
                        uzunsoz = soz;
                    }
                    soz = "";
                }
            }
            if (soz.Length > uzunsoz.Length)
            {

                uzunsoz = soz;
            }
            Console.WriteLine(uzunsoz);
        }
    }
        

    }









