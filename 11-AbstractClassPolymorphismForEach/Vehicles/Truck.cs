using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_AbstractClassPolymorphismForEach.Vehicles
{
    internal class Truck : Vehicle
    {
        public double CargoCapacity { get; set; }
        public int AxleCount { get; set; }
        public double CurrentLoad { get; set; }

        public Truck(string Brand, string Model, int Year, string PlateNumber, int MaxSpeed, double CargoCapacity, int AxleCount, double CurrentLoad, double FuelLevel = 100) : base(Brand, Model, Year, PlateNumber, MaxSpeed, FuelLevel)
        {
            this.CargoCapacity = CargoCapacity;
            this.AxleCount = AxleCount;
            this.CurrentLoad = CurrentLoad;
        }

        public override void GetVehicleInfo()
        {
            Console.WriteLine($"Brand: {Brand}, Model: {Model}, Year: {Year}, Plate Number: {PlateNumber}, Fuel Level: {FuelLevel},Cargo Capacity: {CargoCapacity} ,Axle Count: {AxleCount},Current Load: {CurrentLoad}     ");
        }
        public void ShowTruckInfo()
        {
            Console.WriteLine("Truck info:");
            GetVehicleInfo();
        }
        public override void ShowBasicInfo()
        {
            base.ShowBasicInfo();
        }

        public void LoadCargo(double weight, double distance)
        {
            Console.WriteLine($"{weight} tons of cargo were loaded");
            CurrentLoad += weight;
            Console.WriteLine($"Current load is {CurrentLoad} tons");
            Console.WriteLine($"New Fuel cost is {(distance / 100) * (25 + CurrentLoad * 2) * 1.80} AZN");
        }
        public double CalculateFuelCost(double distance)
        {
            return (distance / 100) * (25 + CurrentLoad * 2) * 1.80;
        }
    }
}
