namespace Shapes
{
    using System;
    using Models;

    public class StartUp
    {
        public static void Main()
        {
            var width = double.Parse(Console.ReadLine());
            var height = double.Parse(Console.ReadLine());
            var radius = double.Parse(Console.ReadLine());
            var rectangle = new Rectangle(width, height);
            var circle = new Circle(radius);

            var rectangleArea = rectangle.CalculateArea();
            var rectanglePeimeter = rectangle.CalculatePerimeter();
            var circleArea = circle.CalculateArea();
            var circlePerimeter = circle.CalculatePerimeter();

            Console.WriteLine($"Rectangle Area: {rectangleArea:f2}");
            Console.WriteLine($"Rectangle Perimeter: {rectanglePeimeter:f2}");
            Console.WriteLine();
            
            Console.WriteLine(rectangle.Draw());

            Console.WriteLine($"Circle Area: {circleArea:f2}");
            Console.WriteLine($"Circle Perimeter: {circlePerimeter:f2}");
            Console.WriteLine();

            Console.WriteLine(circle.Draw());
            
        }
    }
}
