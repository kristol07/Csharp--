using System;
using System.Linq;

namespace ClassLearning
{
    public abstract class Shape
    {
        protected string Name
        {
            get; set;
        }

        abstract protected double GetPerimeter();
        public virtual void PrintName()
        {
            Console.WriteLine(Name);
        }
        protected virtual void PrintPerimeter()
        {
            Console.WriteLine(GetPerimeter());
        }
    }

    public class Circle : Shape
    {
        public const double PI = 3.14;
        protected double Radius
        {
            get; set;
        }

        public Circle(double radius, string name = "Circle")
        {
            Radius = radius;
            Name = name;
        }

        protected override double GetPerimeter()
        {
            return 2 * PI * Radius;
        }

        public override void PrintName()
        {
            Console.WriteLine(Name);
        }

        protected override void PrintPerimeter()
        {
            Console.WriteLine(GetPerimeter());
        }
    }

    public class Triangle : Shape
    {
        public Triangle(double sideLength1, double sideLength2, double sideLength3, string name = "Triangle")
        {
            Name = name;

            double[] sideLength = {sideLength1, sideLength2, sideLength3};

            Array.Sort(sideLength);

            if (sideLength[0] + sideLength[1] <= sideLength[2])
            {
                throw new ArgumentException("Invalid Input!");
            }

            SideLength1 = sideLength[0];
            SideLength2 = sideLength[1];
            SideLength3 = sideLength[2];

        }

        protected double SideLength1
        {
            get; set;
        }

        protected double SideLength2
        {
            get; set;
        }

        protected double SideLength3
        {
            get; set;
        }

        protected override double GetPerimeter()
        {
            return SideLength1 + SideLength2 + SideLength3;
        }

        public override void PrintName()
        {
            Console.WriteLine(Name);
        }

        protected override void PrintPerimeter()
        {
            Console.WriteLine(GetPerimeter());
        }
    }

    public class EquilateralTriangle : Triangle
    {
        public EquilateralTriangle(double sideLength, string name = "Equilateral Triangle") 
                                            : base(sideLength, sideLength, sideLength, name)
        {

        }

        public override void PrintName()
        {
            Console.WriteLine(Name);
        }
    }

}