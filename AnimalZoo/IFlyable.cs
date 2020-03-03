using System;

namespace CsharpTest
{
    public interface IFlyable
    {
        public void Fly();
    }

    public class FlyWithWings : IFlyable
    {
        public void Fly()
        {
            Console.WriteLine("I can fly with wings!");
        }
    }

    public class FlyNoWay : IFlyable
    {
        public void Fly()
        {
            
        }
    }
}