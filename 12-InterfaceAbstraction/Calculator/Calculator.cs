namespace _12_InterfaceAbstraction.Calculator
{
    internal class Calculation : ICalculation
    {
        public double num1;
        public double num2;
        public string op;
        public Calculation(double num1, string op, double num2)
        {
            this.num1 = num1;
            this.num2 = num2;
            this.op = op;
        }
        public void Calculate()
        {
            if (op == "+")
            {
                Console.WriteLine($"Sum of these numbers is: {num1 + num2}");
            }
            else if (op == "-") { Console.WriteLine($"Difference of these numbers is: {num1 - num2}"); }
            else if (op == "*") { Console.WriteLine($"Product of these numbers is: {num1 * num2}"); }
            else if (op == "/")
            {
                if (num2 == 0) { Console.WriteLine("You cant divide by 0..."); }
                else { Console.WriteLine($"Quotient of these numbers is: {num1 / num2}"); }
            }
            else { Console.WriteLine("Invalid Operation."); }
        }
    }
}
