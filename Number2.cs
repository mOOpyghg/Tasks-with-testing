using System;

namespace ShapeLibrary
{
    public class ShapeCalculator
    {
        public double CalculateCircleArea(double radius)
        {
            return Math.PI * radius * radius;
        }

        
        public double CalculateTriangleArea(double side1, double side2, double side3)
        {
            
            double semiPerimeter = (side1 + side2 + side3) / 2;
            return Math.Sqrt(semiPerimeter * (semiPerimeter - side1) * (semiPerimeter - side2) * (semiPerimeter - side3));
        }

        
        public bool IsRightAngleTriangle(double side1, double side2, double side3)
        {
            double[] sides = { side1, side2, side3 };
            Array.Sort(sides);
            return Math.Pow(sides[0], 2) + Math.Pow(sides[1], 2) == Math.Pow(sides[2], 2);
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            
            ShapeCalculator calculator = new ShapeCalculator();

            
            double circleArea = calculator.CalculateCircleArea(5);
            Console.WriteLine($"Площадь круга: {circleArea}");

            
            double triangleArea = calculator.CalculateTriangleArea(3, 4, 5);
            Console.WriteLine($"Площадь треугольника: {triangleArea}");

            
            bool isRightAngleTriangle = calculator.IsRightAngleTriangle(3, 4, 5);
            Console.WriteLine($"Треугольник прямоугольный: {isRightAngleTriangle}");
        }
    }
}
