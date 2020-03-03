using System;

namespace CsharpTest
{

    public abstract class Animal
    {
        public IQuackable quackable;
        public IFlyable flyable;

        public void Fly()
        {
            flyable.Fly();
        }

        public void Quack()
        {
            quackable.Quack();
        }

        // abstract public void Fly();
        // abstract public void Quack();
        abstract public void Display();
        abstract public override string ToString();
    }

    public class Sheep : Animal
    {
        public Sheep()
        {
            quackable = new QuackMie();
            flyable = new FlyNoWay();
        }

        public override void Display()
        {
            Console.WriteLine("Sharp horn.");
        }

        public override string ToString()
        {
            return "As a sheep, I have sharp horn. Miieeeeee~";
        }

    }

    public class Bird : Animal
    {
        public Bird()
        {
            quackable = new QuackJiji();
            flyable = new FlyWithWings();
        }

        public override void Display()
        {
            Console.WriteLine("Black hair.");
        }

        public override string ToString()
        {
            return "As a bird, I have black wings, and I can fly! Gigi~";
        }
    }
    public class Cat : Animal
    {
        public Cat()
        {
            quackable = new QuackMiao();
            flyable = new FlyNoWay();
        }

        public override void Display()
        {
            Console.WriteLine("Black fur.");
        }

        public override string ToString()
        {
            return "As a cat, I have black fur. Miao~miao~";
        }
    }
    public class Frog : Animal
    {
        public Frog()
        {
            quackable = new QuackGugu();
            flyable = new FlyNoWay();
        }

        public override void Display()
        {
            Console.WriteLine("Green skin.");;
        }

        public override string ToString()
        {
            return "As a frog, I have green skin. Gugu--gugu--";
        }
    }
    public class StrangeAnimal : Animal
    {
        public StrangeAnimal()
        {
            quackable = new QuackMiao();
            flyable = new FlyWithWings();
        }

        public override void Display()
        {
            Console.WriteLine("Rainbow shoes.");
        }

        public override string ToString()
        {
            return "As a strange animal, I have rainbow shoes with which I could fly! Miao~miao~";
        }
    }

}