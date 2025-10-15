#region riyazi emel

// namespace method
// {
//     internal class Program
//     {
//         static void Main(string[] args)
//         {
//             Calcul(12, 23, "+");
//         }
//         public static void Calcul(double num1, double num2, string op)
//         {
//             if (op == "+")
//             {
//                 Console.WriteLine("Toplama neticesi:");
//                 Console.WriteLine(num1 + num2);
//             }
//             else if (op == "-")
//             {
//                 Console.WriteLine("Ferqin neticesi:");
//                 Console.WriteLine(num1 - num2);
//             }
//             else if (op == "/")
//             {
//                 Console.WriteLine("Nisbetin neticesi:");
//                 Console.WriteLine(num1 / num2);
//             }
//             else if (op == "*")
//             {
//                 Console.WriteLine("Nisbetin neticesi:");
//                 Console.WriteLine(num1 * num2);
//             }
//             else
//             {
//                 Console.WriteLine("Duzgun emeliyyat secin.");
//             }

//         }

//     }
// }
#endregion

#region tek cut 
// namespace method
// {
//     internal class Program
//     {
//         static void Main(string[] args)
//         {
//             Array([14,20,35,40,57,60,100]);
//         }
//         public static void Array(int[] arr)
//         {
//             for(int i =0 ; i < arr.Length; i++)
//             {
//                 if (arr[i] % 2 == 0)
//                 {
//                     Console.WriteLine(arr[i]);
//                     Console.WriteLine("Cut eded");
//                     Console.WriteLine("------------------");
//                 }
//                 else
//                 {
//                     Console.WriteLine(arr[i]);
//                     Console.WriteLine("Tek eded");
//                     Console.WriteLine("------------------");
//                 }
//             }
//         }

//     }
// }
#endregion

#region 4-5 eded
// namespace method
// {
//     internal class Program
//     {
//         static void Main(string[] args)
//         {
//             Array([14,20,35,40,57,60,100]);
//         }
//         public static void Array(int[] arr)
//         {
//             int sum4 = 0;
//             int sum5 = 0;
//             foreach (var num in arr)
//             {

//                 if (num % 4 == 0)
//                 {
//                     sum4 += num;
//                 }
//                 if (num % 5 == 0)
//                 {
//                     sum5 = num;
//                 }

//             }
//              Console.WriteLine("4'e bölünebilenlerin toplamı: " + sum4);
//             Console.WriteLine("5'e bölünebilenlerin toplamı: " + sum5);
//             Console.WriteLine("Toplam: " + (sum4 + sum5));
//         }

//     }
//}
#endregion

#region herf
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
#endregion
