using _12_InterfaceAbstraction.Calculator;

namespace _12_InterfaceAbstraction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"First number:");
            string number1 = Console.ReadLine();
            double num1;
            bool num = double.TryParse(number1 , out num1);

            Console.WriteLine($"Operation(+,-,*,/):");
            string op= Console.ReadLine();

            Console.WriteLine($"second number:");
            string number2 = Console.ReadLine();
            double num2;
            bool num3 = double.TryParse(number2, out num2);


            Calculation calculator = new(num1,op,num2);
            calculator.Calculate();

        }
    }
}
