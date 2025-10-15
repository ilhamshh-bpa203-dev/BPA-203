namespace method
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Str("salam men Ilham Huseynov, umid edirem ki, 100 bal alacam.", 'a');
        }
        public static void Str(string cumle, char herf)
        {
            int say = 0;

            for (int i = 0; i < cumle.Length; i++)
            {
                if (cumle[i] == herf)
                {
                    say++;
                }
            }

            if (say > 0)
            {
                Console.WriteLine("var");
                Console.WriteLine($"{herf} herfi {say} defe var");
            }
            else
            {
                Console.WriteLine("yoxdur");
            }
        }

    }
}
