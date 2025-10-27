using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13_NullableEnumStruct.Cafe
{
    internal class DrinkOrder
    {
        public int orderNumber;
        public string customerName;
        public DrinkType drink;
        public DrinkSize size;
        public OrderStatus status;
        public decimal price;
        public static int count;

        public DrinkOrder(int orderNumber, string customerName, DrinkType drink, DrinkSize size)
        {
            this.orderNumber = orderNumber;
            this.customerName = customerName;
            this.drink = drink;
            this.size = size;
            //status = new OrderStatus();
            count++;

        }
        public decimal CalculatePrice()
        {
            switch (drink)
            {
                case DrinkType.Coffee:

                    switch (size)
                    {
                        case DrinkSize.Small: price = 3; break;
                        case DrinkSize.Medium: price = 4; break;
                        case DrinkSize.Large: price = 5; break;
                        default: Console.WriteLine("Invalid size."); break;
                    }
                    break;
                case DrinkType.Tea:
                    switch (size)
                    {
                        case DrinkSize.Small: price = 2; break;
                        case DrinkSize.Medium: price = 3; break;
                        case DrinkSize.Large: price = 4; break;
                        default: Console.WriteLine("Invalid size."); break;
                    }
                    break;
                case DrinkType.Juice:
                    switch (size)
                    {
                        case DrinkSize.Small: price = 4; break;
                        case DrinkSize.Medium: price = 5; break;
                        case DrinkSize.Large: price = 6; break;
                        default: Console.WriteLine("Invalid size."); break;
                    }
                    break;
                case DrinkType.Water:
                    switch (size)
                    {
                        case DrinkSize.Small: price = 1; break;
                        case DrinkSize.Medium: price = 1.5m; break;
                        case DrinkSize.Large: price = 2; break;
                        default: Console.WriteLine("Invalid size."); break;
                    }
                    break;
                default:
                    Console.WriteLine("Invalid drink.");
                    break;
            }
            return price;


        }


        public void UpdateStatus(OrderStatus newStatus)
        {
            status = newStatus;
            Console.WriteLine($"Sifaris #{orderNumber} statusu: {newStatus}");
        }


        public void DisplayOrder()
        {
            Console.WriteLine($"{customerName},your order is {size} {drink}.Number #{orderNumber}");
            Console.WriteLine($"Price of order is {CalculatePrice()} azn");
        }

    }
}
