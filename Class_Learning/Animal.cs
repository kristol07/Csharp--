using System;

namespace ClassLearning
{

    public interface IFlyable
    {
        void Fly();
    }

    public interface IQuackable
    {
        void Quack();
    }

    public abstract class Animal
    {
        public string Look;
        // private string quackSound;

        // Animal类的构造函数

        public void Display()
        {
            Console.WriteLine(Look);
        }
        public abstract override string ToString();
    }

    public class Cat : Animal, IQuackable
    {

        readonly string QUACK_SOUND;
        public Cat(string look = "I am skinny cat.",
                    string quackSound = "Miao~miao~")
        {
            this.Look = look;
            QUACK_SOUND = quackSound;
        }

        public void Quack()
        {
            Console.WriteLine(QUACK_SOUND);
        }

        public override string ToString()
        {
            return Look + " " + QUACK_SOUND;
        }

    }

    public class Sheep : Animal, IQuackable
    {
        readonly string QUACK_SOUND;
        public Sheep(string look = "I am sheep with sharp horn.",
                    string quackSound = "Mieeee~")
        {
            this.Look = look;
            QUACK_SOUND = quackSound;
        }

        public void Quack()
        {
            Console.WriteLine(QUACK_SOUND);
        }

        public override string ToString()
        {
            return Look + " " + QUACK_SOUND;
        }
    }

    public class Bird : Animal, IQuackable, IFlyable
    {

        readonly string FLY_WAY, QUACK_SOUND;
        public Bird(string look = "I am bird with wings.", 
                    string quackSound = "Jiu~jiu~", 
                    string flyWay = "I can fly!")
        {
            this.Look = look;
            QUACK_SOUND = quackSound;
            FLY_WAY = flyWay;
        }

        public void Quack()
        {
            Console.WriteLine(QUACK_SOUND);
        }

        public void Fly()
        {
            Console.WriteLine(FLY_WAY);
        }

        public override string ToString()
        {
            return Look + " " + FLY_WAY + " " + QUACK_SOUND;
        }
    }
}