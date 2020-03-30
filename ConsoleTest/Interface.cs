using System;

namespace CsharpConcepts
{
    interface IInfo
    {
        string GetName();
        string GetAge();
    }

    class CA : IInfo
    {
        public string Name;
        public int Age;
        public string GetName() { return Name; }
        public string GetAge() { return Age.ToString(); }
    }

    class CB : IInfo
    {
        public string First;
        public string Last;
        public double PersonAge;
        public string GetName() { return First + " " + Last; }
        public string GetAge() { return PersonAge.ToString(); }
    }

    public class InterfaceLearning
    {
        static void PrintInfo(IInfo item)
        {
            Console.WriteLine("Name: {0}, Age {1}", item.GetName(), item.GetAge());
        }

        public static void RunExample()
        {
            CA a = new CA() { Name = "John Doe", Age = 35 };
            CB b = new CB() { First = "Jane", Last = "Doe", PersonAge = 33 };

            PrintInfo(a);
            PrintInfo(b);
        }
    }

}