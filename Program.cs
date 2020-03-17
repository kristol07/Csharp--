using System;
using System.Reflection;
using DrillTrajectoryPlot;

namespace CsharpTest
{

    class Program
    {
        static void Main(string[] args)
        {

            // Money myAccount = new Money(100, Currency.USD);
            // Money newTel = new Money(530);
            // Money monthlySalary = new Money(1000, Currency.RMB);

            // Console.WriteLine("Account: {0}", myAccount);

            // Console.WriteLine("====\nBought a tv...");
            // myAccount -= newTel;
            // Console.WriteLine("Account: {0}", myAccount);

            // Console.WriteLine("====\nReceived salary of this month...");
            // myAccount += monthlySalary;
            // Console.WriteLine("Account: {0}", myAccount);

            // Console.WriteLine("Account return-to-zero...");
            // myAccount = 0;
            // Console.WriteLine("Account: {0}", myAccount);

            // // test Flags attribute in Chapter Enum
            // FlagsEnum.PrintEnumNames();

            // // test interface 
            // InterfaceTest.Test();

            // Animal[] myAnimalZoo = { new Cat(), new Sheep(), new Bird() };

            // foreach (Animal myAnimal in myAnimalZoo)
            // {
            //     Console.WriteLine("=============");

            //     myAnimal.Display();

            //     // if(myAnimal is IFlyable)
            //     // {
            //     //     ((IFlyable)myAnimal).Fly();
            //     // }

            //     IFlyable flyAnimal = myAnimal as IFlyable;
            //     if (flyAnimal != null)
            //     {
            //         flyAnimal.Fly();
            //     }

            //     IQuackable quackAnimal = myAnimal as IQuackable;
            //     if (quackAnimal != null)
            //     {
            //         quackAnimal.Quack();
            //     }

            //     Console.WriteLine(myAnimal);
            // }

            // Circle circle = new Circle(5);
            // circle.PrintName();
            // circle.PrintPerimeter();

            // Triangle triangle = new Triangle(1,3);
            // triangle.PrintName();
            // triangle.PrintPerimeter();

            // EquilateralTriangle equilateralTriangle = new EquilateralTriangle(10);
            // equilateralTriangle.PrintName();
            // equilateralTriangle.PrintPerimeter();

            // DrillTrajectoryPlot.ConsoleApp app = new DrillTrajectoryPlot.ConsoleApp();
            // app.Run();

            Reflection.Test();
        }
    }



}