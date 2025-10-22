namespace _10.Access_Modifires__Encupsulation__Namespace
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CarHP car = new CarHP();

            car.HorsePower = 20;

            Console.WriteLine(car.HorsePower);

        }
    }
}
