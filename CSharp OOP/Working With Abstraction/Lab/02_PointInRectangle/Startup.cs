namespace _02_PointInRectangle
{
    using System;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            var coordinat = Console.ReadLine().Split().Select(int.Parse).ToArray(); ;
            var topLeftX = coordinat[0];
            var topLeftY = coordinat[1];
            var bottomRightX = coordinat[2];
            var bottomRightY = coordinat[3];

            var topLeft = new Point(topLeftX, topLeftY);
            var bottomRight = new Point(bottomRightX, bottomRightY);
            var rectangle = new Rectangle(topLeft, bottomRight);

            var lineCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < lineCount; i++)
            {
                var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
                var x = line[0];
                var y = line[1];

                var point = new Point(x, y);
                Console.WriteLine(rectangle.Contains(point));
            }
        }
    }
}
