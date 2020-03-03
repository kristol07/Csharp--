using System;

namespace CsharpTest
{
    public interface IQuackable
    {
        public void Quack();
    }

    public class QuackMiao : IQuackable
    {
        public void Quack()
        {
            Console.WriteLine("Miao~miao~");
        }
    }

    public class QuackMie : IQuackable
    {
        public void Quack()
        {
            Console.WriteLine("Miieeeeee~");
        }
    }

    public class QuackGugu : IQuackable
    {
        public void Quack()
        {
            Console.WriteLine("Gugu--gugu--");
        }
    }

    public class QuackJiji : IQuackable
    {
        public void Quack()
        {
            Console.WriteLine("Jiji~");
        }
    }
}