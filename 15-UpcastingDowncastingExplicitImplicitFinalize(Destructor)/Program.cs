using _15_UpcastingDowncastingExplicitImplicitFinalize_Destructor_.Exchange;
using _15_UpcastingDowncastingExplicitImplicitFinalize_Destructor_.Models;

namespace _15_UpcastingDowncastingExplicitImplicitFinalize_Destructor_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Upcasting-Downcasting
            //Dog dog = new Dog { AvgLifeTime = 12, Breed = "Haski", Gender = "Male", Name = "Hunter" };
            //Eagle eagle = new Eagle { AvgLifeTime = 20, Gender = "Male", FlySpeed = 200 };

            ////Implicit-UpCasting
            //Animal animal = dog;
            //Animal animal1 = eagle;

            ////Explicit-DownCasting
            //Dog dog1 = (Dog)animal;
            //Eagle eagle1 = (Eagle)animal;

            //Console.WriteLine(dog1.Gender);

            //Animal[] animals = { eagle, dog };
            //foreach (Animal animal in animals)
            //{
            //    //Eagle eagle1 = (Eagle)animal;
            //    //eagle1.Fly();

            //    //Eagle eagle1 = animal as Eagle;
            //    //eagle1.Fly();

            //    if (animal is Eagle)
            //    {

            //        Eagle eagle1 = (Eagle) animal;
            //        eagle1.Fly();
            //    }
            //} 
            #endregion

            #region Boxing -Unboxing
            ////Boxing
            //int a = 5;
            //Object b = a;

            ////Unboxing
            //int c = (int)b;

            //Test test = new Test();
            //Object d = test;

            //ITestable testable = test; 
            #endregion

            #region Implicit-Explicit
            //Dollar dollar = new (200);
            //Manat manat = new(170);

            //Manat manat1 = (Manat)dollar;
            //Console.WriteLine(manat1.AZN);

            //Dollar dollar1 =(Dollar) manat;
            //Console.WriteLine(dollar1.USD);

            //Manat manat2 = 300m;
            //Console.WriteLine(manat2.AZN); 
            #endregion

            if (true)
            {
                for (int i =0;i<1000;i++)
                {
                    Dog dog = new Dog(0);
                }

            }
            GC.Collect();
            Console.Read();



        }
    }
    //public struct Test : ITestable
    //{
    //    public int X { get; set; }

    //    public int Y { get; set; }

    //}
    //public interface ITestable 
    //{
    //    public int Y { get; set; }
    //}
}
