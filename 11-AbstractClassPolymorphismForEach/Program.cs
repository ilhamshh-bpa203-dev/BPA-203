namespace _11_AbstractClassPolymorphismForEach.Vehicles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //double distance = 243.78;
            //double weight = 15.0;

            //car.GetVehicleInfo();
            //car.ShowCarInfo();
            //car.CalculateFuelCost(distance);
            //motor.ShowMotorcycleINfo();
            //motor.GetVehicleInfo();
            //motor.ShowBasicInfo();
            //motor.CalculateFuelCost(distance);

            // 1. 3 car obyekti
            Car mers = new("Mercedes", "E200", 2023, "44BC371", 4, 500, true, 220);
            Car bmw = new("BMW", "320i", 2022, "99AA009", 4, 480, true, 235, 59);
            Car tyt = new("Toyota", "Camry", 2021, "90AD437", 4, 524, true, 210, 15);

            //2. 2 Motorcycle obyekti
            Motorcycle yamaha = new("Yamaha", "R1", 2023, "50H007", 299, 998, false, "Sport");
            Motorcycle harley = new("Harley", "Davidson", 2022, "42A782", 180, 1868, true, "Cruiser");

            //3. 2 Truck obyekti
            Truck man = new("MAN", "TGX", 2020, "43BH678", 120, 18, 3, 12);
            Truck volvo = new("Volvo", "FH16", 2021, "43BM887", 110, 25, 4, 18);

            //4. obyekt melumatlari
            //mers
            Console.WriteLine("Mersedec:");
            mers.ShowCarInfo();
            Console.WriteLine(" ");
            Console.WriteLine("Mersedec's fuel cost in 500km:");
            Console.WriteLine(mers.CalculateFuelCost(500));
            Console.WriteLine(" ");
            //bmw
            Console.WriteLine("BMW:");
            bmw.ShowCarInfo();
            Console.WriteLine(" ");
            Console.WriteLine("BMW's fuel cost in 500km:");
            Console.WriteLine(bmw.CalculateFuelCost(500));
            Console.WriteLine(" ");
            //Toyota
            Console.WriteLine("Toyota:");
            tyt.ShowCarInfo();
            Console.WriteLine(" ");
            Console.WriteLine("Toyota's fuel cost in 500km:");
            Console.WriteLine(tyt.CalculateFuelCost(500));
            Console.WriteLine(" ");
            //Yamaha
            Console.WriteLine("Yamaha:");
            yamaha.ShowMotorcycleINfo();
            Console.WriteLine(" ");
            Console.WriteLine("Yamaha's fuel cost in 300km:");
            Console.WriteLine(yamaha.CalculateFuelCost(300));
            Console.WriteLine(" ");
            //Harley
            Console.WriteLine("Harley:");
            harley.ShowMotorcycleINfo();
            Console.WriteLine(" ");
            Console.WriteLine("Harley's fuel cost in 300km:");
            Console.WriteLine(harley.CalculateFuelCost(300));
            Console.WriteLine(" ");
            //MAN
            Console.WriteLine("MAN:");
            man.ShowTruckInfo();
            Console.WriteLine(" ");
            Console.WriteLine("MAN's fuel cost in 800km:");
            Console.WriteLine(man.CalculateFuelCost(800));
            Console.WriteLine(" ");
            //Volvo
            Console.WriteLine("Volvo:");
            volvo.ShowTruckInfo();
            Console.WriteLine(" ");
            Console.WriteLine("Volvo's fuel cost in 800km:");
            Console.WriteLine(volvo.CalculateFuelCost(800));
            Console.WriteLine(" ");

            //5. add cargo 

            man.LoadCargo(5, 800);
            //6.
            //umumi neqliyat sayi:
            Console.WriteLine(" ");

            Console.WriteLine($"Total vehicle {Vehicle.vehicleCount}");
            //orta suret
            Console.WriteLine(" ");
            Console.WriteLine($"Max avarage speed is:{(mers.MaxSpeed + tyt.MaxSpeed + bmw.MaxSpeed + yamaha.MaxSpeed + volvo.MaxSpeed + harley.MaxSpeed + man.MaxSpeed) / Vehicle.vehicleCount}");
            Console.WriteLine(" ");
            // bahali yanacaq
            Console.WriteLine(" ");
            double[] fuels = { mers.CalculateFuelCost(100), bmw.CalculateFuelCost(100), tyt.CalculateFuelCost(100), yamaha.CalculateFuelCost(100), harley.CalculateFuelCost(100), man.CalculateFuelCost(100), volvo.CalculateFuelCost(100) };
            Console.WriteLine($"The Most Expensive Fuel Cost: {fuels.Max()} AZN");

        }
    }
}
