using System;

namespace CsharpTest
{
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

        }
    }



}