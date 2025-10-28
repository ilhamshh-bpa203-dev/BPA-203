using _13_NullableEnumStruct.Cafe;
using System.Dynamic;

namespace _13_NullableEnumStruct
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //DrinkOrder order = new(15,"Ilham",0,0);

            //1. 3 sifaris

            #region 1. Üç sifariş yaradın:
            DrinkOrder order1 = new(101, "Ali", DrinkType.Coffee, DrinkSize.Medium);
            DrinkOrder order2 = new(102, "Leyla", DrinkType.Tea, DrinkSize.Large);
            DrinkOrder order3 = new(103, "Vuqar", DrinkType.Juice, DrinkSize.Small);

            //order 1
            order1.DisplayOrder();
            Console.WriteLine(" ");
            order1.UpdateStatus(OrderStatus.Preparing);
            Console.WriteLine(" ");
            order1.UpdateStatus(OrderStatus.Ready);
            Console.WriteLine(" ");
            order1.UpdateStatus(OrderStatus.Delivered);
            Console.WriteLine(" ");
            //order 2
            order2.DisplayOrder();
            Console.WriteLine(" ");
            order2.UpdateStatus(OrderStatus.Ready);
            Console.WriteLine(" ");
            //order 3
            order3.DisplayOrder();
            #endregion

            //2. enum metodlar

            #region enum methods
            //GetValues() istifadə edin:
            foreach (var drink in Enum.GetValues(typeof(DrinkType)))
            {
                Console.WriteLine($"{(int)drink}-{drink.ToString()}");
            }
            Console.WriteLine(' ');
            foreach (var size in Enum.GetValues(typeof(DrinkSize)))
            {
                Console.WriteLine($"{(int)size}-{size.ToString()}");
            }
            Console.WriteLine(" ");
            foreach (var status in Enum.GetValues(typeof(OrderStatus)))
            {
                Console.WriteLine($"{(int)status}-{status.ToString()}");
            }
            Console.WriteLine(" ");


            ////ToString() istifadə edin:
            Console.WriteLine(DrinkType.Coffee.ToString());
            Console.WriteLine(DrinkSize.Large.ToString());

            ////Parse() istifadə edin:
            string tea = "Tea";
            DrinkType type = (DrinkType)Enum.Parse(typeof(DrinkType), tea);
            string med = "Medium";
            DrinkSize siz = (DrinkSize)Enum.Parse(typeof(DrinkSize), med);
            Console.WriteLine(type + " " + siz);

            #endregion

            //3. Sadə statistika:

            Console.WriteLine($"Umumi sifaris {DrinkOrder.count}");
            Console.WriteLine($"Birinci sifaris qiymeti {order1.CalculatePrice()} azn");
            Console.WriteLine($"Ikinci sifaris qiymeti {order2.CalculatePrice()} azn");
            Console.WriteLine($"Ucuncu sifaris qiymeti {order3.CalculatePrice()} azn");
            Console.WriteLine($"Uc sifarisin cemi {order1.CalculatePrice() + order2.CalculatePrice() + order3.CalculatePrice()}");

        }
    }
}
