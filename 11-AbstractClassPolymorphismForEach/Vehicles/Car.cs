using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_AbstractClassPolymorphismForEach.Vehicles
{
    internal class Car : Vehicle
    {
        public int DoorsCount { get; set; }
        public int TrunkCapacity { get; set; }
        public bool IsAutomatic { get; set; }






        public Car(string Brand, string Model, int Year, string PlateNumber, int DoorsCount, int TrunkCapacity, bool IsAutomatic, int MaxSpeed, double FuelLevel = 100) : base(Brand, Model, Year, PlateNumber, MaxSpeed, FuelLevel)
        {
            this.DoorsCount = DoorsCount;
            this.TrunkCapacity = TrunkCapacity;
            this.IsAutomatic = IsAutomatic;
        }

        public override void GetVehicleInfo()
        {
            Console.WriteLine($"Brand: {Brand}, Model: {Model}, Year: {Year}, Plate Number: {PlateNumber}, Fuel Level: {FuelLevel}, Doors Count : {DoorsCount},Trunk Capacity: {TrunkCapacity},  Is Automatic: {IsAutomatic}, Max Speed(km/h): {MaxSpeed}");
        }
        public void ShowCarInfo()
        {
            Console.WriteLine("Car infos:");
            GetVehicleInfo();
        }
        public override void ShowBasicInfo()
        {
            base.ShowBasicInfo();
        }
        public double CalculateFuelCost(double distance)
        {
            return distance / 100 * 8 * 1.5;
        }

    }
}
