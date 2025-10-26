using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_AbstractClassPolymorphismForEach.Vehicles
{
    internal abstract class Vehicle
    {
        public static int vehicleCount;
        private string _brand;
        public string Brand { get; set; }
        private string _model;
        public string Model { get; set; }
        private int _year;
        public int Year { get; set; }
        private string _plateNumber;
        public string PlateNumber { get; set; }
        private double _fuelLevel;
        public double FuelLevel



        {
            get => _fuelLevel;
            set
            {
                if (value < 0 || value > 100)
                {
                    Console.WriteLine("Invalid fuel level.");
                }
                else
                {
                    _fuelLevel = value;

                }
            }

        }
        public int MaxSpeed { get; set; }
        public Vehicle(string Brand, string Model, int Year, string PlateNumber, int MaxSpeed, double FuelLevel = 100)
        {
            this.Brand = Brand;
            this.Model = Model;
            this.Year = Year;
            this.PlateNumber = PlateNumber;
            this.FuelLevel = FuelLevel;
            this.MaxSpeed = MaxSpeed;
            vehicleCount++;

        }
        public abstract void GetVehicleInfo();
        public virtual void ShowBasicInfo()
        {
            Console.WriteLine($"Brand: {Brand}, Model: {Model}, Year: {Year}, Plate Number: {PlateNumber}, Fuel Level: {FuelLevel} ");
        }
    }
}
