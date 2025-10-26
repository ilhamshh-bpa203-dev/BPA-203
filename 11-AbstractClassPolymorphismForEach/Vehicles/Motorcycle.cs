using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_AbstractClassPolymorphismForEach.Vehicles
{
    internal class Motorcycle : Vehicle
    {
        public int EngineCapacity { get; set; }
        public bool HasSidecar { get; set; }
        public string Type { get; set; }




        public Motorcycle(string Brand, string Model, int Year, string PlateNumber, int MaxSpeed, int EngineCapacity, bool HasSidecar, string Type, double FuelLevel = 100) : base(Brand, Model, Year, PlateNumber, MaxSpeed, FuelLevel)
        {
            this.EngineCapacity = EngineCapacity;
            this.HasSidecar = HasSidecar;
            this.Type = Type;
        }

        public override void GetVehicleInfo()
        {
            Console.WriteLine($"Brand: {Brand}, Model: {Model}, Year: {Year}, Plate Number: {PlateNumber}, Fuel Level: {FuelLevel}, Engine Capacity: {EngineCapacity} ,Has Sidecar: {HasSidecar},Type: {Type}   ");
        }
        public void ShowMotorcycleINfo()
        {
            Console.WriteLine("Motor Infos:");
            GetVehicleInfo();
        }
        public override void ShowBasicInfo()
        {
            base.ShowBasicInfo();
        }
        public double CalculateFuelCost(double distance)
        {
            return distance / 100 * 4 * 1.5;
        }
    }
}
