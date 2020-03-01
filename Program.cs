using System;

namespace CsharpTest
{

    interface ILiveBirth
    {
        string BabyCalled();
    }

    class Animal { }
    class Cat : Animal, ILiveBirth
    {
        public string BabyCalled() { return "kitten"; }
    }
    class Dog : Animal, ILiveBirth
    {
        public string BabyCalled() { return "puppy"; }
    }
    class Bird : Animal
    {

    }
    class Program
    {
        static void Main(string[] args)
        {

            Money myAccount = new Money(100, Currency.USD);
            Money newTel = new Money(530);
            Money monthlySalary = new Money(1000, Currency.RMB);

            Console.WriteLine("Account: {0}", myAccount);

            Console.WriteLine("====\nBought a tv...");
            myAccount -= newTel;
            Console.WriteLine("Account: {0}", myAccount);

            Console.WriteLine("====\nReceived salary of this month...");
            myAccount += monthlySalary;
            Console.WriteLine("Account: {0}", myAccount);

            Console.WriteLine("Account return-to-zero...");
            myAccount = 0;
            Console.WriteLine("Account: {0}", myAccount);

            // test Flags attribute in Chapter Enum
            FlagsEnum.PrintEnumNames();

            // test interface 
            InterfaceTest.Test();

            Animal[] animalArray = new Animal[3];
            animalArray[0] = new Cat();
            animalArray[1] = new Dog();
            animalArray[2] = new Bird();
            foreach (Animal a in animalArray)
            {
                ILiveBirth b = a as ILiveBirth;
                if (b != null)
                {
                    Console.WriteLine("Baya is called: {0}", b.BabyCalled());
                }
            }

        }
    }



}