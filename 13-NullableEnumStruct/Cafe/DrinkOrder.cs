using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13_NullableEnumStruct.Cafe
{
    internal class DrinkOrder
    {
        public int OrderNumber { get; set; }
        public string CustomerName { get; set; }
        public DrinkType Drink { get; set; }
        public DrinkSize Size { get; set; }
        public OrderStatus Status { get; set; }
        public decimal Price { get; set; }
        public static int count;
        


        public DrinkOrder(int orderNumber, string customerName, DrinkType drink, DrinkSize size)
        {
           OrderNumber = orderNumber;
            CustomerName = customerName;
            Drink = drink;
            Size = size;
            count++;

        }
        public decimal CalculatePrice()
        {
            switch (Drink)
            {
                case DrinkType.Coffee:

                    switch (Size)
                    {
                        case DrinkSize.Small: Price = 3; break;
                        case DrinkSize.Medium: Price = 4; break;
                        case DrinkSize.Large: Price = 5; break;
                        default: Console.WriteLine("Invalid size."); break;
                    }
                    break;
                case DrinkType.Tea:
                    switch (Size)
                    {
                        case DrinkSize.Small: Price = 2; break;
                        case DrinkSize.Medium: Price = 3; break;
                        case DrinkSize.Large: Price = 4; break;
                        default: Console.WriteLine("Invalid size."); break;
                    }
                    break;
                case DrinkType.Juice:
                    switch (Size)
                    {
                        case DrinkSize.Small: Price = 4; break;
                        case DrinkSize.Medium: Price = 5; break;
                        case DrinkSize.Large: Price = 6; break;
                        default: Console.WriteLine("Invalid size."); break;
                    }
                    break;
                case DrinkType.Water:
                    switch (Size)
                    {
                        case DrinkSize.Small: Price = 1; break;
                        case DrinkSize.Medium: Price = 1.5m; break;
                        case DrinkSize.Large: Price = 2; break;
                        default: Console.WriteLine("Invalid size."); break;
                    }
                    break;
                default:
                    Console.WriteLine("Invalid drink.");
                    break;
            }
            return Price;


        }


        public void UpdateStatus(OrderStatus newStatus)
        {
            Status = newStatus;
            Console.WriteLine($"Sifaris #{OrderNumber} statusu: {newStatus}");
        }


        public void DisplayOrder()
        {
            Console.WriteLine($"{CustomerName},your order is {Size} {Drink}.Number #{OrderNumber}");
            Console.WriteLine($"Price of order is {CalculatePrice()} azn");
        }

    }
}
